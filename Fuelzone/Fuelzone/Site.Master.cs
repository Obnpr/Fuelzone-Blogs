using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fuelzone
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is authenticated using .NET var "IsAuthenticated"
            bool isAuthenticated = Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"];

            // Config visibility of buttons based on authentication status
            Li2.Visible = isAuthenticated;          // Show Sign-Out link if authenticated
            signUpLink.Visible = !isAuthenticated;  // Show Sign-In link if not authenticated
            Li1.Visible = !isAuthenticated;         // Show Sign-Up link if not authenticated
            Prfle.Visible = isAuthenticated;        // Show Profile button if authenticated
        }

        // Sign-Out Profile button click event
        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Logout();
            Response.Redirect("~/Home.aspx"); // Redirects user to Home page
        }

        protected void Logout()
        {
            // Clear the authentication, signs-out user
            System.Web.Security.FormsAuthentication.SignOut();

            // Clear all session data
            Session.Clear();
            Session.Abandon();

            // Clear authentication cookies
            if (Request.Cookies[".ASPXAUTH"] != null)
            {
                HttpCookie authCookie = new HttpCookie(".ASPXAUTH");
                authCookie.Expires = DateTime.Now.AddDays(-1); // Set the cookie to expire in the past
                Response.Cookies.Add(authCookie);
            }
        }
    }
}
