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

        [Column(IsPrimaryKey = true, AutoSync=AutoSync.OnInsert, IsDbGenerated = true)]
        public int Id{ get; set; }
       
        [Column()]
        public string AspNetUsersID{ get; set; }
      
        [Column()]
        public string DeveloperTag { get; set; }

        [Column()]
        public string Genre { get; set; }

        #endregion

        #region Constructors

        public Developer() { }

        public Developer(string aspNetUserID)
        {
            DeveloperTag = ""; //Code for this later to add "Entertainment" value
            Genre = ""; //Code for this later to let players see what genre developers are focused in
            AspNetUsersID = aspNetUserID;
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