using CommandLine;
using FileManager.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

using FileManager.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace FileManager
{
    public static class MyAppData
    {
        public static IConfiguration Configuration;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var host = ConfigHelper.CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<FileDbContext>();
                IFileService fileService = services.GetService<IFileService>();
                IConfigurationService fileConfigService = services.GetService<IConfigurationService>();
                context.Database.EnsureCreated();
                CommandLineRunner commandLineConfig = new CommandLineRunner(MyAppData.Configuration, fileConfigService, fileService);
                commandLineConfig.CliConfig(args);
            }

        }
    }
}
