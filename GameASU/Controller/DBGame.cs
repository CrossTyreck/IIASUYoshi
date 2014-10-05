using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using GameASU.Data;

namespace GameASU.Controller
{
    public class DBGame : DataContext
    {
        private Table<Game> GameTable;
        private Game game;

        public DBGame()
            : base(global::System.Configuration.ConfigurationManager.ConnectionStrings["GameASU"].ConnectionString)
        {
            this.Connection.Open();
            GameTable = this.Create().GetTable<Game>();
        }

        public DBGame Create()
        {
            return new DBGame();
        }

        public IQueryable<Game> SelectTableData()
        {
            IQueryable<Game> gamesQuery =
              from game in GameTable
              select game;

            return gamesQuery;
        }

        public bool InsertGame(string developerID, string gameName, int screenWidth, int screenHeight)
        {
            game = new Game(developerID, gameName, screenWidth, screenHeight);

            try
            {
                GameTable = this.GetTable<Game>();
                GameTable.InsertOnSubmit(game);

                return true;
            }
            catch { return false; }
        }

    }

}
