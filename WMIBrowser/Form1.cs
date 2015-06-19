using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace WMIBrowser
{
    public partial class Form1 : Form
    {
        private int count;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            count = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Initialize class counter and clear list view.
            count = 0;
            lbClassList.Items.Clear();

            if (tbNameSpaceValue.Text.Equals(""))
            {
                this.AddNamespacesToList();
            }
            else
            {
                this.AddClassesToList();
            }
        }

        private void AddNamespacesToList()
        {
            try
            {
                // Enumerate all WMI instances of __namespace WMI class.
                ManagementClass nsClass = new ManagementClass(
                   new ManagementScope("root"),
                   new ManagementPath("__namespace"),
                   null);
                foreach (ManagementObject ns in nsClass.GetInstances())
                {
                    lbClassList.Items.Add(ns["Name"].ToString());
                    count++;
                }
                lblStatusValue.Text = count + " namespaces found.";
            }
            catch (Exception e)
            {
                lblStatusValue.Text = e.Message;
            }
        }

        private void AddClassesToList()
        {
            try
            {
                // Perform WMI object query on selected namespace.
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                    new ManagementScope(tbNameSpaceValue.Text),
                   new WqlObjectQuery("select * from meta_class"),
                   null);
                foreach (ManagementClass wmiClass in searcher.Get())
                {
                    lbClassList.Items.Add(wmiClass["__CLASS"].ToString());
                    count++;
                }
                lblStatusValue.Text = count + " classes found.";
            }
            catch (Exception ex)
            {
                lblStatusValue.Text = ex.Message;
            }
        }
    }
}

/*
   public class WebForm1 : System.Web.UI.Page {
      protected System.Web.UI.WebControls.Label Label1;
      protected System.Web.UI.WebControls.Button searchButton;
      protected System.Web.UI.WebControls.Label Label3;
      protected System.Web.UI.WebControls.Label Label2;
   
      private void searchButton_Click(object sender, System.EventArgs e) {
      }

   }
}
*/