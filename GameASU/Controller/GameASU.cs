using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;

namespace GameASU.Controller
{
    public class GameASU : DataContext
    {
        public GameASU()
            : base(global::System.Configuration.ConfigurationManager.ConnectionStrings["GameASU"].ConnectionString)
        {
            this.Connection.Open();
        }

        public static GameASU Create()
        {
            return new GameASU();
        }
    }

}
