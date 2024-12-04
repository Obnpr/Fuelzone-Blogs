using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Fuelzone
{
    public partial class CODBlackOps6page : System.Web.UI.Page
    {
        // Override OnInit to attach Page_Load event
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load_CODBlackOps6);
            base.OnInit(e);
        }

        // First time loading handler
        protected void Page_Load_CODBlackOps6(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadComments();
            }
        }

        // Post Comment button event
        protected void SubmitCommentButton_Click(object sender, EventArgs e)
        {
            string commentText = commentInput.Text;

            // Validate that the comment text is not empty
            if (!string.IsNullOrWhiteSpace(commentText))
            {
                // Check if the user is logged in
                if (Session["UserId"] != null)
                {
                    int userId = (int)Session["UserId"];
                    int gameId = 3; // Game ID for CODBlackOps6

                    // Save the comment to the database
                    SaveCommentToDatabase(commentText, userId, gameId);

                    // Clear the input field and reload comments
                    commentInput.Text = "";
                    LoadComments();
                }
                else
                {
                    // Display a message if the user is not logged in
                    lblMessage.Text = "You must be logged in to leave a comment.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        // Like button click event
        protected void LikeButton_Click(object sender, EventArgs e)
        {
            // Check if the user is logged in
            if (Session["UserId"] != null)
            {
                int userId = (int)Session["UserId"];
                var button = (System.Web.UI.WebControls.Button)sender;
                int commentId = int.Parse(button.CommandArgument);

                // Toggle like status
                if (UserHasLikedComment(userId, commentId))
                {
                    RemoveLikeFromDatabase(userId, commentId);
                }
                else
                {
                    AddLikeToDatabase(userId, commentId);
                }

                // Reload comments to reflect updated like count
                LoadComments();
            }
            else
            {
                // Display a message if the user is not logged in
                lblMessage.Text = "You must be logged in to like a comment.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Load comments from the database
        private void LoadComments()
        {
            int gameId = 3;  // Game ID for CODBlackOps6
            var comments = GetCommentsFromDatabase(gameId);

            // Bind the comments to the repeater control
            CommentsRepeater.DataSource = comments;
            CommentsRepeater.DataBind();
        }

        // Save a comment to the database
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
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error saving comment: " + ex.Message);
                    }
                }
            }
        }

        // Get comments from the database
        private List<Comment2> GetCommentsFromDatabase(int gameId)
        {
            var comments = new List<Comment2>();
            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT C.comment_id, C.comment_text, A.username, C.user_posted_date, " +
                               "(SELECT COUNT(*) FROM CommentLikes WHERE comment_fk_id = C.comment_id) AS LikeCount, " +
                               "A.admin " +
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
                            comments.Add(new Comment2
                            {
                                CommentId = reader.GetInt32(reader.GetOrdinal("comment_id")),
                                Username = reader["username"].ToString(),
                                CommentText = reader["comment_text"].ToString(),
                                Timestamp = Convert.ToDateTime(reader["user_posted_date"]).ToString("g"),
                                LikeCount = reader.GetInt32(reader.GetOrdinal("LikeCount")),
                                IsAdmin = reader.GetBoolean(reader.GetOrdinal("admin"))
                            });
                        }
                    }
                }
            }

            return comments;
        }

        // Add a like to the database
        private void AddLikeToDatabase(int userId, int commentId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO CommentLikes (user_fk_id, comment_fk_id) VALUES (@userId, @commentId)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@commentId", commentId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Remove a like from the database
        private void RemoveLikeFromDatabase(int userId, int commentId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM CommentLikes WHERE user_fk_id = @userId AND comment_fk_id = @commentId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@commentId", commentId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Check if the user has already liked the comment
        private bool UserHasLikedComment(int userId, int commentId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM CommentLikes WHERE user_fk_id = @userId AND comment_fk_id = @commentId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@commentId", commentId);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }

    // Comment class to hold comment data
    public class Comment2
    {
        public int CommentId { get; set; }
        public string Username { get; set; }
        public string CommentText { get; set; }
        public string Timestamp { get; set; }
        public int LikeCount { get; set; }
        public bool IsAdmin { get; set; }
    }
}