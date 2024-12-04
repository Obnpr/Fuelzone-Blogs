using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Fuelzone.pages
{
    public partial class Tutorialmainpage : System.Web.UI.Page
    {
        // Dictionary with game details: GameID, (GameName, ImageUrl, PageUrl)
        private static readonly Dictionary<int, (string GameName, string ImageUrl, string PageUrl)> gameDetails = new Dictionary<int, (string GameName, string ImageUrl, string PageUrl)>
        {
            { 1, ("Valorant", "/Assets/GameArtwork/Valorant.jpg", "/pages/tutorial/valorantpage") },
            { 2, ("Fortnite", "/Assets/GameArtwork/Fortnite.jpg", "/pages/tutorial/fortnitepage") },
            { 3, ("Call of Duty: Black Ops 6", "/Assets/GameArtwork/CODBlackOps6.jpg", "/pages/tutorial/codblackops6page") },
        };

        // Page_Load method is called when the page is loaded. If not postback loads LoadFeaturedGame()
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFeaturedGame();
            }
        }

        // LoadFeaturedGame method selects a random game and updates the featured game section on the page.
        private void LoadFeaturedGame()
        {
            // Generate a random number.
            Random random = new Random();
            int randomGameId = random.Next(1, gameDetails.Count + 1);

            // Retrieve the game details from the dictionary, using randomGameId.
            var game = gameDetails[randomGameId];

            // Update the HTML.
            featuredGameLink.HRef = game.PageUrl;
            featuredGameImage.Src = game.ImageUrl;
            featuredGameImage.Alt = game.GameName;
        }
    }
}
