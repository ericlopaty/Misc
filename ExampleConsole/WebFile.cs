using System;
using System.Collections.Generic;
using System.Collections;
using System.Net;
using System.IO;

namespace ExampleConsole
{
    class WebFile
    {
        private const string template = "http://space.jpl.nasa.gov/cgi-bin/wspace?tbody=6&vbody=-90&month={0}&day={1}&century=20&decade=0&year=4&hour={2}&minute=0&fovmul=1&rfov=30&bfov=30";

        static void GetFile(string[] args)
		{
			WebClient req=new WebClient();
			DateTime d=new DateTime(2004,5,26,0,0,0);
			DateTime end=new DateTime(2004,6,27,0,0,0);
			while (d<end)
			{
				string uri=string.Format(template,d.Month,d.Day,d.Hour);
				string filename=string.Format("c:\\cassini\\{0:00}{1:00}{2:00}.jpg",d.Month,d.Day,d.Hour);
				req.DownloadFile(uri,filename);
				Console.WriteLine(filename);
				d=d.AddHours(1);
			}
			Console.ReadLine();
		}
    }

    class WeatherSat
    {
        static void Getem(string prefix)
        {
            string address = @"http://www.goes-arch.noaa.gov/";
            List<string> queue = new List<string>(48);
            List<string> retry = new List<string>(1);
            Stream rs = null;
            FileStream fs = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            int byteCount = 0;
            for (int h = 0; h < 24; h++)
            {
                queue.Add(string.Format("{0}{1}{2,2:00}15.GIF", address, prefix, h));
                queue.Add(string.Format("{0}{1}{2,2:00}45.GIF", address, prefix, h));
            }
            for (int attempt = 1; attempt <= 5; attempt++)
            {
                while (queue.Count > 0)
                {
                    try
                    {
                        string url = queue[0];
                        string fileName = url.Substring(url.Length - 17, 17);
                        Console.Write("Attempt {0}: {1}...", attempt, fileName);
                        request = (HttpWebRequest)HttpWebRequest.Create(url);
                        response = (HttpWebResponse)request.GetResponse();
                        byteCount = (int)response.ContentLength;
                        using (rs = response.GetResponseStream())
                        {
                            using (fs = new FileStream(fileName, FileMode.Create))
                            {
                                int b = -1;
                                for (int i = 0; i < byteCount; i++)
                                {
                                    b = rs.ReadByte();
                                    fs.WriteByte((byte)b);
                                }
                                fs.Flush();
                                fs.Close();
                            }
                            rs.Close();
                        }
                        Console.WriteLine("{0} bytes written.", byteCount);
                    }
                    catch (Exception x)
                    {
                        Console.WriteLine(x.Message);
                        retry.Add(queue[0]);
                        if (response != null)
                            response.Close();
                        if (rs != null)
                        {
                            rs.Close();
                            rs.Dispose();
                        }
                        if (fs != null)
                        {
                            fs.Close();
                            fs.Dispose();
                        }
                    }
                    queue.RemoveAt(0);
                }
                if (retry.Count > 0)
                    queue.AddRange(retry);
                retry.Clear();
                //while (retry.Count > 0)
                //{
                //  queue.Add(retry[0]);
                //  retry.RemoveAt(0);
                //}
            }
        }
    }

}
