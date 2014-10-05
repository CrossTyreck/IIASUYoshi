using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using GameASU.Data;

namespace GameASU.Controller
{
    public class DBDeveloper : DataContext
    {

        private Table<Developer> DevTable { get { return this.GetTable<Developer>(); } }
        private Developer Dev;

        public DBDeveloper()
            : base(global::System.Configuration.ConfigurationManager.ConnectionStrings["GameASU"].ConnectionString)
        {
            this.Connection.Open();
        }

        public DBDeveloper Create()
        {
            return new DBDeveloper();
        }

        public IQueryable<Developer> SelectTableData()
        {
            IQueryable<Developer> devQuery =
              from dev in DevTable
              select dev;

            return devQuery;
        }

        public IQueryable<Developer> GetDevId(string aspNetUserId)
        {
            IQueryable<Developer> devQuery =
              from dev in DevTable
              where dev.AspNetUsersID == aspNetUserId
              select dev;

            return devQuery;
        }

        public bool InsertDeveloper(string aspNetUserID)
        {
            Dev = new Developer(aspNetUserID);

            try
            {
                DevTable.InsertOnSubmit(Dev);
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
