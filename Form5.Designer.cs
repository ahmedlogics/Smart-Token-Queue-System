namespace WindowsFormsApp1
{
    partial class Form5
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
            this.label8 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.queuelist = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblToken = new System.Windows.Forms.TextBox();
            this.lblTokenID = new System.Windows.Forms.TextBox();
            this.lblTimeSlot = new System.Windows.Forms.TextBox();
            this.lblBranch = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.queuelist)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label8.Location = new System.Drawing.Point(535, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 28);
            this.label8.TabIndex = 5;
            this.label8.Text = "TimeSlot";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DarkBlue;
            this.btnBack.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(455, 241);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(113, 36);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.MouseCaptureChanged += new System.EventHandler(this.btnBack_Click);
            // 
            // queuelist
            // 
            this.queuelist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.queuelist.Location = new System.Drawing.Point(72, 297);
            this.queuelist.Name = "queuelist";
            this.queuelist.RowTemplate.Height = 24;
            this.queuelist.Size = new System.Drawing.Size(890, 331);
            this.queuelist.TabIndex = 7;
            this.queuelist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Queuelist_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(149, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 28);
            this.label1.TabIndex = 12;
            this.label1.Text = "Branch";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(148, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 28);
            this.label3.TabIndex = 10;
            this.label3.Text = "Department";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(534, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 28);
            this.label4.TabIndex = 9;
            this.label4.Text = "Token ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(146, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 28);
            this.label5.TabIndex = 8;
            this.label5.Text = "TokenNumber\t";
            // 
            // lblToken
            // 
            this.lblToken.Font = new System.Drawing.Font("Arial", 10F);
            this.lblToken.Location = new System.Drawing.Point(303, 54);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(157, 27);
            this.lblToken.TabIndex = 13;
            // 
            // lblTokenID
            // 
            this.lblTokenID.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTokenID.Location = new System.Drawing.Point(691, 46);
            this.lblTokenID.Name = "lblTokenID";
            this.lblTokenID.Size = new System.Drawing.Size(164, 27);
            this.lblTokenID.TabIndex = 14;
            // 
            // lblTimeSlot
            // 
            this.lblTimeSlot.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTimeSlot.Location = new System.Drawing.Point(692, 154);
            this.lblTimeSlot.Name = "lblTimeSlot";
            this.lblTimeSlot.Size = new System.Drawing.Size(164, 27);
            this.lblTimeSlot.TabIndex = 15;
            // 
            // lblBranch
            // 
            this.lblBranch.Font = new System.Drawing.Font("Arial", 10F);
            this.lblBranch.Location = new System.Drawing.Point(303, 151);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(157, 27);
            this.lblBranch.TabIndex = 17;
            // 
            // lblDepartment
            // 
            this.lblDepartment.Font = new System.Drawing.Font("Arial", 10F);
            this.lblDepartment.Location = new System.Drawing.Point(303, 101);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(157, 27);
            this.lblDepartment.TabIndex = 18;
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Arial", 10F);
            this.lblDate.Location = new System.Drawing.Point(690, 99);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(164, 27);
            this.lblDate.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.Location = new System.Drawing.Point(534, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 28);
            this.label6.TabIndex = 19;
            this.label6.Text = "Booking Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(146, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 28);
            this.label2.TabIndex = 11;
            this.label2.Text = "Category";
            // 
            // lblCategory
            // 
            this.lblCategory.Font = new System.Drawing.Font("Arial", 10F);
            this.lblCategory.Location = new System.Drawing.Point(302, 198);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(157, 27);
            this.lblCategory.TabIndex = 16;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1043, 680);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblTimeSlot);
            this.Controls.Add(this.lblTokenID);
            this.Controls.Add(this.lblToken);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.queuelist);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label8);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.queuelist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView queuelist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox lblToken;
        private System.Windows.Forms.TextBox lblTokenID;
        private System.Windows.Forms.TextBox lblTimeSlot;
        private System.Windows.Forms.TextBox lblBranch;
        private System.Windows.Forms.TextBox lblDepartment;
        private System.Windows.Forms.TextBox lblDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lblCategory;
    }
}