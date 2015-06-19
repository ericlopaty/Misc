using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace monitor
{
    class Program
    {
        static FileSystemWatcher watcher;
        static Dictionary<string, long> list;
        static long totalSize = 0;

        static void Main(string[] args)
        {
            list = new Dictionary<string, long>();
            Recurse(new DirectoryInfo(args[0]));
            watcher = new FileSystemWatcher(args[0]);
            watcher.Deleted += new FileSystemEventHandler(OnDelete);
            watcher.NotifyFilter = NotifyFilters.FileName;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            Console.Clear();
            Console.WriteLine("{0,15:#,##0}", list.Count);
            Console.WriteLine("{0,15:#,##0}", totalSize);
            Console.ReadLine();
        }

        static void Recurse(DirectoryInfo d)
        {
            FileInfo[] files = d.GetFiles();
            foreach (FileInfo file in files)
            {
                list.Add(file.FullName, file.Length);
                totalSize += file.Length;
            }
            DirectoryInfo[] dirs = d.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
                Recurse(dir);
        }

        static void OnDelete(object sender, FileSystemEventArgs e)
        {
            try
            {
                totalSize -= list[e.FullPath];
                list.Remove(e.FullPath);
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("{0,15:#,##0}", list.Count);
                Console.WriteLine("{0,15:#,##0}", totalSize);
            }
            catch
            {
            }
        }
    }
}
