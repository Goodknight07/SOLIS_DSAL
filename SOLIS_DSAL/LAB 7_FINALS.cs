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
    public partial class LAB_7_FINALS : Form
    {
        public LAB_7_FINALS()
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

        private void MayniladTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void ConsumptionTxt_Leave(object sender, EventArgs e)
        {
           
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
        }
    }
}
