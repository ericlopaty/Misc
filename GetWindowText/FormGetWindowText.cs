using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GetWindowText
{
    public partial class FormGetWindowText : Form
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        private int handle = 0;

        public FormGetWindowText()
        {
            InitializeComponent();
            btnGetWindowText.Enabled = false;
        }

        private void btnGetWindowText_Click(object sender, EventArgs e)
        {
            tbWindowText.Text = GetText(new IntPtr(handle));
        }

        public static string GetText(IntPtr hWnd)
        {
            int length = GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        private void tbHandle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                handle = int.Parse(tbHandle.Text);
                if (handle > 0)
                    btnGetWindowText.Enabled = true;
            }
            catch
            {
                handle = 0;
                btnGetWindowText.Enabled = false;
            }
        }

        private void tbHandle_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
