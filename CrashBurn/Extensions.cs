using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Runtime.CompilerServices;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace CommonLib
{
    public static class Extensions
    {
        #region String Extensions

        /// <summary>
        /// Compares two string without regard to case.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
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

        #region Integer Extensions

        public static string ToRoman(this int n)
        {
            object[,] groups = new object[,] {
                {1000,"M"},{900,"CM"},{500,"D"},{400,"CD"},{100,"C"},{90, "XC"},{50, "L"},
                {40, "XL"},{10, "X"},{9, "IX"},{5, "V"},{4, "IV"},{1, "I"}};
            StringBuilder roman = new StringBuilder();
            while (n > 0)
            {
                for (int j = 0; j < groups.Length; j++)
                {
                    if ((int)groups[j, 0] <= n)
                    {
                        roman.Append((string)groups[j, 1]);
                        n -= (int)groups[j, 0];
                        break;
                    }
                }
            }
            return roman.ToString();
        }

        static string ToBinary(this int n, int width)
        {
            StringBuilder s = new StringBuilder();
            while (n > 0)
            {
                s.Insert(0, string.Format("{0}", n % 2));
                n /= 2;
            }
            return s.Length < width ? s.ToString().PadLeft(width, '0') : s.ToString();
        }

        #endregion

        #region Database Extensions

        /// <summary>
        /// Initializes and opens a SQLConnection.
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="dataSource"></param>
        /// <param name="initialCatalog"></param>
        public static void Open(this SqlConnection cn, string dataSource, string initialCatalog)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = dataSource;
                builder.InitialCatalog = initialCatalog;
                builder.IntegratedSecurity = true;
                cn.ConnectionString = builder.ConnectionString;
                cn.Open();
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        /// <summary>
        /// Initializes and opens a SQLConnection.
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="dataSource"></param>
        /// <param name="initialCatalog"></param>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        public static void Open(this SqlConnection cn, string dataSource, string initialCatalog, string userID, string password)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = dataSource;
                builder.InitialCatalog = initialCatalog;
                builder.IntegratedSecurity = false;
                builder.UserID = userID;
                builder.Password = password;
                cn.ConnectionString = builder.ConnectionString;
                cn.Open();
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        /// <summary>
        /// Initializes and executes a query on a SQLConnection.
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandBehavior"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Initializes and executes a query on a SQLConnection.
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Initializes and executes a query on a SQLConnection.
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a string from a SQLDataReader with a default value in case of null.
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="i"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetString(this SqlDataReader rdr, int i, string defaultValue)
        {
            return rdr.IsDBNull(i) ? defaultValue : rdr.GetString(i);
        }

        /// <summary>
        /// Returns an int from a SQLDataReader with a default value in case of null.
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="i"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetInt32(this SqlDataReader rdr, int i, int defaultValue)
        {
            return rdr.IsDBNull(i) ? defaultValue : rdr.GetInt32(i);
        }

        /// <summary>
        /// Returns a long from a SQLDataReader with a default value in case of null.
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="i"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static long GetInt64(this SqlDataReader rdr, int i, long defaultValue)
        {
            return rdr.IsDBNull(i) ? defaultValue : rdr.GetInt64(i);
        }

        /// <summary>
        /// Returns a bool from a SQLDataReader with a default value in case of null.
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="i"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool GetBoolean(this SqlDataReader rdr, int i, bool defaultValue)
        {
            return rdr.IsDBNull(i) ? defaultValue : rdr.GetBoolean(i);
        }

        /// <summary>
        /// Returns a DateTime from a SQLDataReader with a default value in case of null.
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="i"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(this SqlDataReader rdr, int i, DateTime defaultValue)
        {
            return rdr.IsDBNull(i) ? defaultValue : rdr.GetDateTime(i);
        }

        /// <summary>
        /// Returns a double from SQLDataReader with a default value in case of null.
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="i"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double GetDouble(this SqlDataReader rdr, int i, double defaultValue)
        {
            return rdr.IsDBNull(i) ? defaultValue : rdr.GetDouble(i);
        }

        /// <summary>
        /// Initializes and adds a parameter to s SQLCommand.
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="paramName"></param>
        /// <param name="paramType"></param>
        /// <param name="paramDirection"></param>
        /// <param name="paramSize"></param>
        /// <param name="paramValue"></param>
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

        /// <summary>
        /// Flash window caption until focus is received.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static bool FlashWindow(this Form form)
        {
            FLASHWINFO fi = CreateFLASHWINFO(form.Handle, FLASHW_ALL + FLASHW_TIMERNOFG, UInt32.MaxValue, 0);
            return FlashWindowEx(ref fi);
        }

        /// <summary>
        /// Flash window caption a specified number of times.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool FlashWindow(this Form form, int count)
        {
            FLASHWINFO fi = CreateFLASHWINFO(form.Handle, FLASHW_ALL, (UInt32)count, 0);
            return FlashWindowEx(ref fi);
        }

        /// <summary>
        /// Turn on/off window caption flashing.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static bool FlashWindow(this Form form, bool state)
        {
            FLASHWINFO fi = CreateFLASHWINFO(form.Handle, state ? FLASHW_ALL : FLASHW_STOP, UInt32.MaxValue, 0);
            return FlashWindowEx(ref fi);
        }

        #endregion

        #region Control Extensions

        delegate void SetTextDelegate(Control control, string text);
        delegate void SetTagDelegate(Control control, object tagValue);

        /// <summary>
        /// Cross-threaded method to set Text property.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="text"></param>
        public static void SetText(this Control control, string text)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetTextDelegate(SetText), new object[] { control, text });
            else
                control.Text = text;
        }

        /// <summary>
        /// Cross-threaded method to set Tag property.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="tag"></param>
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
                    //test.Dispose(); 
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
