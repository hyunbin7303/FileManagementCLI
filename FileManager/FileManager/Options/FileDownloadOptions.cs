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
    [Verb("file-download", HelpText = "File Download.")]
    public class FileDownloadOptions : Options
    {
        public List<File> fileList = null;

        [Option('s', "source", Default = ".", HelpText = "The source directory for the files to process.")]
        public string Source { get; set; }

        [Option('t', "Type", Default = ".", HelpText = "Type of storage")]
        public string Type { get; set; }

        [Option('f', "FileName", Default = ".", HelpText = "File Name")]
        public string FileName { get; set; }

        [Option('d', "destination", HelpText = "Destination to download the data.")]
        public string Destination { get; set; }
        public CloudSetup AzureSetup { get; set; } = new CloudSetup();

        private IFileService _fileService;

        public int RunAddAndReturnExitCode(FileDownloadOptions options, IFileService fileService)
        {
            _fileService = fileService;
            if (options.Verbose && !string.IsNullOrEmpty(options.Source))
            {
                Console.WriteLine($"Verbose : {options.Verbose}");
                Console.WriteLine($"Source of Files: {options.Source}");
            }
            if(!string.IsNullOrEmpty(options.Destination))
            {
                Log.Logger.Information("Destionation.");
            }
            if (!string.IsNullOrEmpty(options.FileName))
            {
                Log.Logger.Information("FileName.");
            }
            Log.Logger.Information("File Dolwnload Options.");
            SelectOptions();
            return 0;
        }

        private void SelectOptions()
        {
            Console.WriteLine("Display ----------------");
            Console.WriteLine("1. Downloading Azureblob file.");
            Console.WriteLine("2. Downloading file from the GoogleDoc.");
            Console.WriteLine("3. Exit.");
            var userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Log.Logger.Information("Downloading Google Files.");
                Console.WriteLine("Downloading Google Files.");
                GoogleDocDownloading(FileName);
            }
            else if (userInput == "2")
            {

            }
            else if (userInput == "3")
            {

            }
            else
            {
                return;
            }
        }
        public void GoogleDocDownloading(string fileId)
        {

        }
        private void DownloadAzureInfo(string containerName)
        {
            AzureBlobAdapter azureBlobRepository = new AzureBlobAdapter("connection string should be same..", containerName);
        }

    }
}
