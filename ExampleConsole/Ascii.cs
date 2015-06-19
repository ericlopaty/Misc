using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    class Ascii
    {
        static void FilterAscii()
        {
            int c;
            while ((c = Console.Read()) >= 0)
            {
                if (c >= 32 && c <= 127)
                    Console.Write((char)c);
            }
        }
    }
}
