using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        private string connectionString = @"Data Source=AHMEDPC\SQLEXPRESS;Initial Catalog=projectdb;Integrated Security=True";

        public Form6()
        {
            InitializeComponent();
            LoadDepartments();
            LoadBranches();
            timer1.Start();
        }

        // Load departments into the combo box
        private void LoadDepartments()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT DISTINCT Department FROM token";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbDepartment.Items.Add(reader["Department"].ToString());
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message);
            }
        }

        // Load branches into the combo box
        private void LoadBranches()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT DISTINCT Branch FROM token";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbBranch.Items.Add(reader["Branch"].ToString());
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading branches: " + ex.Message);
            }
        }

        // Load filtered tokens when either combo box changes
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTokensIntoGrid();
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTokensIntoGrid();
        }

        // Load token numbers and time slots into the DataGridView
        private void LoadTokensIntoGrid()
        {
            if (cmbDepartment.SelectedItem == null || cmbBranch.SelectedItem == null)
            {
                return; // Ensure both are selected before proceeding
            }

            string selectedDepartment = cmbDepartment.SelectedItem.ToString();
            string selectedBranch = cmbBranch.SelectedItem.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT TM.TokenNo, T.TimeSlot, T.Status, T.Date
                        FROM token T
                        INNER JOIN tokenmaster TM ON T.TokenID = TM.TokenID
                        WHERE T.Department = @Department AND T.Branch = @Branch
                        ORDER BY T.Date ASC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Department", selectedDepartment);
                    cmd.Parameters.AddWithValue("@Branch", selectedBranch);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridViewTokens.DataSource = dt;
                    dataGridViewTokens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading token data: " + ex.Message);
            }
        }

        // Navigate back to Form3
        private void btnBack_Click(object sender, EventArgs e)
        {
            selectoption f3 = new selectoption();
            f3.Show();
            this.Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            LoadTokensIntoGrid();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void DataGridViewTokens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
