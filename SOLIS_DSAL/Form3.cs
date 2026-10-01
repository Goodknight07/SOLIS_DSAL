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
using System.Data.SqlClient;

namespace SOLIS_DSAL
{
    public partial class Form3 : Form
    {
        string picturepath;
        string connectionstring = null;
        SqlConnection connection;
        SqlCommand command;
        DataSet dset;
        SqlDataAdapter adaptersql;
        string sql = null;

        public Form3()
        {
            InitializeComponent();

            connectionstring = "Data Source = C203-03; Initial Catalog = DSAL_Db; user id = SA; password = B1Admin123@";
            connection = new SqlConnection(connectionstring);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlDataAdapter adaptersql = new SqlDataAdapter("SELECT * FROM Employee_Tbl1", connection);
                DataTable table = new DataTable();
                adaptersql.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();
            bool found = false;

            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                if (dataGridView1.Rows[row].IsNewRow)
                    continue;

                for (int col = 0; col < dataGridView1.Columns.Count; col++)
                {
                    string value =
                        dataGridView1.Rows[row].Cells[col].Value?.ToString() ?? "";

                    if (value.Equals(searchValue, StringComparison.OrdinalIgnoreCase))
                    {
                        dataGridView1.ClearSelection();

                        dataGridView1.Rows[row].Selected = true;
                        dataGridView1.CurrentCell =
                            dataGridView1.Rows[row].Cells[col];

                        MessageBox.Show(
                            "Record found at row " + (row + 1));

                        found = true;
                        break;
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LAB1_Midterm example1 = new LAB1_Midterm();
            example1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LAB1_Midterm2 example2 = new LAB1_Midterm2();
            example2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LAB1_Midterm3 example3 = new LAB1_Midterm3();
            example3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LAB1_Midterm4 example4 = new LAB1_Midterm4();
            example4.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LAB1_Midterm5 example5 = new LAB1_Midterm5();
            example5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LAB1_Midterm6 example6 = new LAB1_Midterm6();
            example6.Show();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form2 update = new Form2();
            update.Show();
        }
    }
}
