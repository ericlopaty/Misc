using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLRestore
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        //private async void RestoreButton_Click(object sender, RoutedEventArgs e)
        //{
        //    IList<string> databaseBackupFileNames = BackupFiles.SelectedItems.Cast<string>().ToList();

        //    if (databaseBackupFileNames.Count > 0)
        //    {
        //        IsEnabled = false;
        //        RestoreUtility restoreUtility = new RestoreUtility();

        //        StatusBarMessage.Text = "Starting Restore ...";
        //        StatusBarMessage.Refresh();

        //        restoreUtility.RestorePercentComplete += RestoreUtilityOnRestorePercentComplete;

        //        foreach (string databaseBackupFileName in databaseBackupFileNames)
        //        {
        //            string databaseName = ExtractDatabaseName(databaseBackupFileName);

        //            StatusBarMessage.Text = "Killing Processes for " + databaseName;
        //            StatusBarMessage.Refresh();
        //            RestoreUtility.KillAllProcesses(databaseName);

        //            StatusBarMessage.Text = "Restoring " + databaseName;
        //            StatusProgressBar.Visibility = Visibility.Visible;
        //            StatusProgressBar.Value = 0;
        //            StatusBarMessage.Refresh();
        //            StatusProgressBar.Refresh();

        //            await restoreUtility.RestoreDatabaseAsync(databaseName, databaseBackupFileName);
        //        }

        //        restoreUtility.RestorePercentComplete -= RestoreUtilityOnRestorePercentComplete;

        //        StatusProgressBar.Visibility = Visibility.Hidden;
        //        StatusBarMessage.Text = "Restore Complete.";
        //        IsEnabled = true;
        //    }
        //}

        //private void RestoreUtilityOnRestorePercentComplete(object sender, RestorePercentCompleteEventArgs e)
        //{
        //    Dispatcher.InvokeAsync(() => StatusBarMessage.Text = e.Database + " - " + e.Message);
        //    Dispatcher.InvokeAsync(() => StatusProgressBar.Value = e.Percent);
        //}

        //private void SelectFilesButton_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog dialog = new OpenFileDialog();
        //    dialog.CheckFileExists = true;
        //    dialog.CheckPathExists = true;
        //    dialog.Filter = "Backup Files|*.bak";
        //    dialog.Multiselect = true;
        //    dialog.Title = "Choose Backup Files";

        //    bool? showDialogresult = dialog.ShowDialog();

        //    if (showDialogresult == true)
        //    {
        //        BackupFiles.Items.Clear();

        //        foreach (string filename in dialog.FileNames)
        //        {
        //            BackupFiles.Items.Add(filename);
        //        }

        //        BackupFiles.SelectAll();
        //    }
        //}

        //private string ExtractDatabaseName(string databaseFilename)
        //{
        //    string filename = System.IO.Path.GetFileNameWithoutExtension(databaseFilename);
        //    string[] filenameParts = filename.Split('_');
        //    string databaseName = filename;

        //    if (filenameParts.Length > 1)
        //    {
        //        databaseName = filenameParts[1];
        //    }

        //    return databaseName;
        //}

    }
}
