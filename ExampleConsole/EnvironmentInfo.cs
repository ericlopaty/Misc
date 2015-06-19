using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    class EnvironmentInfo
    {
        public static void Dispatch()
        {
            Console.WriteLine(Environment.CommandLine);
            Console.WriteLine(Environment.CurrentDirectory);
            Console.WriteLine(Environment.ExpandEnvironmentVariables("The home path is %HOMEPATH%"));
            Console.WriteLine(Environment.GetEnvironmentVariable("%HOMEPATH%"));
            Program.Divider("Environment Variables");
            Hashtable env = (Hashtable)Environment.GetEnvironmentVariables();
            foreach (string key in env.Keys)
                Console.WriteLine("{0}={1}", key, env[key]);
            Program.Divider("Environment.SpecialFolder");
            Console.WriteLine("{0} = {1}", ".ApplicationData", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            Console.WriteLine("{0} = {1}", ".CommonApplicationData", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            Console.WriteLine("{0} = {1}", ".CommonProgramFiles", Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles));
            Console.WriteLine("{0} = {1}", ".Cookes", Environment.GetFolderPath(Environment.SpecialFolder.Cookies));
            Console.WriteLine("{0} = {1}", ".Desktop", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Console.WriteLine("{0} = {1}", ".DesktopDirectory", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            Console.WriteLine("{0} = {1}", ".Favorites", Environment.GetFolderPath(Environment.SpecialFolder.Favorites));
            Console.WriteLine("{0} = {1}", ".History", Environment.GetFolderPath(Environment.SpecialFolder.History));
            Console.WriteLine("{0} = {1}", ".InternetCache", Environment.GetFolderPath(Environment.SpecialFolder.InternetCache));
            Console.WriteLine("{0} = {1}", ".LocalApplicationData", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            Console.WriteLine("{0} = {1}", ".MyComputer", Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));
            Console.WriteLine("{0} = {1}", ".MyDocuments", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            Console.WriteLine("{0} = {1}", ".MyMusic", Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            Console.WriteLine("{0} = {1}", ".MyPictures", Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            Console.WriteLine("{0} = {1}", ".Personal", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            Console.WriteLine("{0} = {1}", ".ProgramFiles", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
            Console.WriteLine("{0} = {1}", ".Programs", Environment.GetFolderPath(Environment.SpecialFolder.Programs));
            Console.WriteLine("{0} = {1}", ".Recent", Environment.GetFolderPath(Environment.SpecialFolder.Recent));
            Console.WriteLine("{0} = {1}", ".SendTo", Environment.GetFolderPath(Environment.SpecialFolder.SendTo));
            Console.WriteLine("{0} = {1}", ".StartMenu", Environment.GetFolderPath(Environment.SpecialFolder.StartMenu));
            Console.WriteLine("{0} = {1}", ".Startup", Environment.GetFolderPath(Environment.SpecialFolder.Startup));
            Console.WriteLine("{0} = {1}", ".System", Environment.GetFolderPath(Environment.SpecialFolder.System));
            Console.WriteLine("{0} = {1}", ".Templates", Environment.GetFolderPath(Environment.SpecialFolder.Templates));
            Program.Divider("");
            string[] drives=Environment.GetLogicalDrives();
            foreach (string drive in drives)
                Console.WriteLine("Drive = {0}",drive);

            Console.WriteLine(Environment.MachineName);
            Console.WriteLine(Environment.OSVersion);
            Console.WriteLine(Environment.ProcessorCount);
            Console.WriteLine(Environment.SystemDirectory);
            Console.WriteLine(Environment.TickCount);
            Console.WriteLine(Environment.UserDomainName);
            Console.WriteLine(Environment.UserInteractive);
            Console.WriteLine(Environment.UserName);
            Console.WriteLine(Environment.Version.ToString());
            Console.WriteLine(Environment.WorkingSet);

        }

    }
}
