using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Reflection;
using System.IO;

namespace ExampleConsole
{
    class Database
    {
        private static SqlConnection cn;
        private static SqlCommand cmd;
        private static Random r = new Random(DateTime.Now.Millisecond);
        //private static readonly string CONNECTION_KEY = @"SOFTWARE\7WOLFE\SQLEXPRESS\Scratch";
        private static string connectString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\docs\dev\sqlserver\scratch.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";

        //static Database()
        //{
        //    RegistryKey regKey = Registry.CurrentUser.OpenSubKey(CONNECTION_KEY);
        //    connectString = (string)regKey.GetValue("connect");
        //    regKey.Close();
        //}

        public static void Dispatch()
        {
            //Test();
            //LoadCustomers();
            //LoadAccounts();
            Demo1();
            //string command = "select * from account_type";
            //SqlConnection cn = new SqlConnection(connect);
            //cn.Open();
            //SqlCommand cmd = new SqlCommand(command, cn);
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    Console.WriteLine("{0}={1}", dr[0], dr[1]);
            //}
        }

        public static void Demo1()
        {
            SqlConnection cn=new SqlConnection(connectString);
            string sql="SELECT * FROM customer ORDER BY customer_name";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Customers");
            foreach (DataRow row in ds.Tables["Customers"].Rows)
                Console.WriteLine(row["customer_name"]);
            cn.Close();
            cn.Dispose();
        }

        public static void Test()
        {
            SqlConnection cn = new SqlConnection(connectString);
            cn.Open();

            string sql = "INSERT account(account_id,customer_id,account_type_id,account_balance) VALUES ('4804089922','498927','C',0)";
            SqlCommand cmd = new SqlCommand(sql, cn);
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine(i);
            cmd.Dispose();
            cn.Close();
            cn.Dispose();
        }

        public static void LoadCustomers()
        {
            SqlConnection cn;
            SqlCommand cmd;
            string sql;
            string customerName;
            string customerId;
            string customerTaxId;
            int i;

            Console.WriteLine("inserting customers");
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (cn = new SqlConnection(connectString))
            {
                cn.Open();
                using (cmd = new SqlCommand("DELETE customer", cn))
                {
                    i = cmd.ExecuteNonQuery();
                    Console.WriteLine(string.Format("{0} customers deleted", i));
                }
                StreamReader rdr = new StreamReader(assembly.GetManifestResourceStream("ExampleConsole.names.txt"));
                while ((customerName = rdr.ReadLine()) != null)
                {
                    customerId = UniqueId(cn, "customer", "customer_id", 6);
                    string s = UniqueId(cn, "customer", "customer_taxid", 9);
                    customerTaxId = s.Substring(0, 3) + "-" + s.Substring(3, 2) + "-" + s.Substring(5, 4);
                    Console.WriteLine("inserting customer {0} with id {1}", customerName, customerId);
                    sql = string.Format("INSERT customer(customer_id,customer_name,customer_taxid,customer_balance) VALUES('{0}','{1}','{2}',{3})",
                        customerId, customerName, customerTaxId, 0);
                    using (cmd = new SqlCommand(sql, cn))
                    {
                        cmd = new SqlCommand(sql, cn);
                        int rows = cmd.ExecuteNonQuery();
                    }
                }
                cn.Close();
            }
        }

        public static void DeleteAccounts()
        {
            string sql;
            int i;

            Console.WriteLine("deleting accounts");
            using (cn = new SqlConnection(connectString))
            {
                cn.Open();
                sql = "DELETE account";
                using (cmd = new SqlCommand(sql, cn))
                {
                    i = cmd.ExecuteNonQuery();
                    Console.WriteLine("{0} accounts deleted", i);
                }
                cn.Close();
            }
        }
        
        public static void LoadAccounts()
        {
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader rdr;
            List<string> customerIds;
            string sql;
            string accountId;
            int i;

            Console.WriteLine("inserting accounts");
            using (cn = new SqlConnection(connectString))
            {
                cn.Open();
                sql = "SELECT customer_id from customer";
                cmd = new SqlCommand(sql, cn);
                using (rdr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                {
                    customerIds = new List<string>();
                    while (rdr.Read())
                        customerIds.Add(rdr.GetString(0));
                    rdr.Close();
                }
                foreach (string id in customerIds)
                {
                    accountId = UniqueId(cn, "account", "account_id", 10);
                    sql = string.Format("INSERT account(account_id,customer_id,account_type_id,account_balance) VALUES ('{0}','{1}','C',0)", accountId, id);
                    cmd = new SqlCommand(sql, cn);
                    if (cmd.ExecuteNonQuery()==1)
                        Console.WriteLine("added account_id {0} for customer_id {1}", accountId, id);
                    else
                        Console.WriteLine("error adding account_id {0} for customer_id {1}", accountId, id);
                    accountId = UniqueId(cn, "account", "account_id", 10);
                    sql = string.Format("INSERT account(account_id,customer_id,account_type_id,account_balance) VALUES ('{0}','{1}','S',0)", accountId, id);
                    cmd = new SqlCommand(sql, cn);
                    if (cmd.ExecuteNonQuery() == 1)
                        Console.WriteLine("added account_id {0} for customer_id {1}", accountId, id);
                    else
                        Console.WriteLine("error adding account_id {0} for customer_id {1}", accountId, id);
                }
                cn.Close();
            }
        }

        public static string UniqueId(SqlConnection cn, string table,string column, int length)
        {
            SqlCommand cmd;
            StringBuilder t = new StringBuilder(length);
            string sql;
            int i,p;

            do
            {
                for (i = 0; i < length; i++)
                {
                    p = r.Next(10);
                    t.Append("1234567890".Substring(p, 1));
                }
                sql = string.Format("SELECT COUNT(*) FROM {0} WHERE {1}='{2}'",
                    table, column, t.ToString());
                cmd = new SqlCommand(sql, cn);
                i = (int)cmd.ExecuteScalar();
            } while (i > 0);
            return t.ToString();
        }
    }
}
