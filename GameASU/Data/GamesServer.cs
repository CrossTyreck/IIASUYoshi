using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using GameASU.Data;
using System.IO;
using GameASU.Controller;

namespace GameASU.Data
{
    /// <summary>
    /// Access information about games loaded on the server.
    /// </summary>
    public class GamesServer
    {
        GameASUDBGateWay dbGameASU = new GameASUDBGateWay();

    /// <summary>
    /// Verifies that the list of games in the database are also on the 
    /// server.
    /// </summary>
    /// <returns>True if games list is synced. False if not.</returns>
    public bool VerifyGameListIntegrity(out string error)
    {
        Table<Games> Games = dbGameASU.GetTable<Games>();
        string[] files = Directory.GetFiles("~\\Games\\", "*.unity3d", SearchOption.TopDirectoryOnly);
        error = String.Empty;

        IQueryable<Games> gamesQuery =
            from game in Games
            select game;

        foreach(Games game in gamesQuery)
        {
            foreach (string file in files)
            {
                if (!file.ToLower().Contains(game.GameName.ToLower()))
                {
                    error += file + " ";
                }
                
            }
        }

        return (error.Equals(String.Empty)) ? true : false;
    }

    }

    
}