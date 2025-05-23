﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Fuelzone
{
    public partial class Contact : System.Web.UI.Page
    {
        // Override OnInit to attach Page_Load event
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load_Valorant);
            base.OnInit(e);
        }

        // If first time load, loads the current comments
        protected void Page_Load_Valorant(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadComments();
            }
        }

        // Submitting a comment handler
        protected void SubmitCommentButton_Click(object sender, EventArgs e)
        {
            string commentText = commentInput.Text;

            if (!string.IsNullOrWhiteSpace(commentText))
            {
                if (Session["UserId"] != null)
                {
                    int userId = (int)Session["UserId"];
                    int gameId = 1;
                    SaveCommentToDatabase(commentText, userId, gameId);
                    commentInput.Text = "";
                    LoadComments();
                }
                else
                {
                    lblMessage.Text = "You must be logged in to leave a comment.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        //  Liking button handler
        protected void LikeButton_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                int userId = (int)Session["UserId"];
                var button = (System.Web.UI.WebControls.Button)sender;
                int commentId = int.Parse(button.CommandArgument);

                if (UserHasLikedComment(userId, commentId))
                {
                    RemoveLikeFromDatabase(userId, commentId);
                }
                else
                {
                    AddLikeToDatabase(userId, commentId);
                }

                LoadComments();
            }
            else
            {
                lblMessage.Text = "You must be logged in to like a comment.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Load Comments from Database using Repeaters
        private void LoadComments()
        {
            int gameId = 1;
            var comments = GetCommentsFromDatabase(gameId);

            if (comments.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("No comments found.");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(comments.Count + " comments found.");
            }

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

        // Save Comment to Database
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

        // Add Like to Database
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

        // Remove Like from Database
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

        // Check if User has Liked a Comment
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

        // Get Comments from Database
        private List<Comment1> GetCommentsFromDatabase(int gameId)
        {
            var comments = new List<Comment1>();

            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT C.comment_id, C.comment_text, A.username, C.user_posted_date, " +
                               "(SELECT COUNT(*) FROM CommentLikes WHERE comment_fk_id = C.comment_id) AS LikeCount, " +
                               "A.admin " + // admin status
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
                            comments.Add(new Comment1
                            {
                                CommentId = reader.GetInt32(reader.GetOrdinal("comment_id")),
                                Username = reader["username"].ToString(),
                                CommentText = reader["comment_text"].ToString(),
                                Timestamp = Convert.ToDateTime(reader["user_posted_date"]).ToString("g"),
                                LikeCount = reader.GetInt32(reader.GetOrdinal("LikeCount")),
                                IsAdmin = reader.GetBoolean(reader.GetOrdinal("admin")) // Set IsAdmin property
                            });
                        }
                    }
                }
            }

            return comments;
        }
    }

    // Comment Class
    public class Comment1
    {
        public int CommentId { get; set; }
        public string Username { get; set; }
        public string CommentText { get; set; }
        public string Timestamp { get; set; }
        public int LikeCount { get; set; }
        public bool IsAdmin { get; set; }
    }
}
