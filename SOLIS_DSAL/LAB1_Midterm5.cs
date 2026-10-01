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
    public partial class LAB1_Midterm5 : Form
    {
        public LAB1_Midterm5()
        {
            InitializeComponent();
        }

        private void LAB1_Midterm5_Load(object sender, EventArgs e)
        {
            //create datagridview columns
            dataGridView1.Columns.Add("ID", "Student ID");
            dataGridView1.Columns.Add("Name", "Student Name");
            dataGridView1.Columns.Add("Course", "Course");

            //add sample data
            dataGridView1.Rows.Add("1001", "Juan Dela Cruz", "BSIT");
            dataGridView1.Rows.Add("1002", "Maria Santos", "BSCS");
            dataGridView1.Rows.Add("1003", "Pedro Reyes", "BSIS");
            dataGridView1.Rows.Add("1004", "Ana Garcia", "BSIT");
            dataGridView1.Rows.Add("1005", "Carlo Mendoza", "BSCS");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchCourse = txtSearch.Text.Trim();
            int count = 0;

            dataGridView1.ClearSelection();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow)
                    continue;

                string course =
                    dataGridView1.Rows[i].Cells["Course"].Value?.ToString() ?? "";

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
    }
}
