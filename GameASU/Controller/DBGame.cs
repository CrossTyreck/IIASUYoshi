using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using GameASU.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data;
using System.Data.Linq.Mapping;
using System.Reflection;

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
        public Game GetGame(string gameName)
        {
            Game gamesQuery =
              (from game in GameTable
               where game.GameName.Equals(gameName)
               select game).Single();

            return gamesQuery;
        }

        public string GetGameNameByID(int ID)
        {
            Game gamesQuery =
              (from game in GameTable
               where game.Id.Equals(ID)
               select game).Single();

            return gamesQuery.GameNameOnServer;
        }

        public string GetImageNameByID(int ID)
        {
            Game gamesQuery =
              (from game in GameTable
               where game.Id.Equals(ID)
               select game).Single();

            return gamesQuery.TileImageLocation;
        }

        //Used for games and Developers.....What was I thinking?
        public override void SubmitChanges(ConflictMode failureMode)
        {
            base.SubmitChanges(failureMode);
        }

    }

}
