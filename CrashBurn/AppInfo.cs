using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace CrashBurn
{
    public class AppInfo
    {
        private static string name;
        private static string title;
        private static string description;
        private static string company;
        private static string product;
        private static string copyright;
        private static string trademark;
        private static string version;
        private static string assemblyVersion;
        private static string path;
        private static string fullPath;

        static AppInfo()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            object[] attribs;
            attribs = assembly.GetCustomAttributes(false);
            foreach (object o in attribs)
                if (o.GetType() == typeof(AssemblyTitleAttribute))
                    title = (o as AssemblyTitleAttribute).Title;
                else if (o.GetType() == typeof(AssemblyDescriptionAttribute))
                    description = (o as AssemblyDescriptionAttribute).Description;
                else if (o.GetType() == typeof(AssemblyCompanyAttribute))
                    company = (o as AssemblyCompanyAttribute).Company;
                else if (o.GetType() == typeof(AssemblyProductAttribute))
                    product = (o as AssemblyProductAttribute).Product;
                else if (o.GetType() == typeof(AssemblyCopyrightAttribute))
                    copyright = (o as AssemblyCopyrightAttribute).Copyright;
                else if (o.GetType() == typeof(AssemblyTrademarkAttribute))
                    trademark = (o as AssemblyTrademarkAttribute).Trademark;
                else if (o.GetType() == typeof(AssemblyFileVersionAttribute))
                    version = (o as AssemblyFileVersionAttribute).Version;
            AssemblyName t = assembly.GetName();
            assemblyVersion = t.Version.ToString();
            name = t.Name;
            path = Directory.GetParent(assembly.Location).FullName;
            fullPath = assembly.Location;
        }

        public static string Title { get { return title; } }
        public static string Description { get { return description; } }
        public static string Company { get { return company; } }
        public static string Product { get { return product; } }
        public static string Copyright { get { return copyright; } }
        public static string Trademark { get { return trademark; } }
        public static string Version { get { return version; } }
        public static string AssemblyVersion { get { return assemblyVersion; } }
        public static string Name { get { return name; } }
        public static string Path { get { return path; } }
        public static string FullPath { get { return fullPath; } }

        private void DoGetAppInfo()
        {
            StringBuilder s = new System.Text.StringBuilder();
            s.Append("CompanyName: " + Application.CompanyName + "; ");
            s.Append("ProductName: " + Application.ProductName + "; ");
            s.Append("ProductVersion: " + Application.ProductVersion + "; ");
            s.Append("CommonAppDataRegistry: " + Application.CommonAppDataRegistry.ToString());
            s.Append("UserAppDataRegistry: " + Application.UserAppDataRegistry + "; ");
            s.Append("CommonAppDataPath: " + Application.CommonAppDataPath + "; ");
            s.Append("UserAppDataPath: " + Application.UserAppDataPath + "; ");
            s.Append("LocalUserAppDataPath: " + Application.LocalUserAppDataPath + "; ");
            s.Append("ExecutablePath: " + Application.ExecutablePath + "; ");
            s.Append("StartupPath: " + Application.StartupPath + "; ");
            s.Append("Title: " + AppInfo.Title + "; ");
            s.Append("Description: " + AppInfo.Description + "; ");
            s.Append("Company: " + AppInfo.Company + "; ");
            s.Append("Product: " + AppInfo.Product + "; ");
            s.Append("Copyright: " + AppInfo.Copyright + "; ");
            s.Append("Trademark: " + AppInfo.Trademark + "; ");
            s.Append("File Version: " + AppInfo.Version + "; ");
            s.Append("Assembly Version: " + AppInfo.AssemblyVersion + "; ");
            s.Append("Assembly Name: " + AppInfo.Name + "; ");
            s.Append("Path: " + AppInfo.Path + "; ");
            s.Append("Full Path: " + AppInfo.FullPath + "; ");

            // Sample for Environment class summary
            String str;
            String nl = Environment.NewLine;

            //  Invoke this sample with an arbitrary set of command line arguments.
            Console.WriteLine("CommandLine: {0}", Environment.CommandLine);

            String[] arguments = Environment.GetCommandLineArgs();
            Console.WriteLine("GetCommandLineArgs: {0}", String.Join(", ", arguments));

            Console.WriteLine("CurrentDirectory: {0}", Environment.CurrentDirectory);
            Console.WriteLine("ExitCode: {0}", Environment.ExitCode);
            Console.WriteLine("HasShutdownStarted: {0}", Environment.HasShutdownStarted);
            Console.WriteLine("MachineName: {0}", Environment.MachineName);
            Console.WriteLine("NewLine: {0}  first line{0}  second line{0}  third line", Environment.NewLine);
            Console.WriteLine("OSVersion: {0}", Environment.OSVersion.ToString());
            Console.WriteLine("StackTrace: '{0}'", Environment.StackTrace);
            Console.WriteLine("SystemDirectory: {0}", Environment.SystemDirectory);
            Console.WriteLine("TickCount: {0}", Environment.TickCount);
            Console.WriteLine("UserDomainName: {0}", Environment.UserDomainName);
            Console.WriteLine("UserInteractive: {0}", Environment.UserInteractive);
            Console.WriteLine("UserName: {0}", Environment.UserName);
            Console.WriteLine("Version: {0}", Environment.Version.ToString());
            Console.WriteLine("WorkingSet: {0}", Environment.WorkingSet);
            String query = "My system drive is %SystemDrive% and my system root is %SystemRoot%";
            str = Environment.ExpandEnvironmentVariables(query);
            Console.WriteLine("ExpandEnvironmentVariables: {0}  {1}", nl, str);
            Console.WriteLine("GetEnvironmentVariable: {0}  My temporary directory is {1}.", nl, Environment.GetEnvironmentVariable("TEMP"));
            Console.WriteLine("GetEnvironmentVariables: ");
            IDictionary environmentVariables = Environment.GetEnvironmentVariables();
            foreach (DictionaryEntry de in environmentVariables)
            {
                Console.WriteLine("  {0} = {1}", de.Key, de.Value);
            }
            Console.WriteLine("GetFolderPath: {0}", Environment.GetFolderPath(Environment.SpecialFolder.System));
            String[] drives = Environment.GetLogicalDrives();
            Console.WriteLine("GetLogicalDrives: {0}", String.Join(", ", drives));
        }
    }
}
