using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FileManager
{
    public interface IConfig
    {
        string FileUploaderDestination { get; set; }
    }
    public class Config : IConfig
    {
        public string FileUploaderDestination { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    class Program
    {

        static void Main(string[] args)
        {

            var parser = new Parser(config => config.HelpWriter = Console.Out);
            //if (args.Length == 0)
            //{
            //    parser.ParseArguments<Options>(new[] { "--help" });
            //    return;
            //}
            var types = LoadVerbs();
            Parser.Default.ParseArguments(args, types).WithParsed(Run).WithNotParsed(errors => Console.WriteLine("Error"));
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
                    FileUploadOptions fileUploader = new FileUploadOptions();
                    fileUploader.RunAddAndReturnExitCode((FileUploadOptions)obj);
                    break;
                case DirectoryChangeOptions d:
                    break;

                case DirectoryDisplayOptions q:
                    break;

            }
        }


    }
}
