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
        DataTable Table = new DataTable();
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

            string searchValue = txtSearch.Text.Trim();

            bool found = false;

            //sequential search
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //ignore the empty new row
                if (dataGridView1.Rows[1].IsNewRow)
                    continue;

                string studentName =
                    dataGridView1.Rows[i].Cells["last_name"].Value?.ToString() ?? "";

                if (studentName.Equals(searchValue,
                    StringComparison.OrdinalIgnoreCase))
                {
                    //select the matching row
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;

                    //move datagridview to the matching record
                    dataGridView1.CurrentCell =
                        dataGridView1.Rows[i].Cells["last_name"];

                    MessageBox.Show(
                        "Record found at row" + (i + 1),
                        "Sequential Search",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show(
                    "Record not found.",
                    "Sequential Search",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string searchName = txtSearch.Text.Trim();
            bool found = false;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow)
                    continue;

                string fist =
                    dataGridView1.Rows[i].Cells["first_name"].Value?.ToString() ?? "";

                if (fist.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    string middle =
                        dataGridView1.Rows[i].Cells["middle_name"].Value?.ToString() ?? "";

                    string last =
                        dataGridView1.Rows[i].Cells["last_name"].Value?.ToString() ?? "";

                    string id =
                        dataGridView1.Rows[i].Cells["employee_id"].Value?.ToString() ?? "";

                    MessageBox.Show(
                        "Employee Found\n\n" +
                        "First Name: " + fist +
                        "\nMiddle Name: " + middle +
                        "\nLast Name: " + last +
                        "\nID: " + id);

                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;

                    found = true;
                    break;
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string searchName = txtSearch.Text.Trim();
            bool found = false;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow)
                    continue;

                string middle =
                    dataGridView1.Rows[i].Cells["middle_name"].Value?.ToString() ?? "";

                if (middle.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    string first =
                        dataGridView1.Rows[i].Cells["first_name"].Value?.ToString() ?? "";

                    string last =
                        dataGridView1.Rows[i].Cells["last_name"].Value?.ToString() ?? "";

                    string id =
                        dataGridView1.Rows[i].Cells["employee_id"].Value?.ToString() ?? "";

                    MessageBox.Show(
                        "Employee Found\n\n" +
                        "First Name: " + first +
                        "\nMiddle Name: " + middle +
                        "\nLast Name: " + last +
                        "\nID: " + id);

                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;

                    found = true;
                    break;
                }
            }

            if (!found)
                MessageBox.Show("Employee not found.");
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            string searchCourse = txtSearch.Text.Trim();
            int count = 0;

            dataGridView1.ClearSelection();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow)
                    continue;

                string course =
                    dataGridView1.Rows[i].Cells["province"].Value?.ToString() ?? "";

                if (course.Equals(searchCourse,
                    StringComparison.OrdinalIgnoreCase))
                {
                    dataGridView1.Rows[i].Selected = true;
                    count++;
                }
            }

            if (count > 0)
            {
                MessageBox.Show(
                    count + " matching record(s) found.");
            }
            else
            {
                MessageBox.Show("No matching records found.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string target = txtSearch.Text.Trim();
            bool found = false;

            for (int i = 0; i < Table.Rows.Count; i++)
            {
                string id = Table.Rows[i]["employee_id"].ToString();

                if (id.Equals(target, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "Employee found at record " + (i + 1));

                    found = true;
                    break;
                }
            }

            if (!found)
                MessageBox.Show("Employee not found. ");
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (e.ColumnIndex == 0)
                {
                    Form2 activity1_c = new Form2();
                    activity1_c.Show();

                    activity1_c.showinfo(Convert.ToInt32(cellValue));
                    activity1_c.Activate();

                }

                else
                {
                    MessageBox.Show("Close Already Existing Window.");
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
