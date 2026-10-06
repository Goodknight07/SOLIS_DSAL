using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOLIS_DSAL
{
    public partial class Form2 : Form
    {
        string picturepath;
        string connectionstring = null;
        SqlConnection connection;
        SqlCommand command;
        DataSet dset;
        SqlDataAdapter adaptersql;
        string sql = null;
        public Form2()
        {
            InitializeComponent();
            connectionstring = "Data Source = C203-03; Initial Catalog = DSAL_Db; user id = SA; password = B1Admin123@";
            connection = new SqlConnection(connectionstring);
        }

        public void showinfo(int i)
        {
            connection.Open();
            sql = "SELECT * FROM Employee_Tbl1 WHERE employee_id = \'" + i + "\'";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();

            dset = new DataSet();
            adaptersql.Fill(dset, "Employee_Tbl");

            dataGridView1.DataSource = dset.Tables[0];

            if (dset.Tables[0].Rows.Count > 0)
            {
                DataRow row = dset.Tables[0].Rows[0];
                EIDtxtbox.Text = row["employee_id"].ToString();
                EFtxtbox.Text = row["first_name"].ToString();
                EMtxtbox.Text = row["middle_name"].ToString();
                ELtxtbox.Text = row["last_name"].ToString();
                EStxtbox.Text = row["suffix"].ToString();
                salutationsCMB.Text = row["salutation"].ToString();
                HouseTxtbox.Text = row["house_no"].ToString();
                BarangayTxtbox.Text = row["barangay"].ToString();
                CityTxtbox.Text = row["city"].ToString();
                ProvinceTxtbox.Text = row["province"].ToString();
                ZipTxtbox.Text = row["zip"].ToString();
                birthdayTxtbox.Text = row["birthday"].ToString();
                nationalityTxtbox.Text = row["nationality"].ToString();
                emailTxtbox.Text = row["email_address"].ToString();
                MobileNOTxtbox.Text = row["mobile_no"].ToString();
                JobtitleCMB.Text = row["job_title"].ToString();
                DepartmentCMB.Text = row["department"].ToString();
                StatusCMB.Text = row["emp_status"].ToString();

                connection.Close();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

       

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                sql = "UPDATE Employee_Tbl1 SET first_name = '" + EFtxtbox.Text + "', middle_name = '" + EMtxtbox.Text + "', last_name = '" + ELtxtbox.Text + "', suffix = '" + EStxtbox.Text + "', salutation = '" + salutationsCMB.Text + "', house_no = '" + HouseTxtbox.Text + "', barangay = '" + BarangayTxtbox.Text + "', city = '" + CityTxtbox.Text + "', province = '" + ProvinceTxtbox.Text + "', zip = '" + ZipTxtbox.Text + "', birthday = '" + birthdayTxtbox.Text + "', nationality = '" + nationalityTxtbox.Text + "', email_address = '" + emailTxtbox.Text + "', mobile_no = '" + MobileNOTxtbox.Text + "', job_title = '" + JobtitleCMB.Text + "', department = '" + DepartmentCMB.Text + "', emp_status = '" + StatusCMB.Text + "' WHERE employee_id = '" + EIDtxtbox.Text + "'";
                command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;

                adaptersql = new SqlDataAdapter();
                adaptersql.UpdateCommand = command;
                command.ExecuteNonQuery();

                sql = "SELECT * FROM Employee_Tbl1";
                command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;

                adaptersql = new SqlDataAdapter();
                adaptersql.SelectCommand = command;
                command.ExecuteNonQuery();

                dset = new DataSet();
                adaptersql.Fill(dset, "Employee_Tbl1");

                MessageBox.Show("Record updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "update failed");
                return;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

            this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
