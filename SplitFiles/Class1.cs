using System;
using System.IO;

namespace SplitFiles
{
    class Class1
    {
        private static readonly string path = "C:\\data\\keith\\base64\\";

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
                return;
            System.IO.StreamReader reader = new StreamReader(args[0]);
            System.IO.StreamWriter writer = null;
            int lines = 0;
            int fileLines = 0;
            int files = 0;
            string destFile;
            string s = reader.ReadLine();
            lines++;
            while (s != null)
            {
                if (s.StartsWith("FILE NAME="))
                {
                    if (writer != null)
                    {
                        writer.Close();
                        Console.WriteLine("{0}]", fileLines);
                        fileLines = 0;
                    }
                    destFile = s.Substring(10) + ".base64";
                    if (File.Exists(path + destFile))
                    {
                        int i = 0;
                        while (File.Exists(path + destFile + "." + i.ToString()))
                        {
                            i++;
                        }
                        destFile = destFile + "." + i.ToString();
                    }
                    writer = new StreamWriter(path + destFile);
                    files++;
                    Console.Write("Writing file {0} -- {1} [", files, destFile);
                }
                else
                {
                    fileLines++;
                    writer.WriteLine(s);
                }
                s = reader.ReadLine();
                lines++;
            }
            writer.Close();
            Console.WriteLine("{0}]", fileLines);
            reader.Close();
            Console.WriteLine("{0} lines processed", lines);
            Console.ReadLine();
        }
    }
}
