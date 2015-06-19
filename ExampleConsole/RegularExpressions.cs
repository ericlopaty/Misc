using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ExampleConsole
{
    [Chapter(10)]
    class RegularExpressions
    {
        public static void Dispatch()
        {
            string s1 = "One,Two,Three Liberty Associates, Inc.";
            StringBuilder sb = new StringBuilder();

            Regex regex = new Regex(" |, |,");
            int id = 1;
            foreach (string subString in regex.Split(s1))
                sb.AppendFormat("{0}: {1}\n", id++, subString);
            Console.WriteLine("{0}", sb);

            sb = new StringBuilder();
            id = 1;
            foreach (string subString in Regex.Split(s1, " |, |,"))
                sb.AppendFormat("{0}: {1}\n", id++, subString);
            Console.WriteLine(sb.ToString());

            sb = new StringBuilder();
            id = 1;
            foreach (string subString in regex.Split(s1, 3))
                sb.AppendFormat("{0}: {1}\n", id++, subString);
            Console.WriteLine("{0}", sb);

            regex = new Regex(@"(\S+)\s");      // \S+ = non whitespace, one or more; \s = whitespace
            MatchCollection matches = regex.Matches("This is a test string");
            foreach (Match match in matches)
                Console.WriteLine("length: {0} match: [{1}]", match.Length, match.ToString());
            Console.WriteLine();
            matches = regex.Matches("This is a test string ");
            foreach (Match match in matches)
                Console.WriteLine("length: {0} match: [{1}]", match.Length, match.ToString());
            Console.WriteLine();

            s1 = "04:03:27 127.0.0.1 LibertyAssociates.com\n" +
                "05:04:28 128.0.0.2 R2K.com\n" +
                "06:05:29 129.0.0.3 IBM.com\n";
            regex = new Regex(@"(?<time>(\d|\:)+)\s" +   // one or more digits or colons, followed by a space
                @"(?<ip>(\d|\.)+)\s" +     // one or more digits or dots, followed by a space
                @"(?<site>\S+)");   // one or more characters
            matches = regex.Matches(s1);
            foreach (Match match in matches)
            {
                if (match.Length > 0)
                {
                    Console.WriteLine("Match: {0}", match.ToString());
                    Console.WriteLine("time: {0}", match.Groups["time"]);
                    Console.WriteLine("ip: {0}", match.Groups["ip"]);
                    Console.WriteLine("site: {0}", match.Groups["site"]);
                    Console.WriteLine();
                }
            }

            Console.WriteLine("----");
            s1 = "04:03:27 Jesse 0.0.0.127 Liberty ";
            // regular expression which groups company twice
            regex = new Regex(@"(?<time>(\d|\:)+)\s" +
            @"(?<company>\S+)\s" +
            @"(?<ip>(\d|\.)+)\s" +
            @"(?<company>\S+)\s");
            matches = regex.Matches(s1);
            foreach (Match match in matches)
            {
                if (match.Length != 0)
                {
                    Console.WriteLine("theMatch: {0}", match.ToString());
                    Console.WriteLine("time: {0}", match.Groups["time"]);
                    Console.WriteLine("ip: {0}", match.Groups["ip"]);
                    Console.WriteLine("Company: {0}", match.Groups["company"]);
                    foreach (Capture cap in match.Groups["company"].Captures)
                        Console.WriteLine("cap: {0}", cap.ToString());
                }
            }
        }
    }
}
