

using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace Utility.SqlDatabase
{
    public class RestoreUtility
    {
        public delegate void RestorePercentCompleteEventHandler(object sender, RestorePercentCompleteEventArgs e);
        public event RestorePercentCompleteEventHandler RestorePercentComplete;

        private string _restoreDatabaseName;

        public static void KillAllProcesses(string databaseName)
        {
            ServerConnection serverConnection = new ServerConnection(new SqlConnection("Data Source=.;Integrated Security=SSPI;"));
            Server server = new Server(serverConnection);

            server.KillAllProcesses(databaseName);
        }

        public void RestoreDatabase(string databaseName, string databaseFullFilePath)
        {
            Task task = RestoreDatabaseAsync(databaseName, databaseFullFilePath);
            task.Wait();
        }

        public async Task RestoreDatabaseAsync(string databaseName, string databaseFullFilePath)
        {
            ServerConnection serverConnection = new ServerConnection(new SqlConnection("Data Source=.;Integrated Security=SSPI;"));
            Server server = new Server(serverConnection);
            Restore restore = new Restore();
            restore.Action = RestoreActionType.Database;
            restore.Database = databaseName;
            restore.Devices.Add(new BackupDeviceItem(databaseFullFilePath, DeviceType.File));
            restore.ReplaceDatabase = true;
            restore.PercentCompleteNotification = 1;

            if (!server.Databases.Contains(databaseName))
            {
                DataTable fileList = restore.ReadFileList(server);
                string dbLogicalName = fileList.Rows[0][0].ToString();
                string dbPhysicalName = fileList.Rows[0][1].ToString();
                string logLogicalName = fileList.Rows[1][0].ToString();
                string logPhysicalName = fileList.Rows[1][1].ToString();

                dbPhysicalName = Path.Combine(server.DefaultFile, Path.GetFileName(dbPhysicalName));
                logPhysicalName = Path.Combine(server.DefaultLog, Path.GetFileName(logPhysicalName));

                restore.RelocateFiles.Add(new RelocateFile(dbLogicalName, dbPhysicalName));
                restore.RelocateFiles.Add(new RelocateFile(logLogicalName, logPhysicalName));
            }

            _restoreDatabaseName = databaseName;
            restore.PercentComplete += Restore_PercentComplete;
            restore.SqlRestoreAsync(server);

            await Task.Run(() => restore.Wait());

            restore.PercentComplete -= Restore_PercentComplete;
            _restoreDatabaseName = null;
        }

        private void Restore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            if (RestorePercentComplete != null)
            {
                RestorePercentComplete(sender, new RestorePercentCompleteEventArgs { Message = e.Message, Percent = e.Percent, Database = _restoreDatabaseName });
            }
        }
    }
}
