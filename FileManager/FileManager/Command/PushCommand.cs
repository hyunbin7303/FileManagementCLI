using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
	[Verb("push", HelpText = "Save all your commits to the cloud")]
	public class PushCommand : ICommand
	{
		public void Execute()
		{
			Console.WriteLine("Executing Push");
		}
	}

}
