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
    public partial class Form2 : Form
    {
        // Replace with your actual connection string
        string connectionString = @"Data Source=AHMEDPC\SQLEXPRESS;Initial Catalog=projectdb;Integrated Security=True";

        public Form2()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string cnic = txtCNIC.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text;
          

            // Validation
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(cnic) ||
                string.IsNullOrWhiteSpace(password) )
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check if CNIC already exists
                string checkCnicQuery = "SELECT * FROM register WHERE CNIC = @CNIC";
                using (SqlCommand checkCmd = new SqlCommand(checkCnicQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@CNIC", cnic);
                    long exists = Convert.ToInt64(checkCmd.ExecuteScalar());

                    if (exists > 0)
                    {
                        MessageBox.Show("An account with this CNIC already exists.");
                        return;
                    }
                }

                // Insert new user
                string insertQuery = @"INSERT INTO register (fullname, cnic, phone, password)
                                       VALUES (@FullName, @CNIC, @Phone, @PasswordHash)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@CNIC", cnic);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@PasswordHash", password); // You can hash it later
                   // cmd.Parameters.AddWithValue("@UserCategory", userCategory);

                    int rowsInserted = cmd.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        MessageBox.Show("Registered successfully!");

                        // Go back to login form
                        Form1 loginForm = new Form1();
                        loginForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Registration failed. Try again.");
                    }
                }
            }
        }
    }
}
