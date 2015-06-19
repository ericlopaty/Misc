using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterHTML
{
    class Program
    {
        private static bool inTag = false;
        private static bool articleStart = false;

        static void Main(string[] args)
        {
            string inputLine, outputLine;
            while ((inputLine = Console.ReadLine()) != null)
            {
                for (int i = 0; i < inputLine.Length; i++)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Contains("<NYT_TEXT>"))
                    {
                        int j = inputLine.IndexOf("<NYT_TEXT>");
                        inputLine = inputLine.Substring(j + 10);
                        articleStart = true;
                    }
                    if (inputLine.Contains("</NYT_TEXT>"))
                    {
                        int j = inputLine.IndexOf("</NYT_TEXT>");
                        inputLine = inputLine.Substring(0, j);
                        articleStart = false;
                    }

                    

                }
            }
        }
    }
}
