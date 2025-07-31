namespace WindowsFormsApp1
{
    partial class paymentform
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
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.txtPaymentDetails = new System.Windows.Forms.TextBox();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAmount.Location = new System.Drawing.Point(106, 103);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(46, 28);
            this.lblAmount.TabIndex = 1;
            this.lblAmount.Text = "---a";
            this.lblAmount.Click += new System.EventHandler(this.LblAmount_Click);
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.DarkBlue;
            this.btnDone.Font = new System.Drawing.Font("Arial", 10F);
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.Location = new System.Drawing.Point(366, 293);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(95, 44);
            this.btnDone.TabIndex = 2;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.BtnDone_Click_1);
            // 
            // txtPaymentDetails
            // 
            this.txtPaymentDetails.Font = new System.Drawing.Font("Arial", 11F);
            this.txtPaymentDetails.Location = new System.Drawing.Point(389, 195);
            this.txtPaymentDetails.Name = "txtPaymentDetails";
            this.txtPaymentDetails.Size = new System.Drawing.Size(214, 29);
            this.txtPaymentDetails.TabIndex = 3;
            this.txtPaymentDetails.TextChanged += new System.EventHandler(this.TxtPaymentDetails_TextChanged);
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Arial", 11F);
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(389, 149);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(214, 29);
            this.cmbPaymentMethod.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(103, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter Account No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(103, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Payment Method :";
            // 
            // paymentform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(878, 539);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.txtPaymentDetails);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.lblAmount);
            this.Name = "paymentform";
            this.Text = "paymentform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.TextBox txtPaymentDetails;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}