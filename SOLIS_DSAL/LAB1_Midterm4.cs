using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOLIS_DSAL
{
    public partial class LAB1_Midterm4 : Form
    {
        public LAB1_Midterm4()
        {
            InitializeComponent();
        }

        private void LAB1_Midterm4_Load(object sender, EventArgs e)
        {
            //create datagridview columns
            dataGridView1.Columns.Add("ID", " ID");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Course", "Course");
            dataGridView1.Columns.Add("Year", "Year");

            //add sample data
            dataGridView1.Rows.Add("1001", "Juan Dela Cruz", "BSIT", "1 ");
            dataGridView1.Rows.Add("1002", "Maria Santos", "BSCS", "2 ");
            dataGridView1.Rows.Add("1003", "Carlo Reyes", "BSIT", "3");
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
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

                    if(value.Equals(searchValue, StringComparison.OrdinalIgnoreCase))
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
    }
}
