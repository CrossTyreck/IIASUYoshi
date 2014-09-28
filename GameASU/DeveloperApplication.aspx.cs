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

namespace GameASU
{
    public partial class DeveloperApplication : System.Web.UI.Page
    {



        protected void Page_Load()
        {
            
          
        }

        protected void CheckDevRole_Click(object sender, EventArgs e)
        {
            if (!acceptTerms.Checked)
            {
                TermsLabel.ForeColor = System.Drawing.Color.Red;
                TermsLabel.Text = "Please accept the terms to become a developer.";
            }
            else
            {
                if(AddDeveloperRole())
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ALERT", "alert('" + User.Identity.GetUserName() + " successfully added to Developer role.')", true);
                }

            }
        }

        private bool AddDeveloperRole() 
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
          
            RoleGroup role = new RoleGroup();

            try
            {
                IdentityResult result = manager.AddToRole(Context.User.Identity.GetUserId(), "Developer");
               
            }
            catch (InvalidOperationException eOp)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ALERT", "alert('" + eOp.Message + " Please contact site Administrator.')", true);
                return false;
            }

            return true;
        }


    }
}