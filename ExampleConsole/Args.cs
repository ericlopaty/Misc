using System;
using System.Collections.Generic;

/* -----------------------------------------------------------------------------
 * Copyright 2009, Eric Lopaty (EricLopaty@gmail.com)
 * No warrantee is given.
 * Use is permitted.
 * ----------------------------------------------------------------------------- */

namespace Toolkit
{
    public static class Args
    {
        public static Dictionary<string, string> Parse(string[] args)
        {
            try
            {
                Dictionary<string, string> argsList = new Dictionary<string, string>();
                string keyName = "";
                foreach (string token in args)
                {
                    if (token.StartsWith("/") || token.StartsWith("-"))
                    {
                        if (keyName.Length > 0)
                        {
                            argsList.Add(keyName, keyName);
                        }
                        keyName = token.Substring(1);
                    }
                    else
                    {
                        if (keyName.Length > 0)
                        {
                            argsList.Add(keyName, token);
                            keyName = string.Empty;
                        }
                        else
                        {
                            argsList.Add(token, token);
                        }
                    }
                }
                if (keyName.Length > 0)
                {
                    argsList.Add(keyName, keyName);
                }
                return argsList;
            }
            catch (System.Exception x)
            {
                string message = string.Format("Args: Unable to parse command line. ({0})", x.Message);
                throw new Exception(message, x);
            }
        }
    }
}
