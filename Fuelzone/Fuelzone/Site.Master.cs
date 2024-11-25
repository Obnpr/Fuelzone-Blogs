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
            if (IsPostBack)
            {
                // Set visibility based on authentication status
                btnProfile.Visible = Context.User.Identity.IsAuthenticated;
            }
        }
        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Logout();
            Response.Redirect("~/Home.aspx");
        }

        protected void Logout()
        {
            // Clear the authentication ticket and sign the user out
            System.Web.Security.FormsAuthentication.SignOut();

            // Clear all session data
            Session.Clear();
            Session.Abandon();

            // Clear cookies (optional, if cookies are used for authentication)
            if (Request.Cookies[".ASPXAUTH"] != null)
            {
                HttpCookie authCookie = new HttpCookie(".ASPXAUTH");
                authCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(authCookie);
            }
        }


    }
}