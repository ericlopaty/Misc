using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Instancing
{
    [ComVisible(true)]
    [Guid("F29E0077-4978-4603-9A49-FAD5FF73E662")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class TestClass
    {
        private static readonly string logFile = @"C:\temp\Instancing.log";
        private static int instanceCount;
        private int thisInstance;
        private string msg;

        private static void ShowError(Exception x)
        {
            MessageBox.Show(string.Format("ERROR: {0}", x.Message), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void WriteLog(string message)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(logFile))
                {
                    writer.WriteLine(message);
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception x)
            {
                ShowError(x);
            }
        }

        static TestClass()
        {
            instanceCount = 0;
            WriteLog(string.Format("Creating Global TestClass: There are no individual instances."));
        }

        public TestClass()
        {
            instanceCount++;
            msg = "";
            WriteLog(string.Format("Creating a TestClass instance, the count is {0}", instanceCount));
            thisInstance = instanceCount;
        }

        [ComVisible(true)]
        public void WriteMessage(string s)
        {
            msg += s;
            WriteLog(msg);
        }

        ~TestClass()
        {
            WriteLog(string.Format("Destroying TestClass instance {0}", thisInstance));
            instanceCount--;
        }
    }
}
