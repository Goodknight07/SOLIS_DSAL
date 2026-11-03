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
    public partial class SOLIS_EXAM : Form
    {
        public SOLIS_EXAM()
        {
            InitializeComponent();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void ConsumptionTxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void MayniladTxtbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TotalamountTxt_TextChanged(object sender, EventArgs e)
        {

        }

        public void CalculateTxt_Click(object sender, EventArgs e)
        {
            DisplayInputs();

            SOLIS_EXAM_RECEIPT receipt = new SOLIS_EXAM_RECEIPT();

            receipt.source = this;
            receipt.DisplayReceipt(listBox1);

            receipt.ShowDialog();
        }

        private void SOLIS_EXAM_Load(object sender, EventArgs e)
        {
            MayniladTxtbox.Text = "Maynilad Water Services Inc";
            DisplayTxt.Text = "WB-Water Bill, GD-Guarantee Deposit, MISC-Reopening Fee, Connection Fee, Metering Charge";

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DisplayInputs()
        {
            listBox1.Items.Clear();

            listBox1.Items.Add("MAYNILAD WATER SERVICE INC");
            listBox1.Items.Add("8390 DR A  SANTOS AVE BF HOMES");
            listBox1.Items.Add("");

            listBox1.Items.Add("SERVICE INFORMATION");
            listBox1.Items.Add("Contract Account No.: " + AccnameTxt.Text);
            listBox1.Items.Add("Account Name: " + AccnameTxt.Text);
            listBox1.Items.Add("Service Address: " + AdressTxt.Text);
            listBox1.Items.Add("TIN: " + TinTxt.Text);
            listBox1.Items.Add("Rate Class: " + RateclassTxt.Text);
            listBox1.Items.Add("Business Area: " + BusinessAreaTxt.Text);

            listBox1.Items.Add("");
            listBox1.Items.Add("METERING INFORMATION");
            listBox1.Items.Add("Meter No.: " + MeternoTxt.Text);
            listBox1.Items.Add("Reading Date: " + ReadingdateTxt.Text);
            listBox1.Items.Add("Present Reading: " + PresreadingTxt.Text);
            listBox1.Items.Add("Previous Reading: " + PrevreadingTxt.Text);
            listBox1.Items.Add("Consumption: " + ConsumptionTxt.Text + " cu.m");

            listBox1.Items.Add("");
            listBox1.Items.Add("BILLING SUMMARY");
            listBox1.Items.Add("Billing Period: " + FirstTxt.Text + " to " + LastTxt.Text);

            listBox1.Items.Add("Basic Charge: " + BasicchargeTxt.Text);
            listBox1.Items.Add("Environmental Charge: " + EnvichargeTxt.Text);
            listBox1.Items.Add("Maintenance Charge: " + MaintenacechargeTxt.Text);
            listBox1.Items.Add("Total Charges Before Tax: " + TotalcurrentchargeTxt.Text);
            listBox1.Items.Add("Government Tax: " + GovtaxTxt.Text);

            listBox1.Items.Add("");
            listBox1.Items.Add("TOTAL AMOUNT: " + TotalamountTxt.Text);
            listBox1.Items.Add("PAYMENT DUE DATE: " + PaymentdueTxt.Text);
        }
    }

}
