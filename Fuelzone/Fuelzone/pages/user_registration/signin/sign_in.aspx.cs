using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fuelzone.pages.user_registration.signin
{
    public partial class Sign_in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If user is already logged in, redirect them to the home page
            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {
                Response.Redirect("~/");
            }
        }

        // When the user submits the login form
        protected void btnSignin_Click(object sender, EventArgs e)
        {
            // Collecting input values from form fields
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // Basic input validation
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "Email and Password are required!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Hash the entered password
            string hashedPassword = HashPassword(password);

            // Get the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;

            try
            {
                // Connect to the database and verify user credentials
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if the email and password match any record in the database
                    string query = "SELECT Id, Username FROM Account WHERE Email = @Email AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32(0); // Get the Id column
                                string username = reader.GetString(1); // Get the Username column

                                // Set session values to indicate the user is logged in
                                Session["IsAuthenticated"] = true;
                                Session["UserId"] = userId; // Store the UserId in the session
                                Session["Username"] = username;

                                // Redirect to the home page or another page after successful login
                                Response.Redirect("~/");
                            }
                            else
                            {
                                lblMessage.Text = "Invalid email or password.";
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., database connection issues)
                lblMessage.Text = "An error occurred: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;

                // Comment: In production, log the error instead of showing it to the user
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
    }
}
