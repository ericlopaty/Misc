using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace adonetconsole
{
  class Updates
  {
    public static void Dispatch()
    {
      Two();
    }

    static void One()
    {
      //Retrieve the contents of the order into a DataTable.
      string strConn=Util.Connection("Northwind"), strSQL;
      strSQL = "SELECT OrderID, ProductID, Quantity, UnitPrice " +
               "FROM [Order Details] WHERE OrderID = @OrderID " +
               "ORDER BY ProductID;";
      SqlDataAdapter da = new SqlDataAdapter(strSQL, strConn);
      da.SelectCommand.Parameters.AddWithValue("@OrderID", 10503);
      DataTable tbl = new DataTable("Order Details");
      da.Fill(tbl);

      //Modify the contents of the order.
      DataRow rowToDelete, rowToUpdate, rowToInsert;
      //Delete the tofu DataRow
      rowToDelete = tbl.Rows[0];
      rowToDelete.Delete();
      //Double the quantity for hot sauce
      rowToUpdate = tbl.Rows[1];
      rowToUpdate["Quantity"] = (short)(rowToUpdate["Quantity"]) * 2;
      //Add a new DataRow for chai
      rowToInsert = tbl.Rows.Add(new object[] { 10503, 1, 24, 18 });

      //Submit the pending changes.
      try
      {
        da.Update(tbl);
        Console.WriteLine("Successfully submitted new changes");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Call to SqlDataAdapter.Update " +
                          "threw exception: {0}", ex.Message);
      }
    }

    static void Two()
    {
      DisplayOrder();
    }

    static void DisplayOrder()
    {
      string strConn, strSQL;
      strConn = Util.Connection("Northwind");
      using (SqlConnection cn = new SqlConnection(strConn))
      {
        cn.Open();

        strSQL = "SELECT P.ProductName, D.Quantity, D.UnitPrice " +
                 "  FROM [Order Details] D JOIN Products P " +
                 "       ON D.ProductID = P.ProductID " +
                 "  WHERE D.OrderID = @OrderID";
        int intOrderID = 10503;
        SqlCommand cmd = new SqlCommand(strSQL, cn);
        cmd.Parameters.AddWithValue("@OrderID", intOrderID);

        Console.WriteLine("Contents of order {0}", intOrderID);
        using (SqlDataReader rdr = cmd.ExecuteReader())
        {
          while (rdr.Read())
            Console.WriteLine("  {0,-32}   {1}   {2:c}",
                              rdr.GetString(0), rdr.GetInt16(1),
                              rdr.GetDecimal(2));
          rdr.Close();
        }
        Console.WriteLine();

        cn.Close();
      }
    }

    static void ResetOrder()
    {
      //Reset the order.
      string strConn, strSQL;
      strConn = Util.Connection("Northwind"); 
      using (SqlConnection cn = new SqlConnection(strConn))
      {
        cn.Open();

        //Delete the current contents of the order
        strSQL = "DELETE [Order Details] WHERE OrderID = @OrderID";
        SqlCommand cmd = new SqlCommand(strSQL, cn);
        cmd.Parameters.AddWithValue("@OrderID", 10503);
        cmd.ExecuteNonQuery();

        strSQL = "INSERT INTO [Order Details] " +
                 "  (OrderID, ProductID, Quantity, UnitPrice) VALUES " +
                 "  (@OrderID, @ProductID, @Quantity, @UnitPrice)";
        cmd.CommandText = strSQL;

        //Re-add the tofu
        cmd.Parameters.AddWithValue("@ProductID", 14);
        cmd.Parameters.AddWithValue("@Quantity", 70);
        cmd.Parameters.AddWithValue("@UnitPrice", 23.25);
        cmd.ExecuteNonQuery();

        //Re-add the hot sauce
        cmd.Parameters["@ProductID"].Value = 65;
        cmd.Parameters["@Quantity"].Value = 20;
        cmd.Parameters["@UnitPrice"].Value = 21.05;
        cmd.ExecuteNonQuery();

        cn.Close();
      }
    }

    static void Three()
    {
      SqlParameterCollection pc;
      SqlParameter p;
      //Set the InsertCommand
      strSQL = "INSERT INTO [Order Details] " +
               "  (OrderID, ProductID, Quantity, UnitPrice) VALUES " +
               "  (@OrderID, @ProductID, @Quantity, @UnitPrice)";
      da.InsertCommand = new SqlCommand(strSQL, cn);
      pc = da.InsertCommand.Parameters;
      pc.Add("@OrderID", SqlDbType.Int, 0, "OrderID");
      pc.Add("@ProductID", SqlDbType.Int, 0, "ProductID");
      pc.Add("@Quantity", SqlDbType.SmallInt, 0, "Quantity");
      pc.Add("@UnitPrice", SqlDbType.Money, 0, "UnitPrice");

      //Set the UpdateCommand
      strSQL = "UPDATE [Order Details] " +
               "  SET OrderID = @OrderID_New, ProductID = @ProductID_New, " +
               "      Quantity = @Quantity_New, UnitPrice = @UnitPrice_New " +
               "  WHERE OrderID = @OrderID_Old AND ProductID = @ProductID_Old " +
               "    AND Quantity = @Quantity_Old AND UnitPrice = @UnitPrice_Old";
      da.UpdateCommand = new SqlCommand(strSQL, cn);
      pc = da.UpdateCommand.Parameters;
      pc.Add("@OrderID_New", SqlDbType.Int, 0, "OrderID");
      pc.Add("@ProductID_New", SqlDbType.Int, 0, "ProductID");
      pc.Add("@Quantity_New", SqlDbType.SmallInt, 0, "Quantity");
      pc.Add("@UnitPrice_New", SqlDbType.Money, 0, "UnitPrice");
      p = pc.Add("@OrderID_Old", SqlDbType.Int, 0, "OrderID");
      p.SourceVersion = DataRowVersion.Original;
      p = pc.Add("@ProductID_Old", SqlDbType.Int, 0, "ProductID");
      p.SourceVersion = DataRowVersion.Original;
      p = pc.Add("@Quantity_Old", SqlDbType.SmallInt, 0, "Quantity");
      p.SourceVersion = DataRowVersion.Original;
      p = pc.Add("@UnitPrice_Old", SqlDbType.Money, 0, "UnitPrice");
      p.SourceVersion = DataRowVersion.Original;

      //Set the DeleteCommand
      strSQL = "DELETE [Order Details] " +
               "  WHERE OrderID = @OrderID AND ProductID = @ProductID " +
               "    AND Quantity = @Quantity AND UnitPrice = @UnitPrice";
      da.DeleteCommand = new SqlCommand(strSQL, cn);
      pc = da.DeleteCommand.Parameters;
      p = pc.Add("@OrderID", SqlDbType.Int, 0, "OrderID");
      p.SourceVersion = DataRowVersion.Original;
      p = pc.Add("@ProductID", SqlDbType.Int, 0, "ProductID");
      p.SourceVersion = DataRowVersion.Original;
      p = pc.Add("@Quantity", SqlDbType.SmallInt, 0, "Quantity");
      p.SourceVersion = DataRowVersion.Original;
      p = pc.Add("@UnitPrice", SqlDbType.Money, 0, "UnitPrice");
      p.SourceVersion = DataRowVersion.Original;
    }

    static void ThreeA()
    {
      //Create the stored procedures
      CreateSprocs(cn);

      SqlParameterCollection pc;
      SqlParameter p;

      //Set the InsertCommand
      da.InsertCommand = new SqlCommand("procInsertDetail", cn);
      da.InsertCommand.CommandType = CommandType.StoredProcedure;
      pc = da.InsertCommand.Parameters;
      pc.Add("@OrderID", SqlDbType.Int, 0, "OrderID");
      pc.Add("@ProductID", SqlDbType.Int, 0, "ProductID");
      pc.Add("@Quantity", SqlDbType.SmallInt, 0, "Quantity");
      pc.Add("@UnitPrice", SqlDbType.Money, 0, "UnitPrice");

      //Set the UpdateCommand
      da.UpdateCommand = new SqlCommand("procUpdateDetail", cn);
      da.UpdateCommand.CommandType = CommandType.StoredProcedure;
      pc = da.UpdateCommand.Parameters;
      pc.Add("@OrderID_New", SqlDbType.Int, 0, "OrderID");
      pc.Add("@ProductID_New", SqlDbType.Int, 0, "ProductID");
      pc.Add("@Quantity_New", SqlDbType.SmallInt, 0, "Quantity");
      pc.Add("@UnitPrice_New", SqlDbType.Money, 0, "UnitPrice");
      p = pc.Add("@OrderID_Old", SqlDbType.Int, 0, "OrderID");
      p.SourceVersion = DataRowVersion.Original;
      p = pc.Add("@ProductID_Old", SqlDbType.Int, 0, "ProductID");
      p.SourceVersion = DataRowVersion.Original;
      p = pc.Add("@Quantity_Old", SqlDbType.SmallInt, 0, "Quantity");
      p.SourceVersion = DataRowVersion.Original;
      p = pc.Add("@UnitPrice_Old", SqlDbType.Money, 0, "UnitPrice");
      p.SourceVersion = DataRowVersion.Original;

      //Set the DeleteCommand
      da.DeleteCommand = new SqlCommand("procDeleteDetail", cn);
      da.DeleteCommand.CommandType = CommandType.StoredProcedure;
      pc = da.DeleteCommand.Parameters;
      p = pc.Add("@OrderID", SqlDbType.Int, 0, "OrderID");
      p.SourceVersion = DataRowVersion.Original;
      p = pc.Add("@ProductID", SqlDbType.Int, 0, "ProductID");
      p.SourceVersion = DataRowVersion.Original;
      p = pc.Add("@Quantity", SqlDbType.SmallInt, 0, "Quantity");
      p.SourceVersion = DataRowVersion.Original;
      p = pc.Add("@UnitPrice", SqlDbType.Money, 0, "UnitPrice");
      p.SourceVersion = DataRowVersion.Original;
    }

    static void CreateSprocs(SqlConnection cn)
    {
      SqlCommand cmd = cn.CreateCommand();
      string strSQL;

      //Drop any pre-existing stored procedures with these names
      cmd.CommandText = "DROP PROCEDURE procInsertDetail";
      try { cmd.ExecuteNonQuery(); }
      catch { }
      cmd.CommandText = "DROP PROCEDURE procUpdateDetail";
      try { cmd.ExecuteNonQuery(); }
      catch { }
      cmd.CommandText = "DROP PROCEDURE procDeleteDetail";
      try { cmd.ExecuteNonQuery(); }
      catch { }

      strSQL = "CREATE PROCEDURE procInsertDetail " +
               "    (@OrderID int, @ProductID int, " +
               "     @Quantity smallint, @UnitPrice money) AS " +
               "INSERT INTO [Order Details] " +
               "    (OrderID, ProductID, Quantity, UnitPrice) " +
               "    VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice)";
      cmd.CommandText = strSQL;
      cmd.ExecuteNonQuery();

      strSQL = "CREATE PROCEDURE procUpdateDetail " +
               "    (@OrderID_New int, @ProductID_New int, " +
               "     @Quantity_New smallint, @UnitPrice_New money, " +
               "     @OrderID_Old int, @ProductID_Old int, " +
               "     @Quantity_Old smallint, @UnitPrice_Old money) AS " +
               "UPDATE [Order Details] " +
               "    SET OrderID = @OrderID_New, " +
               "        ProductID = @ProductID_New, " +
               "        Quantity = @Quantity_New, " +
               "        UnitPrice = @UnitPrice_New " +
               "    WHERE OrderID = @OrderID_Old AND " +
               "          ProductID = @ProductID_Old AND " +
               "          Quantity = @Quantity_Old AND " +
               "          UnitPrice = @UnitPrice_Old";
      cmd.CommandText = strSQL;
      cmd.ExecuteNonQuery();

      strSQL = "CREATE PROCEDURE procDeleteDetail " +
               "    (@OrderID int, @ProductID int, " +
               "     @Quantity smallint, @UnitPrice money) AS " +
               "DELETE FROM [Order Details] " +
               "    WHERE OrderID = @OrderID AND " +
               "          ProductID = @ProductID AND " +
               "          Quantity = @Quantity AND UnitPrice = @UnitPrice";
      cmd.CommandText = strSQL;
      cmd.ExecuteNonQuery();
    }
  }
}
