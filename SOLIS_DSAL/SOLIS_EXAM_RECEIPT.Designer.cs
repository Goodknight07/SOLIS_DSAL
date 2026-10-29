namespace SOLIS_DSAL
{
    partial class SOLIS_EXAM_RECEIPT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RECEIPT = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // RECEIPT
            // 
            this.RECEIPT.FormattingEnabled = true;
            this.RECEIPT.Location = new System.Drawing.Point(12, 12);
            this.RECEIPT.Name = "RECEIPT";
            this.RECEIPT.Size = new System.Drawing.Size(375, 628);
            this.RECEIPT.TabIndex = 0;
            // 
            // SOLIS_EXAM_RECEIPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 661);
            this.Controls.Add(this.RECEIPT);
            this.Name = "SOLIS_EXAM_RECEIPT";
            this.Text = "SOLIS_EXAM_RECEIPT";
            this.Load += new System.EventHandler(this.SOLIS_EXAM_RECEIPT_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox RECEIPT;
    }
}