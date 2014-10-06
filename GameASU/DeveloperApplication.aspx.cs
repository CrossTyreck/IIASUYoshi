using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using GameASU.Models;
using System.Text;
using GameASU.Controller;
using System.Web.Security;

namespace GameASU
{
    public partial class DeveloperApplication : System.Web.UI.Page
    {
        #region Variables

        private DBDeveloper DeveloperDBCon = new DBDeveloper();
        private string UserID = "";
        private string UserName = "";

        #endregion

        protected void Page_Load()
        {
            UserID = Context.User.Identity.GetUserId();
            UserName = Context.User.Identity.GetUserName();
        }

        #region Protected Methods

        protected void CheckDevRole_Click(object sender, EventArgs e)
        {
            if (!acceptTerms.Checked)
            {
                TermsLabel.ForeColor = System.Drawing.Color.Red;
                TermsLabel.Text = "Please accept the terms to become a developer.";
            }
            else
            {
                if (AddDeveloperRole() && AddDeveloperToDB())
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ALERT", "alert('" + UserName + " is now a Developer!')", true);
                    IdentityHelper.RedirectToReturnUrl("~/Default.aspx", Response);
                }

            }
        }

        #endregion

        #region Private Methods

        private bool AddDeveloperRole()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            RoleGroup role = new RoleGroup();

            try
            {
                IdentityResult result = manager.AddToRole(UserID, "Developer");
                
                

            }
            catch (InvalidOperationException eOp)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ALERT", "alert('" + eOp.Message + " Please contact site Administrator.')", true);
                return false;
            }

            return true;
        }

        private bool AddDeveloperToDB()
        {
            using (DeveloperDBCon)
            {
                return DeveloperDBCon.InsertDeveloper(UserID);
            }
        }

        #endregion

    }
}