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
using GameASU.Controller;

namespace GameASU
{
    public partial class UploadGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Boolean fileOK = false;
                String path = GameUpload.FileName;
                if (GameUpload.HasFile)
                {
                    String fileExtension = System.IO.Path.GetExtension(GameUpload.FileName).ToLower();

                    if (fileExtension == ".unity3d") { fileOK = true; }
                }

                if (fileOK)
                {
                    try
                    {
                        GameUpload.PostedFile.SaveAs(Server.MapPath("~/Games/" + GameUpload.FileName));
                        lblFileStatus.Text = "File uploaded!";
                    }
                    catch (Exception ex)
                    {
                        lblFileStatus.Text = ex.Message + ". Basically, File could not be uploaded.";
                    }
                }
                else{lblFileStatus.Text = "Cannot accept files of this type.";}
            }
        }

        protected void UploadGame_Click(object sender, EventArgs e)
        {
        }
    }
}