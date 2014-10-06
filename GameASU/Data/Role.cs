using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Web;

namespace GameASU.Data
{

    #region Class Role
    [Table(Name = "AspNetRoles")]
    public class Role
    {

        #region Variables

        [Column(IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, IsDbGenerated = true)]
        public string Id { get; set; }

        [Column()]
        public string Name { get; set; }

        #endregion

        #region Constructors

        public Role() { }

        public Role(string aspNetUserID)
        {
            Id = aspNetUserID;
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