using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class selectoption : Form
    {
        public selectoption()
        {
            InitializeComponent();
        }
        private string loggedInCNIC;

        public selectoption(string cnic)
        {
            InitializeComponent();
            loggedInCNIC = cnic;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Form4 bookForm = new Form4(loggedInCNIC);
            bookForm.Show();
            this.Hide();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form6 queueForm = new Form6();
            queueForm.Show();
            this.Hide();

        }
    }
}
