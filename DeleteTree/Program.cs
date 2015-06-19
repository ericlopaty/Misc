using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace DeleteTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = args[0];
            DeleteFolder(new DirectoryInfo(rootPath));
            Console.ReadLine();
        }

        private static void DeleteFolder(DirectoryInfo rootFolder)
        {
            try
            {
                Console.WriteLine("Deleting files in {0}", rootFolder.FullName);
                foreach (DirectoryInfo subFolder in rootFolder.GetDirectories())
                {
                    DeleteFolder(subFolder);
                }
                int files = rootFolder.GetFiles().Length;
                int c = 0;
                foreach (FileInfo file in rootFolder.GetFiles())
                {
                    try
                    {
                        c++;
                        Console.WriteLine("---> {0}/{1}: {2}", c, files, file.Name);
                        file.Delete();
                    }
                    catch (Exception x)
                    {
                        Console.WriteLine("Error: {0}", x.Message);
                    }
                    Thread.Sleep(1000);
                }
                try
                {
                    rootFolder.Delete();
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error: {0}", x.Message);
                }
            }
            catch (Exception x)
            {
                Console.WriteLine("Error: {0}", x.Message);
            }
        }
    }
}
