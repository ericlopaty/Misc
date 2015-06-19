using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CrashBurn
{
    enum SECTION { Header, Attribs, Code };

    class CodeStats
    {
        static void DoCodeStats(string[] args)
        {
            if (Directory.Exists(args[0]))
            {
                DirectoryInfo dir = new DirectoryInfo(args[0]);
                Console.WriteLine(Stats.Header());
                ProcessFolder(dir);
            }
        }

        static void ProcessFolder(DirectoryInfo dir)
        {
            Stats folderTotal = new Stats(dir.FullName);
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                folderTotal += ProcessFile(file);
            }
            Console.WriteLine(folderTotal);

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo d in dirs)
            {
                ProcessFolder(d);
            }
        }

        static Stats ProcessFile(FileInfo file)
        {
            Stats stats = new Stats(file.Name);
            stats.fileCount++;
            if (IsModule(file, ".VBP"))
                stats.vbpCount++;
            if (IsModule(file, ".FRM.CLS.BAS.CTL"))
            {
                SECTION s = SECTION.Header;
                if (IsModule(file, ".FRM")) stats.frmCount++;
                if (IsModule(file, ".CTL")) stats.ctlCount++;
                if (IsModule(file, ".CLS")) stats.clsCount++;
                if (IsModule(file, ".BAS")) stats.basCount++;
                using (StreamReader reader = File.OpenText(file.FullName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim().ToLower();
                        // look for controls in the header section
                        if (s == SECTION.Header)
                        {
                            if (IsControl(line)) stats.controlCount++;
                            // reached the attributes section
                            if (line.StartsWith("attribute ")) s = SECTION.Attribs;
                        }
                        // look for the end of the attributes section
                        if (s == SECTION.Attribs)
                        {
                            if (!line.StartsWith("attribute ")) s = SECTION.Code;
                        }
                        // look for everything else in the code section
                        if (s == SECTION.Code)
                        {
                            stats.lineCount++;
                            if (line.Length == 0)
                                stats.blankLineCount++;
                            else
                                stats.codeLineCount++;
                            if (IsComment(line)) stats.commentCount++;
                            if (IsSub(line)) stats.functionCount++;
                            if (IsFunction(line)) stats.functionCount++;
                            if (IsProperty(line)) stats.propertyCount++;
                        }
                    }
                    reader.Close();
                }
            }
            return stats;
        }

        static bool IsModule(FileInfo f, string target)
        {
            return target.IndexOf(f.Extension, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        // comments start with ' or rem.
        static bool IsComment(string line)
        {
            return line.StartsWith("'") || line.StartsWith("rem");
        }

        // a control starts with the text "begin", but we omit the wrapper "begin vb.usercontrol"
        static bool IsControl(string line)
        {
            return line.StartsWith("begin ") && !line.StartsWith("begin vb.usercontrol");
        }

        // instead of looking for public/private/friend subs, look for "end sub"
        static bool IsSub(string line)
        {
            return line.StartsWith("end sub");
        }

        // instead of looking for public/private/friend function, look for "end function"
        static bool IsFunction(string line)
        {
            return line.StartsWith("end function");
        }

        // instead of looking for public/private/friend property, look for "end property"
        static bool IsProperty(string line)
        {
            return line.StartsWith("end property");
        }
    }

    class Stats
    {
        public string folderName;
        public int fileCount;
        public int vbpCount;
        public int frmCount;
        public int basCount;
        public int clsCount;
        public int ctlCount;
        public int lineCount;
        public int codeLineCount;
        public int commentCount;
        public int blankLineCount;
        public int functionCount;
        public int propertyCount;
        public int controlCount;

        public Stats(string folderName)
        {
            this.folderName = folderName;
            fileCount = vbpCount = frmCount = basCount =
                clsCount = ctlCount =
                lineCount = codeLineCount = commentCount = blankLineCount =
                functionCount = propertyCount = controlCount = 0;
        }

        public static string Header()
        {
            return "Folder Name\tFiles\tVBP\tFRM\tBAS\tCLS\tCTL\tControls\tFunctions\tProperties\tTotal Lines\tCode Lines\tBlank Lines\tComments";
        }

        public override string ToString()
        {
            return string.Format(
                "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}",
                folderName, fileCount, vbpCount, frmCount, basCount,
                clsCount, ctlCount, controlCount, functionCount,
                propertyCount, lineCount, codeLineCount,
                blankLineCount, commentCount);
        }

        public static Stats operator +(Stats l, Stats r)
        {
            Stats t = new Stats(l.folderName);
            t.fileCount = l.fileCount + r.fileCount;
            t.vbpCount = l.vbpCount + r.vbpCount;
            t.frmCount = l.frmCount + r.frmCount;
            t.basCount = l.basCount + r.basCount;
            t.clsCount = l.clsCount + r.clsCount;
            t.ctlCount = l.ctlCount + r.ctlCount;
            t.lineCount = l.lineCount + r.lineCount;
            t.codeLineCount = l.codeLineCount + r.codeLineCount;
            t.commentCount = l.commentCount + r.commentCount;
            t.blankLineCount = l.blankLineCount + r.blankLineCount;
            t.functionCount = l.functionCount + r.functionCount;
            t.propertyCount = l.propertyCount + r.propertyCount;
            t.controlCount = l.controlCount + r.controlCount;
            return t;
        }
    }
}
