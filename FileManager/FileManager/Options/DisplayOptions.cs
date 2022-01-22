using CommandLine;
using CommandLine.Text;
using FileManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Domain.Models;

namespace FileManager
{
    [Verb("display", HelpText = "Display the contents of a file.")]
    public class DisplayOptions : Options
    {
        private static string defaultFolder = "C:\\Uploader"; // Need to set up by t he appSettings.Json file.
        private IFileService _fileService;

        public DisplayOptions(){}
        public DisplayOptions(User user, CloudSetup azureSetup, IFileService fileService) 
        {
            this.user = user;
            this.CloudSetup = azureSetup;
            _fileService = fileService;
        }

        [Option('p', "provider", Default = ".", HelpText = "Cloud Provider / Folder Repo")]
        public string Provider { get; set; }
        public int Execute(DisplayOptions options)
        {
            if (options.Verbose)
            {
                Console.WriteLine($"Verbose : {options.Verbose}");
            }
            if (options.Provider != null)
            {
                if(options.Provider.ToLowerInvariant() == "azureblob" || options.Provider.ToLowerInvariant() == "az")
                {
                    _fileService.GetFiles();
                    return 0;
                }
            }
            _fileService.GetFiles();
            DisplayHelp();
            return 0;
        }


        private void DisplayHelp()
        {
            Console.WriteLine("Display ----------------");
            Console.WriteLine("1. Folder Destination display.");
            Console.WriteLine("2. Application setup display.");
            Console.WriteLine("3. More info.");
            var userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Console.WriteLine("Displaying Cloud/Folder information.");
                FolderDestinationDisplay("Local");
            }
            else if (userInput == "2")
            {
               
            }
            else if(userInput=="3")
            {

            }
            else
            {
                return;
            }

        }


        private void FolderDestinationDisplay(string setupChoose)
        {
            Console.WriteLine("Folder Destination.");
            switch(setupChoose)
            {
                case "Local":
                    DisplayLocalFolder();
                    break;
                case "Google":
                    GetGoogleDriveFiles();
                    break;
                case "Dropbox":
                    DisplayDropbox();
                    break;
            }
        }
        private List<File> GetGoogleDriveFiles()
        {
            List<File> fileList = new List<File>();
            return fileList;
        }

        private void DisplayDropbox()
        {
            throw new NotImplementedException();
        }
        private void DisplayLocalFolder()
        {
            Console.WriteLine("Default Folder : " + defaultFolder);
        }
    }
}
