using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using GameASU.Models;
using GameASU.Controller;
using System.Data.Linq;
using GameASU.Data;

namespace GameASU
{
    public partial class RoleMembership : System.Web.UI.Page
    {

        private DBRole RoleDBConn = new DBRole();

        private enum UserControl
        {
            Add,
            Remove
        };

        public void Page_Load()
        {

            if (!IsPostBack)
            {
                try
                {
                    var UserManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

                    foreach (var user in UserManager.Users)
                    {
                        UsersListBox.Items.Add(user.UserName);

                    }

                    using (RoleDBConn)
                    {
                        foreach (var role in RoleDBConn.SelectTableData())
                        {
                            RolesListBox.Items.Add(role.Name);
                        }
                    }
                }
                catch (Exception e) { }

            }
        }


        public void AddUser_OnClick(object sender, EventArgs args)
        {
            if (CheckSelectedItems())
            {
                UserManipulation(UserControl.Add);
            }
        }

        public void RemoveUser_OnClick(object sender, EventArgs args)
        {
            if (CheckSelectedItems())
            {
                UserManipulation(UserControl.Remove);
            }

        }

        private bool CheckSelectedItems()
        {
            if (UsersListBox.SelectedItem == null)
            {
                Msg.Text = "Please select a user.";
                return false;
            }

            if (RolesListBox.SelectedItem == null)
            {
                Msg.Text = "Please select a role.";
                return false;
            }

            return true;
        }

        private void UserManipulation(UserControl command)
        {
            try
            {
                var UserManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

                switch (command)
                {
                    case UserControl.Add:
                        if(!ValidateCommandWithUser(UserManager)){
                        UserManager.AddToRole(UserManager.FindByName(UsersListBox.SelectedItem.ToString()).Id, RolesListBox.SelectedItem.ToString());
                        Msg.Text = "User added to Role.";
                        }
                        else { Msg.Text = "User already in Role."; }
                        return;
                    case UserControl.Remove:
                        if (ValidateCommandWithUser(UserManager))
                        {
                            UserManager.RemoveFromRole(UserManager.FindByName(UsersListBox.SelectedItem.ToString()).Id, RolesListBox.SelectedItem.ToString());
                            Msg.Text = "User removed from Role.";
                        }
                        else { Msg.Text = "User not in Role."; }
                        return;
                    default:
                        Msg.Text = "Error retrieving User Control Command.";
                        return;
                }
            }
            catch (Exception e) { Msg.Text = e.Message; }
        }

        private bool ValidateCommandWithUser(ApplicationUserManager userManager)
        {
            return userManager.IsInRole(userManager.FindByName(UsersListBox.SelectedItem.ToString()).Id, RolesListBox.SelectedItem.ToString());
        }
    }
}