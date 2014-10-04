using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Web;

namespace GameASU.Data
{

    #region Class Developer
    [Table(Name = "tblDeveloper")]
    public class Developer
    {

        #region Variables

        private string _Id;
        private string _AspNetUsersID;
        private string _developerTag;
        private string _genre;

        [Column(IsPrimaryKey = true)]
        public string DeveloperID
        {
            get { return this._Id; }
            set { this._Id = value; }
        }

        [Column()]
        public string AspNetUsersID
        {
            get { return this._AspNetUsersID; }
            set { this._AspNetUsersID = value; }
        }

        [Column()]
        public string DeveloperTag
        {
            get { return this._developerTag; }
            set { this._developerTag = value; }
        }


        [Column()]
        public string Genre
        {
            get { return this._genre; }
            set { this._genre = value; }
        }

        #endregion

        #region Constructors
        public Developer() { }

        public Developer(string aspNetUserID, string developerID)
        {
            DeveloperID = developerID;
            DeveloperTag = ""; //Code for this later to add "Entertainment" value
            Genre = ""; //Code for this later to let players see what genre developers are focused in
            AspNetUsersID = aspNetUserID;
        }

        #endregion
    }

    #endregion
}