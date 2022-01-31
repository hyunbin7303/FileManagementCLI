using CommandLine;
using FileManager.Infrastructure._3rd_Parties;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Domain.Models;
using Microsoft.Extensions.Logging;
using FileManager.Domain;

namespace FileManager
{
    public enum DownloadOption
    {
        SelectOne,
        SelectAll,
    }

    [Verb("file-download", HelpText = "File Download.")]
    public class FileDownloadOptions : Options
    {
        public List<File> fileList = null;
        private IFileService _fileService;
        private IConfigurationService _configurationService;

        [Option('s', "source", HelpText = "The source directory for the files to process.")]
        public string Source { get; set; }

        [Option('t', "--type", HelpText = "Type of storage")]
        public string Type { get; set; }

        [Option('f', "--file" , HelpText = "File Name")]
        public string FileName { get; set; }

        [Option('o', "destination", HelpText = "Destination to download the data.")]
        public string Output { get; set; }

        public FileDownloadOptions() { }

        public FileDownloadOptions(IFileService fileService, IConfigurationService configurationService)
        {
            _fileService = fileService;
            _configurationService = configurationService;
            if (_configurationService != null)
                this.CloudSetup = configurationService.GetCloudSetup();

        }
        public int RunAddAndReturnExitCode(FileDownloadOptions options)
        {
            if (options.Verbose && !string.IsNullOrEmpty(options.Source))
            {
                Console.WriteLine($"Verbose : {options.Verbose}");
                Console.WriteLine($"Source of Files: {options.Source}");
            }
            if (!string.IsNullOrEmpty(options.FileName))
            {
                Log.Logger.Information("FileName.");
            }
            if(!string.IsNullOrEmpty(options.All))
            {
                Log.Logger.Information(options.All);
                if (!string.IsNullOrEmpty(options.Type))
                {

                }
                return 0;
            }
            Log.Logger.Information("File Dolwnload Options.");
            SelectOptions();
            return 0;
        }

        private void SelectOptions()
        {
            Console.WriteLine("Display all files I have.");
            _fileService.GetFileByFileName("");

            Console.WriteLine("1. Download Azureblob file.");
            Console.WriteLine("2. Download all files from the Azure Blob.");
            Console.WriteLine("3. Exit.");
            var userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Log.Logger.Information("Downloading Azureblob file.");
                var check = _fileService.GetFilesByUserId();
                foreach(var file in check)
                {
                    DownloadAzureInfo("", "");
                }
            }
            else if (userInput == "2")
            {
                var check = _fileService.GetFilesByUserId();

            }
            else if (userInput == "3")
            {

            }
            else
            {
                return;
            }
        }
        private async Task DownloadAzureInfo(string filePathWithName, string destinationPath)
        {
            AzureBlobAdapter adapter = new AzureBlobAdapter(CloudSetup.ConnString, CloudSetup.ContainerName);
            var check  = await adapter.DownloadFileAsync(filePathWithName, destinationPath);
        }

    }
}
