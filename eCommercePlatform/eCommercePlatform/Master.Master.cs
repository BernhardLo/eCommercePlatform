using SQLHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommercePlatform
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (Session["Username"] == null)
            {
                //Signup Modal
                sb.Append("<li>");
                sb.Append("<a data-toggle=\"modal\" href=\"/Index.aspx#signupModal\">");
                sb.Append("<span class=\"glyphicon glyphicon-user\"></span>");
                sb.Append("&nbsp;&nbsp;Sign Up");
                sb.Append("</a>");
                sb.Append("</li>");

                //Login Modal
                sb.Append("<li>");
                sb.Append("<a data-toggle=\"modal\" href=\"/Index.aspx#loginModal\">");
                sb.Append("<span class=\"glyphicon glyphicon-log-in\"></span>");
                sb.Append("&nbsp;&nbsp;Login");
                sb.Append("</a>");
                sb.Append("</li>");
            }
            else
            {
                //Profile
                sb.Append("<li>");
                sb.Append("<a data-toggle=\"modal\" href=\"/Index.aspx#profileModal\">");
                sb.Append("<span class=\"glyphicon glyphicon-user\"></span>");
                sb.Append("&nbsp;&nbsp;Profile");
                sb.Append("</a>");
                sb.Append("</li>");

                //Log Out
                sb.Append("<li>");
                sb.Append("<a data-toggle=\"modal\" href=\"/Index.aspx#logoutModal\">");
                sb.Append("<span class=\"glyphicon glyphicon-log-out\"></span>");
                sb.Append("&nbsp;&nbsp;Log Out");
                sb.Append("</a>");
                sb.Append("</li>");
            }

            rightnav.Text = sb.ToString();
        }

    }
}