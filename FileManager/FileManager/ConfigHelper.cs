using Common.Interfaces;
using FileManager.Infrastructure;
using FileManager.Infrastructure.Interfaces;
using FileManager.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class ConfigHelper
    {

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureHostConfiguration((builder) =>
                {
                    BuildConfig(builder);
                })
                .ConfigureAppConfiguration((context, builder) =>
                {

                })

                .ConfigureServices((context, service) =>
                {
                    //service.AddDbContextFactory<>
                    service.AddDatabase(context.Configuration);//configure database
                    service.AddSingleton(context.Configuration);//CommandLineRunner constructor needs IConfiguration
                    service.AddTransient<IConfigurationService, ConfigurationService>();
                    service.AddScoped<IFileService, FileService>();
                    service.AddTransient(typeof(IRepository<>), typeof(Repository<>));
                    service.AddTransient<IFileRepository, FileRepository>();
                    service.AddTransient<IUserRepository, UserRepository>();
                    MyAppData.Configuration = context.Configuration;
                })
                .ConfigureLogging((context, builder) =>
                {
                    // use global serilog 
                    Log.Logger = new LoggerConfiguration()
                                            .ReadFrom.Configuration(context.Configuration)
                                            .Enrich.FromLogContext()
                                            .WriteTo.Console()
                                            .CreateLogger();
                    Log.Logger.Information("File Manager App starting.");
                    //builder.AddSerilog();
                })
                .UseSerilog();
        }
        private static IConfigurationBuilder BuildConfig(IConfigurationBuilder builder)
        {
            return builder.SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appSettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? null}json", optional: true)
              .AddEnvironmentVariables();
        }

    }
}
