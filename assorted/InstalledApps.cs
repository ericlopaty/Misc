using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Reflection;

[assembly: AssemblyTitle("InstalledApps")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyCompany("Prudential Financial")]
[assembly: AssemblyProduct("InstalledApps")]
[assembly: AssemblyCopyright("Copyright � Prudential Financial 2011")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

namespace InstalledApps
{
    class Program
    {
        static void Main(string[] args)
        {
            string branch;
            RegistryKey key;
            string[] products;
            List<string> installedApps = new List<string>();
            string productKeyPath;
            string productName;
            string productVersion;
            StreamWriter outputFile = null;

            try
            {
                branch = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";
                installedApps.Clear();
                key = Registry.LocalMachine.OpenSubKey(branch, false);
                products = key.GetSubKeyNames();
                key.Close();
                foreach (string product in products)
                {
                    productKeyPath = branch + "\\" + product;
                    key = Registry.LocalMachine.OpenSubKey(productKeyPath, false);
                    productName = (string)key.GetValue("DisplayName", "");
                    if (productName.Length == 0)
                        productName = string.Format("{0}", product);
                    productVersion = (string)key.GetValue("DisplayVersion", "");
                    installedApps.Add(string.Format("{0}, [{1}]", productName, productVersion));
                }
                branch = @"Installer\Products";
                key = Registry.ClassesRoot.OpenSubKey(branch, false);
                products = key.GetSubKeyNames();
                key.Close();
                foreach (string product in products)
                {
                    productKeyPath = branch + "\\" + product;
                    key = Registry.ClassesRoot.OpenSubKey(productKeyPath, false);
                    productName = (string)key.GetValue("ProductName", "");
                    if (productName.Length == 0)
                        productName = string.Format("{0}", product);
                    productVersion = string.Format("{0}", (int)key.GetValue("Version", 0));
                    installedApps.Add(string.Format("{0}, [{1}]", productName, productVersion));
                }
                installedApps.Sort();
                foreach (string app in installedApps)
                    Console.WriteLine(app);
            }
            catch (System.Exception x)
            {
                Console.WriteLine(x.Message);
            }
            finally
            {
                if (outputFile != null)
                {
                    outputFile.Flush();
                    outputFile.Close();
                    outputFile.Dispose();
                }
            }
        }
    }
}
