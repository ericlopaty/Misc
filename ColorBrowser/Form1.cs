using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace ColorBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Type type = Type.GetType("System.Drawing.Color");
            MemberInfo[] members = type.GetMembers();
            foreach (MemberInfo member in members)
            {
                if (member.MemberType.ToString() == "Property")
                    listBox1.Items.Add(member);
            }
        }
    }
}





