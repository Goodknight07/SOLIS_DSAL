using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOLIS_DSAL
{
    public partial class SOLIS_QUIZ1 : Form
    {
        string connectionstring = null;
        SqlConnection connection;
        SqlCommand command;
        DataSet dset;
        SqlDataAdapter adaptersql;
        string sql = null;

        public SOLIS_QUIZ1()
        {
            connectionstring = "Data Source = C203-03; Initial Catalog = QUIZ1DSAL; user id = SA; password = B1Admin123@";
            connection = new SqlConnection(connectionstring);
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SOLIS_QUIZ1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
                connection.Open();
                sql = "INSERT INTO Quiz1Tbl (product_name, expiration_date) VALUES ('" + ProductNTxtbox.Text + "', ' " + ExpirationDTxtbox.Text + "')";
                command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;
                adaptersql = new SqlDataAdapter();
                adaptersql.InsertCommand = command;
                command.ExecuteNonQuery();
                sql = "SELECT * FROM Quiz1Tbl";
                command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;
                adaptersql = new SqlDataAdapter();
                adaptersql.SelectCommand = command;
                command.ExecuteNonQuery();
                dset = new DataSet();
                adaptersql.Fill(dset, "studentTbl");

                ProductNTxtbox.Clear();
                ExpirationDTxtbox.Clear();

                connection.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
       
        }

        private void ProductNTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ExpirationDTxtbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ProductNTxtbox_MouseClick(object sender, MouseEventArgs e)
        {
           
                if (ProductNTxtbox.Text == "555 Tuna")
                    ExpirationDTxtbox.Text = "June 2025";

                else if (ProductNTxtbox.Text == "Century Tuna")
                    ExpirationDTxtbox.Text = "June 2026";

                else if (ProductNTxtbox.Text == "Cofeelol")
                    ExpirationDTxtbox.Text = "October 2024";

                else if (ProductNTxtbox.Text == "Jasmine Oil")
                    ExpirationDTxtbox.Text = "September 2025";

                else if (ProductNTxtbox.Text == "Sugarlol ")
                    ExpirationDTxtbox.Text = "June 2026";
                else
                {
                    MessageBox.Show("Product unavailable!");
                }

        }

        private void button1_Leave(object sender, EventArgs e)
        {
        
        }

        private void ProductNTxtbox_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
