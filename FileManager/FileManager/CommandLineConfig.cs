using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class CommandLineConfig
    {
        public static void CliConfig(string[] args)
        {
            var parser = new Parser(config => config.HelpWriter = Console.Out);
            if (args.Length == 0)
            {
                parser.ParseArguments<Options>(new[] { "--help" });
                return;
            }
            var types = LoadVerbs();
            Parser.Default
                .ParseArguments(args, types)
                .WithParsed(Run)
                .WithNotParsed(errors => Console.WriteLine("Error"));
        }
        private static Type[] LoadVerbs()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetCustomAttribute<VerbAttribute>() != null).ToArray();
        }
        private static void Run(object obj)
        {
            switch (obj)
            {
                case FileUploadOptions c:
                    FileUploadOptions fileUploader = new FileUploadOptions("");
                    fileUploader.RunAddAndReturnExitCode((FileUploadOptions)obj);
                    break;

                case FileDownloadOptions f:
                    FileDownloadOptions fileDownloader = new FileDownloadOptions();
                    //fileDownloader.Select();
                    break;

                case DirectoryChangeOptions d:
                    DirectoryChangeOptions directoryChangeOptions = new DirectoryChangeOptions();
                    break;

                case DisplayOptions q:
                    var displayOpt = new DisplayOptions();
                    displayOpt.Execute((DisplayOptions)obj);
                    break;
            }
        }

    }
}
