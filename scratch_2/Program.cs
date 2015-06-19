using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace scratch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("john");
            list.Add("paul");
            list.Add("george");
            list.Add("ringo");

            foreach (string s in list)
            {
                if (string.Compare(s, "paul") == 0)
                    list.Remove(s);
                else
                    Console.WriteLine(s);                
            }
            Console.ReadLine();

        }
    }
}
