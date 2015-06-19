using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace guid
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Guid guid = System.Guid.NewGuid();
            Clipboard.SetData(DataFormats.StringFormat, guid.ToString("D").ToUpper());
            Console.WriteLine(guid.ToString("D").ToUpper());
            Console.ReadLine();
        }
    }
}
