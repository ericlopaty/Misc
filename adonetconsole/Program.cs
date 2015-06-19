using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlTypes;

namespace adonetconsole
{
  class Program
  {
    static void Main(string[] args)
    {
      Updates.Dispatch();
      Console.WriteLine("press ENTER to exit.");
      Console.ReadLine();
    }
  }
}