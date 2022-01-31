using CommandLine;
using FileManager.Domain;
using FileManager.Domain.Models;
using FileManager.Infrastructure;
using FileManager.Infrastructure._3rd_Parties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManager
{
    [Verb("file-upload",  HelpText = "Upload the file to the specific directory.")]
    public class FileUploadOptions : Options
    {
        private IFileService _fileService;
        private IConfigurationService _configurationService;

        [Option("filename", Required = false, HelpText = "Input filename.")]
        public string filename { get; set; }

        [Option('s', "source", Default = ".",HelpText = "The source directory for the files to process.")]
        public string Source { get; set; }

        [Option('t', "Type", Default =".", HelpText = "Type of storage")]
        public string Type { get; set; }

        [Option('d', "destination", HelpText = "Destination to store the data.")]
        public string Destination { get; set; }
        public FileUploadOptions() { }
        public FileUploadOptions(IFileService fileService, IConfigurationService configurationService)
        {
            _fileService = fileService;
            _configurationService = configurationService;
            if (_configurationService != null)
                this.CloudSetup = configurationService.GetCloudSetup();

        }

        public int RunAddAndReturnExitCode(FileUploadOptions options)
        {
            if (options.Verbose && !string.IsNullOrEmpty(options.Source))
            {
                Console.WriteLine($"Verbose : {options.Verbose}");
                Console.WriteLine($"Source of Files: {options.Source}");
            }
            SelectOptions();
            return 0;
        }
        private void SelectOptions()
        {
            Console.WriteLine("Uploader Option Display--------------------");
            Console.WriteLine("1. Upload all files to the Azure blob.");
            Console.WriteLine("2. Upload the specific file to the Azure blob.");
            var userInput = Console.ReadLine();
            if (userInput == "1")
            {
                var files = WinFileManageHelper.GetAllFiles(CloudSetup.UploadFilePath);
                foreach (var file in files)
                {
                    _fileService.UploadFileToDestination(StorageType.AzureBlobStorage, file.Name, CloudSetup.UploadFilePath);
                }
                 
            }
            else if (userInput == "2")
            { 
                var files = WinFileManageHelper.GetAllFiles(CloudSetup.UploadFilePath);
                Console.WriteLine("Please enter file name.");
                var fileNameInput = Console.ReadLine();
                _fileService.UploadFileToDestination(StorageType.AzureBlobStorage, fileNameInput, CloudSetup.UploadFilePath);
            }
            else
            {
            }
        }
    }
}


// Folder Access Layer.
