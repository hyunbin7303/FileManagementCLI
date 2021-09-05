using CommandLine;
using FileManager.Command;
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
                case FileUploadOption c:
                    break;
                case DirectoryChangeOption d:
                    break;
                //case Options o:
                //    break;
                case DefaultVerbOption v:
                    break;
            }
        }

        static IServiceProvider BuildServiceProvider(string[] args)
        {
            IServiceCollection collection = new ServiceCollection();
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json", optional: false).AddCommandLine(args).Build();
            IConfig config = configuration.Get<Config>();

            collection.AddSingleton<Options>();
            collection.AddSingleton<IConfig>(config);
            return collection.BuildServiceProvider();
        }

    }
}
