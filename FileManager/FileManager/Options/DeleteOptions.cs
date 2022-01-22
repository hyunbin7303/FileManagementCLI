using CommandLine;
using FileManager.Domain;
using FileManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class DeleteOptions : Options
    {
        public DeleteOptions(){ }
        public DeleteOptions(User user, CloudSetup azureSetup, IFileService fileService)
        {
            this.user = user;
            this.CloudSetup = azureSetup;
            _fileService = fileService;
        }
        [Option("filename", Required = false, HelpText = "Input filename.")]
        public string filename { get; set; }
        [Option('s', "source", Default = ".", HelpText = "The source directory for the files to process.")]
        public string Source { get; set; }
        private IFileService _fileService;

        public void RunApp(DeleteOptions options)
        {
            if (options.Verbose && !string.IsNullOrEmpty(options.Source))
            {
                Console.WriteLine($"Verbose : {options.Verbose}");
                Console.WriteLine($"Source of Files: {options.Source}");
            }
            _fileService.DeleteFile(options.filename, options.user.UserId);
        }
    }
}
