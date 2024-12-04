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
        // Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            // If user is already logged in, redirect them to the home page
            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {
                Response.Redirect("~/");
            }
        }

        // Button click handler
        protected void btnSignin_Click(object sender, EventArgs e)
        {
            // Collecting input values from form fields
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // Input validation
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "Email and Password are required!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Hash the entered password for comparison
            string hashedPassword = HashPassword(password);

            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL query to check if the email and hashed password match any record in the database
                    string query = "SELECT Id, Username FROM Account WHERE Email = @Email AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve user details from the query result
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
                                // Display error message if credentials are incorrect
                                lblMessage.Text = "Invalid email or password.";
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions. Like database connection issues
                lblMessage.Text = "An error occurred: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Method to hash the password using SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                // Convert each byte to a hexadecimal string
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
