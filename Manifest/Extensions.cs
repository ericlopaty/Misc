using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Manifest
{
    public static class Extensions
    {

        #region String Extensions

        public static bool IsEqualTo(this string left, string right)
        {
            try
            {
                return left.Equals(right, StringComparison.CurrentCultureIgnoreCase);
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        #endregion

        #region SQL Extensions

        public static void Open(this SqlConnection cn, string server, string database)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = server;
                builder.InitialCatalog = database;
                builder.IntegratedSecurity = true;
                cn.ConnectionString = builder.ConnectionString;
                cn.Open();
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public static void Open(this SqlConnection cn, string server, string database, string userId, string password)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = server;
                builder.InitialCatalog = database;
                builder.IntegratedSecurity = false;
                builder.UserID = userId;
                builder.Password = password;
                cn.ConnectionString = builder.ConnectionString;
                cn.Open();
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public static SqlDataReader ExecuteReader(this SqlConnection cn, string commandText, CommandType commandType, int commandTimeout, CommandBehavior commandBehavior)
        {
            SqlDataReader reader = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = commandText;
                cmd.CommandTimeout = commandTimeout;
                cmd.CommandType = commandType;
                cmd.Connection = cn;
                reader = cmd.ExecuteReader(commandBehavior);
            }
            return reader;
        }

        public static int ExecuteNonQuery(this SqlConnection cn, string commandText, CommandType commandType, int commandTimeout)
        {
            int result = -1;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = commandText;
                cmd.CommandTimeout = commandTimeout;
                cmd.CommandType = commandType;
                cmd.Connection = cn;
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static object ExecuteScalar(this SqlConnection cn, string commandText, CommandType commandType, int commandTimeout)
        {
            Object result = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = commandText;
                cmd.CommandTimeout = commandTimeout;
                cmd.CommandType = commandType;
                cmd.Connection = cn;
                result = cmd.ExecuteScalar();
            }
            return result;
        }

        public static string GetString(this SqlDataReader reader, int col, string defaultValue)
        {
            return reader.IsDBNull(col) ? defaultValue : reader.GetString(col);
        }

        public static int GetInt32(this SqlDataReader reader, int col, int defaultValue)
        {
            return reader.IsDBNull(col) ? defaultValue : reader.GetInt32(col);
        }

        public static long GetInt64(this SqlDataReader reader, int i, long defaultValue)
        {
            return reader.IsDBNull(i) ? defaultValue : reader.GetInt64(i);
        }

        public static bool GetBoolean(this SqlDataReader reader, int i, bool defaultValue)
        {
            return reader.IsDBNull(i) ? defaultValue : reader.GetBoolean(i);
        }

        public static DateTime GetDateTime(this SqlDataReader reader, int i, DateTime defaultValue)
        {
            return reader.IsDBNull(i) ? defaultValue : reader.GetDateTime(i);
        }

        public static double GetDouble(this SqlDataReader reader, int i, double defaultValue)
        {
            return reader.IsDBNull(i) ? defaultValue : reader.GetDouble(i);
        }

        public static void AddParameter(this SqlCommand cmd, string paramName, DbType paramType, ParameterDirection paramDirection, int paramSize, object paramValue)
        {
            SqlParameter param = cmd.CreateParameter();
            param.ParameterName = paramName;
            param.DbType = paramType;
            param.Direction = paramDirection;
            param.Size = paramSize;
            param.Value = paramValue;
            cmd.Parameters.Add(param);
        }

        #endregion

        #region ODBC Extensions

        public static void Open(this OdbcConnection cn, string dsn)
        {
            try
            {
                OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder();
                builder.Dsn = dsn;
                cn.ConnectionString = builder.ConnectionString;
                cn.Open();
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public static OdbcDataReader ExecuteReader(this OdbcConnection cn, string commandText, CommandType commandType, int commandTimeout, CommandBehavior commandBehavior)
        {
            OdbcDataReader reader = null;
            using (OdbcCommand cmd = new OdbcCommand())
            {
                cmd.CommandText = commandText;
                cmd.CommandTimeout = commandTimeout;
                cmd.CommandType = commandType;
                cmd.Connection = cn;
                reader = cmd.ExecuteReader(commandBehavior);
            }
            return reader;
        }

        public static int ExecuteNonQuery(this OdbcConnection cn, string commandText, CommandType commandType, int commandTimeout)
        {
            int result = -1;
            using (OdbcCommand cmd = new OdbcCommand())
            {
                cmd.CommandText = commandText;
                cmd.CommandTimeout = commandTimeout;
                cmd.CommandType = commandType;
                cmd.Connection = cn;
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static object ExecuteScalar(this OdbcConnection cn, string commandText, CommandType commandType, int commandTimeout)
        {
            Object result = null;
            using (OdbcCommand cmd = new OdbcCommand())
            {
                cmd.CommandText = commandText;
                cmd.CommandTimeout = commandTimeout;
                cmd.CommandType = commandType;
                cmd.Connection = cn;
                result = cmd.ExecuteScalar();
            }
            return result;
        }

        public static string GetString(this OdbcDataReader reader, int col, string defaultValue)
        {
            return reader.IsDBNull(col) ? defaultValue : reader.GetString(col);
        }

        public static int GetInt32(this OdbcDataReader reader, int col, int defaultValue)
        {
            return reader.IsDBNull(col) ? defaultValue : reader.GetInt32(col);
        }

        public static long GetInt64(this OdbcDataReader reader, int i, long defaultValue)
        {
            return reader.IsDBNull(i) ? defaultValue : reader.GetInt64(i);
        }

        public static bool GetBoolean(this OdbcDataReader reader, int i, bool defaultValue)
        {
            return reader.IsDBNull(i) ? defaultValue : reader.GetBoolean(i);
        }

        public static DateTime GetDateTime(this OdbcDataReader reader, int i, DateTime defaultValue)
        {
            return reader.IsDBNull(i) ? defaultValue : reader.GetDateTime(i);
        }

        public static double GetDouble(this OdbcDataReader reader, int i, double defaultValue)
        {
            return reader.IsDBNull(i) ? defaultValue : reader.GetDouble(i);
        }

        public static void AddParameter(this OdbcCommand cmd, string paramName, DbType paramType, ParameterDirection paramDirection, int paramSize, object paramValue)
        {
            OdbcParameter param = cmd.CreateParameter();
            param.ParameterName = paramName;
            param.DbType = paramType;
            param.Direction = paramDirection;
            param.Size = paramSize;
            param.Value = paramValue;
            cmd.Parameters.Add(param);
        }

        #endregion
                
        #region Assembly Extensions

        // assembly = Assembly.GetEntryAssembly();
        // assembly = Assembly.GetExecutingAssembly();
        // assembly = Assembly.GetCallingAssembly();

        // Application.CompanyName == Assembly.GetCompany()
        // Application.ProductName == Assembly.GetProduct()
        // Application.ProductVersion == Assembly.GetFileVersion()
        // Application.StartupPath == Assembly.GetExecutionPath()

        public static string GetTitle(this Assembly assembly)
        {
            object[] attribs;
            attribs = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            return (attribs.Length > 0) ? ((AssemblyTitleAttribute)attribs[0]).Title : "";
        }

        public static string GetDescription(this Assembly assembly)
        {
            object[] attribs;
            attribs = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            return (attribs.Length > 0) ? ((AssemblyDescriptionAttribute)attribs[0]).Description : "";
        }

        public static string GetCompany(this Assembly assembly)
        {
            // Application.CompanyName
            object[] attribs;
            attribs = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            return (attribs.Length > 0) ? ((AssemblyCompanyAttribute)attribs[0]).Company : "";
        }

        public static string GetProduct(this Assembly assembly)
        {
            // Application.ProductName
            object[] attribs;
            attribs = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            return (attribs.Length > 0) ? ((AssemblyProductAttribute)attribs[0]).Product : "";
        }

        public static string GetCopyright(this Assembly assembly)
        {
            object[] attribs;
            attribs = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            return (attribs.Length > 0) ? ((AssemblyCopyrightAttribute)attribs[0]).Copyright : "";
        }

        public static string GetTrademark(this Assembly assembly)
        {
            object[] attribs;
            attribs = assembly.GetCustomAttributes(typeof(AssemblyTrademarkAttribute), false);
            return (attribs.Length > 0) ? ((AssemblyTrademarkAttribute)attribs[0]).Trademark : "";
        }

        public static string GetAssemblyVersion(this Assembly assembly)
        {
            return assembly.GetName().Version.ToString();
        }

        public static string GetFileVersion(this Assembly assembly)
        {
            // Application.ProductVersion
            object[] attribs;
            attribs = assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
            return (attribs.Length > 0) ? ((AssemblyFileVersionAttribute)attribs[0]).Version : "";
        }

        public static string GetAssemblyName(this Assembly assembly)
        {
            return assembly.GetName().Name;
        }

        public static string GetExecutionPath(this Assembly assembly)
        {
            return Directory.GetParent(assembly.Location).ToString();
        }

        public static string GetResourceContent(this Assembly assembly, string resourceName)
        {
            string[] resources = assembly.GetManifestResourceNames();
            string content = "";
            try
            {
                foreach (string resource in resources)
                {
                    if (resource.Contains(resourceName))
                    {
                        using (Stream stream = assembly.GetManifestResourceStream(resource))
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                content = reader.ReadToEnd();
                                reader.Close();
                            }
                            stream.Close();
                        }
                        return content;
                    }
                }
                throw new Exception("Resource not found.");
            }
            catch (Exception x)
            {
                throw new Exception("Unable to retrieve resource contents.", x);
            }
        }

        #endregion

        #region Form Extensions

        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            public UInt32 cbSize;         // The size of the structure in bytes.
            public IntPtr hwnd;         // A Handle to the Window to be Flashed. The window can be either opened or minimized.
            public UInt32 dwFlags;        // The Flash Status.
            public UInt32 uCount;         // The number of times to Flash the window.
            public UInt32 dwTimeout;      // The rate at which the Window is to be flashed, in milliseconds. If Zero, the function uses the default cursor blink rate.
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        private const UInt32 FLASHW_STOP = 0;           // Stop flashing. The system restores the window to its original state.
        private const UInt32 FLASHW_CAPTION = 1;        // Flash the window caption.        
        private const UInt32 FLASHW_TRAY = 2;           // Flash the taskbar button.        
        private const UInt32 FLASHW_ALL = 3;            // Flash both the window caption and taskbar button.
        private const UInt32 FLASHW_TIMER = 4;          // Flash continuously, until the FLASHW_STOP flag is set.
        private const UInt32 FLASHW_TIMERNOFG = 12;     // Flash continuously until the window comes to the foreground.

        private static FLASHWINFO CreateFLASHWINFO(IntPtr handle, UInt32 flags, UInt32 count, UInt32 timeout)
        {
            FLASHWINFO fi = new FLASHWINFO();
            fi.cbSize = (UInt32)Marshal.SizeOf(fi);
            fi.hwnd = handle;
            fi.dwFlags = flags;
            fi.uCount = count;
            fi.dwTimeout = timeout;
            return fi;
        }

        public static bool FlashWindow(this Form form)
        {
            FLASHWINFO fi = CreateFLASHWINFO(form.Handle, FLASHW_ALL + FLASHW_TIMERNOFG, UInt32.MaxValue, 0);
            return FlashWindowEx(ref fi);
        }

        public static bool FlashWindow(this Form form, int count)
        {
            FLASHWINFO fi = CreateFLASHWINFO(form.Handle, FLASHW_ALL, (UInt32)count, 0);
            return FlashWindowEx(ref fi);
        }

        public static bool FlashWindow(this Form form, bool state)
        {
            FLASHWINFO fi = CreateFLASHWINFO(form.Handle, state ? FLASHW_ALL : FLASHW_STOP, UInt32.MaxValue, 0);
            return FlashWindowEx(ref fi);
        }

        #endregion

        #region Control Extensions

        delegate void SetTextDelegate(Control control, string text);
        delegate void SetTagDelegate(Control control, object tagValue);

        public static void SetText(this Control control, string text)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetTextDelegate(SetText), new object[] { control, text });
            else
                control.Text = text;
        }

        public static void SetTag(this Control control, object tag)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetTagDelegate(SetTag), new object[] { control, tag });
            else
                control.Tag = tag;
        }

        #endregion

        #region Registry Extensions

        public static bool KeyExists(this RegistryKey key, string subKey)
        {
            RegistryKey test = null;
            try
            {
                test = key.OpenSubKey(subKey);
                return (test != null);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (test != null)
                {
                    test.Close();
                }
            }
        }

        public static bool ValueExists(this RegistryKey key, string name)
        {
            try
            {
                return key.GetValue(name) != null;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private static bool IsString(this RegistryKey key, string name)
        {
            try
            {
                return key.GetValueKind(name) == RegistryValueKind.String;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsInt(this RegistryKey key, string name)
        {
            try
            {
                return key.GetValueKind(name) == RegistryValueKind.DWord;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsLong(this RegistryKey key, string name)
        {
            try
            {
                return key.GetValueKind(name) == RegistryValueKind.QWord;
            }
            catch
            {
                return false;
            }
        }


        public static string GetString(this RegistryKey key, string name, string defaultValue)
        {
            try
            {
                object value = key.GetValue(name);
                if (value == null)
                    return defaultValue;
                if (key.GetValueKind(name) == RegistryValueKind.String)
                    return (string)value;
                else
                    return defaultValue;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public static string GetString(this RegistryKey key, string name)
        {
            try
            {
                object value = key.GetValue(name);
                if (value == null)
                    return "";
                if (key.GetValueKind(name) == RegistryValueKind.String)
                    return (string)value;
                else
                    return "";
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public static int GetInt(this RegistryKey key, string name, int defaultValue)
        {
            try
            {
                object value = key.GetValue(name);
                if (value == null)
                    return defaultValue;
                if (key.GetValueKind(name) == RegistryValueKind.DWord)
                    return (int)value;
                else
                    return defaultValue;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public static int GetInt(this RegistryKey key, string name)
        {
            try
            {
                object value = key.GetValue(name);
                if (value == null)
                    return 0;
                if (key.GetValueKind(name) == RegistryValueKind.DWord)
                    return (int)value;
                else
                    return 0;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public static long GetLong(this RegistryKey key, string name, long defaultValue)
        {
            try
            {
                object value = key.GetValue(name);
                if (value == null)
                    return defaultValue;
                if (key.GetValueKind(name) == RegistryValueKind.QWord)
                    return (long)value;
                else
                    return defaultValue;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public static long GetLong(this RegistryKey key, string name)
        {
            try
            {
                object value = key.GetValue(name);
                if (value == null)
                    return 0;
                if (key.GetValueKind(name) == RegistryValueKind.QWord)
                    return (long)value;
                else
                    return 0;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public static string[] GetMultiString(this RegistryKey key, string name, string[] defaultValue)
        {
            try
            {
                object value = key.GetValue(name);
                if (value == null)
                    return defaultValue;
                if (key.GetValueKind(name) == RegistryValueKind.MultiString)
                    return (string[])value;
                else
                    return defaultValue;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public static string[] GetMultiString(this RegistryKey key, string name)
        {
            try
            {
                object value = key.GetValue(name);
                if (value == null)
                    return null;
                if (key.GetValueKind(name) == RegistryValueKind.MultiString)
                    return (string[])value;
                else
                    return null;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public static void SaveString(this RegistryKey key, string name, string value)
        {
            try
            {
                key.SetValue(name, value, RegistryValueKind.String);
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public static void SaveInt(this RegistryKey key, string name, int value)
        {
            try
            {
                key.SetValue(name, value, RegistryValueKind.DWord);
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public static void SaveMultiString(this RegistryKey key, string name, string[] values)
        {
            try
            {
                key.SetValue(name, values, RegistryValueKind.MultiString);
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public static void SaveLong(this RegistryKey key, string name, long value)
        {
            try
            {
                key.SetValue(name, value, RegistryValueKind.QWord);
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        #endregion

    }
}
