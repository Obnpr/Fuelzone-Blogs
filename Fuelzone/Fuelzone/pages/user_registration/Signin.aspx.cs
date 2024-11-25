using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

namespace Fuelzone.pages.user_registration.Signin
{
    public partial class Signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If user is already logged in, redirect them to the home page
            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {
                Response.Redirect("~/");
            }
        }
    }
}
