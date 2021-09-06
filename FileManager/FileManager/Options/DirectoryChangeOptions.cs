using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    [Verb("directory-change", HelpText = "Changing the directory of the upload destination.")]
    public class DirectoryChangeOptions : Options
    {

        public void Execute()
        {
            Console.WriteLine($"Executing Commit with message: {Message}");
        }


    }
}
