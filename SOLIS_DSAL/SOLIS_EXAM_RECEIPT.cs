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

    public partial class SOLIS_EXAM_RECEIPT : Form
    {
        public SOLIS_EXAM source;
        public ListBox history;
        public SOLIS_EXAM_RECEIPT()
        {
            InitializeComponent();
        }

        public void SOLIS_EXAM_RECEIPT_Load(object sender, EventArgs e)
        {
            if (source != null)
            {
                foreach (Control c in source.Controls)
                {
                    if (c is TextBox)
                    {
                        Control[] match = Controls.Find(c.Name, true);

                        if (match.Length > 0 && match[0] is TextBox)
                        {
                            TextBox dest = (TextBox)match[0];
                            dest.Text = c.Text;
                            dest.ReadOnly = true;
                        }
                    }
                }
            }
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        public void DisplayReceipt(ListBox sourceList)
        {
            listBox1.Items.Clear();

            foreach (var item in sourceList.Items)
            {
                listBox1.Items.Add(item);
            }
        }
    }
    
}
   
