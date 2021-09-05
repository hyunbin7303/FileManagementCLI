using CommandLine;
using CommandLine.Text;
using System.Collections.Generic;

namespace FileManager
{
    public class Options : IOption
    {

        [Option("filename", Required = false, HelpText = "Input filename.")]
        public string filename { get; set; }

        //[Option('m', "max", Required = false, Default = 5000, HelpText = "The maximum number : ")]
        //public int MaxRandomInt { get; set; }
        //[Option(shortName: 'c', longName: "confidence", Required = false, HelpText = "Minimum confidence.", Default = 0.9f)]
        //public float Confidence { get; set; }

        [Option('d', "detailed", HelpText = "Whether to output detailed information about the file.")]
        public bool Detailed { get; set; }

        [Value(index: 0, Required = true, HelpText = "The file to display information for.")]
        public string Path { get; set; }

        [Option("file-directory", HelpText = "Whether to output detailed information about the file.")]
        public string fileDirectory { get; set; }

        //[Usage(ApplicationAlias ="")]
        //public static IEnumerable<File>
    }
}
