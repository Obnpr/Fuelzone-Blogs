﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace Fuelzone
{
    public partial class Profile : Page
    {
        // Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verifying authentication using Session
                bool isAuthenticated = Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"];

                if (isAuthenticated)
                {
                    string username = Session["Username"] as string;
                    if (!string.IsNullOrEmpty(username))
                    {
                        UsernameLiteral.Text = "Authenticated as: " + username; // Display authenticated username
                        LoadUserProfile(username); // Load user profile data
                        LoadUserComments(username); // Load user comments
                    }
                    else
                    {
                        UsernameLiteral.Text = "Error: Username not available in session.";
                        EmailLiteral.Text = "Error loading email.";
                    }
                }
                else
                {
                    UsernameLiteral.Text = "Please log in to view your profile.";
                    EmailLiteral.Text = "Authentication required.";
                    UserCommentsLiteral.Text = "<p>No comments to display.</p>";
                }
            }
        }

        // LoadUserProfile - Loads user profile details from the database
        private void LoadUserProfile(string username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;
            string query = @"
                SELECT 
                    RTRIM(LTRIM(username)) AS Username, 
                    RTRIM(LTRIM(email)) AS Email 
                FROM 
                    Account 
                WHERE 
                    RTRIM(LTRIM(username)) = @Username";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username.Trim());

                    try
                    {
                        conn.Open(); 
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // Update the UI with the user's profile information
                            UsernameLiteral.Text = reader["Username"].ToString();
                            EmailLiteral.Text = reader["Email"].ToString();
                        }
                        else
                        {
                            UsernameLiteral.Text = "User not found.";
                            EmailLiteral.Text = "Email not available.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log error and show fallback messages
                        System.Diagnostics.Debug.WriteLine("Error loading user profile: " + ex.Message);
                        UsernameLiteral.Text = "Error loading profile.";
                        EmailLiteral.Text = "Error loading email.";
                    }
                }
            }
        }

        // LoadUserComments - Loads user comments from the database
        private void LoadUserComments(string username)
        {
            // Dictionary to map game details
            var gameDetails = new Dictionary<int, (string GameName, string Color, string PageUrl)>
            {
                { 1, ("Valorant", "red", "/pages/discussion/Valorantpage") },
                { 2, ("Fortnite", "blue", "/pages/discussion/Fortnitepage") },
                { 3, ("Call of Duty: Black Ops 6", "orange", "/pages/discussion/CODBlackOps6page") }
            };

            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;

            // SQL query to retrieve user comments and likes
            string query = @"
                SELECT 
                    C.comment_id AS CommentID, 
                    C.comment_text AS CommentText, 
                    C.game_id AS GameID, 
                    COUNT(CL.like_id) AS LikesCount 
                FROM 
                    Comment C
                LEFT JOIN 
                    CommentLikes CL ON C.comment_id = CL.comment_fk_id
                WHERE 
                    C.user_fk_id = (SELECT Id FROM Account WHERE RTRIM(LTRIM(username)) = @Username)
                GROUP BY 
                    C.comment_id, C.comment_text, C.game_id
                ORDER BY 
                    LikesCount DESC";

            // Establish a connection with the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username.Trim());

                    try
                    {
                        conn.Open(); 
                        SqlDataReader reader = cmd.ExecuteReader();
                        StringBuilder html = new StringBuilder();

                        // Start building the HTML for comments
                        html.Append("<div style='list-style-type:none; padding:0;'>");
                        while (reader.Read())
                        {
                            int commentId = Convert.ToInt32(reader["CommentID"]);
                            string commentText = reader["CommentText"].ToString();
                            int likesCount = Convert.ToInt32(reader["LikesCount"]);
                            int gameId = reader["GameID"] != DBNull.Value ? Convert.ToInt32(reader["GameID"]) : 0;

                            // Retrieve game details from dictionary
                            string gameName = gameDetails.ContainsKey(gameId) ? gameDetails[gameId].GameName : "Unknown Game";
                            string gameColor = gameDetails.ContainsKey(gameId) ? gameDetails[gameId].Color : "gray";
                            string gameUrl = gameDetails.ContainsKey(gameId) ? gameDetails[gameId].PageUrl : "#";

                            string gameLink = $"{gameUrl}?commentId={commentId}";

                            // Build HTML for each comment
                            html.Append("<div class='comment-box' style='border: 1px solid #ccc; padding: 15px; margin-bottom: 15px; border-radius: 5px;'>");
                            html.Append($"<h5 style='font-size:20px; font-weight:bold;'><a href='{gameLink}' style='color:{gameColor}; text-decoration:none;'>{gameName}</a></h5>");
                            html.Append($"<p style='margin:5px 0;'><strong>{username}</strong>: {commentText}</p>");
                            html.Append($"<p style='color:white; margin:5px 0;'>👍Likes: {likesCount}</p>");
                            html.Append("</div>");
                        }
                        html.Append("</div>");

                        UserCommentsLiteral.Text = html.ToString();
                    }
                    catch (Exception ex)
                    {
                        // Log error and show fallback message
                        System.Diagnostics.Debug.WriteLine("Error loading user comments: " + ex.Message);
                        UserCommentsLiteral.Text = "<p>Error loading comments.</p>";
                    }
                }
            }
        }
    }
}
