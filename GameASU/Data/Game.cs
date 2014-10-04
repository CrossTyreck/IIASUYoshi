using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Web;
using GameASUContext = GameASU.Model.DBGame;

namespace GameASU.Data
{

    #region Class Game
    [Table(Name = "tblGames")]
    public class Game
    {

        #region Variables

        private int _id;
        private string _tblDeveloperID;
        private string _gameName;
        private int _screenWidth;
        private int _screenHeight;
        private GameASUContext dbGame;

        [Column(IsPrimaryKey = true)]
        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        [Column()]
        public string tblDeveloperID
        {
            get { return this._tblDeveloperID; }
            set { this._tblDeveloperID = value; }
        }

        [Column()]
        public string GameName
        {
            get { return this._gameName; }
            set { this._gameName = value; }
        }


        [Column()]
        public int ScreenWidth
        {
            get { return this._screenWidth; }
            set { this._screenWidth = value; }
        }

        [Column()]
        public int ScreenHeight
        {
            get { return this._screenHeight; }
            set { this._screenHeight = value; }
        }

        #endregion

        #region Constructors
        public Game() { }

        public Game(string developerId, string gameName, int screenWidth, int screenHeight)
        {
            tblDeveloperID = developerId;
            GameName = gameName;
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
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