using System;
using System.IO;

namespace DumpFile
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(args[0], FileMode.Open, FileAccess.Read);
            byte[] buffer = null;
            long dumped = 0;
            string b;
            Console.WriteLine("File: {0}",args[0]);
            Console.WriteLine("---------------------------------------------------------------------------");
            while (dumped < fs.Length)
            {
                long bufLen=Math.Min(16,fs.Length-dumped);
                buffer = new byte[bufLen];
                fs.Read(buffer, 0, (int)bufLen);
                Console.Write("{0,6:X}: |", dumped);
                dumped += bufLen;
                for (int i = 0; i < 16; i++)
                {
                    if (i > 0) Console.Write(" ");
                    if (i < bufLen)
                        b = string.Format("{0:X}", buffer[i]).PadLeft(2, '0');
                    else
                        b = "";
                    Console.Write("{0,2}", b);
                }
                Console.Write("|");
                for (int i = 0; i < 16; i++)
                {
                    if (i < bufLen)
                    {
                        if (buffer[i] >= 32 && buffer[i] <= 127)
                            Console.Write("{0,1}", (char)buffer[i]);
                        else
                            Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("|");
            }
        }
    }
}
