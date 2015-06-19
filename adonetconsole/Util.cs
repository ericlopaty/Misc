using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace adonetconsole
{
  static class Util
  {
    public static string Connection(string catalog)
    {
      SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
      builder.DataSource = "(local)";
      builder.InitialCatalog = catalog;
      builder.IntegratedSecurity = true;
      builder.MinPoolSize = 0;
      builder.MaxPoolSize = 10;
      builder.Pooling = true;
      builder.AsynchronousProcessing = true;
      return builder.ConnectionString;
    }

    public static DataTable LoadDataTable(string catalog, string tableName, string sql)
    {
      SqlDataAdapter da = new SqlDataAdapter(sql, Connection(catalog));
      DataTable tbl = new DataTable(tableName);
      da.Fill(tbl);
      return tbl;
    }

    public static DataSet LoadDataSet(string catalog, string tables, string sql)
    {
      SqlDataAdapter da = new SqlDataAdapter(sql, Connection(catalog));
      string[] mappings = tables.Split(new char[] { ';' });
      int tableCount=0;
      for (int i = 0; i < mappings.Length; i++)
      {
        da.TableMappings.Add("Table" + ((tableCount == 0) ? "" : tableCount.ToString()), mappings[i].Trim());
        tableCount++;
      }
      DataSet ds = new DataSet();
      da.Fill(ds);
      return ds;
    }

    public static void DumpReader(SqlDataReader rdr)
    {
      int[] columnSizes = new int[rdr.FieldCount];
      const string pattern = "------------------------------------------------------------";
      for (int i = 0; i < rdr.FieldCount; i++)
      {
        columnSizes[i] = rdr.GetName(i).Length;
        Console.Write("{0} ", rdr.GetName(i));
      }
      Console.WriteLine();
      for (int i = 0; i < rdr.FieldCount; i++)
      {
        Console.Write("{0} ", pattern.Substring(0, columnSizes[i]));
      }
      Console.WriteLine();
      while (rdr.Read())
      {
        for (int i = 0; i < rdr.FieldCount; i++)
          Console.Write("\"{0}\"{1}", rdr[i], (i == rdr.FieldCount - 1 ? "" : ", "));
        Console.WriteLine();
      }
      Console.WriteLine();
    }

    public static void DumpTable(DataTable t)
    {
      const string pattern = "------------------------------------------------------------";
      int[] columnSizes = new int[t.Columns.Count];
      for (int i = 0; i < t.Columns.Count; i++)
        columnSizes[i] = t.Columns[i].Caption.Length;
      foreach (DataRow row in t.Rows)
        for (int i = 0; i < t.Columns.Count; i++)
          columnSizes[i] = Math.Max(columnSizes[i], string.Format("{0}", row[i]).Length);
      for (int i = 0; i < t.Columns.Count; i++)
      {
        string template = "{0,-" + string.Format("{0}", columnSizes[i]) + "} ";
        Console.Write(template, t.Columns[i].Caption);
      }
      Console.WriteLine();
      for (int i = 0; i < t.Columns.Count; i++)
        Console.Write(pattern.Substring(0, columnSizes[i]) + " ");
      Console.WriteLine();
      foreach (DataRow row in t.Rows)
      {
        for (int i = 0; i < t.Columns.Count; i++)
        {
          string template = "{0,-" + string.Format("{0}", columnSizes[i]) + "} ";
          Console.Write(template, row[i]);
        }
        Console.WriteLine();
      }
      Console.WriteLine();
    }
  }
}
