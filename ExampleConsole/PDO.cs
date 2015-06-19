using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    class PDO
    {
        public static void PaidDaysOff()
        {
            DateTime startDate = new DateTime(2008, 8, 11, 0, 0, 0);
            TimeSpan span = DateTime.Now.Subtract(startDate);
            double factor = 7.9220219535072375592567242122341e-7;
            double pdo = span.TotalSeconds * factor;
            string text = string.Format("{0:0.000000}", pdo);
            Console.WriteLine(text);
        }
    }
}
