using CommandLine;
using CommandLine.Text;
using FileManager.Domain;
using System.Collections.Generic;
using FileManager.Domain.Models;

namespace FileManager
{
    public class Options
    {
        public CloudSetup CloudSetup { get; set; } 
        public User user { get; set; }
        public Options()
        {
            user = new User();
            CloudSetup = new CloudSetup();
        }
        [Option("filename", Required = false, HelpText = "Input filename.")]
        public string filename { get; set; }

        [Option("select", Required = false, HelpText = "Input filename.")]
        public string Select { get; set; }

        [Option('m', "message", Required = false, HelpText = "Explain what code change you did")]
        public string Message { get; set; }

        [Option('v', "verbose", Default = false,HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [Option('a', "--all", HelpText = "All files")]
        public string All { get; set; }

        //[Option('h', "help", Default = false, HelpText = "")]
        //public string Help { get; set; }

    }
}
