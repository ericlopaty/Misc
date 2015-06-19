using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace adonetconsole
{
  class DataSets
  {
    public static void Dispatch()
    {
      AddRows();
    }

    static void DisposeAll()
    {
      string sql =
        "SELECT CustomerID, CompanyName FROM Customers;" +
        "SELECT OrderID, CustomerID, OrderDate FROM Orders;" +
        "SELECT OrderID, ProductID, Quantity, UnitPrice " +
        "FROM [Order Details]";
      SqlDataAdapter da = new SqlDataAdapter(sql, Util.Connection("Northwind"));
      using (DataSet ds = new DataSet("Northwind"))
      {
        da.Fill(ds);
        ds.Disposed += new EventHandler(Handle_DataSet_Disposed);
        ds.Disposed += new EventHandler(Log_Disposed);
        foreach (DataTable tbl in ds.Tables)
        {
          tbl.Disposed += new EventHandler(Log_Disposed);
          foreach (DataColumn col in tbl.Columns)
            col.Disposed += new EventHandler(Log_Disposed);
        }
        Console.WriteLine("Calling DataSet.Dispose");
      }
      Console.WriteLine("Done calling DataSet.Dispose");
    }

    static void Handle_DataSet_Disposed(object sender, EventArgs e)
    {
      DataSet ds = (DataSet)sender;
      foreach (DataTable tbl in ds.Tables)
      {
        foreach (DataColumn col in tbl.Columns)
          col.Dispose();
        tbl.Dispose();
      }
    }

    static void Log_Disposed(object sender, EventArgs e)
    {
      if (sender is DataSet)
        Console.WriteLine("  Disposing DataSet");
      else if (sender is DataTable)
        Console.WriteLine("    Disposing DataTable {0}", ((DataTable)sender).TableName);
      else if (sender is DataColumn)
        Console.WriteLine("      Disposing DataColumn {0}", ((DataColumn)sender).ColumnName);
    }

    static void LoadDataSet()
    {
      DataSet ds = new DataSet();
      string sql = 
        "SELECT CustomerID, CompanyName FROM Customers WHERE CustomerID = 'ANTON';" +
        "SELECT OrderID, CustomerID FROM Orders WHERE CustomerID = 'ANTON'";
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        using (SqlCommand cmd = new SqlCommand(sql, cn))
        {
          cn.Open();
          using (SqlDataReader rdr = cmd.ExecuteReader())
          {
            ds.Load(rdr, LoadOption.PreserveChanges, new String[] { "Customers", "Orders" });
          }
        }
        //see datatable load
        //see load with datatables (if already existing)
        //see load with error handler
      }

      foreach (DataTable tbl in ds.Tables)
      {
        Console.WriteLine(tbl.TableName);
        foreach (DataRow row in tbl.Rows)
          Console.WriteLine("  {0} - {1}", row[0], row[1]);
        Console.WriteLine();
      }
    }

    static void DataSetToDataReader()
    {
      string sql =
        "SELECT OrderID, CustomerID FROM Orders  WHERE CustomerID = 'ANTON';" +
        "SELECT CustomerID, CompanyName FROM Customers WHERE CustomerID = 'ANTON';";
      SqlDataAdapter da = new SqlDataAdapter(sql, Util.Connection("Northwind"));
      DataSet ds = new DataSet();
      da.Fill(ds);
      DataTable[] tables = new DataTable[] { ds.Tables[1], ds.Tables[0] };
      using (DataTableReader rdr = ds.CreateDataReader(tables))
      //using (DataTableReader rdr = ds.CreateDataReader())
      {
        do
        {
          while (rdr.Read())
            Console.WriteLine("{0} - {1}", rdr[0], rdr[1]);
          Console.WriteLine();
        } while (rdr.NextResult());
      }
    }

    static void Time()
    {
      DateTime nowLocal = DateTime.Now;
      DateTime nowUtc = TimeZone.CurrentTimeZone.ToUniversalTime(nowLocal);
      Console.WriteLine("Kind: {0,-5}  DateTime: {1}", nowLocal.Kind, nowLocal);
      Console.WriteLine("Kind: {0,-5}  DateTime: {1}", nowUtc.Kind, nowUtc);
      Console.WriteLine("{0}", nowLocal.ToUniversalTime());
    }

    static void Versioning()
    {
      DataTable tbl = new DataTable("Customers");
      tbl.Columns.Add("CustomerID", typeof(string));
      tbl.Columns.Add("CompanyName", typeof(string));
      tbl.PrimaryKey = new DataColumn[] { tbl.Columns["CustomerID"] };
      tbl.LoadDataRow(new object[] { "NEWCO", "Initial Value" }, true);

      DataRow row = tbl.Rows.Find("NEWCO");
      row["CompanyName"] = "New Value";
      Console.WriteLine("DataRowVersion.Current = {0}", row["CompanyName", DataRowVersion.Current]);
      Console.WriteLine("DataRowVersion.Original = {0}", row["CompanyName", DataRowVersion.Original]);
    }

    static void AddRows()
    {
      DataTable tbl = new DataTable("Customers");
      tbl.RowChanged+=new DataRowChangeEventHandler(OnRowChanged);
      tbl.Columns.Add("CustomerID", typeof(string));
      tbl.Columns.Add("CompanyName", typeof(string));
      tbl.PrimaryKey = new DataColumn[] { tbl.Columns["CustomerID"] };
      DataRow row = tbl.NewRow();
      row["CustomerID"] = "NEWCO";
      row["CompanyName"] = "New Customer";
      tbl.Rows.Add(row);
      
      //tbl.Rows.Add("NEWCO", "New Customer");

      //tbl.LoadDataRow(new object[] { "NEWCO", "New Customer" }, false);

      row = tbl.Rows.Find("NEWCO");
      if (row == null)
        Console.WriteLine("Customer not found!");
      else
      {
        row.BeginEdit();
        row["CompanyName"] = "New Value";
        row.EndEdit();
      }

      row.ItemArray = new object[] { null, "New Value" };

      if (row.IsNull("CompanyName"))
        Console.WriteLine("It's Null");
      else
      {
        Console.WriteLine("It's not Null");
        row["CompanyName"] = DBNull.Value;
      }
      row.Delete(); //pending

      tbl.Rows.Remove(row); //immediate - local
      tbl.Rows.RemoveAt(tbl.Rows.IndexOf(row)); //immediate - local
    }

    static void OnRowChanged(object sender, EventArgs e)
    {
      Console.WriteLine("row changed");
    }

    static void CreateDataTableComplete()
    {
      DataSet ds = new DataSet();
      DataTable tbl;
      DataColumn col;
      ForeignKeyConstraint fk;

      //Create the customers table.
      tbl = ds.Tables.Add("Customers");
      tbl.Columns.Add("CustomerID", typeof(string)).MaxLength = 5;
      tbl.Columns.Add("CompanyName", typeof(string)).MaxLength = 40;
      tbl.Columns.Add("ContactName", typeof(string)).MaxLength = 30;
      tbl.Columns.Add("Phone", typeof(string)).MaxLength = 24;
      tbl.PrimaryKey = new DataColumn[] { tbl.Columns["CustomerID"] };
      //Create the orders table.
      tbl = ds.Tables.Add("Orders");
      col = tbl.Columns.Add("OrderID", typeof(int));
      col.AutoIncrement = true;
      col.AutoIncrementSeed = -1;
      col.AutoIncrementStep = -1;
      col.ReadOnly = true;
      col = tbl.Columns.Add("CustomerID", typeof(string));
      col.AllowDBNull = false;
      col.MaxLength = 5;
      tbl.Columns.Add("EmployeeID", typeof(int));
      tbl.Columns.Add("OrderDate", typeof(DateTime));
      tbl.PrimaryKey = new DataColumn[] { tbl.Columns["OrderID"] };

      //Create the order details table.
      tbl = ds.Tables.Add("Order Details");
      tbl.Columns.Add("OrderID", typeof(int));
      tbl.Columns.Add("ProductID", typeof(int));
      tbl.Columns.Add("UnitPrice", typeof(Decimal)).AllowDBNull = false;
      col = tbl.Columns.Add("Quantity", typeof(int));
      col.AllowDBNull = false;
      col.DefaultValue = 1;
      tbl.Columns.Add("Discount", typeof(Decimal)).DefaultValue = 0;
      tbl.Columns.Add("ItemTotal", typeof(Decimal),
                      "UnitPrice * Quantity * (1 – Discount)");
      tbl.PrimaryKey = new DataColumn[] {tbl.Columns["OrderID"],
                                   tbl.Columns["ProductID"]};

      //Create the foreign key constraints.
      fk = new ForeignKeyConstraint("FK_Customers_Orders",
                                    ds.Tables["Customers"].Columns["CustomerID"],
                                    ds.Tables["Orders"].Columns["CustomerID"]);
      ds.Tables["Orders"].Constraints.Add(fk);
      fk = new ForeignKeyConstraint("FK_Orders_OrderDetails",
                                    ds.Tables["Orders"].Columns["OrderID"],
                                    ds.Tables["Order Details"].Columns["OrderID"]);
      ds.Tables["Order Details"].Constraints.Add(fk);
    }

    static void AutoIncrement()
    {
      string sql= "SELECT CustomerID, CompanyName FROM Customers";
      SqlDataAdapter da = new SqlDataAdapter(sql, Util.Connection("Northwind"));
      DataTable tbl = new DataTable("Customers");
      da.FillSchema(tbl, SchemaType.Source);
      //Add a DataColumn that will number the rows 1, 2, 3, ...
      DataColumn col = tbl.Columns.Add("RowNum", typeof(int));
      col.AutoIncrement = true;
      col.AutoIncrementSeed = 1;
      col.AutoIncrementStep = 1;
      //Retrieve the results of the query
      da.Fill(tbl);
      //Create a new DataView that will show rows 21 - 30
      int intPageSize = 10;
      int intPageNum = 3;
      DataView vue = new DataView(tbl);
      vue.RowFilter = String.Format("RowNum > {0} AND RowNum <= {1}", (intPageNum - 1) * intPageSize, intPageNum * intPageSize);
      //Print the contents of the rows visible through the DataView
      foreach (DataRowView row in vue)
        Console.WriteLine("{0}: {1} - {2}", row["RowNum"], row["CustomerID"], row["CompanyName"]);
    }

    static void CreateDataTable()
    {
      DataSet ds = new DataSet("DataSet");
      DataTable tblCustomers, tblOrders;
      
      tblCustomers = ds.Tables.Add("Customers");
      tblCustomers.Columns.Add("CustomerID", typeof(string));
      tblCustomers.Columns.Add("CompanyName", typeof(string));
      tblCustomers.PrimaryKey = new DataColumn[] { tblCustomers.Columns["CustomerID"] };

      tblOrders = ds.Tables.Add("Order Details");
      tblOrders.Columns.Add("OrderID", typeof(int));
      tblOrders.Columns.Add("ProductID", typeof(int));
      tblOrders.Columns.Add("CustomerID", typeof(string));
      tblOrders.PrimaryKey = new DataColumn[] { tblOrders.Columns["OrderID"], tblOrders.Columns["ProductID"] };
      tblOrders.Columns.Add("Quantity", typeof(int));
      tblOrders.Columns.Add("UnitPrice", typeof(Decimal));
      tblOrders.Columns.Add("ItemTotal", typeof(Decimal), "Quantity * UnitPrice");
      
      //or
      //tblCustomers.Constraints.Add("PK_CustomerID", tblCustomers.Columns["CustomerID"], true);
      //tblCustomers.Constraints.Add("UK_CompanyName", tblCustomers.Columns["CompanyName"], false);

      //tblOrders.Constraints.Add("FK_Customers_Orders", tblCustomers.Columns["CustomerID"], tblOrders.Columns["CustomerID"]);


    }

    static void One()
    {
      DataSet ds = new DataSet("MyDataSet");
      Console.WriteLine(ds.DataSetName);
      string sql = "SELECT OrderID, CustomerID FROM Orders";
      SqlDataAdapter da = new SqlDataAdapter(sql, Util.Connection("Northwind"));
      da.Fill(ds, "Orders");
      Console.WriteLine(ds.Tables[0].TableName);
      Console.WriteLine(ds.Tables[0].Rows.Count);
      Console.WriteLine();

      foreach (DataColumn col in ds.Tables["Orders"].Columns)
        Console.WriteLine("{0} - {1}", col.ColumnName, col.DataType);
      Console.WriteLine();
      {
        DataRow row = ds.Tables["Orders"].Rows[0];
        Console.WriteLine("OrderID = {0}", row["OrderID"]);
        Console.WriteLine("CustomerID = {0}", row["CustomerID"]);
        Console.WriteLine();
        DisplayRow(row);
      }
      Console.WriteLine();
      
      DataTable tbl = ds.Tables["Orders"];
      foreach (DataRow row in tbl.Rows)
      {
        Console.WriteLine("Contents of row #{0}", tbl.Rows.IndexOf(row));
        DisplayRow(row);
      }
    }

    static void DisplayRow(DataRow row)
    {
      foreach (DataColumn col in row.Table.Columns)
        Console.WriteLine("  {0}: {1}", col.ColumnName, row[col]);
    }
  }
}
