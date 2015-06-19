using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReplaceText
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            string target = "", replacement = "";
            if (args.Length == 2)
            {
                target = args[0];
                replacement = args[1];
            }
            if (args.Length == 1)
            {
                target = args[0];
                replacement = "";
            }
            while ((line = Console.ReadLine()) != null)
            {
                line = line.Replace(target, replacement);
                Console.WriteLine(line);
            }
        }
    }
}
