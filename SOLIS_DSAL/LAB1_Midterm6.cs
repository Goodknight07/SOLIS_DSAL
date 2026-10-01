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
    public partial class LAB1_Midterm6 : Form
    {
        public LAB1_Midterm6()
        {
            InitializeComponent();
        }
        DataTable Table = new DataTable();
        private void LAB1_Midterm6_Load(object sender, EventArgs e)
        {
            Table.Columns.Add("ID");
            Table.Columns.Add("Name");
            Table.Columns.Add("Course");

            Table.Rows.Add("1001", "Juan Cruz", "BSIT");
            Table.Rows.Add("1002", "Maria Santos", "BSCS");
            Table.Rows.Add("1003", "Pedro Reyes", "BSIS");
            Table.Rows.Add("1004", "Ana Garcia", "BSIT");

            dataGridView1.DataSource = Table;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string target = txtSearch.Text.Trim();
            bool found = false;

            for(int i = 0; i < Table.Rows.Count; i++)
            {
                string name = Table.Rows[i]["Name"].ToString();

                if (name.Equals(target, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "Student found at record " + (i + 1));

                    found = true;
                    break;
                }
            }

            if (!found)
                MessageBox.Show("Student not found. ");
        }
    }
}
