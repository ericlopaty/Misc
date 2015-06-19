using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;

namespace ExampleConsole
{
    class HelloXML
    {
        static void TBD(string[] args)
        {
            //XmlTextWriter writer = new XmlTextWriter(Console.Out);
            //writer.WriteStartDocument();
            //writer.WriteElementString("Hello", "XML");
            //writer.WriteEndDocument();
            //writer.Close();

            //Stream stream = File.OpenRead("c:\\data\\file.xml");
            //int bytesToRead = 1024;
            //int bytesRead = 0;
            //byte[] buffer = new byte[bytesToRead];
            //do
            //{
            //  bytesRead = stream.Read(buffer, 0, bytesToRead);
            //  Console.Write(Encoding.ASCII.GetChars(buffer, 0, bytesRead));
            //} while (bytesToRead == bytesRead);
            //stream.Close();

            //using (TextReader reader = File.Open("c:\\data\\file.xml"))
            //{
            //  while (reader.Peek() != -1)
            //  {
            //    string line = reader.ReadLine();
            //    Console.WriteLine(line);
            //  }
            //  reader.Close();
            //}

            WebRequest request = WebRequest.Create("http://www.cnn.com");
            WebResponse response = request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                while (reader.Peek() != -1)
                {
                    Console.Write(reader.ReadLine());
                    Console.ReadLine();
                }
                reader.Close();
            }

            Console.ReadLine();
        }
    }
}
