using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {   
        private string tokenID;
        private string tokenNo;
        private string category1;
        // ✅ Changed from int to string

        private string connectionString = @"Data Source=AHMEDPC\SQLEXPRESS;Initial Catalog=projectdb;Integrated Security=True";

        public Form5(string tokenID, string tokenNumber, string department, string branch, string category, string date, string timeSlot)
        {
            InitializeComponent();
            this.tokenID = tokenID;
            this.tokenNo = tokenNumber;
            this.category1 = category;

            lblCategory.Text = category1;

            // Set color
            lblCategory.BackColor = category == "Senior Citizen" ? Color.LightBlue : Color.LightCyan;

            lblToken.Text = tokenNumber;
            lblDepartment.Text = department;
            lblBranch.Text = branch;
            lblCategory.Text = category;
            lblDate.Text = date;
            lblTimeSlot.Text = timeSlot;
            lblTokenID.Text = tokenID;

            LoadTokenDetails();  // Optional: if needed
            LoadQueueDetails();
            LoadQueueIntoGrid();
        }


        private void LoadTokenDetails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
        SELECT TM.TokenNo, T.Department, T.Branch, T.TimeSlot 
        FROM token T
        INNER JOIN tokenmaster TM ON T.TokenID = TM.TokenID
        WHERE TM.TokenNo = @TokenNo AND TM.TokenID = @TokenID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TokenID", tokenID);
                cmd.Parameters.AddWithValue("@TokenNo", tokenNo);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblToken.Text = tokenNo;
                    lblDepartment.Text = reader["Department"].ToString();
                    lblBranch.Text = reader["Branch"].ToString();
                    label8.Text = reader["TimeSlot"].ToString();
                }
                conn.Close();
            }
        }


        private void LoadQueueDetails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Get department, branch, and date in one query
                string getInfoQuery = @"
            SELECT T.Department, T.Branch, T.Date
            FROM token T
            INNER JOIN tokenmaster TM ON T.TokenID = TM.TokenID
            WHERE TM.TokenNo = @TokenNo AND TM.TokenID = @TokenID";

                SqlCommand infoCmd = new SqlCommand(getInfoQuery, conn);
                infoCmd.Parameters.AddWithValue("@TokenNo", tokenNo);
                infoCmd.Parameters.AddWithValue("@TokenID", tokenID);

                string department = "", branch = "";
                DateTime tokenDate = DateTime.MinValue;

                using (SqlDataReader reader = infoCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        department = reader["Department"].ToString();
                        branch = reader["Branch"].ToString();
                        tokenDate = Convert.ToDateTime(reader["Date"]);
                    }
                    else
                    {
                        MessageBox.Show("Token not found.");
                        return;
                    }
                }

                // Now count how many pending tokens exist before this one
                string countQuery = @"
            SELECT COUNT(*) 
            FROM token T
            INNER JOIN tokenmaster TM ON T.TokenID = TM.TokenID
            WHERE T.Department = @Department
              AND T.Branch = @Branch
              AND T.Status = 'Pending'
              AND T.Date < @TokenDate";

                SqlCommand countCmd = new SqlCommand(countQuery, conn);
                countCmd.Parameters.AddWithValue("@Department", department);
                countCmd.Parameters.AddWithValue("@Branch", branch);
                countCmd.Parameters.AddWithValue("@TokenDate", tokenDate);

                int tokensBefore = (int)countCmd.ExecuteScalar();

                int estimatedMinutesPerPerson = 10;
                int estimatedTime = tokensBefore * estimatedMinutesPerPerson;

                lblCategory.Text = category1;
                lblTokenID.Text = tokenID;

                conn.Close();
            }
        }


        private void LoadQueueIntoGrid()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Step 1: Get Department and Branch for the Token
                    string getDeptBranchQuery = @"
 SELECT Department, Branch
FROM token
WHERE TokenID = (
 SELECT TokenID FROM tokenmaster WHERE TokenNo = @TokenNo
 )";
                    SqlCommand cmd1 = new SqlCommand(getDeptBranchQuery, conn);
                    cmd1.Parameters.AddWithValue("@TokenNo", tokenNo);
                    string department = "", branch = "";
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        department = reader["Department"].ToString();
                        branch = reader["Branch"].ToString();
                    }
                    reader.Close();
                    // Step 2: Filter queue for same Department & Branch
                    string queueQuery = @"
 SELECT TM.TokenNo, T.Department, T.Branch, T.Category, T.TimeSlot, T.Status, T.Date
 FROM token T
 INNER JOIN tokenmaster TM ON T.TokenID = TM.TokenID
 WHERE T.Status = 'Pending' AND T.Department = @Department AND T.Branch = @Branch
 ORDER BY
 CASE WHEN T.Category = 'Senior Citizen' THEN 0 ELSE 1 END,
 T.Date,
 T.TimeSlot
";
                    SqlCommand cmd2 = new SqlCommand(queueQuery, conn);
                    cmd2.Parameters.AddWithValue("@Department", lblDepartment.Text);
                    cmd2.Parameters.AddWithValue("@Branch", lblBranch.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.Columns.Add("Estimated Time");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["Estimated Time"] = (i * 10).ToString() + " minutes";
                    }
                    queuelist.DataSource = dt;
                    queuelist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading filtered queue: " + ex.Message);
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            selectoption f3 = new selectoption();
            f3.Show();
            this.Close();
        }

        private void Queuelist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }

}
