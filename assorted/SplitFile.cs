using System;
using System.IO;
using System.Reflection;

[assembly: AssemblyTitle("SplitFile")]
[assembly: AssemblyDescription("Splits a file into pieces of a specified size.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Prudential Financial")]
[assembly: AssemblyProduct("SplitFile")]
[assembly: AssemblyCopyright("Copyright © Prudential Financial 2011")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

namespace SplitFile
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
	            string fileName;
	            StreamReader reader=null;
	            StreamWriter writer=null;
	            int current = 0;
	            int index=0;
	            int limit;
	            string line;

				if (args.Length != 2)
				{
					Console.WriteLine();
					Console.WriteLine("Usage: SplitFile <filename> <size>");
					Console.WriteLine();
					Console.WriteLine("Splits a file into pieces of a specified size.");
					return;
				}
	            fileName=args[0];
	            limit = int.Parse(args[1]);
	            if (!File.Exists(fileName))
	            {
					Console.WriteLine("Unable to find {0}",fileName);	                
	                return;
				}
	            using (reader = new StreamReader(fileName))
	            {
	                while ((line = reader.ReadLine()) != null)
	                {
	                    if (writer == null || current+line.Length>limit)
	                    {
	                        if (writer != null)
	                        {
								writer.Flush();
								writer.Close();
								writer.Dispose();
							}
	                        current = 0;
	                        writer=new StreamWriter(string.Format("{0}.{1,3:000}", fileName, index++));
	                    }
	                    writer.WriteLine(line);
	                    current += line.Length;
	                }
	                if (writer != null)
	                {
						writer.Flush();
						writer.Close();
						writer.Dispose();
					}
	                reader.Close();
	            }
			}
			catch (Exception x)
			{
				Console.WriteLine(x.Message);
			}
        }
    }
}
