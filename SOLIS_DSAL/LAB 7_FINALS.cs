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

namespace SOLIS_DSAL
{
    public partial class LAB_7_FINALS : Form
    {
        string picturepath;
        string connectionstring = null;
        SqlConnection connection;
        SqlCommand command;
        DataSet dset;
        SqlDataAdapter adaptersql;
        string sql = null;

        public LAB_7_FINALS()
        {
            InitializeComponent();

            connectionstring = "Data Source = C203-02; Initial Catalog = WaterBillDB; user id = SA; password = B1Admin123@";
            connection = new SqlConnection(connectionstring);




        }

        double rate_meter = 23.52,
            current_charge = 0.00,
            environmental_rate = 0.20,
            environmental_charge = 0.00,
            maitenance_charge = 1.53,
            current_charge_beforetax = 0.00,
            government_tax = 0.00,
            total_amount = 0.00,
            consumption = 0.00,
            basic_charge = 0.00,
            tax = 0.025;

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            connection.Open();


              sql = "INSERT INTO customerInfoTbl (contract_no, account_name, service_address, TIN, rate_class, Business_area, SAO_no, SAO_month) VALUES ('" + AccnumTxt.Text + "', '" + AccnameTxt.Text + "', '" + addressTxt.Text + "', '" + TinTxt.Text + "', '" + RateclassTxt.Text + "', '" + BusinessAreaTxt.Text + "', '" + saoTxt.Text + "', '" + MonthTxt.Text + "')";
             command = new SqlCommand(sql, connection);
             command.CommandType = CommandType.Text;
             adaptersql = new SqlDataAdapter();
             adaptersql.InsertCommand = command;
             command.ExecuteNonQuery();


                sql = "INSERT INTO meterTbl (contract_no, meter_no, reading_date, present_reading, previous_reading, consumption) VALUES ('" + AccnumTxt.Text + "', '" + MeternoTxt.Text + "', '" + ReadingdateTxt.Text + "', '" + PresreadingTxt.Text + "', '" + PrevreadingTxt.Text + "', '" + ConsumptionTxt.Text + "')";
                command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;
                adaptersql = new SqlDataAdapter();
               adaptersql.InsertCommand = command;
               command.ExecuteNonQuery();


               sql = "INSERT INTO paymentTbl (contract_no, billing_periodF, billing_periodL, current_charges, basic_charge, environmental_charge, MSC, total_current_charges_before_taxes, government_tax, total_amount_due, payment_due_date) VALUES ('" + AccnumTxt.Text + "', '" + FirstTxt.Text + "', '" + LastTxt.Text + "', '" + CurrentchargeTxt.Text + "', '" + BasicchargeTxt.Text + "', '" + EnvichargeTxt.Text + "', '" + MaintenacechargeTxt.Text + "', '" + TotalcurrentchargeTxt.Text + "', '" + GovtaxTxt.Text + "', '" + TotalamountTxt.Text + "', '" + FirstTxt.Text + "')";
               command = new SqlCommand(sql, connection);
               command.CommandType = CommandType.Text;
               adaptersql = new SqlDataAdapter();
               adaptersql.InsertCommand = command;
               command.ExecuteNonQuery();

            sql = "SELECT * FROM customerInfoTbl";
            adaptersql = new SqlDataAdapter(sql, connection);
            dset = new DataSet();
            adaptersql.Fill(dset, "customerInfoTbl");
            dataGridView1.DataSource = dset.Tables["customerInfoTbl"];
            connection.Close();

        }

        private void FirstTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void RateclassTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MayniladTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            LAB_7_RECEIPT print = new LAB_7_RECEIPT();
            print.Soa = saoTxt.Text;
            print.maynilad = MayniladTxt.Text;
            print.Month = MonthTxt.Text;
            print.Serviceinfo = MayniladTxt.Text;
            print.contract = AccnumTxt.Text;
            print.account = AccnameTxt.Text;
            print.service = addressTxt.Text;
            print.Tin = TinTxt.Text;
            print.rate = RateclassTxt.Text;
            print.business = BusinessAreaTxt.Text;
            print.meter = MeternoTxt.Text;
            print.reading = ReadingdateTxt.Text;
            print.present = PresreadingTxt.Text;
            print.previous = PrevreadingTxt.Text;
            print.Consumption = ConsumptionTxt.Text;
            print.billstart = FirstTxt.Text;
            print.billend = LastTxt.Text;
            print.current = CurrentchargeTxt.Text;
            print.Basic = BasicchargeTxt.Text;
            print.environmental = EnvichargeTxt.Text;
            print.msc = MaintenacechargeTxt.Text;
            print.beforetax = TotalcurrentchargeTxt.Text;
            print.government = GovtaxTxt.Text;
            print.total = "PHP " + TotalamountTxt.Text;
            print.duedate = FirstTxt.Text;
            print.Show();
        }

        private void ConsumptionTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConsumptionTxt_Leave(object sender, EventArgs e)
        {
            consumption = Convert.ToDouble(ConsumptionTxt.Text);
            basic_charge = rate_meter * consumption;
            BasicchargeTxt.Text = basic_charge.ToString("n");

            environmental_charge = basic_charge * environmental_rate;
            EnvichargeTxt.Text = environmental_charge.ToString("n");

            MaintenacechargeTxt.Text = maitenance_charge.ToString("n");

            current_charge_beforetax = basic_charge + environmental_charge + maitenance_charge;
            TotalcurrentchargeTxt.Text = current_charge_beforetax.ToString("n");

            government_tax = current_charge_beforetax * tax;
            GovtaxTxt.Text = government_tax.ToString("n");

            total_amount = current_charge_beforetax + government_tax;
            TotalamountTxt.Text = total_amount.ToString("n");

            CurrentchargeTxt.Text = TotalamountTxt.Text;

            LastTxt.Text = ReadingdateTxt.Text;
        }

        private void ConsumptionTxt_CursorChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LAB_7_FINALS_Load(object sender, EventArgs e)
        {
            logo.Image = Image.FromFile("C:\\Users\\C203-02\\Downloads\\maynilad logo.jpg");
            MayniladTxt.Text = "Maynilad Water Services Inc";

            connection.Open();

            sql = "SELECT c.contract_no, c.account_name, c.service_address, c.TIN, c.rate_class, c.Business_area, c.SAO_no, c.SAO_month, m.meter_no, m.reading_date, m.present_reading, m.previous_reading, m.consumption, p.billing_periodF, p.billing_periodL, p.current_charges, p.basic_charge, p.environmental_charge, p.MSC, p.total_current_charges_before_taxes, p.government_tax, p.total_amount_due, p.payment_due_date FROM customerInfoTbl c LEFT JOIN meterTbl m ON c.contract_no = m.contract_no LEFT JOIN paymentTbl p ON c.contract_no = p.contract_no";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;

            dset = new DataSet();
            adaptersql.Fill(dset, "customerInfoTbl");
            dataGridView1.DataSource = dset.Tables["customerInfoTbl"];

            connection.Close();
        }
    }
}

