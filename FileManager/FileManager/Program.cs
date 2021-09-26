using CommandLine;
using FileManager.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Serilog;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder();
            BuildConfig(builder);
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("File Manager App starting.");
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, service) =>
                {

                })
                .UseSerilog()
                .Build();

            var parser = new Parser(config => config.HelpWriter = Console.Out);
            
            
            if (args.Length == 0)
            {
                parser.ParseArguments<Options>(new[] { "--help" });
                return;
            }
            var types = LoadVerbs();
            Parser.Default.ParseArguments(args, types).WithParsed(Run).WithNotParsed(errors => Console.WriteLine("Error"));
        
        }
        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appSettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
               .AddEnvironmentVariables();     
        }


        private static Type[] LoadVerbs()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetCustomAttribute<VerbAttribute>() != null).ToArray();
        }
        private static void Run(object obj)
        {
            switch (obj)
            {
                case FileUploadOptions c:
                    FileUploadOptions fileUploader = new FileUploadOptions();
                    fileUploader.RunAddAndReturnExitCode((FileUploadOptions)obj);
                    break;

                case FileDownloadOptions f:
                    FileDownloadOptions fileDownloader = new FileDownloadOptions();
                    break;

                case DirectoryChangeOptions d:
                    DirectoryChangeOptions directoryChangeOptions = new DirectoryChangeOptions();
                    break;

                case DisplayOptions q:
                     var displayOpt = new DisplayOptions();
                    displayOpt.Execute((DisplayOptions)obj);
                    break;

            }
        }

        public class TestingService
        {
            private readonly ILogger<TestingService> _log;
            public TestingService(ILogger<TestingService> log, IConfiguration config)
            {
                _log = log;
            }
            public void Run()
            {
                for(int i = 0; i< 10; i++)
                {

                }
            }
        }
    }
}
