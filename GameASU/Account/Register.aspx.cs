﻿using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using GameASU.Models;
using System.Web.UI.WebControls;

namespace GameASU.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);

            if (result.Succeeded)
            {
                RoleGroup role = new RoleGroup();

                try { result = manager.AddToRole(Context.User.Identity.GetUserId(), "Player"); }

                catch (InvalidOperationException eOp)
                { Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ALERT", "alert('" + eOp.Message + " Please contact site Administrator.')", true); }

                IdentityHelper.SignIn(manager, user, isPersistent: false);

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                IdentityHelper.RedirectToReturnUrl("~/PlayerDashboard.aspx?s=" + user.UserName, Response);


            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}