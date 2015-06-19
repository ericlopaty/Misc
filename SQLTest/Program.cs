using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SQLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("SQL Connection Test");
            Console.WriteLine();
            Console.Write("Server: ");
            string server = Console.ReadLine();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.IntegratedSecurity = true;
            Console.WriteLine("Connection String: {0}", builder.ConnectionString);
            SqlConnection cn = new SqlConnection(builder.ConnectionString);
            Console.WriteLine("Opening connection...");
            try
            {
                cn.Open();
                Console.WriteLine("Connection opened");
            }
            catch (SqlException sqlx)
            {
                Console.WriteLine("SQL Error: {0}", sqlx.Message);
            }
            catch (Exception x)
            {
                Console.WriteLine("Error: {0}", x.Message);
            }
            if (cn.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Current DB: {0}", cn.Database);
                Console.WriteLine("Closing connection...");
                cn.Close();
                Console.WriteLine("Connection closed.");
            }
            cn.Dispose();
            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }
    }
}
