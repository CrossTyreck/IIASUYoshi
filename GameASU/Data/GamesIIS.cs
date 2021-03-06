﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using GameASU.Data;
using System.IO;
using GameASU.Controller;
using GameASU.Model;

namespace GameASU.Data
{
    #region GamesSever
    /// <summary>
    /// Access information about games loaded on the IIS Server.
    /// </summary>
    public class GamesIIS
    {

        #region Variables

        protected GameServerPath GameServerPath = new GameServerPath();
        protected GameFileUpload GameUploader = new GameFileUpload();
        protected DBGame GameDBContext = new DBGame();

        protected string[] Games
        {
            get { return Directory.GetFiles(HttpContext.Current.Server.MapPath("~/Games/"), "*.unity3d", SearchOption.TopDirectoryOnly); }
        }

        #endregion

        #region Constructor

        public GamesIIS() { }

        #endregion

        #region Public Methods


        public bool UploadGameToServer(string fName, HttpPostedFile hpf)
        {
            //have verification in here if the file is already on the server
            return GameUploader.Upload(fName, hpf);
           
        }

        public bool UploadGameImageToServer(string fName, HttpPostedFile hpf)
        {
            //have verification in here if the file is already on the server
            return GameUploader.UploadImage(fName, hpf);

        }

        /// <summary>
        /// Verifies that the list of games in the database are also on the 
        /// server.
        /// </summary>
        /// <returns>True if games list is synced. False if not.</returns>
        public bool VerifyGameListIntegrity(out string error)
        {
            error = String.Empty;
            bool match = false;

            foreach (string gameFile in Games)
            {
                match = false;

                foreach (Game game in GameDBContext.SelectTableData())
                {
                    if (gameFile.ToLower().Contains(game.GameName.ToLower()))
                    {
                        match = true;
                        break;
                    }
                }

                if (!match) error += gameFile.Replace(GameServerPath.GamesFilePath, "||") + " ";
            }

            return (error.Equals(String.Empty)) ? true : false;
        }

        public bool RemoveObjectsFromServer(string gameName, string imageName)
        {
 
            File.Delete(GameServerPath.GetPath(GameServerPath.fileType.Game, gameName));
            File.Delete(GameServerPath.GetPath(GameServerPath.fileType.Image, imageName));
        
            if (!Games.Contains(gameName))
                return true;

            else return false;
        }
        #endregion

    }

    #endregion

}