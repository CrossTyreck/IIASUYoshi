using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameASU
{
    public partial class DeveloperDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetDevName();
        }

        private void GetDevName()
        {
            ContentPlaceHolder mpNavBar;
            Label mpDevName;
            mpNavBar = (ContentPlaceHolder)Master.FindControl("NavBar");
            if (mpNavBar != null)
            {
                mpDevName = (Label)mpNavBar.FindControl("DevName");
                if (mpDevName != null)
                {
                    mpDevName.Text = Context.User.Identity.Name == "" ? "Error Retrieving Name" : Context.User.Identity.Name;
                    mpDevName.Text += "&nbsp&nbsp&nbsp |";
                }
            }
        }
    }
}