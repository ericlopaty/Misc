using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LinesOfCode
{
    class Program
    {
        private static Dictionary<string, SummaryItem> languages;
        private static List<string> codeExt = 
            new List<string>(
                new string[] { ".vb", ".bas", ".cs", ".cpp", ".frm", ".ctl", ".cls", ".h", ".java" });
        private static readonly string titleTemplate = "Root Path: {0}";
        private static readonly string header1 = "Language   Count       Code    Comment      Blank      Total";
        private static readonly string header2 = "-------- ------- ---------- ---------- ---------- ----------";
        private static readonly string summaryTemplate = "{0,-8} {1,7:#,##0} {2,10:#,##0} {3,10:#,##0} {4,10:#,##0} {5,10:#,##0}";
        private static int top = 0;

        static void Main(string[] args)
        {
            int fileTotal, codeTotal, commentTotal, blankTotal, grandTotal;
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: LinesOfCode <root path>");
                PressEnter();
                return;
            }
            if (!Directory.Exists(args[0]))
            {
                Console.WriteLine("Error: Path not found.");
                PressEnter();
                return;
            }
            languages = new Dictionary<string, SummaryItem>();
            languages.Add(".NET", new SummaryItem(-1));
            languages.Add("VB6", new SummaryItem(-1));
            languages.Add("C++", new SummaryItem(-1));
            languages.Add("JAVA", new SummaryItem(-1));
            DirectoryInfo rootInfo = new DirectoryInfo(args[0]);
            Console.Clear();
            Console.WriteLine(titleTemplate, rootInfo.FullName);
            Console.WriteLine();
            Console.WriteLine(header1);
            Console.WriteLine(header2);
            top = 4;

            ScanFolder(rootInfo);
            
            Console.SetCursorPosition(0, top);
            Console.WriteLine(header2);
            fileTotal = codeTotal = commentTotal = blankTotal = grandTotal = 0;
            foreach (SummaryItem item in languages.Values)
            {
                fileTotal += item.Files;
                codeTotal += item.Code;
                commentTotal += item.Comment;
                blankTotal += item.Blank;
                grandTotal += item.Total;
            }
            Console.WriteLine(summaryTemplate, "Total", fileTotal, codeTotal, commentTotal, blankTotal, grandTotal);
            PressEnter();
        }

        static void PressEnter()
        {
            Console.WriteLine();
            Console.Write("Press ENTER to exit.");
            Console.ReadLine();
        }

        static void ScanFolder(DirectoryInfo root)
        {
            FileInfo[] files = root.GetFiles();
            foreach (FileInfo file in files)
                if (codeExt.Contains(file.Extension.ToLower()))
                    ScanFile(file);
            foreach (DirectoryInfo folder in root.GetDirectories())
                ScanFolder(folder);
        }

        static void ScanFile(FileInfo file)
        {
            string extension = file.Extension.ToLower();
            string l;
            string lang = GetLanguage(extension);
            bool commentFlag;
            SummaryItem c = languages[lang];
            c.Files++;
            if (c.Top < 0)
            {
                c.Top = top;
                top++;
            }
            commentFlag = false;
            using (StreamReader reader = new StreamReader(file.FullName))
            {
                while ((l = reader.ReadLine()) != null)
                {
                    c.Total++;
                    if (l.Length == 0)
                    {
                        c.Blank++; continue;
                    }
                    if (".vb .frm .cls .bas .ctl".IndexOf(extension) >= 0)
                    {
                        if (l.StartsWith("'") || l.StartsWith("rem")) { c.Comment++; continue; }
                    }
                    if (".cs .cpp .h .java".IndexOf(extension) >= 0)
                    {
                        if (l.StartsWith("/*")) { c.Comment++; commentFlag = true; continue; }
                        if (l.StartsWith("*/")) { c.Comment++; commentFlag = false; continue; }
                        if (l.StartsWith("//")) { c.Comment++; continue; }
                    }
                    if (commentFlag)
                        c.Comment++;
                    else
                        c.Code++;
                }
                reader.Close();
                Console.SetCursorPosition(0, c.Top);
                Console.Write(summaryTemplate,  lang, c.Files, c.Code, c.Comment, c.Blank, c.Total);
            }
        }

        private static string GetLanguage(string extension)
        {
            if (".vb .cs".IndexOf(extension) >= 0) return ".NET";
            if (".cpp .h".IndexOf(extension) >= 0) return "C++";
            if (".frm .cls .bas .ctl".IndexOf(extension) >= 0) return "VB6";
            if (".java".IndexOf(extension) >= 0) return "JAVA";
            return "";
        }
    }

    class SummaryItem
    {
        public int Files;
        public int Total;
        public int Code;
        public int Comment;
        public int Blank;
        public int Top;

        public SummaryItem(int top)
        {
            Files = Total = Code = Comment = Blank = 0;
            Top = top;            
        }
    }
}
