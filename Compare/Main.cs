using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace Compare
{
    public partial class Main : Form
    {
        private string leftFolder = "";
        private string rightFolder = "";
        private readonly string registryPath = "Software\\Miscellaneous\\Compare";
        bool checkSubFolders = true;
        bool cancelCompare = false;
        string fileViewer = "";
        bool useNotepad = true;
        bool allowMultiple = false;
        List<ListViewItem> items;

        public Main()
        {
            InitializeComponent();
        }

        public string LeftFolder
        {
            set { leftFolder = value; }
        }

        public string RightFolder
        {
            set { rightFolder = value; }
        }

        private void menuCompare_Click(object sender, EventArgs e)
        {
            try
            {
                using (SelectFolders f = new SelectFolders())
                {
                    f.tbLeft.Text = leftFolder;
                    f.tbRight.Text = rightFolder;
                    f.cbSubFolders.Checked = checkSubFolders;
                    DialogResult r = f.ShowDialog();
                    if (r == DialogResult.Cancel)
                    {
                        f.Close();
                        return;
                    }
                    leftFolder = f.tbLeft.Text;
                    rightFolder = f.tbRight.Text;
                    checkSubFolders = f.cbSubFolders.Checked;
                    f.Close();
                    SaveSettings();
                    Compare(leftFolder, rightFolder);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveSettings()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(registryPath);
            key.SetValue("Left Folder", leftFolder, RegistryValueKind.String);
            key.SetValue("Right Folder", rightFolder, RegistryValueKind.String);
            key.SetValue("Check Subfolders", checkSubFolders ? "Y" : "N", RegistryValueKind.String);
            key.SetValue("File Viewer", fileViewer, RegistryValueKind.String);
            key.SetValue("Use Notepad", useNotepad ? "Y" : "N", RegistryValueKind.String);
            key.SetValue("Allow Multiple", allowMultiple ? "Y" : "N", RegistryValueKind.String);
            key.Close();
        }

        private void menuRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Compare(leftFolder, rightFolder);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> GetFiles(string path)
        {
            List<string> fileList = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] thisFolder = dir.GetFiles();
            foreach (FileInfo file in thisFolder)
                fileList.Add(file.FullName);
            fileList.Sort();
            if (checkSubFolders)
            {
                DirectoryInfo[] subFolders = dir.GetDirectories();
                List<string> dirList = new List<string>();
                foreach (DirectoryInfo d in subFolders)
                    dirList.Add(d.FullName);
                dirList.Sort();
                foreach (string d in dirList)
                    fileList.AddRange(GetFiles(d));
            }
            return fileList;
        }

        private void Compare(string leftRoot, string rightRoot)
        {
            ListViewItem item;
            string result;
            string captionLeft = "";
            string captionRight = "";
            Color foreColor;
            int dateCompare;

            cancelCompare = false;
            menuCancel.Enabled = true;
            this.Text = string.Format("Compare: [{0}] with [{1}]", leftFolder, rightFolder);
            statusLabel.Text = "Working...";
            listView.Items.Clear();
            items = new List<ListViewItem>();
            Application.DoEvents();
            FileInfo fileLeft, fileRight;
            long sizeLeft, sizeRight;
            List<string> leftList = new List<string>(GetFiles(leftRoot));
            List<string> rightList = new List<string>(GetFiles(rightRoot));
            int l = 0, r = 0;
            progress.Minimum = 0;
            progress.Maximum = leftList.Count + rightList.Count;
            progress.Value = 0;
            while ((l < leftList.Count || r < rightList.Count) && !cancelCompare)
            {
                captionLeft = captionRight = "";
                fileLeft = fileRight = null;
                sizeLeft = sizeRight = 0;
                if (l < leftList.Count)
                {
                    captionLeft = leftList[l].Substring(leftRoot.Length + 1);
                    fileLeft = new FileInfo(leftList[l]);
                    sizeLeft = fileLeft.Length;
                }
                if (r < rightList.Count)
                {
                    captionRight = rightList[r].Substring(rightRoot.Length + 1);
                    fileRight = new FileInfo(rightList[r]);
                    sizeRight = fileRight.Length;
                }
                switch (FileOrder(captionLeft, captionRight))
                {
                    case 0:
                        statusLabel.Text = fileLeft.Name;
                        bool match = CompareContents(fileLeft, fileRight);
                        dateCompare = DateOrder(fileLeft, fileRight);
                        if (match)
                        {
                            result = (dateCompare == 0) ? "Identical" : "Timestamps Differ";
                            foreColor = (dateCompare == 0) ? Color.Black : Color.Blue;
                        }
                        else
                        {
                            result = (dateCompare == 0) ? "Different"
                                : (dateCompare < 0) ? "Right Newer" : "Left Newer";
                            foreColor = Color.Red;
                        }
                        item = BuildItem(captionLeft, result, DateFormat(fileLeft.LastWriteTime), string.Format("{0:#,##0}", sizeLeft), DateFormat(fileRight.LastWriteTime), string.Format("{0:#,##0}", sizeRight), foreColor, listView.BackColor);
                        items.Add(item);
                        l++;
                        r++;
                        progress.Value += 2;
                        break;
                    case -1:
                        statusLabel.Text = fileLeft.Name;
                        item = BuildItem(captionLeft, "Left Only", DateFormat(fileLeft.LastWriteTime), string.Format("{0:#,##0}", sizeLeft), "", "", Color.Red, listView.BackColor);
                        items.Add(item);
                        l++;
                        progress.Value++;
                        break;
                    case 1:
                        statusLabel.Text = fileRight.Name;
                        item = BuildItem(captionRight, "Right Only", "", "", DateFormat(fileRight.LastWriteTime), string.Format("{0:#,##0}", sizeRight), Color.Red, listView.BackColor);
                        items.Add(item);
                        r++;
                        progress.Value++;
                        break;
                }
                Application.DoEvents();
            }
            progress.Value = 0;
            if (cancelCompare)
                statusLabel.Text = "Cancelled";
            else
                RefreshItems();
            menuRefresh.Enabled = true;
            menuCancel.Enabled = false;
        }

        private void RefreshItems()
        {
            if (items == null) return;
            listView.Items.Clear();
            foreach (ListViewItem item in items)
            {
                if (IsVisible(item))
                    listView.Items.Add(item);
            }
            statusLabel.Text = string.Format("Files: {0}", listView.Items.Count);

        }

        private bool IsVisible(ListViewItem item)
        {
            return
                menuShowAll.Checked
                || (string.Compare(item.SubItems[1].Text, "Identical", true) == 0 && menuViewIdentical.Checked)
                || (string.Compare(item.SubItems[1].Text, "Timestamps Differ", true) == 0 && menuViewIdentical.Checked)
                || (string.Compare(item.SubItems[1].Text, "Left Only", true) == 0 && menuViewLeftOnly.Checked)
                || (string.Compare(item.SubItems[1].Text, "Right Only", true) == 0 && menuViewRightOnly.Checked)
                || (string.Compare(item.SubItems[1].Text, "Left Newer", true) == 0 && menuViewDifferent.Checked)
                || (string.Compare(item.SubItems[1].Text, "Right Newer", true) == 0 && menuViewDifferent.Checked)
                || (string.Compare(item.SubItems[1].Text, "Different", true) == 0 && menuViewDifferent.Checked);
        }

        private int FileOrder(string l, string r)
        {
            //if the left file is null, the right file comes first (duh)
            if (l.Length == 0)
                return 1;
            //if the right file is null, the left file comes first (duh)
            if (r.Length == 0)
                return -1;
            //if both files are in the same folder, compare normally
            string leftFolder = Path.GetDirectoryName(l);
            string rightFolder = Path.GetDirectoryName(r);
            switch (string.Compare(leftFolder, rightFolder, true))
            {
                case 0:
                    // both files are in the same folder, compare file names
                    return string.Compare(l, r, true);
                case -1:
                    // left folder comes first
                    return -1;
                case 1:
                    // right folder comes first
                    return 1;
            }
            return 0;
        }

        private int DateOrder(FileInfo l, FileInfo r)
        {
            return DateTime.Compare(l.LastWriteTime, r.LastWriteTime);
        }

        private string DateCaption2(int c)
        {
            return (c < 0) ? "Right Newer" : (c > 0) ? "Left Newer" : "Different";
        }

        private bool CompareContents(FileInfo fileLeft, FileInfo fileRight)
        {
            bool match = true;
            int t;
            if (fileLeft.Length != fileRight.Length)
                return false;
            using (FileStream readLeft = fileLeft.Open(FileMode.Open, FileAccess.Read))
            {
                using (FileStream readRight = fileRight.Open(FileMode.Open, FileAccess.Read))
                {
                    long bytesRead = 0;
                    while (bytesRead < fileLeft.Length && match)
                    {
                        long bufferSize = Math.Min(262144, fileLeft.Length - bytesRead);
                        byte[] bufferLeft = new byte[bufferSize];
                        byte[] bufferRight = new byte[bufferSize];
                        t = readLeft.Read(bufferLeft, 0, (int)bufferSize);
                        t = readRight.Read(bufferRight, 0, (int)bufferSize);
                        bytesRead += bufferSize;
                        for (int i = 0; i < bufferSize && match; i++)
                            match &= (bufferLeft[i] == bufferRight[i]);
                    }
                    readRight.Close();
                }
                readLeft.Close();
            }
            return match;
        }

        private ListViewItem BuildItem(string caption, string result, string leftDate, string leftSize, string rightDate, string rightSize, Color foreColor, Color backColor)
        {
            string[] columns = new string[6];
            columns[0] = caption;
            columns[1] = result;
            columns[2] = leftDate;
            columns[3] = leftSize;
            columns[4] = rightDate;
            columns[5] = rightSize;
            ListViewItem item = new ListViewItem(columns);
            item.ForeColor = foreColor;
            item.BackColor = backColor;
            return item;
        }

        private string DateFormat(DateTime d)
        {
            return d.ToString("MM/dd/yyyy hh:mm:ss tt");
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormCompare_Load(object sender, EventArgs e)
        {
            try
            {
                listView.Columns.Clear();
                listView.Columns.Add("File Name", 320, HorizontalAlignment.Left);
                listView.Columns.Add("Compare", 150, HorizontalAlignment.Left);
                listView.Columns.Add("Left Date", 150, HorizontalAlignment.Left);
                listView.Columns.Add("Left Size", 70, HorizontalAlignment.Right);
                listView.Columns.Add("Right Date", 150, HorizontalAlignment.Left);
                listView.Columns.Add("Right Size", 70, HorizontalAlignment.Right);
                listView.Sorting = SortOrder.None;
                RegistryKey key = Registry.CurrentUser.CreateSubKey(registryPath);
                leftFolder = (string)key.GetValue("Left Folder", "");
                rightFolder = (string)key.GetValue("Right Folder", "");
                checkSubFolders = string.Compare((string)key.GetValue("Check Subfolders", "Y"), "Y", true) == 0;
                fileViewer = (string)key.GetValue("File Viewer", "");
                useNotepad = string.Compare((string)key.GetValue("Use Notepad", "Y"), "Y", true) == 0;
                if (useNotepad) fileViewer = "NOTEPAD.EXE";
                allowMultiple = string.Compare((string)key.GetValue("Allow Multiple", "N"), "Y", true) == 0;
                statusLabelVersion.Text = string.Format("Version: {0}", Application.ProductVersion);
                key.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                listView.ListViewItemSorter = new ListViewItemComparer(e.Column);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            try
            {
                using (About f = new About())
                {
                    f.ShowDialog();
                    f.Close();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuCancel_Click(object sender, EventArgs e)
        {
            try
            {
                cancelCompare = true;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuView_Click(object sender, EventArgs e)
        {
            try
            {
                menuViewIdentical.Checked = false;
                menuViewLeftOnly.Checked = false;
                menuViewRightOnly.Checked = false;
                menuViewDifferent.Checked = false;
                menuShowAll.Checked = false;
                ((ToolStripMenuItem)sender).Checked = true;
                RefreshItems();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                ViewFiles();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewFiles()
        {
            string args;

            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("No item selected.", "View File(s)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!useNotepad && fileViewer.Length == 0)
            {
                MessageBox.Show("No file viewer selected.", "View File(s)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem item = listView.SelectedItems[0];
                string fileLeft = Path.Combine(leftFolder, item.Text);
                string fileRight = Path.Combine(rightFolder, item.Text);
                if (allowMultiple)
                {
                    if (File.Exists(fileLeft) && File.Exists(fileRight))
                        args = string.Format("\"{0}\" \"{1}\"", fileLeft, fileRight);
                    else if (File.Exists(fileLeft) && !File.Exists(fileRight))
                        args = string.Format("\"{0}\"", fileLeft);
                    else if (!File.Exists(fileLeft) && File.Exists(fileRight))
                        args = string.Format("\"{0}\"", fileRight);
                    else
                    {
                        MessageBox.Show("No files found.", "View File(s)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    Process.Start(fileViewer, args);
                }
                else
                {
                    if (fileViewer.Length>0)
                    if (File.Exists(fileLeft))
                        Process.Start(fileViewer, string.Format("\"{0}\"", fileLeft));
                    if (File.Exists(fileRight))
                        Process.Start(fileViewer, string.Format("\"{0}\"", fileRight));
                }
            }
        }

        private void menuViewFiles_Click(object sender, EventArgs e)
        {
            try
            {
                ViewFiles();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuConfigure_Click(object sender, EventArgs e)
        {
            try
            {
                using (SelectViewer f = new SelectViewer())
                {
                    f.FileViewer = fileViewer;
                    f.AcceptMultipleFiles = allowMultiple;
                    f.UseNotepad = useNotepad;
                    f.ShowDialog();
                    fileViewer = f.FileViewer;
                    useNotepad = f.UseNotepad;
                    allowMultiple = f.AcceptMultipleFiles;
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(registryPath);
                    key.SetValue("File Viewer", fileViewer, RegistryValueKind.String);
                    key.SetValue("Use Notepad", useNotepad ? "Y" : "N", RegistryValueKind.String);
                    key.SetValue("Allow Multiple", allowMultiple ? "Y" : "N", RegistryValueKind.String);
                    key.Close();
                    f.Close();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDiff f = new ViewDiff();
            f.Show();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
