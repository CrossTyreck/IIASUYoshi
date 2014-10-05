using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GameASU.Controller
{
    interface IServerFileUpload
    {
        bool Upload(string fileName, HttpPostedFile obj);
    }
}
