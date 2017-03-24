using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ataw.Framework.Web;
using Ataw.Framework.Core;
using Ataw.RightCloud.Service;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.Core;

namespace Ataw.RightCloud.Web
{

    //[RightFilter]

    public class UserController : AtawBaseController
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public string getUser(string fids)
        {
            UserService user = new UserService();
            if (fids == null) fids = "";
            var data = user.getUser(fids.Split(','));
            return ReturnJson(data);
        }


        public string delUser(string fids)
        {
            UserService user = new UserService();
            if (fids == null) fids = "";
            var data = user.delUser(fids.Split(','));
            return ReturnJson(data);
        }

        public string updateuser(string users)
        {
            var _users = users.SafeJsonObject<List<UserData>>();
            UserService user = new UserService();
            var data = user.updateUser(_users);
            return ReturnJson(data);
        }


        public string RPassword(string fids)
        {
            UserService user = new UserService();
            if (fids == null) fids = "";
            var data = user.RPassword(fids.Split(','));
            return ReturnJson(data);
        }

        public string searchUserDetail(string fControlUnitID, string kind, string userName, string pager)
        {
            UserService user = new UserService();
            var _page = pager.SafeJsonObject<Api.Pagination>();
            var data = user.searchUserDetail(fControlUnitID, kind, userName, _page);
            return ReturnJson(data);

        }

        /// <summary>
        /// 检查是否在同一个组织下面
        /// </summary>
        /// <param name="fids"></param>
        /// <returns></returns>
        public string CheckUser(string fids)
        {
            UserService user = new UserService();
            var _fids = fids.SafeJsonObject<List<string>>();
            var data = user.CheckUser(fids);
            return ReturnJson(data);
        }


        public string AddUserRoleBA(string rolid, string fids)
        {
            UserService user = new UserService();
           // var _fids = fids.SafeJsonObject<List<string>>();
            var data = user.AddUserRoleBA(rolid, fids);
            return ReturnJson(data);
        }
        /// <summary>
        /// 分配角色额外权限
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetPermissionsList(string key)
        {
            UserService _userServer = new UserService();
            var data = _userServer.GetPermissionsList(key);
            return ReturnJson(data);
        }
        /// <summary>
        /// 分配数据权限
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetDataRightTree(string userID, string type)
        {
            UserService _userServer = new UserService();
            var data = _userServer.GetDataRightTree(userID, type);
            return ReturnJson(data);
        }
        public string UserDataRightsGrant(string fids, string userID, string type)
        {
            UserService _userServer = new UserService();
            var data = _userServer.UserDataRightsGrant(fids, userID, type);
            DataCache.DeleteCache(DataCache.GetCacheType.Ataw_RightsInfo_New);
            DataCache.DeleteCache(DataCache.GetCacheType.Ataw_RightsWithButtonInfo_New);
            return ReturnJson(data);
        }

        public string GetUserDataRights(string userID, string type)
        {
            UserService _userServer = new UserService();
            var data = _userServer.GetUserDataRights(userID, type);
            return ReturnJson(data);
        }
        public string SetUserScreenMode(string screenMode)
        {
            UserService _userServer = new UserService();
            var data = _userServer.SetUserScreenMode(screenMode);
            return ReturnJson(data);
        }
        public string GetUserScreenMode()
        {
            UserService _userServer = new UserService();
            var data = _userServer.GetUserScreenMode();
            return ReturnJson(data);
        }
        //public string newUser(string users)
        //{
        //    var _users = users.SafeJsonObjectByWeb<List<UserData>>(); ;
        //    UserService user = new UserService();
        //    var data = user.newUser(_users);
        //    return ReturnJson(data);
        //}


        public string GetUserRole(string userid)
        {
            UserService _userServer = new UserService();
            var data = _userServer.GetUserRole(userid);
            return ReturnJson(data);
        }
    }
}