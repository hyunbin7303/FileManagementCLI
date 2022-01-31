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
        private IFileService _fileService;
        private IConfigurationService _configurationService;
        public DeleteOptions(){ }
        public DeleteOptions(IFileService fileService, IConfigurationService configurationService)
        {
            _fileService = fileService;
            _configurationService = configurationService;
        }
        [Option("filename", Required = false, HelpText = "Input filename.")]
        public string Filename { get; set; }

        [Option('s', "source", Default = ".", HelpText = "The source directory for the files to process.")]
        public string Source { get; set; }

        public void Execute(DeleteOptions options)
        {
            if (options.Verbose && !string.IsNullOrEmpty(options.Source))
            {
                Console.WriteLine($"Verbose : {options.Verbose}");
                Console.WriteLine($"Source of Files: {options.Source}");
            }
            _fileService.DeleteFile(options.Filename, options.user.UserId);
        }
    }
}
