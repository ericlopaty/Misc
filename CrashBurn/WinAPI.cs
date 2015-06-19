using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Xml;
using System.IO;
using Microsoft.Win32;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.Management;

namespace CommonLib
{
    /// <summary>
    /// A collection of useful Windows API calls not included in the
    /// .NET Framework.  Most useful as a guide for using p-invoke.
    /// </summary>
    class WinAPI
    {
        //Public Declare Function GetWindowThreadProcessId Lib "user32" (ByVal hwnd As Integer, ByRef lpdwProcessId As Integer) As Integer

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetCurrentProcessId();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint GetWindowModuleFileName(IntPtr hwnd, StringBuilder lpszFileName, int cchFileNameMax);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            public uint cbSize;     // The size of the structure in bytes.            
            public IntPtr hwnd;     // A Handle to the Window to be Flashed. The window can be either opened or minimized.            
            public uint dwFlags;    // The Flash Status.            
            public uint uCount;     // The number of times to Flash the window.            
            public uint dwTimeout;  // The rate at which the Window is to be flashed, in milliseconds. If Zero, the function uses the default cursor blink rate.
        }

        [DllImport("kernel32")]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern int Beep(int frequency, int duration);

        /// <summary>
        /// FlashWindow parameters.  
        /// FLASHW_ALL is equivalent to FLASHW_CAPTION + FLASHW_TRAY
        /// </summary>
        private const uint FLASHW_STOP = 0;          // Stop flashing. The system restores the window to its original state.
        private const uint FLASHW_CAPTION = 1;       // Flash the window caption.        
        private const uint FLASHW_TRAY = 2;          // Flash the taskbar button.        
        private const uint FLASHW_ALL = 3;           // Flash both the window caption and taskbar button.
        private const uint FLASHW_TIMER = 4;         // Flash continuously, until the FLASHW_STOP flag is set.
        private const uint FLASHW_TIMERNOFG = 12;    // Flash continuously until the window comes to the foreground.

