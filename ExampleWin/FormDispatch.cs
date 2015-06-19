using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Win32;

namespace ExampleWin
{
    public partial class FormDispatch : Form
    {
        private static Random r = new Random(DateTime.Now.Millisecond);
        private static string connectString;
        private Assembly assembly;

        public FormDispatch()
        {
            InitializeComponent();
            assembly = Assembly.GetExecutingAssembly();
            RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Example\\Database");
            connectString = (string)key.GetValue("scratch");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormExamples f = new FormExamples();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDataUpdate f = new FormDataUpdate();
            f.Show();
        }

        private void FormDispatch_Load(object sender, EventArgs e)
        {
        }

        private int DbNonQuery(SqlConnection cn, string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                return cmd.ExecuteNonQuery();
            }
        }

        private string GetId(string column, int length)
        {
            string sql;
            string id;

            using (SqlConnection cn = new SqlConnection(connectString))
            {
                cn.Open();
                sql = string.Format("SELECT next_id FROM unique_id WHERE row_id = '{0}'", column);
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    id = ((int)cmd.ExecuteScalar()).ToString().PadLeft(length, '0');
                }
                sql = string.Format("UPDATE unique_id SET next_id = next_id + 1 WHERE row_id = '{0}'", column);
                DbNonQuery(cn, sql);
                cn.Close();
            }
            return id;
        }

        private void GetId2(string column)
        {
            using (SqlConnection cn = new SqlConnection(connectString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection=cn;
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@column", SqlDbType.NVarChar, 50));
                    cmd.Parameters["@column"].Value = column;
                    cmd.CommandText = "procGetId2";
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        MessageBox.Show(rdr[0].ToString());
                }
                cn.Close();
            }
        }

        private void GetId3(string column)
        {
            using (SqlConnection cn = new SqlConnection(connectString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@column", SqlDbType.NVarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@column"].Value = column;
                    cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                    cmd.CommandText = "procGetId3";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(cmd.Parameters["@id"].Value.ToString());
                }
                cn.Close();
            }
        }

        private void GetId4(string column)
        {
            using (SqlConnection cn = new SqlConnection(connectString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@column", SqlDbType.NVarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@column"].Value = column;
                    cmd.Parameters["@id"].Direction = ParameterDirection.ReturnValue;
                    cmd.CommandText = "procGetId4";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(cmd.Parameters["@id"].Value.ToString());
                }
                cn.Close();
            }
        }

        private void btnLoadNames_Click(object sender, EventArgs e)
        {
            string sql;
            string customerId;
            string customerName;
            string customerTaxId;
            int ctr = 0;

            using (SqlConnection cn = new SqlConnection(connectString))
            {
                cn.Open();
                   int i = DbNonQuery(cn,"DELETE customer");
                    MessageBox.Show(string.Format("{0} customers deleted", i));
                string resourceName = string.Format("{0}.Names.txt", Application.ProductName);
                StreamReader rdr = new StreamReader(assembly.GetManifestResourceStream(resourceName));
                while ((customerName = rdr.ReadLine()) != null)
                {
                    customerId = GetId("customer_id", 6);
                    string s = UniqueId(9);
                    customerTaxId = s.Substring(0, 3) + "-" + s.Substring(3, 2) + "-" + s.Substring(5, 4);
                    sql = string.Format(
                        "INSERT customer(customer_id,customer_name,customer_taxid,customer_balance) VALUES('{0}','{1}','{2}',{3})",
                        customerId, customerName, customerTaxId, 0);
                    int rows = DbNonQuery(cn, sql);
                    ctr++;
                }
                cn.Close();
                MessageBox.Show(string.Format("{0} customers added", ctr));
            }
        }

        public static string UniqueId(int length)
        {
            StringBuilder t = new StringBuilder();
            for (int i = 0; i < length; i++)
                t.Append("1234567890".Substring(r.Next(10), 1));
            return t.ToString();
        }

        private void btnLoadAccounts_Click(object sender, EventArgs e)
        {
            List<string> customerIds;
            string sql;
            string accountId;
            int i, ctr = 0;
            string template = "INSERT account(account_id,customer_id,account_type_id,account_balance) VALUES ('{0}','{1}','{2}',0)";

            using (SqlConnection cn = new SqlConnection(connectString))
            {
                cn.Open();
                sql = "DELETE account";
                i = DbNonQuery(cn, sql);
                MessageBox.Show(string.Format("{0} accounts deleted", i));
                sql = "SELECT customer_id from customer";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        customerIds = new List<string>();
                        while (rdr.Read())
                            customerIds.Add(rdr.GetString(0));
                        rdr.Close();
                    }
                }
                foreach (string id in customerIds)
                {
                    accountId = GetId("account_id", 6);
                    sql = string.Format(template, accountId, id, "C");
                    if (DbNonQuery(cn, sql) == 1)
                        ctr++;
                    accountId = GetId("account_id", 6);
                    sql = string.Format(template, accountId, id, "S");
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        if (cmd.ExecuteNonQuery() == 1)
                            ctr++;
                    }
                }
                cn.Close();
                MessageBox.Show(string.Format("{0} accounts added", ctr));
            }
        }

        private void btnDropTables_Click(object sender, EventArgs e)
        {
            string[] commands = new string[] {
                "DROP TABLE account",
                "DROP TABLE customer",
                "DROP TABLE unique_id"
            };
            using (SqlConnection cn = new SqlConnection(connectString))
            {
                cn.Open();
                foreach (string command in commands)
                {
                    using (SqlCommand cmd = new SqlCommand(command, cn))
                    {
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show(i.ToString());
                    }
                }
                cn.Close();
            }
        }

        private void btnCreateTables_Click(object sender, EventArgs e)
        {
            string[] commands = new string[] {
                    "CREATE TABLE unique_id(row_id NVARCHAR(50) NULL, next_id int NULL)",
                    "INSERT unique_id(row_id, next_id) VALUES('customer_id',1)",
                    "INSERT unique_id(row_id, next_id) VALUES('account_id',1)",
                    "CREATE TABLE customer(customer_id NCHAR(6) NULL, customer_name NVARCHAR(50) NULL, customer_taxid NCHAR(11) NULL, customer_balance MONEY)",
                    "CREATE TABLE account(account_id NCHAR(6) NULL, customer_id NCHAR(6) NULL, account_type_id NCHAR(1) NULL, account_balance MONEY NULL)"
                };
            using (SqlConnection cn = new SqlConnection(connectString))
            {
                cn.Open();
                foreach (string command in commands)
                {
                    using (SqlCommand cmd = new SqlCommand(command, cn))
                    {
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show(i.ToString());
                    }
                }
                cn.Close();
            }
        }

        private void btnGetId_Click(object sender, EventArgs e)
        {
            //GetId2("customer_id");
            //GetId3("account_id");
            GetId4("account_id");
        }
    }
}
