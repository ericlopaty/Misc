using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace CountFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int interval = int.Parse(args[0]);
                string path = args[1];
                DateTime now;
                DateTime target;
                int files;
                int r1 = 0, r2;
                while (true)
                {
                    files = ScanFolder(new DirectoryInfo(path));
                    now = DateTime.Now;
                    Console.WriteLine("At {0}, found {1} files.", now.ToString("HH:mm:ss"), files);
                    target = now.AddSeconds(interval);
                    r1 = (int)target.Subtract(DateTime.Now).TotalSeconds;
                    while (r1 > 0)
                    {
                        r2 = (int)target.Subtract(DateTime.Now).TotalSeconds;
                        if (r2 != r1)
                        {
                            r1 = r2;
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.Write("{0,4}", r1);
                        }
                        Thread.Sleep(100);
                    }
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write("    ");
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private static int ScanFolder(DirectoryInfo path)
        {
            int fileCount = 0;
            foreach (DirectoryInfo folder in path.GetDirectories())
                fileCount += ScanFolder(folder);
            fileCount += path.GetFiles().Length;
            return fileCount;
        }
    }
}
