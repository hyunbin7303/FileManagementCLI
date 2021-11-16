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

        public int RunAddAndReturnExitCode(FileDownloadOptions options)
        {
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
            Console.WriteLine("1. Downloading Google FIles.");
            Console.WriteLine("2. Downloading file from the Dropbox.");
            Console.WriteLine("3. More info.");
            var userInput = Console.ReadLine();
            if (userInput == "1")
            {
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
