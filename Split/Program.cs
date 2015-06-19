using System;
using System.Text;
using System.IO;

namespace Split
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName,outputFileName;
            byte[] buffer;
            FileStream inputFile, outputFile;
            FileInfo fi;
            long remain;
            int index;

            fileName=args[0];
            if (!File.Exists(fileName))
                return;
            fi=new FileInfo(fileName);
            using (inputFile = fi.Open(FileMode.Open))
            {
                remain = fi.Length;
                index = 0;
                while (remain > 0)
                {
                    buffer = new byte[Math.Min(2097152, remain)];
                    inputFile.Read(buffer, 0, buffer.Length);
                    outputFileName = string.Format("{0}.{1,3:000}", fileName, index++);
                    using (outputFile = new FileStream(outputFileName, FileMode.CreateNew))
                    {
                        outputFile.Write(buffer, 0, buffer.Length);
                        outputFile.Flush();
                        outputFile.Close();
                    }
                    remain -= buffer.Length;
                }
                inputFile.Close();
            }
        }
    }
}
