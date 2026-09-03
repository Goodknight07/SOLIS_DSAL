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
using System.Data;

namespace SOLIS_DSAL
{
    public partial class samplefrm_connectedDb : Form
    {
        string picturepath;
        string connectionstring = null;
        SqlConnection connection;
        SqlCommand command;
        DataSet dset;
        SqlDataAdapter adaptersql;
        string sql = null;

        public samplefrm_connectedDb()
        {
            connectionstring = "Data Source = C203-03; Initial Catalog = software_designDb; user id = SA; password = B1Admin123@";
            connection = new SqlConnection(connectionstring);
            InitializeComponent();
        }

        private void samplefrm_connectedDb_Load(object sender, EventArgs e)
        {
            connection.Open();
            sql = "SELECT * FROM studentTbl";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text; 
            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();
            dset = new DataSet();
            adaptersql.Fill(dset, "studentTbl");
            datagrid_display.DataSource = dset.Tables[0];
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            sql = "DELETE FROM studentTbl WHERE student_no = '" + student_noTxtbox.Text + "'";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.DeleteCommand = command;
            command.ExecuteNonQuery();

            sql = "SELECT * FROM studentTbl";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();
            dset = new DataSet();
            adaptersql.Fill(dset, "studentTbl");

            datagrid_display.DataSource = dset.Tables[0];

            connection.Close();

            student_noTxtbox.Clear();
            student_nameTxtbox.Clear();
            student_departmentTxtbox.Clear();
            student_noTxtbox.Focus();

            picturpathTxtbox.Text = "C:\\Users\\C203-03\\Downloads\\DEFAULT IMAGE.png";
            pictureBox1.Image = Image.FromFile(picturpathTxtbox.Text);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //code for inserting picture from the local file to then picturebox
            openFileDialog1.Filter = "Image File | *.gif; *.jpg; *.png; *.bmp";
            //filtering of image display using specific file extension
            openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName); //inserting of selected image to the picturebox shown in the GUI interface
            picturepath = openFileDialog1.FileName;//storing the file location of the selected image inserted in picturebox to a variable
            picturpathTxtbox.Text = picturepath; //displaying the file location of the image stored in a a variable to the textbox
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //code to open the connection between c# and ms sql
            connection.Open();
            sql = "INSERT INTO studentTbl (student_no, student_name, student_department, picturepath) VAlUES ('" + student_noTxtbox.Text + "'," + "'" + student_nameTxtbox.Text + "', '" + student_departmentTxtbox.Text + "', ' " + picturpathTxtbox.Text + "')";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            //codes for mediating the language or world of c# and mssql
            adaptersql = new SqlDataAdapter();
            adaptersql.InsertCommand = command;
            command.ExecuteNonQuery();
            //mssql query to display the contents of student table located inside the database
            sql = "SELECT * FROM studentTbl";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            //codes for mediating the language or world of c# and mssql
            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();
            //codes for mirroring the contents of the database inside the mssql going to c# or visual studio
            dset = new DataSet();
            adaptersql.Fill(dset, "studentTbl");
            //codes for displaying the contents of student table to the inside of data grid view
            datagrid_display.DataSource = dset.Tables[0];
            //clearing tof textboxes after saving the data to the database
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

            student_noTxtbox.Clear();
            student_nameTxtbox.Clear();
            student_departmentTxtbox.Clear();
            picturpathTxtbox.Clear();

            connection.Close();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            connection.Open();
            sql = "SELECT * FROM studentTbl WHERE student_no = '" + student_noTxtbox.Text + "' ";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();

            dset = new DataSet();
            adaptersql.Fill(dset, "studentTbl");

            datagrid_display.DataSource = dset.Tables[0];

            student_nameTxtbox.Text = dset.Tables[0].Rows[0][1].ToString();
            student_departmentTxtbox.Text = dset.Tables[0].Rows[0][2].ToString();
            picturpathTxtbox.Text = dset.Tables[0].Rows[0][3].ToString();
            pictureBox1.Image = Image.FromFile(picturpathTxtbox.Text);

            connection.Close();

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            connection.Open();
            sql = "UPDATE studentTbl SET student_name = '" + student_nameTxtbox.Text + "', student_department = '" + student_departmentTxtbox.Text + "', " + "picturepath = '" + picturpathTxtbox.Text + "' WHERE student_no = '" + student_noTxtbox.Text + "'";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.UpdateCommand = command;
            command.ExecuteNonQuery();

            sql = "SELECT * FROM studentTbl";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();

            dset = new DataSet();
            adaptersql.Fill(dset, "studentTbl");

            datagrid_display.DataSource = dset.Tables[0];

            connection.Close();

        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            student_noTxtbox.Clear();
            student_nameTxtbox.Clear();
            student_departmentTxtbox.Clear();
            student_noTxtbox.Focus();

            picturpathTxtbox.Text = "C:\\Users\\C203-03\\Downloads\\DEFAULT IMAGE.png";
            pictureBox1.Image = Image.FromFile(picturpathTxtbox.Text);

            connection.Open();
            sql = "SELECT * FROM studentTbl";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand= command;
            command.ExecuteNonQuery();

            dset = new DataSet();
            adaptersql.Fill(dset, "studentTbl");

            datagrid_display.DataSource = dset.Tables[0];
            connection.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            student_noTxtbox.Clear();
            student_nameTxtbox.Clear();
            student_departmentTxtbox.Clear();
            student_noTxtbox.Focus();

            picturpathTxtbox.Text = "C:\\Users\\C203-03\\Downloads\\DEFAULT IMAGE.png";
            pictureBox1.Image = Image.FromFile(picturpathTxtbox.Text);

            connection.Open();
            sql = "SELECT * FROM studentTbl";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();

            dset = new DataSet();
            adaptersql.Fill(dset, "studentTbl");

            datagrid_display.DataSource = dset.Tables[0];
            connection.Close();
        }

        private void student_noTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void student_nameTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void student_departmentTxtbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
