using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=AHMEDPC\SQLEXPRESS;Initial Catalog=projectdb;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string cnic = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(cnic) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter CNIC and Password.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Step 1: Check if CNIC exists
                string cnicCheckQuery = "SELECT COUNT(*) FROM register WHERE CNIC = @CNIC";
                using (SqlCommand cmd = new SqlCommand(cnicCheckQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CNIC", cnic);
                    int cnicExists = Convert.ToInt32(cmd.ExecuteScalar());

                    if (cnicExists == 0)
                    {
                        MessageBox.Show("Account not found. Register first.");
                        return;
                    }
                }

                // Step 2: Check if CNIC and password match
                string loginQuery = "SELECT COUNT(*) FROM register WHERE CNIC = @CNIC AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(loginQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CNIC", cnic);
                    cmd.Parameters.AddWithValue("@Password", password);
                    int matchFound = Convert.ToInt32(cmd.ExecuteScalar());

                    if (matchFound == 1)
                    {
                        // Login successful
                        selectoption form3 = new selectoption(cnic);
                        form3.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password. Enter valid info.");
                    }
                }
            }
        }



        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
