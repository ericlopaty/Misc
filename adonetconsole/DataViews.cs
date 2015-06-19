using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace adonetconsole
{
  class DataViews
  {
    public static void Dispatch()
    {
      Views();
    }

    static void Find()
    {
      {
        DataTable tbl = Util.LoadDataTable("Northwind", "Customers", "SELECT CustomerID, CompanyName FROM Customers WHERE CustomerID LIKE 'A%'");
        tbl.PrimaryKey = new DataColumn[] { tbl.Columns["CustomerID"] };

        DataRow row = tbl.Rows.Find("ALFKI");
        if (row == null)
          Console.WriteLine("Row not found!");
        else
          Console.WriteLine(row["CompanyName"]);
        Console.WriteLine();
      }

      {
        DataTable tbl = Util.LoadDataTable("Northwind", "Order Details", "SELECT OrderID, ProductID, Quantity, UnitPrice FROM [Order Details]");
        tbl.PrimaryKey = new DataColumn[] { tbl.Columns["OrderID"], tbl.Columns["ProductID"] };

        object[] objCriteria = new object[] { 10643, 28 };
        DataRow row = tbl.Rows.Find(objCriteria);
        if (row == null)
          Console.WriteLine("Row not found!");
        else
          Console.WriteLine("{0} - {1}", row["Quantity"], row["UnitPrice"]);
        Console.WriteLine();
      }

      {
        string strFilter;
        DataTable tbl = Util.LoadDataTable("Northwind", "Customers", "SELECT CustomerID, CompanyName, City, Country FROM Customers");
        strFilter = "Country = 'USA' AND City <> 'Seattle'";
        string strSortOrder = "City DESC";
        foreach (DataRow row in tbl.Select(strFilter, strSortOrder))
          Console.WriteLine("{0,-35} {1}, {2}", row["CompanyName"], row["City"], row["Country"]);
        Console.WriteLine();
      }

      {
        DataTable tbl = Util.LoadDataTable("Northwind", "Customers", "SELECT CustomerID, CompanyName, City, Country FROM Customers");
        Console.WriteLine("DataTable contains {0} rows", tbl.Rows.Count);
        Console.WriteLine();

        Console.WriteLine("Original rows");
        foreach (DataRow row in tbl.Select("Country = 'USA'"))
          Console.WriteLine("  {0} - {1}", row["CustomerID"], row["CompanyName"]);

        foreach (DataRow row in tbl.Select("Country = 'USA'"))
          row["CompanyName"] = "Modified Value";

        DataViewRowState dvrs = DataViewRowState.ModifiedCurrent;
        Console.WriteLine("Modified rows");
        foreach (DataRow row in tbl.Select("", "", dvrs))
          Console.WriteLine("  {0} - {1} to {2}",
            row["CustomerID", DataRowVersion.Current],
            row["CompanyName", DataRowVersion.Original],
            row["CompanyName", DataRowVersion.Current]);
        Console.WriteLine();
      }

      {
        string strFilter, strSortOrder;
        DataSet ds = Util.LoadDataSet("Northwind", "Customers;Orders", "SELECT CustomerID, CompanyName FROM Customers; SELECT OrderID, CustomerID, OrderDate FROM Orders");

        //Create the DataRelation between the DataTables
        ds.Relations.Add("CustomersOrders", ds.Tables["Customers"].Columns["CustomerID"], ds.Tables["Orders"].Columns["CustomerID"]);

        //Create a column in the orders DataTable
        //that shows data from the customers DataTable
        ds.Tables["Orders"].Columns.Add("CompanyName", typeof(string), "Parent(CustomersOrders).CompanyName");

        //Use the DataRelation/expression based column
        //in the search criteria
        strFilter = "CompanyName LIKE 'A%'";
        strSortOrder = "OrderDate";
        foreach (DataRow row in ds.Tables["Orders"].Select(strFilter, strSortOrder))
          Console.WriteLine("{0,-35} {1} {2:d}", row["CompanyName"],
                            row["OrderID"], row["OrderDate"]);
      }
    }

    static void Views()
    {
      {
        DataTable tbl = Util.LoadDataTable("Northwind", "Customers", "SELECT CustomerID, CompanyName, City, Country FROM Customers");
        DataViewRowState dvrs = DataViewRowState.ModifiedOriginal | DataViewRowState.Deleted;
        DataView vue;

        //Set Table, RowFilter, Sort and RowStateFilter separately
        vue = new DataView();
        vue.Table = tbl;
        vue.RowFilter = "Country = 'USA'";
        vue.Sort = "City DESC";
        vue.RowStateFilter = dvrs;
        Console.WriteLine();
      }

      {
        DataTable tbl = Util.LoadDataTable("Northwind", "Customers", "SELECT CustomerID, CompanyName, City, Country FROM Customers");
        DataView vue = new DataView(tbl);
        DataRowView row = vue[0];
        Console.WriteLine(row["CompanyName"]);
        Console.WriteLine();
      }

      {
        //Create and populate the DataTable
        DataTable tbl = new DataTable("Customers");
        tbl.Columns.Add("CustomerID", typeof(string));
        tbl.Columns.Add("CompanyName", typeof(string));
        tbl.Rows.Add(new object[] { "ALFKI", "Alfreds Futterkiste" });
        tbl.Rows.Add(new object[] { "WOLZA", "Wolski Zajazd" });

        //Create the DataView
        DataView vue = new DataView(tbl);
        vue.Sort = "CompanyName ASC";

        //Use a DataRowView to write the contents of
        //the first row in the DataView to the Console window
        DataRowView row = vue[0];
        Console.WriteLine(row["CompanyName"]);

        //Change the DataView's Sort property
        vue.Sort = "CompanyName DESC";

        //Re-write the contents to the DataRowView to the Console window
        row = vue[0];
        Console.WriteLine(row["CompanyName"]);
        Console.WriteLine();
      }

      {
        DataTable tbl = Util.LoadDataTable("Northwind", "Customers", "SELECT CustomerID, CompanyName, City, Country FROM Customers");
        DataView vue = new DataView(tbl);
        foreach (DataRowView rowview in vue)
          Console.WriteLine(rowview["CompanyName"]);
        Console.WriteLine();
      }

      {
        DataTable tbl = Util.LoadDataTable("Northwind", "Customers", "SELECT CustomerID, CompanyName, ContactName FROM Customers");
        DataView vue = new DataView(tbl);
        vue.Sort = "ContactName";
        int intIndex = vue.Find("Fran Wilson");
        if (intIndex == -1)
          Console.WriteLine("Row not found!");
        else
          Console.WriteLine(vue[intIndex]["CompanyName"]);
        Console.WriteLine();
      }

      {
        DataTable tbl = Util.LoadDataTable("Northwind", "Customers", "SELECT CustomerID, City, Country FROM Customers");
        DataView vue = new DataView(tbl);
        vue.Sort = "Country";
        DataRowView[] aRows = vue.FindRows("Spain");
        if (aRows.Length == 0)
          Console.WriteLine("No rows found!");
        else
          foreach (DataRowView row in aRows)
            Console.WriteLine(row["City"]);
        Console.WriteLine();
      }

      {
        DataTable tbl = new DataTable("Customers");
        tbl.Columns.Add("CustomerID", typeof(string));
        tbl.Columns.Add("CompanyName", typeof(string));
        tbl.Columns.Add("ContactName", typeof(string));
        DataView vue = new DataView(tbl);
        //Add a new row.
        DataRowView row = vue.AddNew();
        row["CustomerID"] = "ABCDE";
        row["CompanyName"] = "New Company";
        row["ContactName"] = "New Contact";
        row.EndEdit();

        //Modify a row.
        row.BeginEdit();
        row["CompanyName"] = "Modified";
        row.EndEdit();

        //Delete a row.
        row.Delete();
        Console.WriteLine();
      }

      {
        //Create and fill a DataTable
        DataTable tblAllCustomers = Util.LoadDataTable("Northwind", "Customers", "SELECT CustomerID, CompanyName, City, Country FROM Customers");
        //Create a DataView so only the Spanish customers are available
        DataView vue = new DataView(tblAllCustomers);
        vue.RowFilter = "Country = 'Spain'";
        //Create a new DataTable based on the DataView and show its contents
        DataTable tblSpanishCustomers = vue.ToTable("SpanishCustomers");
        Console.WriteLine("TableName: {0}", tblSpanishCustomers.TableName);
        Console.WriteLine("Rows:");
        foreach (DataRow row in tblSpanishCustomers.Rows)
          Console.WriteLine("  {0}, {1}", row["City"], row["Country"]);
        Console.WriteLine();
      }

      {
        DataTable tblAllCustomers = Util.LoadDataTable("Northwind", "Customers", "SELECT CustomerID, CompanyName, City, Country FROM Customers");
        //Create a DataView so only the Spanish customers are available
        DataView vue = new DataView(tblAllCustomers);
        vue.RowFilter = "Country = 'Spain'";
        //Create a new DataTable based on the DataView
        //that contains only the City and Country columns
        //and only unique sets of values for those columns
        DataTable tblSpanishCustomers;
        tblSpanishCustomers = vue.ToTable("SpanishCustomers", true, new string[] { "City", "Country" });
        Console.WriteLine("TableName: {0}", tblSpanishCustomers.TableName);
        Console.WriteLine("Columns:");
        foreach (DataColumn col in tblSpanishCustomers.Columns)
          Console.WriteLine("  {0}", col.ColumnName);
        Console.WriteLine();
        Console.WriteLine("Rows:");
        foreach (DataRow row in tblSpanishCustomers.Rows)
          Console.WriteLine("  {0}, {1}", row["City"], row["Country"]);
        Console.WriteLine();
      }

      {
        DataTable tbl = Util.LoadDataTable("Northwind", "Customers", "SELECT CustomerID, CompanyName FROM Customers");
        //Create a DataView and display its contents
        //Using DataRowViews and a for loop with the Count property
        DataView vue = new DataView(tbl);
        DataRowView row;
        for (int intCounter = 0; intCounter < vue.Count; intCounter++)
        {
          row = vue[intCounter];
          Console.WriteLine(row["CompanyName"]);
        }
        Console.WriteLine();
      }
    }
  }
}
