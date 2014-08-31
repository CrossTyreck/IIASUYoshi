/***************************************************************/
// GameASU.Account 
/***************************************************************/
// Use this box to track changes made in code since I am not 
// using a repository.
/***************************************************************/
// 1. Add user to role before logging in.


using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using GameASU.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace GameASU.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = manager.Find(Email.Text, Password.Text);

                if (user != null)
                {
                    //#1 Remove all roles from user
                    if (user.Roles.Count > 0)
                    {
                        List<IdentityUserRole> roles = new List<IdentityUserRole>();
                        roles.AddRange(user.Roles);

                        foreach (IdentityUserRole role in roles)
                        {
                            user.Roles.Remove(role);
                        }
                    }

                    //Add user to the current role they selected
                    manager.AddToRole(user.Id, RoleDropDown.SelectedItem.Text);
                    IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                    IdentityHelper.RedirectToReturnUrl("~/Default.aspx", Response);
                }
                else
                {
                    FailureText.Text = "Invalid username or password.";
                    ErrorMessage.Visible = true;
                }
            }
        }
    }
}