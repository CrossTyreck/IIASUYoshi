using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.AspNet.Identity;
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
using GameASU.Controller;
using System.Drawing;
using System.Data.Common;
using System.Data;


namespace GameASU
{
    public partial class UploadGame : System.Web.UI.Page
    {
        DBGame GameDBConn = new DBGame();
        DBDeveloper DevDBConn = new DBDeveloper();
        GamesIIS GameIIS = new GamesIIS();
        ManageGameSql GameSql = new ManageGameSql();

        protected string UserID { get; set; }

        private enum Status
        {
            UploadSuccess,
            UploadFail,
            GoodFileExt,
            BadFileExt,
        };


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { }
            else
            {
                Game Game = new Game(DevDBConn.GetDevID(Context.User.Identity.GetUserId()),
                                    txtGameName.Text, Int32.Parse(txtWidth.Text),
                                    Int32.Parse(txtHeight.Text), GameUpload.FileName,
                                    GameUpload.FileName.Replace("unity3d",
                                    GameImageUpload.FileName.Substring(GameImageUpload.FileName.LastIndexOf(".") + 1)));


                if (GameUpload.HasFile && VerifyFileExt()) { AddGame(Game); }
                if (GameImageUpload.HasFile && VerifyImageFileExt()) { AddImage(Game); }

            }
        }

        protected void UploadGame_Click(object sender, EventArgs e)
        {
        }

        private bool VerifyFileExt()
        {
            if (System.IO.Path.GetExtension(GameUpload.FileName).ToLower() == ".unity3d")
            {
                SetlblFileStatus(Status.GoodFileExt);
                return true;
            }

            SetlblFileStatus(Status.BadFileExt);

            return false;
        }

        private bool VerifyImageFileExt()
        {
            //need to refactor so that only specific image extensions are allowed
            //if (System.IO.Path.GetExtension(GameUpload.FileName).ToLower() == ".unity3d")
            //{
            //    SetlblFileImageStatus(Status.GoodFileExt);
            //    return true;
            //}

            //SetlblFileImageStatus(Status.BadFileExt);

            SetlblFileImageStatus(Status.GoodFileExt);
            return true;
        }

        private void AddGame(Game game)
        {
            try
            {
                if (!(GameSql.InsertGame(game).Equals("") &&
                    GameIIS.UploadGameToServer(game.Id.ToString() + ".unity3d", GameUpload.PostedFile)))
                    SetlblFileStatus(Status.UploadFail);

                SetlblFileStatus(Status.UploadSuccess);
            }
            catch (Exception e)
            {
                SetlblFileStatus(e.Message, Status.UploadFail);
            }


        }

        private void AddImage(Game game)
        {
            try
            {
                string GameImageName = GameUpload.FileName.Replace(GameUpload.FileName, game.Id.ToString() + "." +
                                                        GameImageUpload.FileName.Substring(
                                                        GameImageUpload.FileName.LastIndexOf(".") + 1));

                if (!(GameSql.UpdateGame(game, GameImageName).Equals("") &&
                    GameIIS.UploadGameImageToServer(GameImageName, GameImageUpload.PostedFile)))
                { SetlblFileImageStatus(Status.UploadFail); }

                SetlblFileImageStatus(Status.UploadSuccess);
            }
            catch (Exception e) { SetlblFileImageStatus(e.Message, Status.UploadFail); }
        }

        private string GetMessage(Status status)
        {
            switch (status)
            {
                case Status.UploadSuccess:
                    return "File upload successful!";
                case Status.UploadFail:
                    return "File could not be uploaded.";
                case Status.GoodFileExt:
                    return "File extension passed.";
                case Status.BadFileExt:
                    return "Cannot accept files of this type.";
                default:
                    return "Error retriving status.";
            }
        }

        private Color GetColor(Status status)
        {
            switch (status)
            {
                case Status.UploadSuccess:
                    return Color.Green;
                case Status.UploadFail:
                    return Color.Red;
                case Status.GoodFileExt:
                    return Color.Green;
                case Status.BadFileExt:
                    return Color.Red;
                default:
                    return Color.Yellow;
            }
        }

        private void SetlblFileStatus(Status status)
        {
            lblFileStatus.Text = GetMessage(status);
            lblFileStatus.BackColor = GetColor(status);
        }

        private void SetlblFileStatus(string error, Status status)
        {
            lblFileStatus.Text = error + " " + GetMessage(status);
            lblFileStatus.BackColor = GetColor(status);
        }
        private void SetlblFileImageStatus(Status status)
        {
            lblFileImageStatus.Text = GetMessage(status);
            lblFileImageStatus.BackColor = GetColor(status);
        }

        private void SetlblFileImageStatus(string error, Status status)
        {
            lblFileImageStatus.Text = error + " " + GetMessage(status);
            lblFileImageStatus.BackColor = GetColor(status);
        }
    }
}