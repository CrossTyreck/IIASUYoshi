﻿using GameASU.Controller;
using GameASU.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameASU
{
    public partial class PlayerDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel RowContainer = new Panel();
            Panel Column;
            ImageButton gameImage;
            Label gameName;

            DBGame DBGameContext = new DBGame();

            List<Game> Games = DBGameContext.SelectTableData().ToList<Game>();


            foreach (Game game in Games)
            {
                for (int row = Games.IndexOf(game); row % 4 == 0; row++)
                {
                    RowContainer = new Panel();
                    RowContainer.CssClass = "row top5";

                }
                    Column = new Panel();
                    gameImage = new ImageButton();
                    gameName = new Label();

                    Column.CssClass = "col-sm-3";
                    gameImage.CssClass = "img-responsive";

                    gameImage.ImageUrl = game.TileImageLocation;
                    gameImage.Click += new ImageClickEventHandler(gameClick);
                    gameImage.AlternateText = game.GameName;

                    gameName.Text = gameImage.AlternateText;
                    
                    Column.Controls.Add(gameImage);
                    Column.Controls.Add(gameName);

                    RowContainer.Controls.Add(Column);

                    for (int row = Games.IndexOf(game); row % 4 == 0; row++)
                    {
                        GameList.Controls.Add(RowContainer);
                    }
            }
        }

        protected void gameClick(object sender, EventArgs e)
        {
            ImageButton gameClicked = sender as ImageButton;
            Response.Redirect("GameHost.aspx?g=" + gameClicked.AlternateText);
        }
    }
}