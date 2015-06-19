using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsAPI
{
    public static class WinAPI
    {
        //---------------------------------------------------------------------

        [DllImport("kernel32")]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern int Beep(int frequency, int duration);

        //---------------------------------------------------------------------

        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentProcessId();

        //---------------------------------------------------------------------

        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            public UInt32 cbSize;         // The size of the structure in bytes.
            public IntPtr hwnd;         // A Handle to the Window to be Flashed. The window can be either opened or minimized.
            public UInt32 dwFlags;        // The Flash Status.
            public UInt32 uCount;         // The number of times to Flash the window.
            public UInt32 dwTimeout;      // The rate at which the Window is to be flashed, in milliseconds. If Zero, the function uses the default cursor blink rate.
        }

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

        private const UInt32 FLASHW_STOP = 0;           // Stop flashing. The system restores the window to its original state.
        private const UInt32 FLASHW_CAPTION = 1;        // Flash the window caption.        
        private const UInt32 FLASHW_TRAY = 2;           // Flash the taskbar button.        
        private const UInt32 FLASHW_ALL = 3;            // Flash both the window caption and taskbar button.
        private const UInt32 FLASHW_TIMER = 4;          // Flash continuously, until the FLASHW_STOP flag is set.
        private const UInt32 FLASHW_TIMERNOFG = 12;     // Flash continuously until the window comes to the foreground.

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        public static bool FlashWindow(IntPtr hwnd)
        {
            FLASHWINFO fi = CreateFLASHWINFO(hwnd, FLASHW_ALL + FLASHW_TIMERNOFG, UInt32.MaxValue, 0);
            return FlashWindowEx(ref fi);
        }

        public static bool FlashWindow(IntPtr hwnd, int count)
        {
            FLASHWINFO fi = CreateFLASHWINFO(hwnd, FLASHW_ALL, (UInt32)count, 0);
            return FlashWindowEx(ref fi);
        }

        public static bool FlashWindow(IntPtr hwnd, bool state)
        {
            FLASHWINFO fi = CreateFLASHWINFO(hwnd, state ? FLASHW_ALL : FLASHW_STOP, UInt32.MaxValue, 0);
            return FlashWindowEx(ref fi);
        }

        //---------------------------------------------------------------------

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, UInt32 uFlags);

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        static readonly UInt32 SWP_NOSIZE = 0x0001;
        static readonly UInt32 SWP_NOMOVE = 0x0002;
        static readonly UInt32 SWP_ASYNCWINDOWPOS = 0x4000;            

        public static bool SetFocus(IntPtr hwnd)
        {
            return SetWindowPos(hwnd, (IntPtr)HWND_TOP, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_ASYNCWINDOWPOS);
        }
    }
}

//Option Strict Off
//Option Explicit On
//Imports Microsoft.VisualBasic
//Imports System
//Imports System.Windows.Forms
//Imports System.IO
//Imports System.Runtime.InteropServices
//Imports System.Text


