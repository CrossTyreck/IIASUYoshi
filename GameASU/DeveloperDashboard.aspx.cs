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
            Panel rowContainer;
            Panel column;
            ImageButton gameImage;
            Label gameName;

            for (int row = 0; row <= 5; row++)
            {
                rowContainer = new Panel();
                rowContainer.CssClass = "row top5";

                //Rows can only contain 4 columns with the current front end
                for (int col = 0; col <= 3; col++)
                {
                    column = new Panel();
                    gameImage = new ImageButton();
                    gameName = new Label();

                    column.CssClass = "col-sm-3";
                    gameImage.CssClass = "img-responsive";

                    gameImage.ImageUrl = "Images/gametileexample.jpg";
                    gameImage.Click += new ImageClickEventHandler(gameClick);
                    gameImage.AlternateText = "Space_Shooter";

                    gameName.Text = gameImage.AlternateText + col;

                    column.Controls.Add(gameImage);
                    column.Controls.Add(gameName);

                    rowContainer.Controls.Add(column);
                }

                GameList.Controls.Add(rowContainer);
            }
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

        protected void gameClick(object sender, EventArgs e)
        {
            ImageButton gameClicked = sender as ImageButton;
            Response.Redirect("GameHost.aspx?g=" + gameClicked.AlternateText);
        }

    }
}