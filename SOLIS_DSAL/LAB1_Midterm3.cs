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
    public partial class LAB1_Midterm3 : Form
    {
        public LAB1_Midterm3()
        {
            InitializeComponent();
        }

        private void LAB1_Midterm3_Load(object sender, EventArgs e)
        {
            //create datagridview columns
            dataGridView1.Columns.Add("EmployeeID", "Employee ID");
            dataGridView1.Columns.Add("EmployeeName", "Employee Name");
            dataGridView1.Columns.Add("Department", "Department");
            dataGridView1.Columns.Add("Position", "Position");

            //add sample data
            dataGridView1.Rows.Add("1001", "Juan Dela Cruz", "CEA", "Front Desk");
            dataGridView1.Rows.Add("1002", "Maria Santos", "CFAD", "Project Head");
            dataGridView1.Rows.Add("1003", "Pedro Reyes", "CLAE", "Finance");
            dataGridView1.Rows.Add("1004", "Ana Garcia", "TTM", "Admin");
            dataGridView1.Rows.Add("1005", "Carlo Mendoza", "CTH", "Adviser");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtSearch.Text.Trim();
            bool found = false;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow)
                    continue;

                string employeeName =
                    dataGridView1.Rows[i].Cells["EmployeeName"].Value?.ToString() ?? "";

                if(employeeName.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    string id =
                        dataGridView1.Rows[i].Cells["EmployeeID"].Value?.ToString() ?? "";

                    string department =
                        dataGridView1.Rows[i].Cells["Department"].Value?.ToString() ?? "";

                    string position =
                        dataGridView1.Rows[i].Cells["Position"].Value?.ToString() ?? "";

                    MessageBox.Show(
                        "Employee Found\n\n" +
                        "ID: " + id +
                        "\nName: " + employeeName +
                        "\nDepartment: " + department +
                        "\nPosition: " + position);

                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;

                    found = true;
                    break;
                }
            }

            if (!found)
                MessageBox.Show("Employee not found.");
        }
    }
}
