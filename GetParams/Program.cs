using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace GetParams
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
            b.DataSource = args[0];
            b.InitialCatalog = args[1];
            b.IntegratedSecurity = true;
            SqlConnection cn = new SqlConnection(b.ConnectionString);
            cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = args[2];
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmd);
                Console.WriteLine();
                Console.WriteLine("' Start Parameter List for {0}", args[2]);
                Console.WriteLine();                
                foreach (SqlParameter param in cmd.Parameters)
                {
                    Console.WriteLine("parameter = new SqlParameter()");
                    Console.WriteLine("parameter.ParameterName = \"{0}\"", param.ParameterName);
                    Console.WriteLine("parameter.DbType = DbType.{0}", param.DbType.ToString());
                    Console.WriteLine("parameter.Direction = ParameterDirection.{0}", param.Direction.ToString());
                    Console.WriteLine("parameter.Size = {0}", param.Size);
                    Console.WriteLine("parameter.IsNullable = {0}", param.IsNullable.ToString().ToLower());
                    Console.WriteLine("parameter.Precision = {0}", param.Precision);
                    Console.WriteLine("parameter.Scale = {0}", param.Scale);
                    Console.WriteLine("command.Parameters.Add(parameter)");
                    Console.WriteLine();
                }
                Console.WriteLine("// End Parameter List");
                Console.WriteLine();
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
    }
}
