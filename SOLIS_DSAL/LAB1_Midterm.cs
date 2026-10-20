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
    public partial class LAB1_Midterm : Form
    {
        public LAB1_Midterm()
        {
            InitializeComponent();
        }

        private void LAB1_Midterm_Load(object sender, EventArgs e)
        {
            DataTable students = new DataTable();
            //create datagridview columns
            students.Columns.Add("ID", typeof(int));
            students.Columns.Add("Name", typeof(string));
            students.Columns.Add("Course", typeof(string));

            //add sample data
            students.Rows.Add("1001", "Juan Dela Cruz", "BSIT");
            students.Rows.Add("1002", "Maria Santos", "BSCS");
            students.Rows.Add("1003", "Pedro Reyes", "BSIS");
            students.Rows.Add("1004", "Ana Garcia", "BSIT");
            students.Rows.Add("1005", "Carlo Mendoza", "BSCS");
            dataGridView1.DataSource = students;
        }

        private void btnSearch_Click(object sender, EventArgs e)
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
                    dataGridView1.Rows[i].Cells["Name"].Value?.ToString() ?? "";

                if (studentName.Equals(searchValue,
                    StringComparison.OrdinalIgnoreCase))
                {
                    //select the matching row
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;

                    //move datagridview to the matching record
                    dataGridView1.CurrentCell =
                        dataGridView1.Rows[i].Cells["Name"];

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            runSearch(SentinelSearch);
        }

        private void runSearch(Func<DataTable, string, int> search)
        {
            var table = (DataTable)dataGridView1.DataSource;
            int index = search(table, txtSearch.Text.Trim());
            dataGridView1.ClearSelection();
            if (index >= 0)
            {
                dataGridView1.Rows[index].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = index;
            }
            MessageBox.Show(index < 0 ? "Not Found" : "Found!");
        }

        private int SentinelSearch(DataTable table, string key)
        {
            var names = table.AsEnumerable()
                 .Select(r => r["Name"].ToString())
                 .ToList();

            int originalCount = names.Count;
            names.Add(key);
            int i = 0;
            while (!string.Equals(names[i], key, StringComparison.OrdinalIgnoreCase))
                i++;

            return i < originalCount ? i : -1;
        }
    }
}
