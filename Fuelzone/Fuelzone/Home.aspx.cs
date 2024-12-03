using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
                LoadTopComments();
                LoadRecommendedGame(); // Cargar juego recomendado
            }

            if (!IsPostBack)
            {
                bool isAuthenticated = Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"];

                // Controlar la visibilidad del recuadro
                newUserBox.Visible = !isAuthenticated;
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
            var gameDetails = new Dictionary<int, (string GameName, string ImageUrl, string PageUrl)>
            {
                { 1, ("Valorant", "/Assets/GameArtwork/Valorant.jpg", "/pages/tutorial/valorantpage") },
                { 2, ("Fortnite", "/Assets/GameArtwork/Fortnite.jpg", "/pages/tutorial/fortnitepage") },
                { 3, ("Call of Duty: Black Ops 6", "/Assets/GameArtwork/CODBlackOps6.jpg", "/pages/tutorial/codblackops6page") },
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

        private void LoadTopComments()
        {
            // Diccionario para mapear los nombres de los juegos
            var gameDetails = new Dictionary<int, (string GameName, string Color, string PageUrl)>
            {
                { 1, ("Valorant", "red", "/pages/discussion/Valorantpage") },
                { 2, ("Fortnite", "blue", "/pages/discussion/Fortnitepage") },
                { 3, ("Call of Duty: Black Ops 6", "orange", "/pages/discussion/CODBlackOps6page") }
            };

            string connectionString = ConfigurationManager.ConnectionStrings["User_account"].ConnectionString;

            string query = @"
        SELECT 
            C.comment_id AS CommentID, 
            A.username AS Username, 
            C.comment_text AS CommentText, 
            C.game_id AS GameID, 
            COUNT(CL.like_id) AS LikesCount
        FROM 
            Comment C
        INNER JOIN 
            Account A ON C.user_fk_id = A.Id
        LEFT JOIN 
            CommentLikes CL ON C.comment_id = CL.comment_fk_id
        GROUP BY 
            C.comment_id, A.username, C.comment_text, C.game_id
        ORDER BY 
            LikesCount DESC
        OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        StringBuilder html = new StringBuilder();

                        html.Append("<div style='list-style-type:none; padding:0;'>");
                        while (reader.Read())
                        {
                            int commentId = Convert.ToInt32(reader["CommentID"]);
                            string username = reader["Username"].ToString();
                            string commentText = reader["CommentText"].ToString();
                            string likesCount = reader["LikesCount"].ToString();
                            int gameId = reader["GameID"] != DBNull.Value ? Convert.ToInt32(reader["GameID"]) : 0;

                            // Obtén el nombre del juego del diccionario
                            string gameName = gameDetails.ContainsKey(gameId) ? gameDetails[gameId].GameName : "Unknown Game";
                            string gameColor = gameDetails.ContainsKey(gameId) ? gameDetails[gameId].Color : "gray";
                            string gameUrl = gameDetails.ContainsKey(gameId) ? gameDetails[gameId].PageUrl : "#";

                            string gameLink = $"{gameUrl}?commentId={commentId}";

                            html.Append("<div class='comment-box' style='border: 1px solid #ccc; padding: 15px; margin-bottom: 15px; border-radius: 5px;'>");
                            html.Append($"<h5 style='font-size:20px; font-weight:bold;'><a href='{gameLink}' style='color:{gameColor}; text-decoration:none;'>{gameName}</a></h5>");
                            html.Append($"<p style='margin:5px 0;'><strong>{username}</strong>: {commentText}</p>");
                            html.Append($"<p style='color:white; margin:5px 0;'>👍Likes: {likesCount}</p>");
                            html.Append("</div>");
                        }
                        html.Append("</div>");

                        TopCommentsLiteral.Text = html.ToString();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error loading top comments: " + ex.Message);
                    }
                }
            }
        }

        private void LoadRecommendedGame()
        {
            var recommendedGames = new Dictionary<int, (string GameName, string ImageUrl, string PageUrl)>
    {
        { 4, ("Minecraft", "/Assets/GameArtwork/Minecraft.jpg","https://www.minecraft.net/es-es") },
        { 5, ("Apex Legends", "/Assets/GameArtwork/Apex.jpg","https://store.steampowered.com/app/1172470/Apex_Legends/") },
        { 6, ("The Witcher 3", "/Assets/GameArtwork/TheWitcher3.jpg", "https://store.steampowered.com/app/292030/The_Witcher_3_Wild_Hunt/") },
        { 7, ("Destiny 2", "/Assets/GameArtwork/Destiny2.jpg","https://store.steampowered.com/app/1085660/Destiny_2/") },
        { 8, ("Path of Exile 2", "/Assets/GameArtwork/PathofExile2.jpg","https://store.steampowered.com/app/2694490/Path_of_Exile_2/") },
        { 10,("New World: Aeternum", "/Assets/GameArtwork/NewWorldAeternum.jpg","https://store.steampowered.com/app/1063730/New_World_Aeternum/") },
        { 11, ("The Legend of Zelda: Breath of the Wild", "/Assets/GameArtwork/TheLegendofZeldaBreathoftheWild.jpg", "https://www.nintendo.com/us/store/products/the-legend-of-zelda-breath-of-the-wild-switch/") }
    };

            try
            {
                // Convertir el diccionario a JSON con nombres de propiedades explícitas
                var jsonGames = Newtonsoft.Json.JsonConvert.SerializeObject(recommendedGames.Values.Select(game => new
                {
                    GameName = game.GameName,
                    ImageUrl = game.ImageUrl,
                    PageUrl = game.PageUrl
                }));

                var initialGame = recommendedGames[4]; // Juego inicial predeterminado

                StringBuilder html = new StringBuilder();
                html.AppendFormat(@"
<div id=""recommended-container"" class=""text-center mb-4"">
    <a id=""recommended-link"" href=""{0}"" target=""_blank"">
        <img id=""recommended-image"" src=""{1}"" alt=""{2}"" class=""img-fluid mb-3"" style=""max-height: 400px; width: 100%; object-fit: cover; border-radius: 10px;"" />
    </a>
    <h4 id=""recommended-title"">{2}</h4>
</div>
<script>
    var games = {3}; // Juegos en formato JSON
    var currentIndex = 0;

    function updateGame() {{
        var container = document.getElementById('recommended-container');
        var link = document.getElementById('recommended-link');
        var image = document.getElementById('recommended-image');
        var title = document.getElementById('recommended-title');

        currentIndex = (currentIndex + 1) % games.length;
        var game = games[currentIndex];

        link.href = game.PageUrl;
        image.src = game.ImageUrl;
        image.alt = game.GameName;
        title.textContent = game.GameName;
    }}

    // Cambiar juego cada 10 segundos
    setInterval(updateGame, 5500);
</script>",
                    initialGame.PageUrl, initialGame.ImageUrl, initialGame.GameName, jsonGames);

                // Asignar el HTML generado al Literal correspondiente
                RecommendedGamesLiteral.Text = html.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading recommended game: " + ex.Message);

                // Valor predeterminado en caso de error
                RecommendedGamesLiteral.Text = @"
        <div class=""text-center mb-4"">
            <h4>Game recommendations unavailable</h4>
            <p>Check back later for more exciting game suggestions!</p>
        </div>";
            }
        }


    }
}
