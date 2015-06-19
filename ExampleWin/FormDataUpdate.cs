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
    public partial class FormDataUpdate : Form
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\docs\dev\sqlserver\scratch.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTable dataTable;
        private string commandString = "SELECT * FROM customer ORDER BY customer_name";

        public FormDataUpdate()
        {
            InitializeComponent();
            dataAdapter = new SqlDataAdapter(commandString, connectionString);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "customer");
            PopulateLB();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            SqlConnection connection =
            (SqlConnection)dataAdapter.SelectCommand.Connection;

            dataAdapter.InsertCommand = connection.CreateCommand();
            dataAdapter.InsertCommand.CommandText =
                "INSERT customer(customer_id, customer_name, customer_taxid, customer_balance) " +
                "VALUES(@customer_id, @customer_name, @customer_taxid, @customer_balance)";
            dataAdapter.InsertCommand.Parameters.Add("@customer_id", SqlDbType.Char, 6, "customer_id");
            dataAdapter.InsertCommand.Parameters.Add("@customer_name", SqlDbType.NVarChar, 50, "customer_name");
            dataAdapter.InsertCommand.Parameters.Add("@customer_taxid", SqlDbType.Char, 11, "customer_taxid");
            dataAdapter.InsertCommand.Parameters.Add("@customer_balance", SqlDbType.Money, 8, "customer_balance");

            dataAdapter.UpdateCommand = connection.CreateCommand();
            dataAdapter.UpdateCommand.CommandText =
                "UPDATE customer " +
                "SET customer_name = @customer_name, customer_taxid = @customer_taxid, @customer_balance = @customer_balance " +
                "WHERE customer_id = @customer_id";
            dataAdapter.UpdateCommand.Parameters.Add("@customer_name", SqlDbType.NVarChar, 50, "customer_name");
            dataAdapter.UpdateCommand.Parameters.Add("@customer_taxid", SqlDbType.Char, 11, "customer_taxid");
            dataAdapter.UpdateCommand.Parameters.Add("@customer_balance", SqlDbType.Money, 8, "customer_balance");
            dataAdapter.UpdateCommand.Parameters.Add("@customer_id", SqlDbType.Char, 6, "customer_id");

            dataAdapter.DeleteCommand = connection.CreateCommand();
            dataAdapter.DeleteCommand.CommandText = "DELETE customer WHERE customer_id = @customer_id";
            dataAdapter.DeleteCommand.Parameters.Add("@customer_id", SqlDbType.Char, 6, "customer_id");
        }

        private void PopulateLB()
        {
            dataTable = dataSet.Tables[0];
            lbCustomer.Items.Clear();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                lbCustomer.Items.Add(dataRow["customer_name"] + " (" + dataRow["customer_id"] + ")");
            }
        }

        private void FormDataUpdate_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DataRow newRow = dataTable.NewRow();
            newRow["customer_id"] = tbCustomerId.Text;
            newRow["customer_name"] = tbCustomerName.Text;
            newRow["customer_taxid"] = tbTaxId.Text;
            newRow["customer_balance"] = tbBalance.Text;
            dataTable.Rows.Add(newRow);
            try
            {
                dataAdapter.Update(dataSet, "customer");
                dataSet.AcceptChanges();
                lblMessage.Text = "Updated!";
                Application.DoEvents();
                PopulateLB();
                ClearFields();
            }
            catch (SqlException ex)
            {
                dataSet.RejectChanges();
                MessageBox.Show(ex.Message);
            }

        }

        private void ClearFields()
        {
            tbCustomerId.Text = "";
            tbCustomerName.Text = "";
            tbTaxId.Text = "";
            tbBalance.Text = "";
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            PopulateLB();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRow targetRow = dataTable.Rows[lbCustomer.SelectedIndex];
            lblMessage.Text = "Updating " + targetRow["customer_name"];
            Application.DoEvents();
            targetRow.BeginEdit();
            targetRow["customer_name"] = tbCustomerName.Text;
            targetRow.EndEdit();
            DataSet dataSetChanged = dataSet.GetChanges(DataRowState.Modified);
            bool okayFlag = true;
            if (dataSetChanged.HasErrors)
            {
                okayFlag = false;
                string msg = "Error in row with customer ID ";
                foreach (DataTable theTable in dataSetChanged.Tables)
                {
                    if (theTable.HasErrors)
                    {
                        DataRow[] errorRows = theTable.GetErrors();
                        foreach (DataRow theRow in errorRows)
                        {
                            msg = msg + theRow["customer_id"];
                        }
                    }
                }
                lblMessage.Text = msg;
            }
            if (okayFlag)
            {
                dataAdapter.Update(dataSetChanged, "customer");
                lblMessage.Text = "Updated " + targetRow["customer_name"];
                Application.DoEvents();
                dataSet.AcceptChanges();
                PopulateLB();
            }
            else
                dataSet.RejectChanges();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow targetRow = dataTable.Rows[lbCustomer.SelectedIndex];
            string msg = targetRow["customer_name"] + " deleted. ";
            targetRow.Delete();
            try
            {
                dataAdapter.Update(dataSet, "customer");
                dataSet.AcceptChanges();
                PopulateLB();
                lblMessage.Text = msg;
                Application.DoEvents();
            }
            catch (SqlException ex)
            {
                dataSet.RejectChanges();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
