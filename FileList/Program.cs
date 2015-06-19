using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileList
{
    class Program
    {
        private static int _projectCount = 0, _solutionCount = 0, _configCount = 0;

        static void Main(string[] args)
        {
            Search(new DirectoryInfo(args[0]));
            Console.WriteLine("Project Count: {0}", _projectCount);
            Console.WriteLine("Solution Count: {0}", _solutionCount);
            Console.WriteLine("Config Count: {0}", _configCount);
        }

        static void Search(DirectoryInfo root)
        {
            foreach (var file in root.GetFiles())
            {
                if (file.Extension.ToLower() == ".csproj") _projectCount++;
                if (file.Extension.ToLower() == ".sln") _solutionCount++;
                if (file.Extension.ToLower() == ".config") _configCount++;
                if (!file.FullName.ToLower().Contains("\\bin\\") && !file.FullName.ToLower().Contains("\\obj\\"))
                {
                    int lines = 0, blanks = 0, comments = 0;
                    if (file.Extension.ToLower() == ".cs")
                        SourceCount(file, out lines, out comments, out blanks);
                    else if (file.Extension.ToLower() == ".xml" || file.Extension.ToLower() == ".xaml")
                        XMLCount(file, out lines, out comments, out blanks);
                    Console.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", file.Extension, file.Name,
                         lines, comments, blanks, lines + comments + blanks, file.FullName));
                }
            }
            foreach (var folder in root.GetDirectories())
            {
                Search(folder);
            }
        }

        static void SourceCount(FileInfo file, out int lines, out int comments, out int blanks)
        {
            using (var reader = file.OpenText())
            {
                comments = 0;
                lines = 0;
                blanks = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Trim().Length == 0)
                        blanks++;
                    else if (line.StartsWith("//"))
                        comments++;
                    else
                        lines++;
                }
            }
        }

        static void XMLCount(FileInfo file, out int lines, out int comments, out int blanks)
        {
            using (var reader = file.OpenText())
            {
                comments = 0;
                lines = 0;
                blanks = 0;
                bool commentFlag = false;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Trim().Length == 0)
                        blanks++;
                    else
                    {
                        if (line.Contains("<!--") && !commentFlag)
                        {
                            commentFlag = true;
                            comments++;
                        }
                        else if (line.Contains("--!>") && commentFlag)
                        {
                            commentFlag = false;
                            comments++;
                        }
                        else
                            lines++;
                    }
                }
            }
        }

    }
}
