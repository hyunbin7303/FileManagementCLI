﻿using CommandLine;
using CommandLine.Text;
using System.Collections.Generic;

namespace FileManager
{
    public class Options : IOption
    {
        [Option("filename", Required = false, HelpText = "Input filename.")]
        public string filename { get; set; }

        [Option("select", Required = false, HelpText = "Input filename.")]
        public string Select { get; set; }

        [Option('m', "message", Required = false, HelpText = "Explain what code change you did")]
        public string Message { get; set; }

        [Option('v', "verbose", Default = false,HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }
        ////[Option('m', "max", Required = false, Default = 5000, HelpText = "The maximum number : ")]
        ////public int MaxRandomInt { get; set; }
        ////[Option(shortName: 'c', longName: "confidence", Required = false, HelpText = "Minimum confidence.", Default = 0.9f)]
        ////public float Confidence { get; set; }
    }
}