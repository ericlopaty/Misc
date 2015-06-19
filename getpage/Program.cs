using System;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;

namespace getpage
{
    class Program
    {
        static System.Threading.Timer repeater;
        static TimerCallback repeaterDelegate;
        static AutoResetEvent autoReset;
        static int lastRunDay = -1;
        static int runHour = 7;

        static void Main(string[] args)
        {
            repeaterDelegate = new TimerCallback(OnTimer);
            autoReset=new AutoResetEvent(false);
            TimeSpan initialDelay = new TimeSpan(0, 0, 0);
            TimeSpan intervalDelay = new TimeSpan(0, 1, 0);
            repeater = new Timer(repeaterDelegate, autoReset, initialDelay, intervalDelay);
            Console.ReadLine();
        }

        static void OnTimer(object state)
        {
            Console.Write(".");
            if (DateTime.Now.Day == lastRunDay)
                return;
            if (DateTime.Now.Hour < runHour)
                return;
            try
            {
                Console.WriteLine();
                string url = "http://forecast.weather.gov/MapClick.php?CityName=Wanaque&state=NJ&site=OKX&textField1=41.0432&textField2=-74.2906&TextType=1";
                WebRequest request = WebRequest.Create(url);
                IWebProxy proxy = WebRequest.GetSystemWebProxy();
                proxy.Credentials = CredentialCache.DefaultCredentials;
                request.Proxy = proxy;
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Console.WriteLine("{0} - Sending request", DateTime.Now);
                using (Stream dataStream = response.GetResponseStream())
                {
                    Console.WriteLine("{0} - Received response", DateTime.Now);
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        string fileName = string.Format(".\\forecast {0}.html", DateTime.Now.Day);
                        using (StreamWriter writer = File.CreateText(fileName))
                        {
                            Console.WriteLine("{0} - Writing response to {1}", DateTime.Now, fileName);
                            string[] lines = reader.ReadToEnd().Split('\n');
                            foreach (string line in lines)
                            {
                                bool flag = false;
                                StringBuilder t = new StringBuilder();
                                for (int i = 0; i < line.Length; i++)
                                {
                                    if (!flag && line[i] == '<')
                                        flag = true;
                                    else if (flag && line[i] == '>')
                                        flag = false;
                                    else if (!flag)
                                        t.Append(line[i]);
                                }
                                if (t.Length > 0)
                                    writer.WriteLine(t.ToString());
                            }
                            writer.Flush();
                            writer.Close();
                        }
                        reader.Close();
                    }
                    dataStream.Close();
                }
                response.Close();
                lastRunDay = DateTime.Now.Day;
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
    }
}
