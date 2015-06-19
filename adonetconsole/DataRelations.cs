using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace adonetconsole
{
  class DataRelations
  {
    public static void Dispatch()
    {
      Aggregates2();
    }

    static void GetChildAndParentRows()
    {
      //Create a new DataSet and add DataTable and DataColumn objects.
      DataSet ds = new DataSet();
      DataTable tbl;
      tbl = ds.Tables.Add("Customers");
      tbl.Columns.Add("CustomerID", typeof(string));
      tbl.Columns.Add("CompanyName", typeof(string));

      tbl = ds.Tables.Add("Orders");
      tbl.Columns.Add("OrderID", typeof(int));
      tbl.Columns.Add("CustomerID", typeof(string));
      tbl.Columns.Add("OrderDate", typeof(DateTime));

      //Add a DataRelation between the two tables.
      DataRelation rel;
      rel = ds.Relations.Add(
        "Customers_Orders",
        ds.Tables["Customers"].Columns["CustomerID"],
        ds.Tables["Orders"].Columns["CustomerID"]);

      //Fill the DataSet
      string sql =
        "SELECT CustomerID, CompanyName FROM Customers " +
        "  WHERE CustomerID LIKE 'A%';" +
        "SELECT OrderID, CustomerID, OrderDate FROM Orders " +
        "  WHERE CustomerID LIKE 'A%'";
      SqlDataAdapter da = new SqlDataAdapter(sql, Util.Connection("Northwind"));
      da.TableMappings.Add("Table", "Customers");
      da.TableMappings.Add("Table1", "Orders");
      da.Fill(ds);

      //Loop through the customers.
      foreach (DataRow rowCustomer in ds.Tables["Customers"].Rows)
      {
        Console.WriteLine("{0} - {1}", rowCustomer["CustomerID"],
                          rowCustomer["CompanyName"]);
        //Loop through the related orders.
        foreach (DataRow rowOrder in rowCustomer.GetChildRows(rel))
          Console.WriteLine(" {0} {1:MM/dd/yyyy}", rowOrder["OrderID"],
                            rowOrder["OrderDate"]);
        Console.WriteLine();
      }

      //Loop through the orders.
      {
        DataRow rowCustomer;
        foreach (DataRow rowOrder in ds.Tables["Orders"].Rows)
        {
          //Locate the related parent row.
          rowCustomer = rowOrder.GetParentRow("Customers_Orders");
          Console.WriteLine("{0} {1:MM/dd/yyyy} {2}",
            rowOrder["OrderID"], rowOrder["OrderDate"], rowCustomer["CompanyName"]);
        }
      }
    }

    static void MultipleColumnDataRelation()
    {
      DataSet ds = new DataSet();
      DataTable tblParent, tblChild;
      tblParent = ds.Tables["ParentTable"];
      tblParent.Columns.Add("ParentColumn1", typeof(string));
      tblParent.Columns.Add("ParentColumn2", typeof(string));
      tblChild = ds.Tables["ChildTable"];
      tblChild.Columns.Add("ChildColumn1", typeof(string));
      tblChild.Columns.Add("ChildColumn2", typeof(string));

      //Create arrays that reference the DataColumn objects
      //on which we'll base the new DataRelation.
      DataColumn[] colsParent, colsChild;
      colsParent = new DataColumn[] { tblParent.Columns["ParentColumn1"], tblParent.Columns["ParentColumn2"] };
      colsChild = new DataColumn[] { tblChild.Columns["ChildColumn1"], tblChild.Columns["ChildColumn2"] };
      //Create the new DataRelation.
      DataRelation rel;
      rel = new DataRelation("MultiColumnRelation", colsParent, colsChild);
      ds.Relations.Add(rel);
    }

    static void MultipleParentRows()
    {
      DataSet ds = new DataSet();
      DataTable tbl;
      tbl = ds.Tables.Add("Customers");
      tbl.Columns.Add("CustomerID", typeof(string));
      tbl.Columns.Add("CompanyName", typeof(string));

      tbl = ds.Tables.Add("Orders");
      tbl.Columns.Add("OrderID", typeof(int));
      tbl.Columns.Add("CustomerID", typeof(string));
      tbl.Columns.Add("OrderDate", typeof(DateTime));

      //Add a DataRelation between the two tables.
      ds.Relations.Add("Customers_Orders",
        ds.Tables["Orders"].Columns["CustomerID"],
        ds.Tables["Customers"].Columns["CustomerID"], false);

      //Fill the DataSet
      string sql =
        "SELECT CustomerID, CompanyName FROM Customers " +
        " WHERE CustomerID LIKE 'A%';" +
        "SELECT OrderID, CustomerID, OrderDate FROM Orders " +
        " WHERE CustomerID LIKE 'A%'";
      SqlDataAdapter da = new SqlDataAdapter(sql, Util.Connection("Northwind"));
      da.TableMappings.Add("Table", "Customers");
      da.TableMappings.Add("Table1", "Orders");
      da.Fill(ds);

      //Loop through the customers.
      foreach (DataRow rowCustomer in ds.Tables["Customers"].Rows)
      {
        Console.WriteLine("{0} - {1}", rowCustomer["CustomerID"],
                          rowCustomer["CompanyName"]);
        //Loop through the related orders.
        foreach (DataRow rowOrder
                         in rowCustomer.GetParentRows("Customers_Orders"))
          Console.WriteLine("  {0}  {1:MM/dd/yyyy}", rowOrder["OrderID"],
                            rowOrder["OrderDate"]);
        Console.WriteLine();
      }
    }

    static void Constraints()
    {
      //Create a new DataSet and add DataTable and DataColumn objects.
      DataSet ds = new DataSet();
      DataTable tbl;
      tbl = ds.Tables.Add("Customers");
      tbl.Columns.Add("CustomerID", typeof(string));
      tbl.Columns.Add("CompanyName", typeof(string));
      //tbl.PrimaryKey = new DataColumn[] { tbl.Columns["CustomerID"] };

      tbl = ds.Tables.Add("Orders");
      tbl.Columns.Add("OrderID", typeof(int));
      tbl.Columns.Add("CustomerID", typeof(string));
      tbl.Columns.Add("OrderDate", typeof(DateTime));
      //ForeignKeyConstraint fk = new ForeignKeyConstraint("FK_Customers_Orders", ds.Tables["Customers"].Columns["CustomerID"], tbl.Columns["CustomerID"]);
      //tbl.Constraints.Add(fk);

      //Add a DataRelation between the two tables.
      ds.Relations.Add("Customers_Orders",
                       ds.Tables["Customers"].Columns["CustomerID"],
                       ds.Tables["Orders"].Columns["CustomerID"]);

      Console.WriteLine("The parent DataTable has {0} constraint(s)",
                        ds.Tables["Customers"].Constraints.Count);
      Console.WriteLine("The child DataTable has {0} constraint(s)",
                        ds.Tables["Orders"].Constraints.Count);
    }

    static void OrgChart()
    {
      string strConn, strSQL;
      strConn = Util.Connection("Northwind");
      strSQL = "SELECT EmployeeID, LastName + ', ' + FirstName AS EmployeeName, ReportsTo FROM Employees";
      SqlDataAdapter da = new SqlDataAdapter(strSQL, strConn);
      DataSet ds = new DataSet();
      DataTable tbl = ds.Tables.Add("Employees");
      da.Fill(tbl);
      DataRelation rel = ds.Relations.Add("Manager_DirectReports", tbl.Columns["EmployeeID"], tbl.Columns["ReportsTo"]);
      //Display the employee hierarchy
      foreach (DataRow row in tbl.Rows)
        if (row.IsNull("ReportsTo"))
          DisplayRow(row, rel, "");
    }

    static void DisplayRow(DataRow row, DataRelation rel, string indent)
    {
      Console.WriteLine(indent + row["EmployeeName"]);
      foreach (DataRow rowChild in row.GetChildRows(rel))
        DisplayRow(rowChild, rel, indent + "    ");
    }

    static void Many2Many()
    {
      string strConn = Util.Connection("pubs"), strSQL;
      strSQL = "SELECT Au_ID, Au_LName, Au_FName FROM Authors;" +
               "SELECT Title_ID, Title FROM Titles;" +
               "SELECT Au_ID, Title_ID FROM TitleAuthor";
      SqlDataAdapter da = new SqlDataAdapter(strSQL, strConn);
      da.TableMappings.Add("Table", "Authors");
      da.TableMappings.Add("Table1", "Titles");
      da.TableMappings.Add("Table2", "TitleAuthor");

      DataSet ds = new DataSet();
      da.Fill(ds);

      ds.Relations.Add("Authors_TitleAuthor",
        ds.Tables["Authors"].Columns["Au_ID"],
        ds.Tables["TitleAuthor"].Columns["Au_ID"],
        false);

      ds.Relations.Add("Titles_TitleAuthor",
        ds.Tables["Titles"].Columns["Title_ID"],
        ds.Tables["TitleAuthor"].Columns["Title_ID"],
        false);

      foreach (DataRow rowAuthor in ds.Tables["authors"].Rows)
      {
        Console.WriteLine("{0}, {1}", rowAuthor["Au_LName"], rowAuthor["Au_FName"]);
        foreach (DataRow rowTitleAuthor in rowAuthor.GetChildRows("Authors_TitleAuthor"))
        {
          DataRow rowTitle = rowTitleAuthor.GetParentRow("Titles_TitleAuthor");
          Console.WriteLine(" {0}", rowTitle["Title"]);
        }
        Console.WriteLine();
      }
    }

    static void Aggregates()
    {
      //Create and fill a DataSet with order information for a customer
      DataSet ds = new DataSet();
      string strConn = Util.Connection("Northwind"), strSQL;
      strSQL = 
        "SELECT OrderID, OrderDate FROM Orders WHERE CustomerID = 'ALFKI';" +
        "SELECT OD.OrderID, OD.ProductID, OD.UnitPrice, OD.Quantity " +
        "FROM [Order Details] OD, Orders O WHERE " +
        "OD.OrderID = O.OrderID AND O.CustomerID = 'ALFKI'";
      SqlDataAdapter da = new SqlDataAdapter(strSQL, strConn);
      da.TableMappings.Add("Table", "Orders");
      da.TableMappings.Add("Table1", "Order Details");
      da.Fill(ds);

      //Add expression-based columns
      DataRelation rel;
      rel = ds.Relations.Add("OrdersOrderDetails",
                             ds.Tables["Orders"].Columns["OrderID"],
                             ds.Tables["Order Details"].Columns["OrderID"]);

      ds.Tables["Order Details"].Columns.Add("ItemTotal", typeof(Decimal),
                                             "Quantity * UnitPrice");
      ds.Tables["Orders"].Columns.Add("NumItems", typeof(int),
                                      "Count(Child.ProductID)");
      ds.Tables["Orders"].Columns.Add("OrderTotal", typeof(Decimal),
                                      "Sum(Child.ItemTotal)");

      //Display data using the expression-based columns
      foreach (DataRow rowOrder in ds.Tables["Orders"].Rows)
      {
        Console.WriteLine("OrderID: {0} NumItems: {1} OrderTotal: {2:C}",
                          rowOrder["OrderID"], rowOrder["NumItems"],
                          rowOrder["OrderTotal"]);
        foreach (DataRow rowDetail in rowOrder.GetChildRows(rel))
          Console.WriteLine("  Quantity: {0,2}  UnitPrice: {1,7:C} " +
                            "ItemTotal: {2,7:C}", rowDetail["Quantity"],
                             rowDetail["UnitPrice"], rowDetail["ItemTotal"]);
        Console.WriteLine();
      }
    }

    static void Aggregates2()
    {
      //Create and fill a DataSet with author and title information
      string strConn = Util.Connection("pubs"), strSQL;
      strSQL = "SELECT Au_ID, Au_LName, Au_FName FROM Authors;" +
               "SELECT Title_ID, Title FROM Titles;" +
               "SELECT Au_ID, Title_ID FROM TitleAuthor";
      SqlDataAdapter da = new SqlDataAdapter(strSQL, strConn);
      da.TableMappings.Add("Table", "Authors");
      da.TableMappings.Add("Table1", "Titles");
      da.TableMappings.Add("Table2", "TitleAuthor");

      DataSet ds = new DataSet();
      da.Fill(ds);

      ds.Relations.Add("Authors_TitleAuthor",
                       ds.Tables["Authors"].Columns["Au_ID"],
                       ds.Tables["TitleAuthor"].Columns["Au_ID"],
                       false);

      ds.Relations.Add("Titles_TitleAuthor",
                       ds.Tables["Titles"].Columns["Title_ID"],
                       ds.Tables["TitleAuthor"].Columns["Title_ID"],
                       false);

      //Use expression based columns and the middle table in the
      //many-to-many relationship to display author and title information
      string strExpression;
      DataTable tbl = ds.Tables["TitleAuthor"];
      strExpression = "Parent(Titles_TitleAuthor).Title";
      tbl.Columns.Add("Title", typeof(string), strExpression);
      strExpression = "Parent(Authors_TitleAuthor).Au_LName + ', ' + " +
                      "Parent(Authors_TitleAuthor).Au_FName";
      tbl.Columns.Add("Author", typeof(string), strExpression);

      foreach (DataRow rowAuthor in ds.Tables["authors"].Rows)
      {
        Console.WriteLine("{0}, {1}", rowAuthor["Au_LName"],
                          rowAuthor["Au_FName"]);
        foreach (DataRow rowTitleAuthor in
                         rowAuthor.GetChildRows("Authors_TitleAuthor"))
          Console.WriteLine(" {0}", rowTitleAuthor["Title"]);
        Console.WriteLine();
      }
    }
  }
}
