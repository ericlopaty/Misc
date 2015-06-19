using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    [Chapter(10)]
    class StringExamples
    {
        public static void Dispatch()
        {
            StringMethods();
        }

        public static void StringMethods()
        {
            Program.Divider("compare, concat, equals, format");
            string s, t;
            s = "hello";
            t = "Hello";
            Console.WriteLine(string.Compare(s, t, true));
            Console.WriteLine(string.Concat("hello"," ","world"));
            s = string.Copy(t);
            Console.WriteLine(string.Compare(s, t));
            Console.WriteLine(string.Equals("hello", "hello"));
            Console.WriteLine("---------- = ----------");
            Console.WriteLine(string.Format("{0,10} = {1,10:#,##0.00}", "value", 1234.567));
            Console.WriteLine(string.Format("{0,-10} = {1,-10:#,##0.00}", "value", 1234.567));
            Program.Divider("intern, copy, join, length, indexer");
            s = "original";
            t = string.Intern(s);
            Console.WriteLine(t);
            t = string.Copy(s);
            Console.WriteLine(t);
            Console.WriteLine(string.Join(",",new string[] {"a","b","c"}));
            Console.WriteLine(t.Length);
            foreach (char c in t)
                Console.Write("{0} ",c);
            Program.Divider("clone");
            t = (string)s.Clone();
            Console.WriteLine(t);
            Console.WriteLine(t.CompareTo(s));
            Program.Divider("copyto, endswith, equals, insert, lastindexof");
            char[] q = new char[t.Length];
            t.CopyTo(0, q, 0, t.Length);
            for (int i = 0; i < t.Length; i++)
                Console.Write(q[i] + "-");
            Console.WriteLine();
            string test = "This is a test";
            Console.WriteLine(test);
            Console.WriteLine("{0} ends with 'est' = {1}", test, test.EndsWith("est"));
            Console.WriteLine("{0} == {1} = {2}", 
                test, "This is a test", 
                test.Equals("This is a test", StringComparison.CurrentCultureIgnoreCase));
            Console.WriteLine("insert ell into Ho = {0}", "Ho".Insert(1, "ell"));
            Console.WriteLine("last index of 'l' in Hello = {0}", "Hello".LastIndexOf('l'));
            Program.Divider("pad left, pad right, remove, split");
            Console.WriteLine("pad left [{0}]", "Hello".PadLeft(10, '*'));
            Console.WriteLine("pad right [{0}]", "Hello".PadRight(10, '*'));
            Console.WriteLine("remove ell from Hello = {0}", "Hello".Remove(1, 3));
            foreach (string str in "a,b;c,d,,e".Split(',', ';'))
                Console.WriteLine(str);
            Program.Divider("startswith, substring, tochararray, tolower, toupper");
            Console.WriteLine("{0} starts with 'TH' = {1}", test, test.StartsWith("TH"));
            Console.WriteLine("Hello".Substring(1, 3));
            q = "This is a test".ToCharArray();
            for (int i = 0; i < q.Length; i++)
                Console.Write(q[i] + "-");
            Console.WriteLine("This is a Test".ToLower());
            Console.WriteLine("This is a Test".ToUpper());
            Program.Divider("trim, trimend, trimstart");
            Console.WriteLine("[" + " \t \t  This is a Test \t \t  ".Trim() + "]");
            Console.WriteLine("[" + " \t \t  This is a Test \t \t  ".TrimEnd() + "]");
            Console.WriteLine("[" + " \t \t  This is a Test \t \t  ".TrimStart() + "]");
            //IsInterned( ) Public static method that returns a reference for the string.

            StringBuilder sb = new StringBuilder();
            Console.WriteLine(sb.Capacity);
            sb.Append("This is a test");
            Console.WriteLine(sb.Length);
            Console.WriteLine(sb.MaxCapacity);
            sb.Insert(5, "not ");
            Console.WriteLine(sb.ToString());
            sb.Remove(5, 4);
            Console.WriteLine(sb.ToString());
            sb.AppendFormat(" {0}", "of stringbuilder");
            Console.WriteLine(sb.ToString());
            sb.Replace("test", "TEST");
            Console.WriteLine(sb.ToString());
            Console.WriteLine(sb[0]);
            //EnsureCapacity( ) Ensures the current StringBuilder has a capacity at least as large as the specified value.
        }

    }
}
