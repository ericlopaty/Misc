using System;
using System.IO;
using System.Text;
using System.Collections;

namespace CrashBurn
{
    class Base64
    {
        static void DoBase64(string[] args)
        {
            string inputFileName = args[0];
            string outputFilename1 = args[1];
            string outputFilename2 = args[2];

            if (!File.Exists(inputFileName))
            {
                Console.WriteLine("file not found");
                return;
            }
            DecodeBase64(inputFileName, outputFilename1);
            DecodeWithString(inputFileName, outputFilename2);
        }

        private static void DecodeBase64(string inputFilename, string outputFilename)
        {
            StreamReader input = File.OpenText(inputFilename);
            FileStream fs = new FileStream(outputFilename, FileMode.Create);
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

        public static void DecodeWithString(string inputFileName, string outputFileName)
        {
            System.IO.StreamReader inFile;
            string base64String;

            try
            {
                char[] base64CharArray;
                inFile = new System.IO.StreamReader(inputFileName, System.Text.Encoding.ASCII);
                base64CharArray = new char[inFile.BaseStream.Length];
                inFile.Read(base64CharArray, 0, (int)inFile.BaseStream.Length);
                base64String = new string(base64CharArray);
            }
            catch (System.Exception exp)
            {
                // Error creating stream or reading from it.
                System.Console.WriteLine("{0}", exp.Message);
                return;
            }

            // Convert the Base64 UUEncoded input into binary output. 
            byte[] binaryData;
            try
            {
                binaryData =
                   System.Convert.FromBase64String(base64String);
            }
            catch (System.ArgumentNullException)
            {
                System.Console.WriteLine("Base 64 string is null.");
                return;
            }
            catch (System.FormatException)
            {
                System.Console.WriteLine("Base 64 string length is not " +
                   "4 or is not an even multiple of 4.");
                return;
            }

            // Write out the decoded data.
            System.IO.FileStream outFile;
            try
            {
                outFile = new System.IO.FileStream(outputFileName,
                                           System.IO.FileMode.Create,
                                           System.IO.FileAccess.Write);
                outFile.Write(binaryData, 0, binaryData.Length);
                outFile.Close();
            }
            catch (System.Exception exp)
            {
                // Error creating stream or writing to it.
                System.Console.WriteLine("{0}", exp.Message);
            }
        }
    }
}
