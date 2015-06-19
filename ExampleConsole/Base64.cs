using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ExampleConsole
{
    class Base64
    {
        static void Process(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("file not found");
                return;
            }
            if (!fileName.EndsWith(".base64"))
            {
                Console.WriteLine("not a .base64 file");
                return;
            }
            StreamReader input = File.OpenText(fileName);
            string root = fileName.Substring(0, fileName.Length - 7);
            FileStream fs = new FileStream(root, FileMode.Create);
            BinaryWriter output = new BinaryWriter(fs);
            string line;
            while ((line = input.ReadLine()) != null)
            {
                if (line.Length % 4 != 0)
                {
                    Console.WriteLine("character count mismatch");
                    break;
                }
                while (line.Length > 0)
                {
                    string t = line.Substring(0, 4);
                    byte[] b = Decode(t);
                    output.Write(b);
                    line = line.Substring(4);
                }
            }
            input.Close();
            output.Flush();
            output.Close();
            fs.Close();
        }

        static byte[] Decode(string t)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
            int[] s = new int[4];
            for (int i = 0; i < 4; i++)
                s[i] = alphabet.IndexOf(t[i]);
            int c = ((s[0] < 0) || (s[1] < 0)) ? 0 : ((s[2] < 0) && (s[3] < 0)) ? 1 : (s[3] < 0) ? 2 : 3;
            byte[] b = new Byte[c];
            if (c > 0) b[0] = (byte)((s[0] << 2) | (s[1] >> 4));
            if (c > 1) b[1] = (byte)(((s[1] & 15) << 4) | (s[2] >> 2));
            if (c > 2) b[2] = (byte)(((s[2] & 3) << 6) | s[3]);
            return b;
        }
    }
}
