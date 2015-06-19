using System;
using System.Text;
using System.IO;

namespace FindText
{
    class Program
    {
        string text;
        string path;
        int totalFound = 0;

        static void Main(string[] args)
        {
            Console.WriteLine();
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: FindText <text> <path>");
                return;
            }
            Program p = new Program();
            p.text = args[0];
            p.path = args[1];
            p.ScanFiles();
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }

        private void ScanFiles()
        {
            int r = Console.CursorTop;
            string root = Path.GetDirectoryName(path);
            string pattern = Path.GetFileName(path);
            DirectoryInfo di = new DirectoryInfo(root);
            Search(di, pattern);
            Console.WriteLine();
            Console.WriteLine("Search completed.  {0} occurrences found.", totalFound);
        }

        private void Search(DirectoryInfo di, string pattern)
        {
            Console.WriteLine("[{0}]", di.FullName);
            int folderCount = 0;
            int r = Console.CursorTop;
            FileInfo[] files = di.GetFiles(pattern);
            foreach (FileInfo file in files)
            {
                try
                {
                    using (StreamReader reader = File.OpenText(file.FullName))
                    {
                        string[] lines = reader.ReadToEnd().Split(new char[] { '\n', '\r' });
                        reader.Close();
                        int lineCount = 0;
                        foreach (string line in lines)
                        {
                            lineCount++;
                            if (line.ToUpper().IndexOf(text.ToUpper()) >= 0)
                            {
                                Console.WriteLine("{0} ({1}): {2}", file.Name, lineCount, line.Trim());
                                totalFound++;
                                folderCount++;
                            }
                        }
                    }
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error in file {0}: {1}", file.FullName, x.Message);
                }
            }
            Console.WriteLine("{0} occurrences found.", folderCount);
            Console.WriteLine();
            DirectoryInfo[] dirs = di.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                Search(dir, pattern);
            }
        }        
    }
}
