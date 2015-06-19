using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Manifest
{
    public partial class FormMain : Form
    {
        private string reportFileName;
        private List<string> report;

        public FormMain()
        {
            InitializeComponent();
        }

        public static string GetAssemblyVersion(Assembly assembly)
        {
            return assembly.GetName().Version.ToString();
        }

        public static string GetFileVersion(Assembly assembly)
        {
            // Application.ProductVersion
            object[] attribs;
            attribs = assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
            return (attribs.Length > 0) ? ((AssemblyFileVersionAttribute)attribs[0]).Version : "";
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuScan_Click(object sender, EventArgs e)
        {
            try
            {
                List<ListViewItem> items = null;
                string defaultPath = "", newPath = "";
                DirectoryInfo dir = null;
                ListViewItem item = null;
                string fileName = "", company = "", product = "", productVersion = "", fileVersion = "", timeStamp = "";
                int widthFileName = 9, widthCompany = 7, widthProduct = 7, widthProductVersion = 15, widthFileVersion = 12, widthTimeStamp = 22;
                bool addFile = false;
                string template = "";

                items = new List<ListViewItem>();
                lvFiles.Items.Clear();
                defaultPath = Properties.Settings.Default.DefaultFolder;
                if (Directory.Exists(defaultPath))
                    folderBrowser.SelectedPath = defaultPath;
                if (folderBrowser.ShowDialog() == DialogResult.Cancel)
                    return;
                this.Text = "Manifest: " + folderBrowser.SelectedPath;
                reportFileName = Path.Combine(folderBrowser.SelectedPath, "Manifest.rpt");
                report = new List<string>();
                newPath = folderBrowser.SelectedPath;
                Properties.Settings.Default.DefaultFolder = newPath;
                Properties.Settings.Default.Save();
                dir = new DirectoryInfo(newPath);
                foreach (FileInfo file in dir.GetFiles())
                {
                    addFile = false;
                    fileName = file.Name;
                    widthFileName = Math.Max(widthFileName, fileName.Length);
                    timeStamp = file.LastWriteTime.ToString("MM/dd/yyyy hh:mm:ss tt");
                    company = "";
                    product = "";
                    productVersion = "";
                    fileVersion = "";
                    labelStatus.Text = file.Name;
                    Application.DoEvents();
                    string extension = file.Extension.ToLower();
                    try
                    {
                        if (extension == ".dll" || extension == ".exe")
                        {
                            addFile = true;
                            Assembly assembly = Assembly.LoadFile(file.FullName);
                            company = assembly.GetCompany();
                            widthCompany = Math.Max(widthCompany, company.Length);
                            product = assembly.GetProduct();
                            widthProduct = Math.Max(widthProduct, product.Length);
                            productVersion = assembly.GetAssemblyVersion();
                            widthProductVersion = Math.Max(widthProductVersion, productVersion.Length);
                            fileVersion = assembly.GetFileVersion();
                            widthFileVersion = Math.Max(widthFileVersion, fileVersion.Length);
                        }
                        else if (extension == ".bat" || extension == ".cmd")
                        {
                            addFile = true;
                        }
                    }
                    catch
                    {
                    }
                    if (addFile)
                    {
                        item = new ListViewItem(new string[] { fileName, company, product, productVersion, fileVersion, timeStamp });
                        items.Add(item);
                    }
                }
                lvFiles.Items.AddRange(items.ToArray());
                template = "!0,-{0}~ !1,-{1}~ !2,-{2}~ !3,-{3}~ !4,-{4}~ !5,-{5}~";
                template = string.Format(template, widthFileName, widthCompany, widthProduct, widthProductVersion, widthFileVersion, widthTimeStamp);
                template = template.Replace('!', '{');
                template = template.Replace('~', '}');
                report.Add(string.Format(template, "File Name", "Company", "Product", "Product Version", "File Version", "Time Stamp"));
                report.Add(string.Format(template,"".PadRight(widthFileName,'-'),"".PadRight(widthCompany,'-'),"".PadRight(widthProduct,'-'),"".PadRight(widthProductVersion,'-'),"".PadRight(widthFileVersion,'-'),"".PadRight(widthTimeStamp,'-')));
                foreach (ListViewItem i in lvFiles.Items)
                    report.Add(string.Format(template, i.SubItems[0].Text, i.SubItems[1].Text, i.SubItems[2].Text, i.SubItems[3].Text, i.SubItems[4].Text, i.SubItems[5].Text));
                menuSaveReport.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                labelStatus.Text = "";
            }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            try
            {
                About f = new About();
                f.ShowDialog();
            }
            catch
            {
            }
        }

        private void lvFiles_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                lvFiles.ListViewItemSorter = new ListViewItemComparer(e.Column);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuSaveReport_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(reportFileName))
                {
                    foreach (string reportLine in report)
                        writer.WriteLine(reportLine);
                    writer.Flush();
                    writer.Close();
                }
                MessageBox.Show("Report saved to " + reportFileName, "Save Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
