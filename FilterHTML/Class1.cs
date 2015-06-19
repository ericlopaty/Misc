using System;
using System.IO;
using System.Text;

namespace FilterHTML
{
  class Class1
  {
    [STAThread]
    static void Main(string[] args)
    {
      string s;
      StringBuilder t;
      bool flag = false;
      StreamReader read = new StreamReader(args[0]);
      StreamWriter write = new StreamWriter(args[0] + ".txt", false);
      while ((s = read.ReadLine()) != null)
      {
        t = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
          if (s[i] == '<' && !flag)
            flag = true;
          else if (s[i] == '>' && flag)
            flag = false;
          else if (!flag)
            t.Append(s[i]);
        }
        write.WriteLine(t.ToString());
      }
      read.Close();
      write.Flush();
      write.Close();
    }
  }
} 
