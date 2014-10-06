using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using GameASU.Data;

namespace GameASU.Controller
{
    public class DBRole : DataContext
    {
        private Table<Role> RoleTable { get { return this.GetTable<Role>(); } }

        public DBRole()
            : base(global::System.Configuration.ConfigurationManager.ConnectionStrings["GameASU"].ConnectionString)
        {
            this.Connection.Open();
        }

        public DBRole Create()
        {
            return new DBRole();
        }

        public IQueryable<Role> SelectTableData()
        {
            IQueryable<Role> roleQuery =
              from role in RoleTable
              select role;

            return roleQuery;
        }

    }

}
