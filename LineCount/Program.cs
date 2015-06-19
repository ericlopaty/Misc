using System;
using System.IO;

namespace LineCount
{
    class Program
    {
        static void Main(string[] args)
        {
            bool noBlank=false;
            string line;
            int lines = 0;
            if (args.Length > 0)
                foreach (string a in args)
                    if (string.Compare(a.ToUpper(), "/NOBLANK") == 0) noBlank = true;
            while ((line = Console.ReadLine()) != null)
            {
                lines += (noBlank && line.Trim().Length == 0) ? 0 : 1;
            }
            Console.WriteLine("{0}", lines);
        }
    }
}
