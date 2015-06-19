using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParamGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection cn;

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
            b.DataSource = tbServer.Text;
            b.InitialCatalog = tbDatabase.Text;
            b.IntegratedSecurity = true;
            cn = new SqlConnection(b.ConnectionString);
            cn.Open();
            DataTable procs = cn.GetSchema("Procedures");
            lbProcs.Items.Clear();
            for (int i = 0; i < procs.Rows.Count; i++)
                lbProcs.Items.Add(procs.Rows[i][2]);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = (string)lbProcs.SelectedItem;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);
            StringBuilder s = new StringBuilder();
            foreach (SqlParameter param in cmd.Parameters)
            {
                s.Append(param.ParameterName + "\n");
            }
            textBox1.Text = s.ToString();
        }
    }
}
