using FileManager.Infrastructure;
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
                    service.AddDataBase(context.Configuration);
                    //setupDefaultFolder = context.Configuration.GetSection("DefaultFolder").Value;
                    service.AddTransient<IFileConfigService, FileConfigService>();
                })
                .ConfigureLogging((context, builder) =>
                {
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
