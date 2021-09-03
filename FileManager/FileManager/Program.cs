using CommandLine;
using FileManager.Command;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace FileManager
{
    public class Options
    {
        [Option('m', "max", Required =false,Default =5000, HelpText ="The maximum number : ")]
        public int MaxRandomInt { get; set; }

        [Value(index: 0, Required = true, HelpText = "The file to display information for.")]
        public string Path { get; set; }

        [Option(shortName: 'c', longName: "confidence", Required = false, HelpText = "Minimum confidence.", Default = 0.9f)]
        public float Confidence { get; set; }

        [Option('d', "detailed", HelpText = "Whether to output detailed information about the file.")]
        public bool Detailed { get; set; }
    }
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
         //   IServiceProvider serviceProvider = BuildServiceProvider(args);

            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed(o =>
                   {
                   })
                   .WithNotParsed(e =>
                   {
                       Console.WriteLine("ERROR");
                   });
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
