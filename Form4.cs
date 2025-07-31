using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        private string connectionString = @"Data Source=AHMEDPC\SQLEXPRESS;Initial Catalog=projectdb;Integrated Security=True";
        private string userCnic;

        public Form4(string cnic)
        {
            InitializeComponent();
            userCnic = cnic;

            // Register Form Load event manually (if not already in Designer)
            this.Load += Form4_Load;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadComboBoxOptions();
           
        }

        private void LoadComboBoxOptions()
        {
            cmbDepartment.Items.Clear();
            cmbBranch.Items.Clear();
            cmbCategory.Items.Clear();
            cmbTimeSlot.Items.Clear();

            cmbDepartment.Items.AddRange(new string[] { "-- Department --", "Nadra", "Passport", "Driving", "Hospital" });
            cmbBranch.Items.AddRange(new string[] { "-- Branch --", "North Karachi", "Gulshan", "Saddar", "Defence" });
            cmbCategory.Items.AddRange(new string[] { "-- Category --", "Normal", "Senior Citizen" });
            cmbTimeSlot.Items.AddRange(new string[] { "-- Time Slot --", "08:00 AM", "10:00 AM", "12:00 PM", "02:00 PM" });

            cmbDepartment.SelectedIndex = 0;
            cmbBranch.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            cmbTimeSlot.SelectedIndex = 0;
        }
        

        
        private string GenerateTokenID()
        {
            return DateTime.Now.ToString("yyyy") + "-" + new Random().Next(1001, 1999).ToString();
        }

        private string GenerateTokenNumber(string dept)
        {
            return dept.Substring(0, 1).ToUpper() + new Random().Next(1,99).ToString();
        }

        private void BtnConfirmBooking_Click_1(object sender, EventArgs e)
        {
            string department = cmbDepartment.SelectedItem?.ToString();
            string branch = cmbBranch.SelectedItem?.ToString();
            string category = cmbCategory.SelectedItem?.ToString();
            string timeSlot = cmbTimeSlot.SelectedItem?.ToString();
            DateTime date = dtpDateTime.Value;

            if (department.Contains("--") || branch.Contains("--") || category.Contains("--") || timeSlot.Contains("--"))
            {
                MessageBox.Show("Please select all fields before booking.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Set fee according to department
            int fee = department == "Nadra" ? 750 :
                      department == "Passport" ? 500 :
                      department == "Driving" ? 300 :
                      department == "Hospital" ? 200 : 100;

            string tokenID = GenerateTokenID();
            string tokenNumber = GenerateTokenNumber(department);

            // Open payment form first
            paymentform paymentForm = new paymentform(tokenID, tokenNumber, department, branch, category, date.ToShortDateString(), timeSlot, fee);
           
            if (paymentForm.ShowDialog() == DialogResult.OK && paymentForm.IsPaymentSuccessful)
            {
                this.Hide();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Insert into token
                    string insertBooking = @"
            INSERT INTO token (Tokenid, Department, Branch, Category, Date, TimeSlot, CNIC, Status)
            VALUES (@Tokenid, @Department, @Branch, @Category, @Date, @TimeSlot, @CNIC, @Status)";
                    using (SqlCommand cmd = new SqlCommand(insertBooking, conn))
                    {
                        cmd.Parameters.AddWithValue("@Tokenid", tokenID);
                        cmd.Parameters.AddWithValue("@Department", department);
                        cmd.Parameters.AddWithValue("@Branch", branch);
                        cmd.Parameters.AddWithValue("@Category", category);
                        cmd.Parameters.AddWithValue("@Date", date);
                        cmd.Parameters.AddWithValue("@TimeSlot", timeSlot);
                        cmd.Parameters.AddWithValue("@CNIC", userCnic);
                        cmd.Parameters.AddWithValue("@Status", "Pending");

                        try { cmd.ExecuteNonQuery(); }
                        catch (SqlException)
                        {
                            MessageBox.Show("Token already booked on this CNIC.", "Duplicate Booking", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Insert into tokenmaster
                    string insertToken = @"INSERT INTO tokenmaster (TokenID, TokenNo, CNIC)
                               VALUES (@TokenID, @TokenNo, @CNIC)";
                    using (SqlCommand cmd = new SqlCommand(insertToken, conn))
                    {
                        cmd.Parameters.AddWithValue("@TokenID", tokenID);
                        cmd.Parameters.AddWithValue("@TokenNo", tokenNumber);
                        cmd.Parameters.AddWithValue("@CNIC", userCnic);
                        cmd.ExecuteNonQuery();
                    }

                }
            }
        }


        private void CmbTimeSlot_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
