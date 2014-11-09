using GameASU.Controller;
using GameASU.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GameASU
{
    public partial class GameHost : System.Web.UI.Page
    {
        protected String GameName { get; set; }

        DBGame GameDBConn = new DBGame();

        protected void Page_Load(object sender, EventArgs e)
        {
            GameName = Request.QueryString["g"];

            Game GametoLoad = GameDBConn.GetGame(GameName);
            GameNameHeader.Text = GametoLoad.GameName;

            Panel gamePanel = new Panel();
            gamePanel.ClientIDMode = ClientIDMode.Static;
            gamePanel.ID = GametoLoad.GameNameOnServer.Replace(".unity3d", "");

            ImageButton gameImage = new ImageButton();
            gameImage.AlternateText = "CLICK TO PLAY!";
            gameImage.ClientIDMode = ClientIDMode.Static;
            gameImage.ID = "#" + GametoLoad.GameNameOnServer.Replace(".unity3d", "");
            gameImage.Attributes.Add("onclick", "javascript:LoadUnityAfterClick('Games/" + GametoLoad.GameNameOnServer + "', '375', '750', '" + GametoLoad.GameNameOnServer.Replace(".unity3d", "") + "')");
            gameImage.Attributes.Add("src", "Images/" + GametoLoad.TileImageLocation);

            gamePanel.Controls.Add(gameImage);

            Container.Controls.Add(gamePanel);
        }
    }
}