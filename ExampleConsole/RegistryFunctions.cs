using System;
using System.Text;
using Microsoft.Win32;

namespace ExampleConsole
{
    class RegistryFunctions
    {
        public static void Dispatch()
        {
            Test1();
        }

        public static void Test1()
        {
            //Registry.CurrentUser.CreateSubKey();
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Vendor\\Product\\Section");
            key.SetValue("Integer", 1234, RegistryValueKind.DWord);
            key.SetValue("Long", 12345678901234, RegistryValueKind.QWord);
            key.SetValue("String", "Hello World", RegistryValueKind.String);
            key.SetValue("ExpandString", "%DIRCMD%", RegistryValueKind.ExpandString);
            string[] strArray = new string[] { "Hello", "World","This","is","an","array"};
            key.SetValue("StringArray", strArray, RegistryValueKind.MultiString);
            //key.SetValue("Binary", 'A', RegistryValueKind.Binary);
            key.DeleteValue("Long");
            key.CreateSubKey("Section2");
            RegistryKey key2 = key.CreateSubKey("Section2");
            key2.SetValue("Hello", "World");
            key.CreateSubKey("Section3");
            RegistryKey key3 = key.CreateSubKey("Section3");
            key3.SetValue("Hello", "World");
            Console.WriteLine(key.SubKeyCount);
            key.DeleteSubKey("Section2");
            foreach (string subKey in key.GetSubKeyNames())
                Console.WriteLine(subKey);
            string strValue = (string)key.GetValue("String");
            Console.WriteLine(strValue);
            RegistryValueKind kind=key.GetValueKind("ExpandString");
            Console.WriteLine(kind==RegistryValueKind.ExpandString);
            foreach (string valueNames in key.GetValueNames())
                Console.WriteLine(valueNames);
            RegistryKey key3a = key.OpenSubKey("Section3");
            Console.WriteLine(key3a.ValueCount);


            Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Vendor\\Product");
            key.Flush();
            key.Close();
        }
    }
}
