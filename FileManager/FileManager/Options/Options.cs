﻿using CommandLine;
using CommandLine.Text;
using FileManager.Domain;
using System.Collections.Generic;
using FileManager.Domain.Models;

namespace FileManager
{
    public class Options
    {
        public User user { get; set; }
        public Options()
        {
            user = new User();
        }
        [Option("filename", Required = false, HelpText = "Input filename.")]
        public string filename { get; set; }

        [Option("select", Required = false, HelpText = "Input filename.")]
        public string Select { get; set; }

        [Option('m', "message", Required = false, HelpText = "Explain what code change you did")]
        public string Message { get; set; }

        [Option('v', "verbose", Default = false,HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

    }
}
