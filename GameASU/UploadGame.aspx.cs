using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using GameASU.Data;
using GameASU.Models;
using GameASU.Model;


namespace GameASU
{
    public partial class UploadGame : System.Web.UI.Page
    {
        DBGame gameDBContext = new DBGame();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (VerifyFileExt())
                {
                    UploadGameToServer();
                }
            }
        }

        protected void UploadGame_Click(object sender, EventArgs e)
        {
        }

        private bool VerifyFileExt()
        {
            if (GameUpload.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(GameUpload.FileName).ToLower();

                if (fileExtension == ".unity3d") { return true; }
            }

            lblFileStatus.Text = "Cannot accept files of this type.";
            return false;
        }

        private bool UploadGameToServer()
        {
            try
            {
                if (AddGame(txtGameName.Text, Int32.Parse(txtWidth.Text), Int32.Parse(txtHeight.Text)))
                    GameUpload.PostedFile.SaveAs(Server.MapPath("~/Games/" + GameUpload.FileName));
                lblFileStatus.Text = "File upload successful!";
                return true;
            }
            catch (Exception e)
            {
                lblFileStatus.Text = e.Message + ". File could not be uploaded.";
            }

            return false;

        }

        private bool AddGame(string gameName, int screenWidth, int screenHeight)
        {
            Table<Game> Games = gameDBContext.GetTable<Game>();
            Games.InsertOnSubmit(new Game(IdentityHelper.GetUserIdFromRequest(Request), gameName, screenWidth, screenHeight));
          
            return true;
        }
    }
}