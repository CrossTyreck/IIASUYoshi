﻿using System;
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
        private Developer Dev = new Developer();

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

        public bool InsertDeveloper(string aspNetUserID, string developerID)
        {
            Dev = new Developer(aspNetUserID, developerID);

            try
            {
                DevTable.InsertOnSubmit(Dev);

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
