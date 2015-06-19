using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("ReplaceText")]
[assembly: AssemblyDescription("Scans stdin and replaces instances of 'target' with 'replacement'.")]
[assembly: AssemblyCompany("Prudential Financial")]
[assembly: AssemblyProduct("ReplaceText")]
[assembly: AssemblyCopyright("Copyright © Prudential Financial 2010")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

namespace ReplaceText
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            string target = "";
            string replacement = "";

            if (args.Length == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Usage ReplaceText 'target' 'replacement' < inputfile > outputfile");
                Console.WriteLine();
                Console.WriteLine("Scans stdin and replaces instances of 'target'");
                Console.WriteLine("with 'replacement'. If 'replacement' is not specified,");
                Console.WriteLine("'target' is removed. 'target' is case sensitive.");
                Console.WriteLine();
                return;
            }
            try
            {
                if (args.Length > 0) target = args[0];
                if (args.Length > 1) replacement = args[1];
                while ((line = Console.ReadLine()) != null)
                {
                    line = line.Replace(target, replacement);
                    Console.WriteLine(line);
                }
            }
            catch (Exception x)
            {
                Console.WriteLine();
                Console.WriteLine("Error: {0}", x.Message);
            }
        }
    }
}
