using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fuelzone
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRegisteredUserCount();
                LoadTopDiscussedGames();
            }
        }

        private void LoadRegisteredUserCount()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;
            string query = "SELECT COUNT(*) FROM Account";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        int userCount = (int)cmd.ExecuteScalar();
                        RegisteredUserCountLiteral.Text = "Total registered users: " + userCount;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error loading user count: " + ex.Message);
                    }
                }
            }
        }

        private void LoadTopDiscussedGames()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;
            string query = "SELECT TOP 3 game_id, COUNT(*) AS CommentCount FROM Comment GROUP BY game_id ORDER BY CommentCount DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<int> topGameIds = new List<int>();
                            while (reader.Read())
                            {
                                topGameIds.Add(reader.GetInt32(0));
                            }
                            SetTopDiscussedGamesDetails(topGameIds);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error loading top discussed games: " + ex.Message);
                    }
                }
            }
        }

        private void SetTopDiscussedGamesDetails(List<int> gameIds)
        {
            // Dummy data mapping for demonstration purposes
            // Ideally, you would fetch this information from a database table containing game details
            var gameDetails = new Dictionary<int, (string GameName, string ImageUrl, string PageUrl)>
            {
                { 1, ("Valorant", "/Assets/GameArtwork/Valorant.jpg", "/pages/tutorials/valorantpage") },
                { 2, ("Fortnite", "/Assets/GameArtwork/Fortnite.jpg", "/pages/tutorials/fortnitepage") },
                { 3, ("Call of Duty: Black Ops 6", "/Assets/GameArtwork/CODBlackOps6.jpg", "/pages/tutorials/codblackops6page") },
            };

            string htmlContent = "<div class=\"row\">";
            foreach (var gameId in gameIds)
            {
                if (gameDetails.ContainsKey(gameId))
                {
                    var details = gameDetails[gameId];
                    htmlContent += $"<div class=\"col-md-4 mb-3 text-center\">" +
                                   $"<a href=\"{details.PageUrl}\">" +
                                   $"<img src=\"{details.ImageUrl}\" class=\"img-fluid\" alt=\"{details.GameName}\" />" +
                                   "</a>" +
                                   $"<h5>{details.GameName}</h5>" +
                                   "</div>";
                }
            }
            htmlContent += "</div>";

            MostDiscussedGameLiteral.Text = htmlContent;
        }
    }
}
