﻿using CommandLine;
using FileManager.Infrastructure._3rd_Parties;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    [Verb("file-download", HelpText = "File Download.")]
    public class FileDownloadOptions : Options
    {
        
        [Option('s', "source", Default = ".", HelpText = "The source directory for the files to process.")]
        public string Source { get; set; }

        [Option('t', "Type", Default = ".", HelpText = "Type of storage")]
        public string Type { get; set; }

        [Option('d', "destination", HelpText = "Destination to store the data.")]
        public string Destination { get; set; }

        public int RunAddAndReturnExitCode(FileDownloadOptions options)
        {
            if (options.Verbose && !string.IsNullOrEmpty(options.Source))
            {
                Console.WriteLine($"Verbose : {options.Verbose}");
                Console.WriteLine($"Source of Files: {options.Source}");
            }
            Log.Logger.Information("File Dolwnloading");

            return 0;
        }
        public void GoogleDocDownloading(string fileName)
        {
            GoogleDocClient client = new GoogleDocClient();

        }
    }
}
