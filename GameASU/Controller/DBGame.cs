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

        //Should pass the developer ID in here
        public Game GetGame(string gameName)
        {
            Game gamesQuery =
              (from game in GameTable
               where game.GameName.Equals(gameName)
               select game).Single();

            return gamesQuery;
        }

        //public bool InsertGame(int developerID, string gameName, int screenWidth, int screenHeight, string gameNameOnServer, string tileImageLocation)
        //{
        //    Game = new Game(developerID, System.Uri.EscapeDataString(gameName), screenWidth, screenHeight, System.Uri.EscapeDataString(gameName + gameNameOnServer), "Images/" + System.Uri.EscapeDataString(tileImageLocation));

        //    try
        //    {
        //        GameTable.InsertOnSubmit(Game);
        //        SubmitChanges(ConflictMode.FailOnFirstConflict);

        //        return true;
        //    }
        //    catch { return false; }
        //}

        public override void SubmitChanges(ConflictMode failureMode)
        {
            base.SubmitChanges(failureMode);
        }

        [Function(Name = "[dbo].[spi_tblGames]")]
        public int InsertGame(Int32 developerID, String gameName, Int32 screenWidth, Int32 screenHeight, String gameNameOnServer, String tileImageLocation)
        {
            Game Game = new Game(developerID, gameName, screenWidth, screenHeight, gameNameOnServer, tileImageLocation);
            
            try
            {
                ObjectParameter ID = new ObjectParameter("ID", DbType.Int32);
               // ID.ParameterType;

                ObjectParameter Ret_Code = new ObjectParameter("Ret_Code", DbType.Int32);
               // Ret_Code.Direction = ParameterDirection.Output;

                ObjectParameter Ret_Message = new ObjectParameter("Ret_Message", DbType.String);
                //Ret_Message.Direction = ParameterDirection.Output;

                object[] Parameters = {
                    new ObjectParameter("tblDeveloperID", Game.tblDeveloperID),
                    new ObjectParameter("GameName", Game.GameName),
                    new ObjectParameter("ScreenWidth", Game.ScreenWidth),
                    new ObjectParameter("ScreenHeight",Game.ScreenHeight),
                    new ObjectParameter("GameNameOnServer", Game.GameNameOnServer),
                    new ObjectParameter("TileImageLocation", Game.TileImageLocation),
                };

                MetaTable GameMeta = this.Mapping.GetTable(typeof(Game));

                MethodInfo MethodInfo = (MethodInfo)MethodInfo.GetCurrentMethod();
                IExecuteResult result = this.ExecuteMethodCall(this, MethodInfo, Parameters);

                return (int)result.ReturnValue;
            }
            catch (Exception e)
            {

            }

            return 0;
          

        }
    }

}
