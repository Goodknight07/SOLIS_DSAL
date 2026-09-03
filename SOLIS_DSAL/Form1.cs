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
    public partial class Form1 : Form
    {
        string picturepath;
        string connectionstring = null;
        SqlConnection connection;
        SqlCommand command;
        DataSet dset;
        SqlDataAdapter adaptersql;
        string sql = null;


        public Form1()
        {
            InitializeComponent();

            connectionstring = "Data Source = C203-03; Initial Catalog = DSAL_Db; user id = SA; password = B1Admin123@";
            connection = new SqlConnection(connectionstring);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EFtxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void s_Load(object sender, EventArgs e)
        {
            connection.Open();
            sql = "SELECT * FROM Employee_Tbl1";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();
            dset = new DataSet();
            adaptersql.Fill(dset, "Employee_Tbl1");
            connection.Close();

            salutationsCMB.Items.Add("Mr");
            salutationsCMB.Items.Add("Ms");
            salutationsCMB.Items.Add("Mrs");

            JobtitleCMB.Items.Add("Team leader");
            JobtitleCMB.Items.Add("Manager");
            JobtitleCMB.Items.Add("Supervisor");

            DepartmentCMB.Items.Add("Customer Service");
            DepartmentCMB.Items.Add("Office Manager");
            DepartmentCMB.Items.Add("Human Resources");

            StatusCMB.Items.Add("Active");
            StatusCMB.Items.Add("Busy");
            StatusCMB.Items.Add("Offline");

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            connection.Open();
            sql = "INSERT INTO Employee_Tbl1 (employee_id, first_name, middle_name, last_name, suffix, salutation, house_no, barangay, city, province, zip, birthday, nationality, email_address, mobile_no, job_title, department, emp_status) VAlUES ('" + EIDtxtbox.Text + "', '" + EFtxtbox.Text + "','" + EMtxtbox.Text + "', '" + ELtxtbox.Text + "', '" + EStxtbox.Text + "', '" + salutationsCMB.Text + "', '" + HouseTxtbox.Text + "','" +  BarangayTxtbox.Text + "', '" + CityTxtbox.Text + "', '" + ProvinceTxtbox.Text + "', '" + ZipTxtbox.Text + "', '" + birthdayTxtbox.Text + "','" + nationalityTxtbox.Text + "', '" + emailTxtbox.Text + "', '" + MobileNOTxtbox.Text + "', '" + JobtitleCMB.Text + "', '" + DepartmentCMB.Text + "','" + StatusCMB.Text + "')";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            adaptersql = new SqlDataAdapter();
            adaptersql.InsertCommand = command;
            command.ExecuteNonQuery();
            sql = "SELECT * FROM Employee_Tbl1";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();
            dset = new DataSet();
            adaptersql.Fill(dset, "Employee_Tbl1");
            connection.Close();
        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image File | *.gif; *.jpg; *.png; *.bmp";
            openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName); 
            picturepath = openFileDialog1.FileName;
           
        }
    }
}
