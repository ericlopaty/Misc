using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ExampleConsole
{
    [Chapter(13)]
    class FileIO
    {
        public static void Dispatch()
        {
            FileListing();
        }

        public static void FileListing()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            Directory.SetCurrentDirectory(@"c:\");

            string[] drives = Environment.GetLogicalDrives();
            foreach (string drive in drives)
                Console.WriteLine(drive);            
            DirectoryInfo di = new DirectoryInfo(drives[0]);
            Dir(di);
        }

        public static void Dir(DirectoryInfo dir)
        {
            Console.WriteLine("Folder: {0} [{1}]", dir.Name, dir.FullName);
            FileInfo[] files = dir.GetFiles();
            Console.WriteLine("--> Files: {0}", files.Length);
            DirectoryInfo[] dirs = dir.GetDirectories();
            Console.WriteLine("--> Directories: {0}", dirs.Length);
            foreach (DirectoryInfo di in dirs)
                Dir(di);
        }
    }

    class Filter
    {
        static void FilterHTML(string fileName)
        {
            string s;
            StringBuilder t;
            bool flag = false;
            StreamReader read = new StreamReader(fileName);
            StreamWriter write = new StreamWriter(fileName + ".txt", false);
            while ((s = read.ReadLine()) != null)
            {
                t = new StringBuilder();
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '<' && !flag)
                        flag = true;
                    else if (s[i] == '>' && flag)
                        flag = false;
                    else if (!flag)
                        t.Append(s[i]);
                }
                write.WriteLine(t.ToString());
            }
            read.Close();
            write.Flush();
            write.Close();
        }

        private void FilterText(string fileName, bool squeezeEmpties, bool createBackup)
        {
            try
            {
                string path = Path.GetDirectoryName(fileName);
                string extension = Path.GetExtension(fileName);
                string baseFileName = Path.GetFileNameWithoutExtension(fileName);
                string backupFileName = Path.Combine(path, baseFileName + ".bak");
                string tempFile = TempFile(path);
                FileInfo inputFile = new FileInfo(fileName);
                if (createBackup)
                    File.Copy(fileName, backupFileName);
                using (StreamReader reader = File.OpenText(fileName))
                {
                    using (StreamWriter writer = File.CreateText(tempFile))
                    {
                        writer.AutoFlush = true;
                        string line;
                        bool emptyLine = false;
                        int lineCount = 0;
                        while ((line = reader.ReadLine()) != null)
                        {
                            lineCount++;
                            if (squeezeEmpties && emptyLine && IsEmpty(line))
                                continue;
                            if (squeezeEmpties && !emptyLine && IsEmpty(line))
                                emptyLine = true;
                            writer.WriteLine(line.TrimEnd(new char[] { ' ', '\t' }));
                            if (!IsEmpty(line))
                                emptyLine = false;
                        }
                        writer.Close();
                    }
                    reader.Close();
                }
                File.Delete(fileName);
                File.Copy(tempFile, fileName);
                File.Delete(tempFile);
            }
            catch (IOException iox)
            {
                ShowError(string.Format("IO ERROR: {0}", iox.Message));
            }
            catch (Exception x)
            {
                ShowError(string.Format("ERROR: {0}", x.Message));
            }
        }

        private static bool IsEmpty(string line)
        {
            return (line.Trim().Length == 0);
        }

        private static void ShowError(string msg)
        {
            Console.WriteLine(msg);
        }

        private static string TempFile(string path)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder fileName;
            string tempFile;
            do
            {
                fileName = new StringBuilder(8);
                for (int i = 0; i < 8; i++)
                    fileName.Append(chars[r.Next(0, chars.Length)]);
                tempFile = Path.Combine(path, fileName.ToString());
            } while (File.Exists(tempFile));
            return tempFile;
        }
    }
}
