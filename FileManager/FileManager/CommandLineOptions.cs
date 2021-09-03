using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class CommandLineOptions
    {
        [Value(index: 0, Required = true, HelpText = "Image file Path to analyze.")]
        public string Path { get; set; }

        [Option(shortName: 'c', longName: "confidence", Required = false, HelpText = "Minimum confidence.", Default = 0.9f)]
        public float Confidence { get; set; }

        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }
    }
}
