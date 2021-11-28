using CommandLine;
using FileManager.Infrastructure;
using FileManager.Infrastructure._3rd_Parties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    [Verb("file-upload",  HelpText = "Upload the file to the specific directory.")]
    public class FileUploadOptions : Options
    {
        [Option("filename", Required = false, HelpText = "Input filename.")]
        public string filename { get; set; }

        [Option('s', "source", Default = ".",HelpText = "The source directory for the files to process.")]
        public string Source { get; set; }

        [Option('t', "Type", Default =".", HelpText = "Type of storage")]
        public string Type { get; set; }

        [Option('d', "destination", HelpText = "Destination to store the data.")]
        public string Destination { get; set; }


        public string DefaultFolder { get; set; }
        public string AzureConnString { get; set; }
        public string AzureContainerName { get; set; }
        public string AzureUploadFilePath { get; set; }

        private IFileService _fileService;
        private IFileConfigService _fileConfigService;

        public int RunAddAndReturnExitCode(FileUploadOptions options, IFileService fileService)
        {
            _fileService = fileService;
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
            Console.WriteLine("Uploader Option Display.");
            WinFileManageHelper.FileDisplay(DefaultFolder);

            Console.WriteLine("1. Upload all files to the Azure blob.");
            Console.WriteLine("2. Upload the specific file to the Azure blob.");
            var userInput = Console.ReadLine();


            if (userInput == "1")
            {
                Console.WriteLine("Downloading Google Files.");
                //GoogleDocDownloading(FileName);
            }
            else if (userInput == "2")
            {
                Console.WriteLine("Type file name.");
                var fileNameInput = Console.ReadLine();
                var check = FileUploadToAzure(user.UserId,AzureUploadFilePath, fileNameInput);
                FileInfoUpdateToDB();
            }

            else
            {
                return;
            }
        }
        private int FileUploadToGoogleDrive(string path, string fileName)
        {

            // Upload file to the Google Drive.


            return 0;
        }
        private async Task<int> FileUploadToAzure(string userName,string path, string fileName)
        {
            AzureBlobAdapter azureBlobRepository = new AzureBlobAdapter(AzureConnString, AzureContainerName);
            await azureBlobRepository.Upload(path, fileName, "");
            // TODO : Need to remove file from the directory. 

            _fileService.UploadFileToDestination(Domain.StorageType.AzureBlobStorage, userName, fileName, path);
            // TODO : Need to update the data(record) in the sql server. 
            return 0;
        }
        private int FileInfoUpdateToDB()
        {
            return 0;
        }


    }
}


// Folder Access Layer.
