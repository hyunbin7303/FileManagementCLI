using CommandLine;
using FileManager.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

using FileManager.Infrastructure;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {

            var host = ConfigHelper.CreateHostBuilder(args).Build();
            var svc = ActivatorUtilities.CreateInstance<TestingService>(host.Services);
            svc.Run();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<FileDbContext>();
                context.Database.EnsureCreated();
            }
            CommandLineConfig.CliConfig(args);
        }
    }
}
