using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;

// 1. Off
// 2. Fatal
// 3. Error
// 4. Warn
// 5. Info
// 6. Debug
// 7. All

namespace ConsoleApplication1
{
    class Program
    {
        private static readonly ILog Log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            for (int i=0;i<20;i++)
            { 
                Log.Info(string.Format("Writing to the log at {0}",DateTime.Now));
                Thread.Sleep(1000);
                Console.WriteLine(i);
            }
        }
    }
}
