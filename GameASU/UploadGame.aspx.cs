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


namespace GameASU
{
    public partial class UploadGame : System.Web.UI.Page
    {
        DBGame GameDBConn = new DBGame();
        DBDeveloper DevDBConn = new DBDeveloper();
        GamesServer GameServer = new GamesServer();

        protected string UserID { get; set; }

        private enum Status
        {
            UploadSuccess,
            UploadFail,
            GoodFileExt,
            BadFileExt
        };


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { }
            else
            { if (GameUpload.HasFile && VerifyFileExt()) { AddGame(); } }
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

        private void AddGame()
        {
            try
            {
                if (!GameServer.UploadGameToServer(GameUpload.FileName, GameUpload.PostedFile)
                || !GameDBConn.InsertGame(DevDBConn.GetDevId(User.Identity.GetUserId()), txtGameName.Text, Int32.Parse(txtWidth.Text), Int32.Parse(txtHeight.Text)))
                {
                    SetlblFileStatus(Status.UploadFail);
                }

                SetlblFileStatus(Status.UploadSuccess);
            }
            catch (Exception e)
            {
                SetlblFileStatus(e.Message, Status.UploadFail);
            }


        }

        private void AddGame(string gameName, int screenWidth, int screenHeight)
        {


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
    }
}