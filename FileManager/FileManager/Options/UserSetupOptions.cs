using CommandLine;
using CommandLine.Text;
using FileManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    [Verb("user", HelpText = "Setting up the user.")]
    public class UserSetupOptions : Options
    {
        private static string defaultFolder = "C:\\Uploader"; // Need to set up by t he appSettings.Json file.
        public int Execute(DisplayOptions options)
        {
            if (options.Verbose)
            {
                Console.WriteLine($"Verbose : {options.Verbose}");
            }
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
            }
            else if(userInput == "2")
            {

            }
            else
            {

            }

        }
    }
}
