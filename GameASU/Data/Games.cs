using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Web;

namespace GameASU.Data
{
    
    [Table(Name = "tblGames")]
    public class Games
    {

#region Variables

        private int _id;
        private int _tblDeveloperID;
        private string _gameName;
        private int _screenWidth;
        private int _screenHeight;

        [Column(IsPrimaryKey = true, Storage = "Id")]
        public int Id
        {
            get{return this._id;}
            set { }
        }

        [Column(Storage = "tblDeveloperID")]
        public int tblDeveloperID
        {
            get { return this._tblDeveloperID; }
            set { this._tblDeveloperID = value; }
        }

        [Column(Storage = "GameName")]
        public string GameName
        {
            get { return this._gameName; }
            set { this._gameName = value; }
        }


        [Column(Storage = "ScreenWidth")]
        public int ScreenWidth
        {
            get { return this._screenWidth; }
            set { this._screenWidth = value; }
        }

        [Column(Storage = "ScreenHeight")]
        public int ScreenHeight
        {
            get { return this._screenHeight; }
            set { this._screenHeight = value; }
        }

#endregion

    }
}