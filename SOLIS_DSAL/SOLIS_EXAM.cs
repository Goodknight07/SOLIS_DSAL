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

        private void MayniladTxtbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TotalamountTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalculateTxt_Click(object sender, EventArgs e)
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
            //
            
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
    }
}
