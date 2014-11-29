using GameASU.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.AspNet.Identity;
using GameASU.Data;

namespace GameASU
{
    public partial class ManageGames : System.Web.UI.Page
    {
        ManageGameSql GameSql = new ManageGameSql();
        DBDeveloper DevDBConn = new DBDeveloper();
        GamesIIS ServerContext = new GamesIIS();
        DBGame GameDb = new DBGame();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int DeveloperID = DevDBConn.GetDevID(Context.User.Identity.GetUserId());
                if (DeveloperID > -1)
                {
                    BindGameGridData(DeveloperID);
                }
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
                BindGameGridData(DeveloperID);
            }

            DeleteGameMessage.Visible = true;
        }

        private void BindGameGridData(int devID)
        {
            Dictionary<int, string> GameListByDev = GameSql.GetGameListByDeveloperID(devID);

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
                DeleteGameMessage.Text = "You have no games! Go to your main dashboard to upload a game!";
                DeleteGameMessage.ForeColor = System.Drawing.Color.Red;
                DeleteGameMessage.Visible = true;
            }
        }
    }
}