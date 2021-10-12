using CommandLine;
using FileManager.Infrastructure._3rd_Parties;
using System;
using System.Collections.Generic;
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
            Console.WriteLine("Uploader Option Display.");
            Console.WriteLine("1.Google Drive.");
            Console.WriteLine("2.Azure Storage.");
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
                var check = FileUploadToAzure(AzureUploadFilePath, fileNameInput);
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
        private async Task<int> FileUploadToAzure(string path, string fileName)
        {
            AzureBlobRepository azureBlobRepository = new AzureBlobRepository(AzureConnString, AzureContainerName);
            await azureBlobRepository.Upload(path, fileName, "");
            // TODO : Need to remove file from the directory. 

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
