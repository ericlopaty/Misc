using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Xml;

namespace CommonLib
{
    class Settings
    {
        private string company;
        private string product;

        private readonly string regTemplate = @"SOFTWARE\{0}\{1}";
        private XmlDocument xmlDoc = null;
        private string xmlFilePath = null;
        private const string xmlTemplate = "//application[@name='{0}']/setting[@name='{1}' and @type='{2}']";

        public enum Scope
        {
            Application,
            User
        }

        public Settings(string company, string product)
        {
            this.company = company;
            this.product = product;
        }

        public Settings(string xmlFilePath)
        {
            try
            {
                this.xmlFilePath = xmlFilePath;
                xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilePath);
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public string GetSetting(Scope appScope, string settingName, string defaultValue)
        {
            RegistryKey key = null;
            try
            {
                string path = string.Format(regTemplate, company, product);
                key = (appScope == Scope.Application) ?
                    Registry.LocalMachine.OpenSubKey(path, false) :
                    Registry.CurrentUser.OpenSubKey(path, false);
                RegistryValueKind kind = key.GetValueKind(settingName);
                if (kind == RegistryValueKind.String)
                    return (string)key.GetValue(settingName);
                else
                    return defaultValue;
            }
            catch (Exception x)
            {
                throw x;
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                    key.Dispose();
                }
            }
        }

        public int GetSetting(Scope appScope, string settingName, int defaultValue)
        {
            RegistryKey key = null;
            try
            {
                string path = string.Format(regTemplate, company, product);
                key = (appScope == Scope.Application) ?
                    Registry.LocalMachine.OpenSubKey(path, false) :
                    Registry.CurrentUser.OpenSubKey(path, false);
                RegistryValueKind kind = key.GetValueKind(settingName);
                if (kind == RegistryValueKind.String)
                    return (int)key.GetValue(settingName);
                else
                    return defaultValue;
            }
            catch (Exception x)
            {
                throw x;
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                    key.Dispose();
                }
            }
        }

        public long GetSetting(Scope appScope, string settingName, long defaultValue)
        {
            RegistryKey key = null;
            try
            {
                string path = string.Format(regTemplate, company, product);
                key = (appScope == Scope.Application) ?
                    Registry.LocalMachine.OpenSubKey(path, false) :
                    Registry.CurrentUser.OpenSubKey(path, false);
                RegistryValueKind kind = key.GetValueKind(settingName);
                if (kind == RegistryValueKind.String)
                    return (long)key.GetValue(settingName);
                else
                    return defaultValue;
            }
            catch (Exception x)
            {
                throw x;
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                    key.Dispose();
                }
            }
        }

        public void SaveSetting(Scope appScope, string settingName, string value)
        {
            RegistryKey key = null;
            try
            {
                string path = string.Format(regTemplate, company, product);
                key = (appScope == Scope.Application) ?
                    Registry.LocalMachine.OpenSubKey(path, false) :
                    Registry.CurrentUser.OpenSubKey(path, false);
                key.SetValue(settingName, value, RegistryValueKind.String);
            }
            catch (Exception x)
            {
                throw x;
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                    key.Dispose();
                }
            }
        }

        public void SaveSetting(Scope appScope, string settingName, int value)
        {
            RegistryKey key = null;
            try
            {
                string path = string.Format(regTemplate, company, product);
                key = (appScope == Scope.Application) ?
                    Registry.LocalMachine.OpenSubKey(path, false) :
                    Registry.CurrentUser.OpenSubKey(path, false);
                key.SetValue(settingName, value, RegistryValueKind.DWord);
            }
            catch (Exception x)
            {
                throw x;
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                    key.Dispose();
                }
            }
        }

        public void SaveSetting(Scope appScope, string settingName, long value)
        {
            RegistryKey key = null;
            try
            {
                string path = string.Format(regTemplate, company, product);
                key = (appScope == Scope.Application) ?
                    Registry.LocalMachine.OpenSubKey(path, false) :
                    Registry.CurrentUser.OpenSubKey(path, false);
                key.SetValue(settingName, value, RegistryValueKind.QWord);
            }
            catch (Exception x)
            {
                throw x;
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                    key.Dispose();
                }
            }
        }

        private string Extract(string application, string setting, string type)
        {
            string expression = "";
            XmlNode node = null;
            try
            {
                expression = string.Format(xmlTemplate, application, setting, type);
                node = xmlDoc.SelectSingleNode(expression);
                if (node == null)
                    return null;
                if (node.ChildNodes.Count == 1)
                    return node.ChildNodes[0].Value;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public int GetXMLSetting(string application, string setting, int defaultValue)
        {
            try
            {
                string s = Extract(application, setting, "integer");
                if (s == null)
                    return defaultValue;
                else
                    return (int)int.Parse(s);
            }
            catch
            {
                return defaultValue;
            }
        }

        public string GetXMLSetting(string application, string setting, string defaultValue)
        {
            try
            {
                string s = Extract(application, setting, "string");
                if (s == null)
                    return defaultValue;
                else
                    return s;
            }
            catch
            {
                return defaultValue;
            }
        }

        public bool GetXMLSetting(string application, string setting, bool defaultValue)
        {
            try
            {
                string s = Extract(application, setting, "boolean");
                if (s == null)
                    return defaultValue;
                else
                {
                    string c = s.ToUpper().Substring(0, 1);
                    return c == "Y" || c == "T" || c == "1";
                }
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
