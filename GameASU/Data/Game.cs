using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Web;
using GameASUContext = GameASU.Controller.DBGame;

namespace GameASU.Data
{

    #region Class Game
    [Table(Name = "tblGames")]
    public class Game
    {
        #region Variables

        [Column(IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, IsDbGenerated = true)]
        public Int32 Id { get; set; }

        [Column(DbType = "INT NOT NULL")]
        public Int32 tblDeveloperID { get; set; }

        [Column(DbType = "VARCHAR(200) NOT NULL")]
        public String GameName { get; set; }

        [Column(DbType = "INT NOT NULL")]
        public Int32 ScreenWidth { get; set; }

        [Column(DbType = "INT NOT NULL")]
        public Int32 ScreenHeight { get; set; }

        [Column(DbType = "VARCHAR(200) NOT NULL")]
        public String GameNameOnServer { get; set; }

        [Column(DbType = "VARCHAR(200) NOT NULL")]
        public String TileImageLocation { get; set; }

        #endregion

        #region Constructors
        public Game() { }

        public Game(Int32 developerId, String gameName, Int32 screenWidth, Int32 screenHeight, String gameNameOnServer, String tileImageLocation)
        {
            tblDeveloperID = developerId;
            GameName = gameName;
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
            GameNameOnServer = gameNameOnServer;
            TileImageLocation = tileImageLocation;
        }

        #endregion

        #region Private Methods
        public void InsertRecord()
        {

        }

        #endregion
    }

    #endregion
}