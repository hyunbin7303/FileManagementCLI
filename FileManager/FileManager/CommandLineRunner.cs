using CommandLine;
using FileManager.Domain;
using FileManager.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class CommandLineRunner
    {
        private readonly IConfiguration _config;
        private readonly IFileService _fileService;
        private readonly IFileConfigService _fileConfigService;
        public CommandLineRunner(IConfiguration config, IFileConfigService configService,IFileService fileService)
        {
            _config = config;
            _fileConfigService = configService;
            _fileService = fileService;
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
            // User setup in here.
            User user = new User(_config.GetValue<string>("UserId"), 0, "SampleUserName","Domain", UserPermission.Normal, "Email@google.com", true);
            CloudSetup cloudSetup = new CloudSetup(_config.GetValue<string>("UserId"));
            
            // Need to figure it out how to change below configuration setup into the one line.
            cloudSetup.ConnString = _config.GetValue<string>("MySettings:AzureStorageKey");
            cloudSetup.ContainerName = _config.GetValue<string>("MySettings:AzureContainerName");
            cloudSetup.DefaultFolder = _config.GetValue<string>("DefaultFolder");
            cloudSetup.AzureUploadFilePath = _config.GetValue<string>("MySettings:AzureUploadFilePath");
            switch (obj)
            {
                // file uploader & Downloader Azure setup config needs to be fixed. Duplicated Code. 
                case FileUploadOptions:
                    FileUploadOptions fileUploader = new FileUploadOptions(user, cloudSetup);
                    fileUploader.RunAddAndReturnExitCode((FileUploadOptions)obj, _fileService);
                    break;

                case FileDownloadOptions:
                    FileDownloadOptions fileDownloader = new FileDownloadOptions(user, cloudSetup);
                    fileDownloader.RunAddAndReturnExitCode((FileDownloadOptions)obj, _fileService);
                    break;

                case DirectoryChangeOptions:
                    DirectoryChangeOptions directoryChangeOptions = new DirectoryChangeOptions();
                    directoryChangeOptions.RunAddAndReturnExitCode((DirectoryChangeOptions)obj, _fileService);
                    break;

                case DisplayOptions:
                    var displayOpt = new DisplayOptions();
                    displayOpt.Execute((DisplayOptions)obj);
                    break;

                case DeleteOptions:

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
