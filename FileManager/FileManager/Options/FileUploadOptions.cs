using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    [Verb("file-upload",  HelpText = "Upload the file to the specific directory.")]
    public class FileUploadOptions : Options
    {
        [Option("filename", Required = false, HelpText = "Input filename.")]
        public string filename { get; set; }

        [Option('s', "source", Default = ".",HelpText = "The source directory for the files to process.")]
        public string Source { get; set; }


        public int RunAddAndReturnExitCode(FileUploadOptions options)
        {
            if (options.Verbose && !string.IsNullOrEmpty(options.Source))
            {
                Console.WriteLine($"Verbose : {options.Verbose}");
                Console.WriteLine($"Source of Files: {options.Source}");
            }
            Console.WriteLine("adding files");
            // TODO : Adding data into the folder. 
            return 0;
        }

        private int FileUploadToGoogleDrive()
        {
            //https://developers.google.com/drive/api/v3/manage-uploads
            return 0;
        }

        private int FileUploadToDB()
        {
            return 0;
        }


    }
}


// Folder Access Layer.
