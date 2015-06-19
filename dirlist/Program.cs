using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dirlist
{
	class Program
	{
		static void Main(string[] args)
		{
			string rootPath = args[0];
			ListFolder(new DirectoryInfo(rootPath));
			Console.ReadLine();
		}

		private static void ListFolder(DirectoryInfo rootFolder)
		{
			try
			{
				foreach (DirectoryInfo subFolder in rootFolder.GetDirectories())
				{
					ListFolder(subFolder);
				}
				int files = rootFolder.GetFiles().Length;
				foreach (FileInfo file in rootFolder.GetFiles())
				{
					Console.WriteLine("del \"{0}\"",file.FullName);
				}
				Console.WriteLine("rmdir \"{0}\"",rootFolder.FullName);
			}
			catch (Exception x)
			{
				Console.WriteLine("Error: {0}", x.Message);
			}
		}
	}
}
