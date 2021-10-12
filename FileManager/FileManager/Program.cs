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
         //   var svc = ActivatorUtilities.CreateInstance<FileConfigService>(host.Services); This is the way of using service.
         //   svc.Run();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<FileDbContext>();
                //context.Database.EnsureCreated();
            }
            
            CommandLineConfig commandLineConfig = new CommandLineConfig(MyAppData.Configuration);
            commandLineConfig.CliConfig(args);
        }
    }
}
