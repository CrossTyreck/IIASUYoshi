using GameASU.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GameASU.Model
{
    public class GameUploader : IServerFileUpload
    {
        private GameServerPath gameServerPath = new GameServerPath();
        public bool Upload(string fileName, HttpPostedFile obj)
        {
            try
            {
                obj.SaveAs(gameServerPath.GetPath(GameServerPath.fileType.Game, fileName));
                return true;
            }
            catch { return false; }
        }
    }
}