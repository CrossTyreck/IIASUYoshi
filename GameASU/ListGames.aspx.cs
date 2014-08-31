using GameASU.Controller;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameASU
{
    public partial class ListGames : System.Web.UI.Page
    {

        protected String GamePath { get; set; }
        protected BlobStorageAccess BSAccess;

        protected String GameName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            GameName = "Space_Shooter.unity3d";
            BSAccess = new BlobStorageAccess("games");

            Panel gamePanel = new Panel();
            gamePanel.ClientIDMode = ClientIDMode.Static;
            gamePanel.ID = BSAccess.GetBlob(GameName).Name.Replace(".unity3d", "");
            GamePath = BSAccess.GetBlob(GameName).Uri.ToString();
            ImageButton gameImage = new ImageButton();
            gameImage.ClientIDMode = ClientIDMode.Static;
            gameImage.ID = "#" + BSAccess.GetBlob(GameName).Name.Replace(".unity3d", "");
            gameImage.Attributes.Add("src", "Images/wolverine.png");
            gameImage.Click += PlayGame_Click;
            gamePanel.Controls.Add(gameImage);
            Container.Controls.Add(gamePanel);
            
        }

        protected void PlayGame_Click(object sender, EventArgs e)
        {
            if (GameName != "")
            {
                CloudBlockBlob blockBlob = BSAccess.DownloadBlob(GameName);

                using (var fileStream = System.IO.File.OpenWrite(HttpContext.Current.Server.MapPath("~/Games/" + GameName)))
                {
                    blockBlob.DownloadToStream(fileStream);
                }

                Response.Redirect("GameHost.aspx?g=" + GameName);
            }
        }
    }
}