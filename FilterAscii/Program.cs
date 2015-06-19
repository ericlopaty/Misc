using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterAscii
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder output;
            string line = Console.ReadLine();
            while (line != null)
            {
                output = new StringBuilder();
                for (int i = 0; i < line.Length; i++)
                    if ((int)line[i] >= 32 && (int)line[i] <= 127)
                        output.Append(line[i]);
                Console.WriteLine(output);
                line = Console.ReadLine();
            }            
        }
    }
}
