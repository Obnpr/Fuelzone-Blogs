using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Fuelzone.pages
{
    public partial class Tutorialmainpage : System.Web.UI.Page
    {
        // Create a dictionary with game details: GameID, (GameName, ImageUrl, PageUrl)
        private static readonly Dictionary<int, (string GameName, string ImageUrl, string PageUrl)> gameDetails = new Dictionary<int, (string GameName, string ImageUrl, string PageUrl)>
        {
            { 1, ("Valorant", "/Assets/GameArtwork/Valorant.jpg", "/pages/tutorials/valorantpage") },
            { 2, ("Fortnite", "/Assets/GameArtwork/Fortnite.jpg", "/pages/tutorials/fortnitepage") },
            { 3, ("Call of Duty: Black Ops 6", "/Assets/GameArtwork/CODBlackOps6.jpg", "/pages/tutorials/codblackops6page") },
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFeaturedGame();
            }
        }

        private void LoadFeaturedGame()
        {
            // Get a random game ID
            Random random = new Random();
            int randomGameId = random.Next(1, gameDetails.Count + 1);

            // Retrieve the game details from the dictionary
            var game = gameDetails[randomGameId];

            // Update the HTML content dynamically
            featuredGameLink.HRef = game.PageUrl;
            featuredGameImage.Src = game.ImageUrl;
            featuredGameImage.Alt = game.GameName;
        }
    }
}
