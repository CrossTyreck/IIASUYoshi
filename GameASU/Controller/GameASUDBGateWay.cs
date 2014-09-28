using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;

namespace GameASU.Controller
{
    public class GameASUDBGateWay : DataContext
    {
            public GameASUDBGateWay()
                : base("GameASU")
            {
            }

            public static GameASUDBGateWay Create()
            {
                return new GameASUDBGateWay();
            }
        }

    }
}