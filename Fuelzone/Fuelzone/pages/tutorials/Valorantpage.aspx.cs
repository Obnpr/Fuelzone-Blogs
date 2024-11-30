using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Fuelzone
{
    public partial class Contact : System.Web.UI.Page
    {
        // Moving the event registration to Page_Init
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load_Valorant);
            base.OnInit(e);
        }

        // Standard Page Load for initial setup
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
                if (Session["UserId"] != null)
                {
                    int userId = (int)Session["UserId"]; // Retrieve logged-in user's ID from the session
                    int gameId = 1; // Static value of game_id to save in the database for each comment
                    SaveCommentToDatabase(commentText, userId, gameId); // Save the comment to the database
                    commentInput.Text = ""; // Clear the input field
                    LoadComments(); // Reload comments to reflect the new addition
                }
                else
                {
                    lblMessage.Text = "You must be logged in to leave a comment."; // Show a message if user is not logged in
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void LoadComments()
        {
            int gameId = 1; // Only load comments for game_id = 1
            var comments = GetCommentsFromDatabase(gameId);

            if (comments.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("No comments found.");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(comments.Count + " comments found.");
            }

            // Make sure CommentsRepeater is correctly initialized
            if (CommentsRepeater == null)
            {
                System.Diagnostics.Debug.WriteLine("CommentsRepeater is null.");
            }
            else
            {
                CommentsRepeater.DataSource = comments;
                CommentsRepeater.DataBind();
            }
        }

        private void SaveCommentToDatabase(string commentText, int userId, int gameId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Comment (comment_text, user_fk_id, game_id) VALUES (@commentText, @userId, @gameId)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@commentText", commentText);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@gameId", gameId);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine("Comment saved successfully.");
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error saving comment: " + ex.Message);
                    }
                }
            }
        }

        private List<Comment> GetCommentsFromDatabase(int gameId)
        {
            var comments = new List<Comment>();

            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT C.comment_id, C.comment_text, A.username, C.user_posted_date " +
                               "FROM Comment C " +
                               "INNER JOIN Account A ON C.user_fk_id = A.Id " +
                               "WHERE C.game_id = @gameId " +
                               "ORDER BY C.user_posted_date DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@gameId", gameId);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comments.Add(new Comment
                            {
                                CommentId = reader.GetInt32(reader.GetOrdinal("comment_id")),
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

    public class Comment
    {
        public int CommentId { get; set; }
        public string Username { get; set; }
        public string CommentText { get; set; }
        public string Timestamp { get; set; }
    }
}
