using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Fuelzone
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load_Valorant(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadComments(); // Load comments on initial page load
            }
        }

        protected void SubmitCommentButton_Click(object sender, EventArgs e)
        {
            string commentText = commentInput.Text;

            if (!string.IsNullOrWhiteSpace(commentText))
            {
                // Check if user is logged in by verifying Session variable
                if (Session["UserId"] != null)
                {
                    int userId = (int)Session["UserId"]; // Retrieve logged-in user's ID from the session

                    // Save the comment to the database
                    SaveCommentToDatabase(commentText, userId);
                    commentInput.Text = ""; // Clear the input field
                    LoadComments(); // Reload comments
                }
                else
                {
                    // Handle scenario where user is not logged in
                    // You could redirect them to the login page or show an appropriate message
                    Response.Redirect("Home.aspx");
                }
            }
        }

        private void LoadComments()
        {
            // Retrieve comments from the database
            var comments = GetCommentsFromDatabase();

            // Bind comments to the Repeater
            CommentsRepeater.DataSource = comments;
            CommentsRepeater.DataBind();
        }

        private void SaveCommentToDatabase(string commentText, int userId)
        {
            // Retrieve connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Comment (comment_text, user_fk_id) VALUES (@commentText, @userId)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@commentText", commentText);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private List<Comment> GetCommentsFromDatabase()
        {
            var comments = new List<Comment>();

            // Retrieve connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT C.comment_id, C.comment_text, A.username, C.user_posted_date " +
                               "FROM Comment C " +
                               "INNER JOIN Account A ON C.user_fk_id = A.Id " +
                               "ORDER BY C.user_posted_date DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comments.Add(new Comment
                            {
                                Username = reader["username"].ToString(),
                                CommentText = reader["comment_text"].ToString(),
                                Timestamp = Convert.ToDateTime(reader["user_posted_date"]).ToString("g")
                            });
                        }
                    }
                }
            }

            return comments;
        }
    }

    // Comment class for displaying comments in the Repeater
    public class Comment
    {
        public string Username { get; set; }
        public string CommentText { get; set; }
        public string Timestamp { get; set; }
    }
}
