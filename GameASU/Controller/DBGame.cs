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
        }

        public static DBGame Create()
        {
            return new DBGame();
        }

        public static IQueryable<Game> SelectTableData()
        {
            Table<Game> tblGames = DBGame.Create().GetTable();

            IQueryable<Game> gamesQuery =
              from game in tblGames
              select game;

            return gamesQuery;
        }

        private Table<Game> GetTable()
        {
            return GetTable<Game>();
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
