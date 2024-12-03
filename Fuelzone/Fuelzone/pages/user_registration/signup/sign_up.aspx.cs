using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

namespace Fuelzone.pages.user_registration.signup
{
    public partial class sign_up : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If user is already logged in, redirect them to the home page
            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {
                Response.Redirect("~/");
            }
        }

        // When user confirms sending input information
        protected void btnSignup_Click(object sender, EventArgs e)
        {
            // Collecting input values from form fields
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // Basic input validation
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "All fields are required!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Hash the password before storing it
            string hashedPassword = HashPassword(password);

            // Generate a user-friendly unique identifier (userId)
            string userId = GenerateUserId(username);

            // Get the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;

            try
            {
                // Connect to the database and insert user details
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if the email or username already exists
                    string checkQuery = "SELECT COUNT(*) FROM Account WHERE Username = @Username OR Email = @Email";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        checkCmd.Parameters.AddWithValue("@Email", email);

                        int userExists = (int)checkCmd.ExecuteScalar();
                        if (userExists > 0)
                        {
                            lblMessage.Text = "Username or Email already exists.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }

                    // Insert new record - no need to specify Id, it will be generated automatically
                    string insertQuery = "INSERT INTO Account (userId, Username, Email, Password, admin) OUTPUT INSERTED.Id VALUES (@userId, @Username, @Email, @Password, @Admin)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@Admin", 0); // Set admin to 0 (FALSE)

                        int newUserId = (int)cmd.ExecuteScalar(); // Fetch the new Id
                        if (newUserId > 0)
                        {
                            lblMessage.Text = "Sign-up successful!";
                            lblMessage.ForeColor = System.Drawing.Color.Green;

                            // Set session value to simulate user being logged in
                            Session["IsAuthenticated"] = true;
                            Session["Username"] = username;
                            Session["UserId"] = newUserId; // Store the correct integer user Id here

                            // Redirect to home page or another page after signup
                            Response.Redirect("~/");
                        }
                        else
                        {
                            lblMessage.Text = "Sign-up failed, please try again.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // This section will catch any exceptions that occur, such as database connection issues.
                lblMessage.Text = "An error occurred: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;

                // Comment: This line could expose sensitive information. In a production environment, avoid showing detailed error messages to the user.
                // Instead, log the exception details to a secure log file.
            }
        }

        // Method to hash the password
        private string HashPassword(string password)
        {
            // Use SHA256 to hash the password securely
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Method to generate a unique userId
        private string GenerateUserId(string username)
        {
            // Generate a user-friendly identifier using a combination of the username and the current timestamp
            string uniqueId = DateTime.Now.Ticks.ToString();
            return $"USER_{username}_{uniqueId}";
        }
    }
}
