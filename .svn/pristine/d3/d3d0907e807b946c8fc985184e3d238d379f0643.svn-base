using Ataw.Framework.Core;
using Ataw.Framework.Web;
using Ataw.RightCloud.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ataw.RightCloud.Data.Table;
using System.Text;

namespace Ataw.RightCloud.Web
{

    public class AuthController : AtawBaseController
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


        [RightFilter]
        public string getCodeFile(string path) {
            string _root = AtawAppContext.Current.BinPath;
            AtawDebug.Assert(!path.IsAkEmpty() && path[0] != '/' && path.IndexOf("..") < 0 ,"不可以访问其他目录",this);
           
                string _filePath = Path.Combine(_root, "../", path);
                string strs = FileUtil.ReadStringByFile(_filePath);
                 string[] sp = new string[] {Environment.NewLine};
                var list =  strs.Split(sp, StringSplitOptions.None);
                return ReturnJson(list);
        }

          [RightFilter]
        public ActionResult Home(string x,string h ,string t,string r,string f)
        {
            string _homePage = "HomeUrl".AppKv<string>("$FEED$");

            ViewBag.HomeUrl = _homePage;
            ViewBag.IsReactDebug = "IsReactDebug".AppKv<bool>(false) || !r.IsAkEmpty();

            ViewBag.IsPublish = false;
            if ("IsPublish".AppKv<bool>(false))
            {
                ViewBag.IsPublish = true;
            }
            else {
                if (!x.IsAkEmpty()) {
                    ViewBag.IsPublish = true;
                }
            }
            ViewBag.IsH = false;
            if ("IsH".AppKv<bool>(false))
            {
                ViewBag.IsH = true;
            }
            else
            {
                if (!h.IsAkEmpty())
                {
                    ViewBag.IsH = true;
                }
            }

            ViewBag.IsT = false;

            if ("IsT".AppKv<bool>(false))
            {
                ViewBag.IsT = true;
            }
            else
            {
                if (!t.IsAkEmpty())
                {
                    ViewBag.IsT = true;
                }
            }

            ViewBag.NickName = AtawAppContext.Current.NickName;
            if (f.IsAkEmpty())
            {
                return View();
            }
            else {
                return View("Front");
            }
        }


          public ActionResult Front(string x, string h, string t, string r, string f)
          {
              return this.Home(x,h,t,r,f);
          }

        // GET: Auth
        public ActionResult Index(string id)
        {
            //HttpBrowserCapabilities bc = new HttpBrowserCapabilities();
           var  bc =  Request.Browser;
           string _bowser = bc.Browser;
           int _version = bc.MajorVersion ;
           ViewBag.Bowser = _bowser;
           ViewBag.Version = _version;
           ViewBag.orgcode = id;
           if (_bowser == "IE")
           {
               if (_version <= 9)
               {
                   ViewBag.IsDown = true;
               }
           }
           else {
               ViewBag.IsDown = false;
           }


            return View("~\\Areas\\RightCloud\\Views\\Auth\\Index.cshtml");
        }

        public string logIn(string userName, string pass, string OrgCode)
        {
            UsersStateService stateService = new UsersStateService();
            AuthService service = new AuthService();
            var _res =   service.logIn(userName,pass,OrgCode);
            var _user = _res.Data;
           // CookieUtil.Add("cSystemName", HttpUtility.UrlEncode(strSystemName));
            CookieUtil.Add("FControlUnitID", _user.FControlUnitID);
            CookieUtil.Add("UserName", _user.LoginName);
            CookieUtil.Add("UserID", _user.FID);
           // CookieUtil.Add("UserType", modelUser.UserType);
            CookieUtil.Add("NickName", _user.NickName);
            CookieUtil.Add("FControlUnitName", HttpUtility.UrlEncode(_user.FControlUnitName));
            stateService.OnlineState(_user.FID);
            FormsAuthentication.SetAuthCookie(_user.FID, true);
            AtawAppContext.Current.PageFlyweight.PageItems["STATIC_LOGIN_USERID"] = _user.FID;

            return  ReturnJson(_res);
        }
          [RightFilter]
        public ActionResult logOut()
        {
            string _url = "/rightcloud/auth/index/{0}".AkFormat(AtawAppContext.Current.FControlUnitID);
            AuthService service = new AuthService();
            service.logOut();
            FormsAuthentication.SignOut();
            ClearCache(AtawAppContext.Current.UserId);            
            UsersStateService stateService = new UsersStateService();
            stateService.OutlineState(AtawAppContext.Current.UserId);
            return new RedirectResult(_url);
        }

        private void ClearCache(string userID)
        {
            if (userID != null)
            {
                HttpRuntime.Cache.Remove(userID + ".IList.Ataw_Menus_ButtonInfo"); //按钮  修改基础菜单、自定义菜单时更新
                HttpRuntime.Cache.Remove(userID + ".IList.Ataw_RightsInfo");//默认权限   修改角色授权用户授权时更新
                HttpRuntime.Cache.Remove(userID + ".IList.Ataw_RightsWithButtonInfo");//默认权限包括按钮    修改角色授权用户授权时更新
                DefaultAtawCache.Current.Delete(userID + ".AvatarPath");//用户头像  修改用户信息时更新
                HttpRuntime.Cache.Remove(userID + ".IList.Ataw_GruopInfo");//用户拥有的组织列表  修改组织，客商信息管理时更新
                HttpRuntime.Cache.Remove("Ataw_Menus_ButtonInfoList"); //所有按钮
                //删除新权限管理的缓存
                HttpRuntime.Cache.Remove(userID + ".IList.Ataw_Menus_ButtonInfo_New");
                HttpRuntime.Cache.Remove(userID + ".IList.Ataw_RightsInfo_New");
                HttpRuntime.Cache.Remove(userID + ".IList.Ataw_RightsWithButtonInfo_New");
                DefaultAtawCache.Current.Delete(userID + ".AvatarPath_New");
                HttpRuntime.Cache.Remove(userID + ".IList.Ataw_GroupInfo_New");


                HttpRuntime.Cache.Remove(userID + ".0.IList.Ataw_RightsInfo");
                HttpRuntime.Cache.Remove(userID + ".1.IList.Ataw_RightsInfo");
                HttpRuntime.Cache.Remove(userID + ".2.IList.Ataw_RightsInfo");
                HttpRuntime.Cache.Remove(userID + ".Ataw_UsersInfo"); //删除缓存用户
                HttpRuntime.Cache.Remove(userID + ".Ataw_UsersDetailInfo"); //删除缓存用户
                AtawAppContext.Current.AtawCache.Delete("MENU_" + userID);//删除当前用户菜单
            }
        }
        public ActionResult React(string id) {
            return PartialView("React");
        }
        public string changePassword(string oldPass = "",string newPass = "")
        {
            AuthService service = new AuthService();
            var res = service.changePassword(oldPass, newPass);
            return ReturnJson(res);
        }
    }
}