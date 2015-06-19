using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSBuildLogFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine;
            bool flag;

            while ((inputLine = Console.ReadLine()) != null)
            {
                flag=false;
                flag = flag || (inputLine.StartsWith("Build started"));
                flag = flag || (inputLine.StartsWith("Project"));
                flag = flag || (inputLine.StartsWith("Done Building Project"));
                flag = flag || (inputLine.StartsWith("Build succeeded."));
                flag = flag || (inputLine.Contains("Warning(s)"));
                flag = flag || (inputLine.Contains("Error(s)"));
                flag = flag || (inputLine.StartsWith("Build FAILED."));
                flag = flag || (inputLine.StartsWith("Time Elapsed"));
                if (flag) Console.WriteLine(inputLine);
            }
        }
    }
}
