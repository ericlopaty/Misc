using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CheckDBConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
                    csb.DataSource = tbServer.Text;
                    csb.InitialCatalog = "master";
                    csb.IntegratedSecurity = true;
                    if (tbLogin.Text.Length > 0)
                    {
                        csb.IntegratedSecurity = false;
                        csb.UserID = tbLogin.Text;
                        csb.Password = tbPassword.Text;
                    }
                    cn.ConnectionString = csb.ConnectionString;
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT @@VERSION";
                        cmd.Connection = cn;
                        cmd.CommandTimeout = 30;
                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                        {
                            reader.Read();
                            string version = reader.GetString(0);
                            tbResult.Text = version;
                            reader.Close();
                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                tbResult.Text = ex.Message;
            }
        }
    }
}
