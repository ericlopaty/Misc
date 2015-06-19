using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XmlTestProject
{
  class Program
  {
    public static string DevRoot = @"c:\dev";

    static void Main(string[] args)
    {
      Serializer.main(args);
      Console.WriteLine("\n-------------------------");
      Console.WriteLine("Press ENTER to exit");
      Console.ReadLine();
    }
  }

}
