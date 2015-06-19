using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StripHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            bool flag;
            StringBuilder t;
            while ((s = Console.ReadLine()) != null)
            {
                t = new StringBuilder();
                flag = false;
                for (int i = 0; i < s.Length; i++)
                {
                    if (!flag && s[i] == '<')
                        flag = true;
                    else if (flag && s[i] == '>')
                        flag = false;
                    else if (!flag)
                        t.Append(s[i]);
                }
                if (t.Length > 0)
                    Console.WriteLine(t.ToString());
            }
        }
    }
}
