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
        public int Id { get; set; }

        [Column()]
        public int tblDeveloperID { get; set; }

        [Column()]
        public string GameName { get; set; }

        [Column()]
        public int ScreenWidth { get; set; }

        [Column()]
        public int ScreenHeight { get; set; }

        [Column()]
        public string GameNameOnServer { get; set; }

        #endregion

        #region Constructors
        public Game() { }

        public Game(int developerId, string gameName, int screenWidth, int screenHeight, string gameNameOnServer)
        {
            tblDeveloperID = developerId;
            GameName = gameName;
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
            GameNameOnServer = gameNameOnServer;
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