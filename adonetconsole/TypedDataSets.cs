using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace adonetconsole
{
  class TypedDataSets
  {
    public static void Dispatch()
    {
      Two();
    }

    static void One()
    {
      {
        string strConn, strSQL;
        strConn = Util.Connection("Northwind");
        strSQL = "SELECT CustomerID, CompanyName FROM Customers; SELECT OrderID, CustomerID, OrderDate FROM Orders";
        SqlDataAdapter da = new SqlDataAdapter(strSQL, strConn);
        DataSet ds = new DataSet("NorthwindDataSet");
        da.TableMappings.Add("Table", "Customers");
        da.TableMappings.Add("Table1", "Orders");
        da.FillSchema(ds, SchemaType.Mapped);
        ds.Relations.Add("Customers_Orders", ds.Tables["Customers"].Columns["CustomerID"], ds.Tables["Orders"].Columns["CustomerID"]);
        ds.WriteXmlSchema(@"C:\dev\NorthwindDataSet.XSD");
        // xsd NorthwindDataSet.xsd /d
        Console.WriteLine();
      }
    }

    static void Two()
    {
      {
        NorthwindDataSet nwds = new NorthwindDataSet();

        string strConn, strSQL;
        strConn = Util.Connection("Northwind");
        strSQL = "SELECT CustomerID, CompanyName FROM Customers; SELECT OrderID, CustomerID, OrderDate FROM Orders";
        SqlDataAdapter da = new SqlDataAdapter(strSQL, strConn);
        da.Fill(nwds);

        NorthwindDataSet.CustomersDataTable tblCustomers = nwds.Customers;
        NorthwindDataSet.OrdersDataTable tblOrders = nwds.Orders;

        Console.WriteLine("rows: {0}", tblCustomers.Rows.Count);
        // add row to customers        
        NorthwindDataSet.CustomersRow rowCustomer = tblCustomers.NewCustomersRow();
        rowCustomer.CustomerID = "NEWCO";
        rowCustomer.CompanyName = "New Company";
        tblCustomers.AddCustomersRow(rowCustomer);
        tblCustomers.AddCustomersRow("NEWC2", "New Company 2");
        rowCustomer = tblCustomers.FindByCustomerID("NEWC2");
        if (rowCustomer == null)
          Console.WriteLine("row not found");
        else
          Console.WriteLine("row found: {0}", rowCustomer.CompanyName);

        foreach (NorthwindDataSet.CustomersRow customer in nwds.Customers)
        {
          Console.WriteLine("Orders for {0}", customer.CompanyName);
          foreach (NorthwindDataSet.OrdersRow rowOrder in customer.GetOrdersRows())
            Console.WriteLine("    {0} - {1:d}", rowOrder.OrderID, rowOrder.OrderDate);
        }
      }
    }
  }
}