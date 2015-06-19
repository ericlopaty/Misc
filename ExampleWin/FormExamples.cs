using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExampleWin
{
    public partial class FormExamples : Form
    {
        private DataSet ds;
        private SqlConnection cn;
        private string sql;
        private string connect = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\docs\dev\sqlserver\scratch.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
                
        public FormExamples()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn = new SqlConnection(connect);
            cn.Open();
            sql = "SELECT * FROM customer ORDER BY customer_name";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            ds = new DataSet();
            da.Fill(ds, "customer");
            dataGrid.DataSource = ds.Tables["customer"].DefaultView;
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da1, da2;
            cn = new SqlConnection(connect);
            cn.Open();
            ds = new DataSet();

            sql = "SELECT * FROM customer";
            da1 = new SqlDataAdapter(sql, cn);
            da1.TableMappings.Add("Table","customer");
            da1.Fill(ds, "customer");
            
            sql = "SELECT * FROM account";
            da2 = new SqlDataAdapter(sql, cn);
            da2.TableMappings.Add("Table", "account");
            da2.Fill(ds, "account");

            DataColumn dc1 = ds.Tables["customer"].Columns["customer_id"];
            DataColumn dc2 = ds.Tables["account"].Columns["customer_id"];
            DataRelation dr = new DataRelation("CustomerToAccount", dc1, dc2);
            ds.Relations.Add(dr);

            DataViewManager dsView = ds.DefaultViewManager;
            dataGrid.DataSource = dsView;
            dataGrid.DataMember = "customer";
            cn.Close();
        }
    }
}
