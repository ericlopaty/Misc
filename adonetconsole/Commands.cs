using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading;

namespace adonetconsole
{
  class Commands
  {
    public static void InfoMessage()
    {
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        cn.StateChange += new StateChangeEventHandler(OnStateChange);
        cn.InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);
        cn.Open();
        string sql = "print 'hello, world'";
        SqlCommand cmd = cn.CreateCommand();
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        int i = cmd.ExecuteNonQuery();
        Console.WriteLine("{0} rows affected", i);
      }
    }

    static void OnInfoMessage(object sender, SqlInfoMessageEventArgs e)
    {
      Console.WriteLine("MESSAGE: {0}", e.Message);
    }

    static void OnStateChange(object sender, StateChangeEventArgs e)
    {
      Console.WriteLine("CONNECTION: {0} --> {1}", e.OriginalState, e.CurrentState);
    }

    private static void ExecScalar()
    {
      Console.WriteLine("execute scalar");
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        cn.Open();
        string sql = "SELECT Count(*) FROM Customers";
        using (SqlCommand cmd = new SqlCommand(sql, cn))
        {
          int i = (int)cmd.ExecuteScalar();
          Console.WriteLine("Customers: {0}", i);
        }
        Console.WriteLine();
      }
    }

    private static void ExecReader()
    {
      Console.WriteLine("execute reader");
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        cn.Open();
        using (SqlCommand cmd = cn.CreateCommand())
        {
          string sql = "SELECT CustomerID, CompanyName FROM Customers";
          cmd.CommandText = sql;
          cmd.CommandType = CommandType.Text;
          using (SqlDataReader rdr = cmd.ExecuteReader())
          {
            Util.DumpReader(rdr);
          }
        }
      }
    }

    private static void ExecNonQuery()
    {
      Console.WriteLine("execute nonquery");
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        string sql;
        int i;
        cn.Open();
        using (SqlCommand cmd = cn.CreateCommand())
        {
          cmd.CommandType = CommandType.Text;
          sql = "INSERT INTO Customers (CustomerID, CompanyName) VALUES ('NewID', 'NewCustomer')";
          cmd.CommandText = sql;
          i = cmd.ExecuteNonQuery();
          Console.WriteLine("{0} rows inserted", i);

          sql = "UPDATE Customers SET CompanyName = 'NewCompanyName' WHERE CustomerID = 'NewID'";
          cmd.CommandText = sql;
          i = cmd.ExecuteNonQuery();
          Console.WriteLine("{0} rows updated", i);

          sql = "DELETE FROM Customers WHERE CustomerID = 'NewID'";
          cmd.CommandText = sql;
          i = cmd.ExecuteNonQuery();
          Console.WriteLine("{0} rows deleted", i);
        }
      }
    }

    private static void ExecBatches()
    {
      Console.WriteLine("execute batches");
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        cn.Open();
        string sql =
          "INSERT INTO Customers (CustomerID, CompanyName) VALUES ('NewID', 'NewCustomer'); " +
          "UPDATE Customers SET CompanyName = 'NewCompanyName' WHERE CustomerID = 'NewID'; " +
          "DELETE FROM Customers WHERE CustomerID = 'NewID'";
        using (SqlCommand cmd = new SqlCommand(sql, cn))
        {
          cmd.StatementCompleted += new StatementCompletedEventHandler(OnStatementCompleted);
          int total = cmd.ExecuteNonQuery();
          Console.WriteLine("{0} total rows affected", total);
        }
      }
    }

    static void OnStatementCompleted(object sender, StatementCompletedEventArgs e)
    {
      Console.WriteLine("{0} rows affected", e.RecordCount);
    }

    private static void ExecTransaction()
    {
      Console.WriteLine("transaction");
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        cn.Open();
        string sql = "UPDATE Products SET UnitPrice = UnitPrice * .7 WHERE CategoryID = 1";
        using (SqlTransaction tran = cn.BeginTransaction())
        {
          using (SqlCommand cmd = new SqlCommand(sql, cn, tran))
          {
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} rows affected", i);
            tran.Rollback();
          }
        }
      }
    }

    private static void ExecSingleAsync()
    {
      Console.WriteLine("asynchronous query");
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        cn.Open();
        string sql = "WAITFOR DELAY '00:00:20'; SELECT CustomerID, CompanyName FROM Customers";
        using (SqlCommand cmd = new SqlCommand(sql, cn))
        {
          IAsyncResult result = cmd.BeginExecuteReader();
          while (!result.IsCompleted)
          {
            Console.Write(".");
            result.AsyncWaitHandle.WaitOne(1000, false);
          }
          Console.WriteLine();
          SqlDataReader rdr = cmd.EndExecuteReader(result);
          Util.DumpReader(rdr);
        }
      }
    }

    private static void ExecMultipleAsync()
    {
      Console.WriteLine("multiple asynchronous queries");
      SqlConnection cnCustomers, cnOrders;
      SqlCommand cmdCustomers, cmdOrders;
      IAsyncResult[] iasyncResults = new IAsyncResult[2];
      WaitHandle[] waitHandles = new WaitHandle[2];
      string sql;

      cnCustomers = new SqlConnection(Util.Connection("Northwind"));
      cnOrders = new SqlConnection(Util.Connection("Northwind"));
      cnCustomers.Open();
      cnOrders.Open();

      sql = "WAITFOR DELAY '00:00:10'; SELECT TOP 10 CustomerID FROM Customers";
      cmdCustomers = new SqlCommand(sql, cnCustomers);
      iasyncResults[0] = cmdCustomers.BeginExecuteReader(null, cmdCustomers, CommandBehavior.CloseConnection);
      waitHandles[0] = iasyncResults[0].AsyncWaitHandle;

      sql = "WAITFOR DELAY '00:00:05'; SELECT TOP 10 OrderID FROM Orders";
      cmdOrders = new SqlCommand(sql, cnOrders);
      iasyncResults[1] = cmdOrders.BeginExecuteReader(null, cmdOrders, CommandBehavior.CloseConnection);
      waitHandles[1] = iasyncResults[1].AsyncWaitHandle;

      for (int i = 0; i < waitHandles.Length; i++)
      {
        int x = WaitHandle.WaitAny(waitHandles);
        SqlCommand cmd = (SqlCommand)iasyncResults[x].AsyncState;
        Console.WriteLine(cmd.CommandText);
        using (SqlDataReader rdr = cmd.EndExecuteReader(iasyncResults[x]))
        {
          Util.DumpReader(rdr);
        }
      }
    }

    // try in winform app
    //static void ExecAsyncCallBack()
    //{
    //  using (SqlConnection cn = new SqlConnection(connect))
    //  {
    //    cn.Open();
    //    string sql = "WAITFOR DELAY '00:00:10'; SELECT TOP 10 CustomerID FROM Customers";
    //    using (SqlCommand cmd = new SqlCommand(sql, cn))
    //    {
    //      AsyncCallback callBack = new AsyncCallback(MyAsyncCallback);
    //      cmd.BeginExecuteReader(callBack, cmd, CommandBehavior.CloseConnection);
    //    }
    //  }
    //}

    // try in winform app
    //static void MyAsyncCallback(IAsyncResult result)
    //{
    //  SqlCommand cmd = (SqlCommand)result.AsyncState;
    //  using (SqlDataReader rdr = cmd.EndExecuteReader(result))
    //  {
    //    DumpReader(rdr);
    //  }
    //  queryComplete = true;
    //}

    static void DataReaderSchema()
    {
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        cn.Open();
        string sql = "SELECT OrderID, CustomerID, OrderDate, Freight FROM Orders";
        using (SqlCommand cmd = new SqlCommand(sql, cn))
        {
          using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
          {
            for (int i = 0; i < rdr.FieldCount; i++)
            {
              Console.WriteLine("Field #{0}, {1}", i, rdr.GetName(i));
              Console.WriteLine(" .NET Type: {0}", rdr.GetFieldType(i).Name);
              Console.WriteLine("   DB Type: {0}", rdr.GetDataTypeName(i));
              Console.WriteLine();
            }
          }
        }
      }
    }

    static void DataReaderSQLTypes()
    {
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        cn.Open();
        string sql = "SELECT OrderID, CustomerID, OrderDate, Freight FROM Orders";
        using (SqlCommand cmd = new SqlCommand(sql, cn))
        {
          using (SqlDataReader rdr = cmd.ExecuteReader())
          {
            while (rdr.Read())
            {
              DateTime d = (rdr.IsDBNull(2) ? new DateTime(1900, 1, 1) : rdr.GetDateTime(2));
              SqlDateTime d2 = rdr.GetSqlDateTime(2);
              Console.WriteLine("{0} {1}", d, d2);
            }
          }
        }
      }
    }

    static void DataReaderMultipleResults()
    {
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        cn.Open();
        string sql =
          "SELECT CustomerID, CompanyName FROM Customers; " +
          "SELECT OrderID, OrderDate FROM Orders; " +
          "SELECT OrderID, ProductID FROM [Order Details]";
        using (SqlCommand cmd = new SqlCommand(sql, cn))
        {
          using (SqlDataReader rdr = cmd.ExecuteReader())
          {
            do
            {
              while (rdr.Read())
                Console.WriteLine("{0} - {1}", rdr[0], rdr[1]);
              Console.WriteLine();
            } while (rdr.NextResult());
          }
        }
      }
    }

    static void ExecParameter()
    {
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        string sql = "SELECT OrderID, CustomerID, OrderDate, EmployeeID FROM Orders WHERE CustomerID = @CustomerID";
        cn.Open();
        using (SqlCommand cmd = new SqlCommand(sql, cn))
        {
          //cmd.Parameters.AddWithValue("@CustomerID", "ALFKI");
          //--
          //SqlParameter p = new SqlParameter("@CustomerID", SqlDbType.NVarChar, 5);
          //p.Value="ALFKI";
          //--
          SqlParameter p = new SqlParameter();
          p.ParameterName = "@CustomerID";
          p.Value = "ALFKI";
          cmd.Parameters.Add(p);
          //--
          using (SqlDataReader rdr = cmd.ExecuteReader())
          {
            while (rdr.Read())
              Console.WriteLine("OrderID: {0}    OrderDate: {1:d}", rdr.GetInt32(0), rdr.GetDateTime(2));
          }
        }
      }
    }

    static void ExecParamReturn()
    {
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        cn.Open();
        string sql = "SELECT @UnitPrice = UnitPrice, @UnitsInStock = UnitsInStock FROM Products WHERE ProductName = @ProductName";
        using (SqlCommand cmd = new SqlCommand(sql, cn))
        {
          SqlParameter pUnitPrice, pInStock, pProductName;
          pUnitPrice = cmd.Parameters.Add("@UnitPrice", SqlDbType.Money);
          pUnitPrice.Direction = ParameterDirection.Output;
          pInStock = cmd.Parameters.Add("@UnitsInStock", SqlDbType.NVarChar, 20);
          pInStock.Direction = ParameterDirection.Output;
          pProductName = cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 40);
          pProductName.Value = "Chai";
          cmd.ExecuteNonQuery();
          if (pUnitPrice.Value == DBNull.Value)
          {
            Console.WriteLine("No product found named {0}", pProductName.Value);
          }
          else
          {
            Console.WriteLine("Unit Price: {0}", pUnitPrice.Value);
            Console.WriteLine("In Stock:   {0}", pInStock.Value);
          }
        }
      }
    }

    static void ExecProc()
    {
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        cn.Open();
        cn.ChangeDatabase("firmwide");
        string sql = "get_next_id";
        using (SqlCommand cmd = new SqlCommand(sql, cn))
        {
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@id_type", "telecom");
          int i = (int)cmd.ExecuteScalar();
          Console.WriteLine("{0}", i);
        }
        sql = "get_next_id2";
        using (SqlCommand cmd = new SqlCommand(sql, cn))
        {
          cmd.CommandType = CommandType.StoredProcedure;
          SqlParameter pIdType = new SqlParameter();
          pIdType.ParameterName = "@id_type";
          pIdType.SqlDbType = SqlDbType.NVarChar;
          pIdType.Size = 50;
          pIdType.Value = "telecom";
          cmd.Parameters.Add(pIdType);
          SqlParameter pNextId = new SqlParameter();
          pNextId.ParameterName = "@next_id";
          pNextId.SqlDbType = SqlDbType.Int;
          pNextId.Direction = ParameterDirection.Output;
          cmd.Parameters.Add(pNextId);
          cmd.ExecuteNonQuery();
          Console.WriteLine("{0}", pNextId.Value);
        }
      }
    }

    static void GetQuerySchema()
    {
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        cn.Open();
        string sql = "SELECT * FROM Orders";
        using (SqlCommand cmd = new SqlCommand(sql, cn))
        {
          using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
          {
            DataTable tbl = rdr.GetSchemaTable();
            Console.WriteLine("ColumnName     SqlDbType  Length  Precision  Scale");
            Console.WriteLine("==========     =========  ======  =========  =====");
            foreach (DataRow row in tbl.Rows)
              Console.WriteLine("{0,-15} {1,-10} {2,3}        {3,3}      {4,3}",
                row["ColumnName"], (SqlDbType)row["ProviderType"],
                row["ColumnSize"], row["NumericPrecision"],
                row["NumericScale"]);
          }
        }
      }
    }
  }
}
