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
        private Table<Game> GameTable { get { return this.GetTable<Game>(); } }
        private Game Game;

        public DBGame()
            : base(global::System.Configuration.ConfigurationManager.ConnectionStrings["GameASU"].ConnectionString)
        {
            this.Connection.Open();
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

        public bool InsertGame(int developerID, string gameName, int screenWidth, int screenHeight)
        {
            Game = new Game(developerID, gameName, screenWidth, screenHeight);

            try
            {
                GameTable.InsertOnSubmit(Game);
                SubmitChanges(ConflictMode.FailOnFirstConflict);

                return true;
            }
            catch { return false; }
        }

        public override void SubmitChanges(ConflictMode failureMode)
        {
            base.SubmitChanges(failureMode);
        }
    }

}
