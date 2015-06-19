using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("FilterText")]
[assembly: AssemblyDescription("Scans lines from stdin and output lines that match.")]
[assembly: AssemblyCompany("Prudential Financial")]
[assembly: AssemblyProduct("FilterText")]
[assembly: AssemblyCopyright("Copyright © Prudential Financial 2010")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

namespace FilterText
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine();
                Console.WriteLine("FilterText \"target\" < inputfile > outputfile");
                Console.WriteLine();
                Console.WriteLine("Scans lines from stdin and outputs lines that match");
                Console.WriteLine("the target to stdout. Target may be a single word or");
                Console.WriteLine("a phrase in quotes and is not case sensitive.");
                return;
            }
            try
            {
                string target = args[0].ToUpper();
                if (target.StartsWith("\""))
                    target = target.Substring(1, target.Length - 1);
                if (target.EndsWith("\""))
                    target = target.Substring(0, target.Length - 1);
                string s;
                while ((s = Console.ReadLine()) != null)
                    if (s.ToUpper().IndexOf(target) >= 0)
                        Console.WriteLine(s);
            }
            catch (Exception x)
            {
                Console.WriteLine();
                Console.WriteLine("Error: {0}", x.Message);
            }
        }
    }
}
