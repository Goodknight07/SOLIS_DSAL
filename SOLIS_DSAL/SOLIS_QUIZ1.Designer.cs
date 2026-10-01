namespace SOLIS_DSAL
{
    partial class SOLIS_QUIZ1
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
            this.label1 = new System.Windows.Forms.Label();
            this.ProductNTxtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ExpirationDTxtbox = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Product Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ProductNTxtbox
            // 
            this.ProductNTxtbox.Location = new System.Drawing.Point(299, 50);
            this.ProductNTxtbox.Name = "ProductNTxtbox";
            this.ProductNTxtbox.Size = new System.Drawing.Size(165, 20);
            this.ProductNTxtbox.TabIndex = 1;
            this.ProductNTxtbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProductNTxtbox_MouseClick);
            this.ProductNTxtbox.TextChanged += new System.EventHandler(this.ProductNTxtbox_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Expiration Date:";
            // 
            // ExpirationDTxtbox
            // 
            this.ExpirationDTxtbox.Enabled = false;
            this.ExpirationDTxtbox.Location = new System.Drawing.Point(299, 76);
            this.ExpirationDTxtbox.Name = "ExpirationDTxtbox";
            this.ExpirationDTxtbox.Size = new System.Drawing.Size(165, 20);
            this.ExpirationDTxtbox.TabIndex = 3;
            this.ExpirationDTxtbox.TextChanged += new System.EventHandler(this.ExpirationDTxtbox_TextChanged);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(225, 104);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(103, 37);
            this.SaveBtn.TabIndex = 4;
            this.SaveBtn.Text = "SAVE";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(334, 104);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(103, 37);
            this.ExitBtn.TabIndex = 5;
            this.ExitBtn.Text = "EXIT";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // SOLIS_QUIZ1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.ExpirationDTxtbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProductNTxtbox);
            this.Controls.Add(this.label1);
            this.Name = "SOLIS_QUIZ1";
            this.Text = "SOLIS_QUIZ1";
            this.Load += new System.EventHandler(this.SOLIS_QUIZ1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ProductNTxtbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ExpirationDTxtbox;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button ExitBtn;
    }
}