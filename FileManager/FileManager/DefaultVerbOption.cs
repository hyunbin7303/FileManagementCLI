using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
	[Verb("copy", isDefault: true, HelpText = "Copy some stuff")]
	public class DefaultVerbOption
	{
		[Option('a', "alpha", Required = true)]
		public string Option { get; set; }
	}
}
