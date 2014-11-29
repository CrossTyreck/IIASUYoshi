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
using System.Data;

namespace GameASU
{
    public partial class RoleMembership : System.Web.UI.Page
    {

        private DBRole RoleDBConn = new DBRole();
        private ManageGameSql GameSql = new ManageGameSql();
        private DBDeveloper DevDBConn = new DBDeveloper();
        private GamesIIS ServerContext = new GamesIIS();
        private DBGame GameDb = new DBGame();

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

                        BindGameGridData();
                }
                catch { }


             


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
                        if (!ValidateCommandWithUser(UserManager))
                        {
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

        private void BindGameGridData()
        {
            Dictionary<int, string> GameListByDev = GameSql.GetGameListForGrid();

            GameList.DataSource = GameListFormatted(GameListByDev);
            GameList.DataBind();

            if (GameList.Rows.Count > 0)
            {
                GameList.UseAccessibleHeader = true;
                GameList.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                RemoveGames.Visible = false;
                DeleteGameMessage.Text = "There are no games on the server.";
                DeleteGameMessage.ForeColor = System.Drawing.Color.Red;
                DeleteGameMessage.Visible = true;
            }
        }

        public DataTable GameListFormatted(Dictionary<int, string> gameList)
        {
            DataTable GameTable = new DataTable();
            DataRow GameRow = null;

            GameTable.Columns.Add("Item");
            GameTable.Columns.Add("GameName");

            foreach (int gameID in gameList.Keys)
            {
                GameRow = GameTable.NewRow();
                GameRow["Item"] = gameID;
                GameRow["GameName"] = gameList[gameID];


                GameTable.Rows.Add(GameRow);
            }
            return GameTable;
        }

        private bool ValidateCommandWithUser(ApplicationUserManager userManager)
        {
            return userManager.IsInRole(userManager.FindByName(UsersListBox.SelectedItem.ToString()).Id, RolesListBox.SelectedItem.ToString());
        }

        protected void DeleteSelectedGames_Click(object sender, EventArgs e)
        {
            bool DisplayMessage = false;
            int DeveloperID = DevDBConn.GetDevID(Context.User.Identity.GetUserId());
            DeleteGameMessage.Text = "Game Removed!";
            int GameID = -1;

            foreach (GridViewRow row in GameList.Rows)
            {

                CheckBox cb = (CheckBox)row.FindControl("SelectedGame");
                if (cb != null && cb.Checked)
                {
                    GameID = Int32.Parse(row.Cells[1].Text);

                    if (DeveloperID > -1 && GameID > -1)
                        if (!(ServerContext.RemoveObjectsFromServer(GameDb.GetGameNameByID(GameID), GameDb.GetImageNameByID(GameID)) && GameSql.DeleteGame(DeveloperID, GameID)))
                        {
                            DeleteGameMessage.Text = "Error removing Game.";
                        }
                }
            }

            if (!DisplayMessage)
            {
                BindGameGridData();
            }

            DeleteGameMessage.Visible = true;
        }



    }
}