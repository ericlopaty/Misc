using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace DependencyChecker
{
    class Program
    {
        private static List<Item> cache = new List<Item>();

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("usage: dependencychecker <solution file>");
                return;
            }
            string rootSolution = args[0];
            if (!File.Exists(rootSolution))
            {
                Console.WriteLine("could not find specified solution.");
                return;
            }
            CheckSolution(rootSolution);
            Console.WriteLine("[end]");
            Console.ReadLine();
        }

        private static void CheckSolution(string solution)
        {
            string projectName = "";
            string projectFile = "";
            string projectGUID = "";
            int i1, i2, j1, j2, k1, k2;
            string line;

            string solutionName = Path.GetFileNameWithoutExtension(solution);
            Console.WriteLine("Checking solution {0}", solutionName);
            using (StreamReader reader = File.OpenText(solution))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.StartsWith("Project(\"{"))
                    {
                        line = line.Substring(52);
                        i1 = line.IndexOf("\"");
                        i2 = line.IndexOf("\"", i1 + 1);
                        j1 = line.IndexOf("\"", i2 + 1);
                        j2 = line.IndexOf("\"", j1 + 1);
                        k1 = line.IndexOf("\"", j2 + 1);
                        k2 = line.IndexOf("\"", k1 + 1);
                        projectName = line.Substring(i1 + 1, i2 - (i1 + 1));
                        projectFile = line.Substring(j1 + 1, j2 - (j1 + 1));
                        projectGUID = line.Substring(k1 + 1, k2 - (k1 + 1));
                        Item p = new Item(projectName, projectFile, ".", projectGUID);
                        cache.Add(p);
                        Console.WriteLine(p.ToString());
                    }
                }
                reader.Close();
            }
            foreach (Item p in cache)
            {
                using (StreamReader reader = File.OpenText(p.Location))
                {
                }
            }
        }
    }

    class Item
    {
        private string name;
        private string location;
        private string root;
        private string guid;

        public Item(string name, string location, string root, string guid)
        {
            this.name = name;
            this.location = location;
            this.root = root;
            this.guid = guid;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", name, guid);
        }

        public string Name { get { return name; } }
        public string Location { get { return location; } }
        public string Root { get { return root; } }
        public string GUID { get { return guid; } }
    }
}
