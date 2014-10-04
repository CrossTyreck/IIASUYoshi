using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameASU.Model
{
    public class UploadGame
    {
        private string _filePath;

        public string FilePath
        {
            get { return this._filePath; }
            set { this._filePath = value; }
        }

        public UploadGame() { }

        public UploadGame(string filePath)
        {


        }
    }
}