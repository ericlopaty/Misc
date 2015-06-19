using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace adonetconsole
{
  class DataAdapters
  {
    public static void DataAdapter()
    {
      DataSet ds;
      SqlDataAdapter da;
      //DataTable tbl;
      int rows;
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        string sql = "SELECT CustomerID, CompanyName FROM Customers";
        ds = new DataSet();
        da = new SqlDataAdapter(sql, cn);
        rows = da.Fill(ds, "Customers");
        //tbl = new DataTable();
        //da.Fill(tbl);
      }
      Console.WriteLine("{0} rows returned", rows);
      Console.WriteLine("New TableName = {0}", ds.Tables[0].TableName);
      Console.WriteLine();
      foreach (DataRow row in ds.Tables[0].Rows)
        Console.WriteLine("{0}–{1}", row["CustomerID"], row["CompanyName"]);
      Console.WriteLine();
      //foreach (DataRow row in tbl.Rows)
      //  Console.WriteLine("{0}–{1}", row["CustomerID"], row["CompanyName"]);
    }

    public static void DataAdapter2()
    {
      string sql =
        "SELECT CustomerID, CompanyName, ContactName FROM Customers WHERE CustomerID = 'ALFKI'; " +
        "SELECT OrderID, CustomerID, OrderDate FROM Orders WHERE CustomerID = 'ALFKI'";
      SqlDataAdapter da = new SqlDataAdapter(sql, Util.Connection("Northwind"));
      da.TableMappings.Add("Table", "Customers");
      da.TableMappings.Add("Table1", "Orders");
      DataSet ds = new DataSet();
      int rows = da.Fill(ds);
      Console.WriteLine("{0} rows returned", rows);
      Console.WriteLine();
      foreach (DataTable tbl in ds.Tables)
        Console.WriteLine("TableName = {0}", tbl.TableName);
    }

    public static void DataAdapterEvents()
    {
      string sql = "SELECT TOP 1 OrderID, EmployeeID FROM Orders";
      SqlDataAdapter da = new SqlDataAdapter(sql, Util.Connection("Northwind"));
      SqlCommandBuilder cb = new SqlCommandBuilder(da);
      da.RowUpdated += new SqlRowUpdatedEventHandler(onRowUpdated);
      da.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
      DataTable tbl = new DataTable("Orders");
      da.Fill(tbl);
      tbl.Rows[0]["EmployeeID"] = (int)tbl.Rows[0]["EmployeeID"] + 1;
      da.Update(tbl);
      tbl.Rows[0]["EmployeeID"] = (int)tbl.Rows[0]["EmployeeID"] - 1;
      da.Update(tbl);
    }

    static void OnRowUpdating(object sender, SqlRowUpdatingEventArgs e)
    {
      Console.WriteLine("RowUpdating Event: {0}", e.StatementType);
      Console.WriteLine("  OrderID: {0}", e.Row["OrderID"]);
      Console.WriteLine("  EmployeeID from {0} to {1}",
                   e.Row["EmployeeID", DataRowVersion.Original],
                   e.Row["EmployeeID"]);
      Console.WriteLine();
    }

    static void onRowUpdated(object sender, SqlRowUpdatedEventArgs e)
    {
      Console.WriteLine("RowUpdated Event: {0}", e.StatementType);
      Console.WriteLine("  OrderID: {0}", e.Row["OrderID"]);
      if (e.Status == UpdateStatus.ErrorsOccurred)
        Console.WriteLine("  Errors occurred");
      else
        Console.WriteLine("  Success!");
      Console.WriteLine();
    }

    public static void DataAdapterEventsBatch()
    {
      string sql = "SELECT OrderID, EmployeeID FROM Orders WHERE CustomerID = 'ALFKI'";
      SqlDataAdapter da = new SqlDataAdapter(sql, Util.Connection("Northwind"));
      da.UpdateBatchSize = 10;
      SqlCommandBuilder cb = new SqlCommandBuilder(da);
      da.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated2);
      da.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating2);
      DataTable tbl = new DataTable("Orders");
      da.Fill(tbl);

      foreach (DataRow row in tbl.Rows)
        row["EmployeeID"] = (int)row["EmployeeID"] + 1;
      da.Update(tbl);

      foreach (DataRow row in tbl.Rows)
        row["EmployeeID"] = (int)row["EmployeeID"] - 1;
      da.Update(tbl);
    }

    static void OnRowUpdating2(object sender,
                               SqlRowUpdatingEventArgs e)
    {
      Console.WriteLine("RowUpdating Event: {0}", e.StatementType);
      Console.WriteLine("  OrderID: {0}", e.Row["OrderID"]);
      Console.WriteLine("  EmployeeID from {0} to {1}",
                   e.Row["EmployeeID", DataRowVersion.Original],
                   e.Row["EmployeeID"]);
      Console.WriteLine();
    }

    static void OnRowUpdated2(object sender,
                              SqlRowUpdatedEventArgs e)
    {
      Console.WriteLine("RowUpdated Event: {0}", e.StatementType);
      Console.WriteLine("  Changes submitted: {0}", e.RowCount);
      DataRow[] rows = new DataRow[e.RowCount];
      e.CopyToRows(rows);
      foreach (DataRow row in rows)
        Console.WriteLine("    OrderID: {0}", row["OrderID"]);
      if (e.Status == UpdateStatus.ErrorsOccurred)
        Console.WriteLine("  Errors occurred");
      else
        Console.WriteLine("  Success!");
      Console.WriteLine();
    }
  }
}
