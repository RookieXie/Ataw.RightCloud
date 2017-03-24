using Ataw.Framework.Web;
using Ataw.RightCloud.Service.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ataw.RightCloud.Web
{
    public class AppController : AtawBaseController
    {
        // GET: App
        public ActionResult getMenu()
        {
            AppService app = new AppService();
           var _res =  app.getAllAppMenu();

           return new ContentResult() { 
               Content = ReturnJson(_res)
           };
        }
    }
}