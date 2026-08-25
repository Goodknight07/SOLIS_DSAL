using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SOLIS_DSAL
{
    public partial class s : Form
    {
        pos_dbconnection posdb_connect = new pos_dbconnection();
        public s()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EFtxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void s_Load(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {

                posdb_connect.pos_connString();


                posdb_connect.pos_sql = @"INSERT INTO Employee_Tbl (
                                    employee_id, first_name, middle_name, last_name, suffix, salutation,
                                    house_no, barangay, city, province, zip, 
                                    birthday, nationality, email_address, mobile_no, 
                                    job_title, department, emp_status
                                  ) 
                                  VALUES (
                                    @id, @fname, @mname, @lname, @suffix, @salutation,
                                    @house, @brgy, @city, @prov, @zip, 
                                    @bday, @nat, @email, @mobile, 
                                    @job, @dept, @status
                                  )";


                posdb_connect.pos_cmd();


                posdb_connect.pos_sql_command.Parameters.AddWithValue("@id", Convert.ToInt32(EIDtxtbox.Text));
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@fname", EFtxtbox.Text);
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@mname", EMtxtbox.Text);
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@lname", ELtxtbox.Text);
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@suffix", EStxtbox.Text);
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@salutation", Convert.ToInt32(salutationsCMB.Text)); // INT
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@house", HouseTxtbox.Text);
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@brgy", BarangayTxtbox.Text);
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@city", CityTxtbox.Text);
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@prov", ProvinceTxtbox.Text);
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@zip", ZipTxtbox.Text);
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@bday", Convert.ToDateTime(dateTimePicker1.Text)); // DATE
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@nat", nationalityTxtbox.Text);
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@email", emailTxtbox.Text);
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@mobile", MobileNOTxtbox.Text);
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@job", JobtitleCMB.Text);
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@dept", DepartmentCMB.Text);
                posdb_connect.pos_sql_command.Parameters.AddWithValue("@status", StatusCMB.Text);


                posdb_connect.pos_sqladapterInsert(); 

                    MessageBox.Show("Employee Record Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (posdb_connect.pos_sql_connection != null && posdb_connect.pos_sql_connection.State == ConnectionState.Open)
                    {
                        posdb_connect.pos_sql_connection.Close();
                    }
                }
                }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
