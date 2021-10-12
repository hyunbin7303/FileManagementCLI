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
        public int RunAddAndReturnExitCode(FileUploadOptions options)
        {
            if (options.Verbose && !string.IsNullOrEmpty(options.Source))
            {
                Console.WriteLine($"Verbose : {options.Verbose}");
                Console.WriteLine($"Source of Files: {options.Source}");
            }
            Console.WriteLine("adding files");
            SelectOptions();
            return 0;
        }
        private void SelectOptions()
        {
            var userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Console.WriteLine("Downloading Google Files.");
                //GoogleDocDownloading(FileName);
            }
            else if (userInput == "2")
            {
                var check = FileUploadToAzure("", "", "");
            }
            else if (userInput == "3")
            {

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
        private async Task<int> FileUploadToAzure(string container, string path, string fileName)
        {
            AzureBlobRepository azureBlobRepository = new AzureBlobRepository(AzureConnString, container);
            await azureBlobRepository.Upload(path, fileName, "");
            return 0;
        }
        private int FileInfoUpdateToDB()
        {
            return 0;
        }


    }
}


// Folder Access Layer.
