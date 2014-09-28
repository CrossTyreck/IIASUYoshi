using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using GameASU.Data;
using System.IO;
using GameASU.Controller;
using GameASUContext = GameASU.Controller.GameASU;

namespace GameASU.Data
{
    /// <summary>
    /// Access information about games loaded on the server.
    /// </summary>
    public class GamesServer
    {
       

        /// <summary>
        /// Verifies that the list of games in the database are also on the 
        /// server.
        /// </summary>
        /// <returns>True if games list is synced. False if not.</returns>
        public bool VerifyGameListIntegrity(out string error)
        {
            GameASUContext dbGameASU = GameASUContext.Create();

            Table<Game> Games = dbGameASU.GetTable<Game>();
            string[] files = Directory.GetFiles(HttpContext.Current.Server.MapPath("~/Games/"), "*.unity3d", SearchOption.TopDirectoryOnly);
            error = String.Empty;
            bool match = false;

            IQueryable<Game> gamesQuery =
                from game in Games
                select game;

            foreach (string file in files)
            {
                match = false;

                foreach (Game game in gamesQuery)
                {
                    if (file.ToLower().Contains(game.GameName.ToLower()))
                    {
                        match = true;
                        break;
                    }
                }

                if(!match) error += file.Replace(HttpContext.Current.Server.MapPath("~/Games/"), "||") + " ";
            }

            return (error.Equals(String.Empty)) ? true : false;
        }

    }


}