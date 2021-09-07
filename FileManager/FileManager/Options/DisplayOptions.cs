using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    [Verb("display", HelpText = "Display the contents of a file.")]
    public class DisplayOptions : Options
    {

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
        }
        private void FolderDestinationDisplay()
        {
            Console.WriteLine("Folder Destination.");
        }
    }
}
