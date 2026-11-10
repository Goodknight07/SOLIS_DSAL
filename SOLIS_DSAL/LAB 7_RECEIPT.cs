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
    public partial class LAB_7_RECEIPT : Form
    {
     
        public LAB_7_RECEIPT()
        {
            InitializeComponent();
        }

        // values coming from laboratory7
        public string Soa, Month, Serviceinfo, contract, account, service, Tin, rate, business,
            meter, mru, seq, reading, present, previous, Consumption,
            billstart, billend, current, Basic, environmental, msc, beforetax,
            government, total, duedate, maynilad;

        private void logo_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void LAB_7_RECEIPT_Load(object sender, EventArgs e)
        {

            SAO.Text = Soa;
            month.Text = Month;
            label61.Text = maynilad;

            accno.Text = contract;
            accname.Text = account;
            address.Text = service;
            tin.Text = Tin;
            rateclass.Text = rate;
            busarea.Text = business;

            meterno.Text = meter;
            readingdate.Text = reading;
            presreading.Text = present;
            prevreading.Text = previous;
            consumption.Text = Consumption;

            first.Text = billstart;
            last.Text = billend;
            charges.Text = current;
            basic.Text = Basic;
            envi.Text = environmental;
            MSC.Text = msc;
            TCCBT.Text = beforetax;
            govtax.Text = government;
            label60.Text = total;
            label59.Text = duedate;

            logo.Image = Image.FromFile("C:\\Users\\C203-02\\Downloads\\maynilad logo.jpg");
        }

        private void accno_Click(object sender, EventArgs e)
        {

        }
    }
}

