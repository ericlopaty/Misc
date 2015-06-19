using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace RowCountDump
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    Console.WriteLine("USAGE: RowCountDump <server>");
                    return;
                }
                var csb = new SqlConnectionStringBuilder
                {
                    DataSource = args[0],
                    InitialCatalog = "master",
                    IntegratedSecurity = true
                };
                var connectionString = csb.ConnectionString;

                using (var cn = new SqlConnection(connectionString))
                {
                    Console.WriteLine("Opening server connection...");
                    cn.Open();

                    Console.WriteLine("Retrieving database names...");
                    var databases = new List<string>();
                    using (var cmd = new SqlCommand("SELECT name FROM sys.databases ORDER BY name", cn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                databases.Add(reader.GetString(0));
                            reader.Close();
                        }
                    }

                    Console.Write("Checking databases...");
                    var dbCnt = 0;
                    foreach (var database in databases)
                    {
                        dbCnt++;
                        Console.WriteLine("Checking {0}/{1}: {2}", dbCnt, databases.Count, database);
                        try
                        {
                            using (var cmd = new SqlCommand(string.Format("USE [{0}]", database), cn))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            var tables = new List<string>();
                            using (var cmd = new SqlCommand("SELECT name FROM sys.tables ORDER BY name", cn))
                            {
                                using (var reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        tables.Add(reader.GetString(0));
                                    }
                                    reader.Close();
                                }
                            }
                            Console.WriteLine("{0} tables found.", tables.Count);

                            Console.WriteLine("Checking tables...");
                            var tbCnt = 0;
                            foreach (string table in tables)
                            {
                                dbCnt++;
                                try
                                {
                                    using (
                                        var cmd =
                                            new SqlCommand(string.Format("SELECT COUNT(*) FROM [{0}]", table),
                                                cn))
                                    {
                                        cmd.CommandTimeout = 180;
                                        var count = (int) cmd.ExecuteScalar();
                                        Console.WriteLine("{0:###}/{1:####} {2,11:###,###,##0} {3}",dbCnt,tables.Count, table, count);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("{0,-100} {1}", table, ex.Message);
                                }
                            }
                        }
                        catch (SqlException)
                        {
                            Console.WriteLine("Unable to access database {0}", database);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Exception Occurred");
                DumpException(ex);
            }
            catch (DbException ex)
            {
                Console.WriteLine("DB Exception Occurred");
                DumpException(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception Occurred");
                DumpException(ex);
            }
            Console.ReadLine();
        }

        private static void DumpException(Exception ex)
        {
            Console.WriteLine(ex.Message);
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(ex.StackTrace);
        }
    }
}