        /// <summary>
        /// Flash until window receives focus.
        /// </summary>
        /// <param name="form">"Me" from VB.NET, "this" from C#</param>
        /// <returns></returns>
        public static bool FlashWindow(System.Windows.Forms.Form form)
        {
            FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL | FLASHW_TIMERNOFG, uint.MaxValue, 0);
            return FlashWindowEx(ref fi);
        }

        /// <summary>
        /// Flash a specified number of times.
        /// </summary>
        /// <param name="form">"Me" from VB.NET, "this" from C#</param>
        /// <param name="count"># of times to flash.</param>
        /// <returns></returns>
        public static bool FlashWindow(System.Windows.Forms.Form form, uint count)
        {
            FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, count, 0);
            return FlashWindowEx(ref fi);
        }

        /// <summary>
        /// Start/Stop flashing.
        /// </summary>
        /// <param name="form">"Me" from VB.NET, "this" from C#</param>
        /// <returns></returns>
        public static bool FlashWindow(System.Windows.Forms.Form form, bool state)
        {
            FLASHWINFO fi =
                Create_FLASHWINFO(form.Handle,
                (state ? FLASHW_ALL : FLASHW_STOP), uint.MaxValue, 0);
            return FlashWindowEx(ref fi);
        }

        /// <summary>
        /// Creates FLASHWINFO structure.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="flags"></param>
        /// <param name="count"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        private static FLASHWINFO Create_FLASHWINFO(IntPtr handle, uint flags, uint count, uint timeout)
        {
            FLASHWINFO fi = new FLASHWINFO();
            fi.cbSize = Convert.ToUInt32(Marshal.SizeOf(fi));
            fi.hwnd = handle;
            fi.dwFlags = flags;
            fi.uCount = count;
            fi.dwTimeout = timeout;
            return fi;
        }

        public enum BeepType : long
        {
            OK = 0x0,
            Hand = 0x10,
            Question = 0x20,
            Exclamation = 0x30,
            Asterisk = 0x40,
            Simple = 0xFFFFFFFF
        };

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MessageBeep(BeepType beepType);

        //<StructLayout(LayoutKind.Sequential)> _
        //Public Structure MENUITEMINFO
        //    Dim cbSize As Integer
        //    Dim fMask As Integer
        //    Dim fType As Integer
        //    Dim fState As Integer
        //    Dim wID As Integer
        //    Dim hSubMenu As Integer
        //    Dim hbmpChecked As Integer
        //    Dim hbmpUnchecked As Integer
        //    Dim dwItemData As Integer
        //    Dim dwTypeData As String
        //    Dim cch As Integer
        //    Private Shared Sub InitStruct(ByRef result As MENUITEMINFO, ByVal init As Boolean)
        //        If init Then
        //            result.dwTypeData = String.Empty
        //        End If
        //    End Sub
        //    Public Shared Function CreateInstance() As MENUITEMINFO
        //        Dim result As New MENUITEMINFO
        //        InitStruct(result, True)
        //        Return result
        //    End Function
        //    Public Function Clone() As MENUITEMINFO
        //        Dim result As MENUITEMINFO = Me
        //        InitStruct(result, False)
        //        Return result
        //    End Function
        //End Structure

        //Public Function WinDisableClose(ByRef frm As Form) As Boolean
        //    Dim oErr As FWErrorHandler.FWError = FWErrorHandler.FWError.CreateInstance()
        //    Dim lngRet As Integer
        //    Dim MII As MENUITEMINFO = MENUITEMINFO.CreateInstance()
        //    Dim hMenu As Integer
        //    Try
        //        hMenu = GetSystemMenu(frm.Handle.ToInt32(), 0)
        //        'UPGRADE_WARNING: (2081) Len has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
        //        MII.cbSize = Marshal.SizeOf(MII)
        //        MII.dwTypeData = New String(Strings.Chr(0), 80)
        //        MII.cch = MII.dwTypeData.Length
        //        MII.fMask = MIIM_STATE
        //        MII.wID = SC_CLOSE
        //        lngRet = GetMenuItemInfo(hMenu, MII.wID, False, MII)
        //        lngRet = SetId(hMenu, MII, SwapID)
        //        If lngRet <> 0 Then
        //            MII.fState = (MII.fState Or MFS_GRAYED)
        //            MII.fMask = MIIM_STATE
        //            lngRet = SetMenuItemInfo(hMenu, MII.wID, False, MII)
        //            If lngRet = 0 Then
        //                lngRet = SetId(hMenu, MII, ResetID)
        //            End If
        //            '                                      SendMessage(Of T As Structure)(ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByRef lParam As T) As Integer
        //            lngRet = PIWDPInvoke.SafeNative.user32.SendMessage(frm.Handle.ToInt32(), WM_NCACTIVATE, CType(True, Integer), 0)
        //        End If
        //    Catch e As System.Exception
        //        If Information.Err().Number <> 0 Then oErr = FWErrorHandler.CreateFWError(Information.Err().Number, e.Source, e.Message)
        //    Finally
        //        If oErr.Number <> 0 Then FWErrorHandler.RaiseFWError(oErr, FWErrorHandler.ComponentName("WinDisableClose", "FWNBCommon.modXMLRoutines"))
        //    End Try
        //End Function

        //Public Function WinEnableClose(ByRef frm As Form) As Boolean
        //    Dim oErr As FWErrorHandler.FWError = FWErrorHandler.FWError.CreateInstance()
        //    Dim lngRet As Integer
        //    Dim MII As MENUITEMINFO = MENUITEMINFO.CreateInstance()
        //    Dim hMenu As Integer
        //    Try
        //        hMenu = PIWDPInvoke.SafeNative.user32.GetSystemMenu(frm.Handle.ToInt32(), 0)
        //        'UPGRADE_WARNING: (2081) Len has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
        //        MII.cbSize = Marshal.SizeOf(MII)
        //        MII.dwTypeData = New String(Strings.Chr(0), 80)
        //        MII.cch = MII.dwTypeData.Length
        //        MII.fMask = MIIM_STATE
        //        MII.wID = xSC_CLOSE
        //        MII.fState = MFS_GRAYED
        //        lngRet = SetId(hMenu, MII, SwapID)
        //        If lngRet <> 0 Then
        //            MII.fState -= MFS_GRAYED
        //            MII.fMask = MIIM_STATE
        //            MII.wID = SC_CLOSE
        //            lngRet = SetMenuItemInfo(hMenu, MII.wID, False, MII)
        //            If lngRet = 0 Then
        //                lngRet = SetId(hMenu, MII, ResetID)
        //            End If
        //            lngRet = PIWDPInvoke.SafeNative.user32.SendMessage(frm.Handle.ToInt32(), WM_NCACTIVATE, CType(True, Integer), 0)
        //        End If
        //    Catch e As System.Exception
        //        If Information.Err().Number <> 0 Then oErr = FWErrorHandler.CreateFWError(Information.Err().Number, e.Source, e.Message)
        //    Finally
        //        If oErr.Number <> 0 Then FWErrorHandler.RaiseFWError(oErr, FWErrorHandler.ComponentName("WinEnableClose", "FWNBCommon.modXMLRoutines"))
        //    End Try
        //End Function

        //Private Function SetId(ByRef hMenu As Integer, ByRef MII As MENUITEMINFO, ByRef Action As Integer) As Integer
        //    Dim result As Integer = 0
        //    Dim oErr As FWErrorHandler.FWError = FWErrorHandler.FWError.CreateInstance()
        //    Dim MenuID, blnRet As Integer
        //    Try
        //        MenuID = MII.wID
        //        If MII.fState = (MII.fState Or MFS_GRAYED) Then
        //            If Action = SwapID Then
        //                MII.wID = SC_CLOSE
        //            Else
        //                MII.wID = xSC_CLOSE
        //            End If
        //        Else
        //            If Action = SwapID Then
        //                MII.wID = xSC_CLOSE
        //            Else
        //                MII.wID = SC_CLOSE
        //            End If
        //        End If
        //        MII.fMask = MIIM_ID
        //        blnRet = SetMenuItemInfo(hMenu, MenuID, False, MII)
        //        If blnRet = 0 Then
        //            MII.wID = MenuID
        //        End If
        //    Catch e As System.Exception
        //        If Information.Err().Number <> 0 Then oErr = FWErrorHandler.CreateFWError(Information.Err().Number, e.Source, e.Message)
        //    Finally
        //        result = blnRet
        //        If oErr.Number <> 0 Then FWErrorHandler.RaiseFWError(oErr, FWErrorHandler.ComponentName("SetId", "FWNBCommon.modXMLRoutines"))
        //    End Try
        //    Return result
        //End Function

        //Public Function WinDisableMinimize(ByRef frm As Form) As Boolean
        //    Dim oErr As FWErrorHandler.FWError = FWErrorHandler.FWError.CreateInstance()
        //    Dim lngRet As Integer
        //    Dim MII As MENUITEMINFO = MENUITEMINFO.CreateInstance()
        //    Dim hMenu As Integer
        //    Try
        //        hMenu = PIWDPInvoke.SafeNative.user32.GetSystemMenu(frm.Handle.ToInt32(), 0)
        //        'UPGRADE_WARNING: (2081) Len has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
        //        MII.cbSize = Marshal.SizeOf(MII)
        //        MII.dwTypeData = New String(Strings.Chr(0), 80)
        //        MII.cch = MII.dwTypeData.Length
        //        MII.fMask = MIIM_STATE
        //        MII.wID = SC_MINIMIZE
        //        lngRet = GetMenuItemInfo(hMenu, MII.wID, False, MII)
        //        lngRet = SetId(hMenu, MII, SwapID)
        //        If lngRet <> 0 Then
        //            MII.fState = (MII.fState Or MFS_GRAYED)
        //            MII.fMask = MIIM_STATE
        //            lngRet = SetMenuItemInfo(hMenu, MII.wID, False, MII)
        //            If lngRet = 0 Then
        //                lngRet = SetId(hMenu, MII, ResetID)
        //            End If
        //            'lngRet = SendMessage(frm.hwnd, WM_NCACTIVATE, True, 0)
        //        End If
        //    Catch e As System.Exception
        //        If Information.Err().Number <> 0 Then oErr = FWErrorHandler.CreateFWError(Information.Err().Number, e.Source, e.Message)
        //    Finally
        //        If oErr.Number <> 0 Then FWErrorHandler.RaiseFWError(oErr, FWErrorHandler.ComponentName("WinDisableMinimize", "FWNBCommon.modXMLRoutines"))
        //    End Try
        //End Function

        public static string GetText(IntPtr hWnd)
        {
            // Allocate correct string length first
            int length = GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        public static string GetModuleName(IntPtr hWnd)
        {
            StringBuilder fileName = new StringBuilder(2000);
            int capacity = 2000;
            GetWindowModuleFileName(hWnd, fileName, capacity);
            return fileName.ToString();
        }

        private string GetPort(string deviceName)
        {
            string portName = string.Empty;
            try
            {
                string queryString = "SELECT Name, PortName FROM Win32_Printer WHERE Name=\"" + deviceName + "\"";
                ManagementObjectSearcher query = new ManagementObjectSearcher(queryString);
                ManagementObjectCollection queryCollection = query.Get();
                foreach (ManagementObject mo in queryCollection)
                {
                    if (!string.IsNullOrEmpty(portName))
                        portName += ", ";

                    portName += mo["PortName"] as string;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return portName;
        }

        public static string[] GetPrinters()
        {
            try
            {
                List<string> printers = new List<string>();
                string queryString = "SELECT Name FROM Win32_Printer";
                using (ManagementObjectSearcher query = new ManagementObjectSearcher(queryString))
                {
                    using (ManagementObjectCollection results = query.Get())
                    {
                        foreach (ManagementObject mo in results)
                        {
                            printers.Add(mo["Name"] as string);
                        }
                    }
                }
                return printers.ToArray();
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public static void GetPrinterInfo(string printerName, out string printerDriver, out string printerPort)
        {
            try
            {
                printerDriver = "";
                printerPort = "";
                string queryString = string.Format("SELECT Name, DriverName, PortName FROM Win32_Printer");
                using (ManagementObjectSearcher query = new ManagementObjectSearcher(queryString))
                {
                    using (ManagementObjectCollection results = query.Get())
                    {
                        foreach (ManagementObject mo in results)
                        {
                            if (string.Compare(mo["Name"] as string, printerName, true) == 0)
                            {
                                printerDriver = mo["DriverName"] as string;
                                printerPort = mo["PortName"] as string;
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}


