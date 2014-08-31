using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameASU.Controller;

namespace GameASU
{
    public partial class GameHost : System.Web.UI.Page
    {
        protected String GameName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            GameName = Request.QueryString["g"];

            Panel gamePanel = new Panel();
            gamePanel.ClientIDMode = ClientIDMode.Static;
            gamePanel.ID = GameName.Replace(".unity3d", "");
            Image gameImage = new Image();
            gameImage.ClientIDMode = ClientIDMode.Static;
            gameImage.ID = "#" + GameName.Replace(".unity3d", "");
            gameImage.Attributes.Add("onclick", "javascript:LoadUnityAfterClick('Games/" + GameName +"', '375', '750', 'Space_Shooter')");
            gameImage.Attributes.Add("src", "Images/wolverine.png");
            gamePanel.Controls.Add(gameImage);
            Container.Controls.Add(gamePanel);
        }
    }
}