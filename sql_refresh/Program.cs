using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace sql_refresh
{
  class Program
  {
    static Properties.Settings config = new sql_refresh.Properties.Settings();
    static string template = "provider=SQLOLEDB;server={0};database={1};user id={2};password={3}";
    static string connection;

    static void Main(string[] args)
    {
      connection = string.Format(template, config.server, config.database, config.user_id, config.password);
      //One();
      //Two();
      Three();
      Console.ReadLine();
    }

    static void One()
    {
      using (OleDbConnection cn = new OleDbConnection(connection))
      {
        cn.Open();
        using (OleDbCommand cmd = new OleDbCommand("select count(*) from contact", cn))
        {
          int i = (int)cmd.ExecuteScalar();
          Console.WriteLine("{0}", i);
        }
        cn.Close();
      }
    }

    static void Two()
    {
      using (OleDbConnection cn = new OleDbConnection(connection))
      {
        cn.Open();
        using (OleDbCommand cmd = new OleDbCommand("select contact_id,contact_lastname,contact_firstname from contact", cn))
        {
          using (OleDbDataReader rdr = cmd.ExecuteReader())
          {
            int i = 1;
            while (rdr.Read())
            {
              Console.WriteLine("{0,3} - [{1}] {2}, {3}", i++, rdr.GetString(0), rdr.GetString(1), rdr.GetString(2));
            }
            rdr.Close();
          }
        }
        cn.Close();
      }
    }

    static void Three()
    {
      string query = "select contact_id,contact_lastname,contact_firstname from contact";
      DataSet ds = UpdateRows(connection, query, "contact");
      foreach (DataRow row in ds.Tables["contact"].Rows)
      {
        Console.WriteLine("{0} - {1}", row["contact_id"], row["contact_lastname"]);
      }
    }

    public static DataSet UpdateRows(string connectionString, string queryString, string tableName)
    {
      DataSet dataSet = new DataSet();
      using (OleDbConnection connection = new OleDbConnection(connectionString))
      {
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        adapter.SelectCommand = new OleDbCommand(queryString, connection);
        OleDbCommandBuilder cb = new OleDbCommandBuilder(adapter);
        connection.Open();
        adapter.Fill(dataSet, tableName);
        cb.GetDeleteCommand(true);
        cb.GetUpdateCommand(true);
        cb.GetInsertCommand(true);
        DataTable tbl = dataSet.Tables["contact"];
        foreach (DataRow row in tbl.Rows)
          if (string.Compare((string)row["contact_id"],"9999",true)==0)
            row.Delete();
        adapter.Update(dataSet, tableName);
        connection.Close();
      }
      return dataSet;
    }
  }
}
