using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace adonet
{
  public partial class Form1 : Form
  {
    SqlConnection cn;
    SqlConnectionStringBuilder builder;
    SqlCommand cmd;
    //SqlTransaction tran;
    //DataSet ds;
    DataTable tbl;
    string sql;

    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      builder = new SqlConnectionStringBuilder();
      builder.DataSource = "(local)";
      builder.InitialCatalog = "Northwind";
      builder.IntegratedSecurity = true;
      builder.MinPoolSize = 0;
      builder.MaxPoolSize = 10;
      builder.Pooling = true;
      builder.AsynchronousProcessing = true;

      using (cn = new SqlConnection(builder.ConnectionString))
      {
        cn.InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);
        cn.StateChange += new StateChangeEventHandler(OnStateChange);
        cn.Open();
        //tran = cn.BeginTransaction();

        //SqlCommand cmd = cn.CreateCommand();
        //SqlCommand cmd = new SqlCommand(sql, cn);


        //cmd = cn.CreateCommand();
        //print handled by SqlInfoMessageEventHandler
        //cmd.CommandText = "PRINT 'Hello, ADO.NET'";
        //cmd.ExecuteNonQuery();
        
        //schema retrieval
        //tbl = cn.GetSchema("tables");
        //tbl = cn.GetSchema("tables");
        //string[] restrictions;
        //restrictions = new string[] { "Northwind", "dbo", "Customers", null };
        //tbl = cn.GetSchema("Columns", restrictions);
        //tbl = cn.GetSchema("restrictions");
        //dataGrid.DataSource=tbl;

        sql = "SELECT CustomerID, CompanyName FROM Customers";
        //cmd = new SqlCommand(strSQL, cn);
        cmd = cn.CreateCommand();
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cn;
        //int i = cmd.ExecuteNonQuery();
        //int i = (int)cmd.ExecuteScalar();
        //SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        //using (SqlDataReader rdr = cmd.ExecuteReader())
        //{
        //  while (rdr.Read())
        //  {
        //    lblMessage.Text = string.Format("{0}",rdr["CompanyName"]);
        //    Application.DoEvents();
        //  }
        //}

        sql = 
          "UPDATE Products SET UnitPrice = UnitPrice * 0.85 WHERE CategoryID = 3;" +
          "UPDATE Products SET UnitPrice = UnitPrice * 1.15 WHERE CategoryID = 4;" +
          "UPDATE Products SET UnitPrice = UnitPrice * 0.75  WHERE CategoryID = 5;";
        cmd.StatementCompleted += new StatementCompletedEventHandler(OnStatementCompleted);

        
        //tran.Commit();
        //cn.ChangeDatabase("firmwide");
        MessageBox.Show(cn.Database);
        tbl = cn.GetSchema("tables");
        dataGrid.DataSource = tbl;
      }
    }

    void OnInfoMessage(object sender, SqlInfoMessageEventArgs e)
    {
      lblMessage.Text = e.Message;
      Application.DoEvents();
    }

    void OnStateChange(object sender, StateChangeEventArgs e)
    {
      {
        lblState.Text = string.Format("StateChange from {0} to {1}", e.OriginalState, e.CurrentState);
        Application.DoEvents();
      }
    }

    static void OnStatementCompleted(object sender, StatementCompletedEventArgs e)
    {
      Console.WriteLine("Statement Affected {0} row(s)", e.RecordCount);
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      lbMessages.Items.Clear();
    }
  }
}
