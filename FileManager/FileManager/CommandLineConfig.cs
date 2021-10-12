using CommandLine;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class CommandLineConfig
    {
        private readonly IConfiguration _config;
        public CommandLineConfig(IConfiguration config)
        {
            _config = config;
        }
        public void CliConfig(string[] args)
        {
            var parser = new Parser(config => config.HelpWriter = Console.Out);
            if (args.Length == 0)
            {
                parser.ParseArguments<Options>(new[] { "--help" });
                return;
            }
            var types = LoadVerbs();
            Parser.Default
                .ParseArguments(args, types)
                .WithParsed(Run)
                .WithNotParsed(errors => Console.WriteLine("Error"));
        }
        private void Run(object obj)
        {
            switch (obj)
            {
                case FileUploadOptions c:
                    FileUploadOptions fileUploader = new FileUploadOptions();
                    fileUploader.AzureConnString =    _config.GetValue<string>("MySettings:AzureStorageKey");
                    fileUploader.AzureContainerName = _config.GetValue<string>("MySettings:AzureContainerName"); 
                    fileUploader.DefaultFolder =      _config.GetValue<string>("DefaultFolder");
                    fileUploader.AzureUploadFilePath = _config.GetValue<string>("MySettings:AzureUploadFilePath");
                    fileUploader.RunAddAndReturnExitCode((FileUploadOptions)obj);
                    break;

                case FileDownloadOptions f:
                    FileDownloadOptions fileDownloader = new FileDownloadOptions();
                    fileDownloader.RunAddAndReturnExitCode((FileDownloadOptions)obj);
                    break;

                case DirectoryChangeOptions d:
                    DirectoryChangeOptions directoryChangeOptions = new DirectoryChangeOptions();
                    //directoryChangeOptions.
                    break;

                case DisplayOptions q:
                    var displayOpt = new DisplayOptions();
                    displayOpt.Execute((DisplayOptions)obj);
                    break;
            }
        }
        private static Type[] LoadVerbs()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetCustomAttribute<VerbAttribute>() != null).ToArray();
        }


    }
}
