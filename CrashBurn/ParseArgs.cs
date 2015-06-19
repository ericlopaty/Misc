using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{
    public class ParseArgs
    {
        private Dictionary<string, string> parsed;

        public ParseArgs(string[] args)
        {
            try
            {
                parsed = new Dictionary<string, string>();
                string item = "";
                string value = "";
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].StartsWith("/") || args[i].StartsWith("-"))
                    {
                        if (item.Length > 0)
                            parsed.Add(item, "");
                        item = args[i].Substring(1).ToLower();
                        value = "";
                    }
                    else
                    {
                        if (item.Length > 0)
                        {
                            value = args[i];
                            parsed.Add(item, value);
                            item = "";
                            value = "";
                        }
                    }
                }
                if (item.Length > 0)
                    parsed.Add(item, value);
            }
            catch (Exception x)
            {
                throw new Exception(string.Format("Error parsing arguments: {0}", x.Message), x);
            }
        }

        public bool Exists(string arg)
        {
            try
            {
                return parsed.ContainsKey(arg.ToLower());
            }
            catch (Exception x)
            {
                throw new Exception(string.Format("Error checking argument: {0}", x.Message), x);
            }
        }

        public string GetValue(string arg)
        {
            return GetValue(arg.ToLower(), "");
        }

        public string GetValue(string arg, string defaultValue)
        {
            try
            {
                if (parsed.ContainsKey(arg.ToLower()))
                    return parsed[arg.ToLower()];
                else
                    return defaultValue;
            }
            catch (Exception x)
            {
                throw new Exception(string.Format("Error retrieving value: {0}", x.Message), x);
            }
        }
    }
}
