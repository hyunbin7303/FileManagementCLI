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
        public DirectoryChangeOptions()
        {
        }
        public void Execute(int directoryId, string targetLocation)
        {
            Console.WriteLine($"Directory Id: {directoryId}, Directory Changing to target location: {targetLocation}");
            // TODO: Update the sql config table for changing directory.
            // SQL Connection needs to come here. 
        }
    }
}
