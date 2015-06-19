using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedInLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 20; i > 0; i--)
                Console.WriteLine((new string('_', 20 - i)) + (new string('*', i)).Replace("*", i.ToString()));
        }
    }
}
