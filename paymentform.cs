using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class paymentform : Form
    {
        private int amountDue;
        private string tokenID, tokenNo, department, branch, category, date, timeSlot;

        private void LblInstruction_Click(object sender, EventArgs e)
        {

        }

        private void LblAmount_Click(object sender, EventArgs e)
        {

        }

        private void TxtPaymentDetails_TextChanged(object sender, EventArgs e)
        {

        }

        public bool IsPaymentSuccessful { get; private set; } = false;



        public paymentform(string tokenID, string tokenNo, string dept, string branch, string cat, string date, string slot, int amount)
        {
            InitializeComponent();

            this.tokenID = tokenID;
            this.tokenNo = tokenNo;
            this.department = dept;
            this.branch = branch;
            this.category = cat;
            this.date = date;
            this.timeSlot = slot;
            this.amountDue = amount;

            lblAmount.Text = "Payable Amount: Rs. " + amountDue;

            cmbPaymentMethod.Items.AddRange(new string[] { "Easypaisa", "JazzCash", "Debit Card", "Credit Card" });
            cmbPaymentMethod.SelectedIndex = 0;
        }

        private void BtnDone_Click_1(object sender, EventArgs e)
        {

            IsPaymentSuccessful = true;
            this.DialogResult = DialogResult.OK; // Important!
            this.Close();

            
            Form7 receipt = new Form7(tokenID, tokenNo, department, branch, category, date, timeSlot, amountDue);
            receipt.Show();
            this.Hide(); ;
        }
    }
}
