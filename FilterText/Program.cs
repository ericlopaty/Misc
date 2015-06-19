using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterText
{
    class Program
    {
        static void Main(string[] args)
        {
            string target = args[0].ToUpper();
            if (target.StartsWith("\""))
                target = target.Substring(1,target.Length-1);
            if (target.EndsWith("\""))
                target=target.Substring(0,target.Length-1);
            string s;
            while ((s = Console.ReadLine()) != null)
                if (s.ToUpper().IndexOf(target)>=0)
                    Console.WriteLine(s);
        }
    }
}
