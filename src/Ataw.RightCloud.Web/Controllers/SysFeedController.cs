using Ataw.Framework.Web;
using Ataw.RightCloud.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ataw.Framework.Core;
using System.Threading;
using System.Text;

namespace Ataw.RightCloud.Web
{
    [RightFilter]
    public class SysFeedController : AtawBaseController
    {

        protected override string ReturnJson<T>(T res)
        {



            JsResponseResult<T> ree = new JsResponseResult<T>()
            {
                ActionType = JsActionType.Object,
                Obj = res
            };


            //if (!new AppLock().IsSuccess())
            //{
            //    ree.ActionType = JsActionType.Lock;
            //    ree.Obj = default(T);
            //}
            ree.EndTimer = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ffff");
            ree.BeginTime = AtawAppContext.Current.GetItem("__beginTime").Value<DateTime>().ToString("yyyy/MM/dd HH:mm:ss.ffff");
            //  ree.SaveString(System.Xml.Formatting.Indented);
            // string str = JsonConvert.SerializeObject(ree);
            string str = FastJson(ree);
            AtawTrace.WriteFile(LogType.JsonData, str);
            HttpContext.Response.HeaderEncoding = Encoding.UTF8;
            //HttpContext.Response.

            return str;
        }

        // GET: SysFeed
        public ActionResult Index()
        {
            return View();
        }

        public string getFirstFeed()
        {
            TestFeed testFeed = new TestFeed();
             var _js =   testFeed.getFirstFeed();
             return ReturnJson(_js);
        }

        public string getFeed(string time)
        {
            if (time.IsAkEmpty()) time = DateTime.Now.ToString();
            TestFeed testFeed = new TestFeed();
            var _js = testFeed.getFeed(time.Value<DateTime>());
            Thread.Sleep(500);
            return ReturnJson(_js);
        }


    }
}