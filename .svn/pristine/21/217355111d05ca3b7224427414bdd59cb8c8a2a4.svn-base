using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ataw.Framework.Web;
using Ataw.RightCloud.Service;
using Ataw.RightCloud.Api;
using Ataw.Framework.Core;
using Ataw.RightCloud.Api.Data;

namespace Ataw.RightCloud.Web
{
    [RightFilter]
    public class UserDetailController : AtawBaseController
    {
        // GET: UserDetail
        public ActionResult Index()
        {
            return View();
        }
        public string getUserDetail(string fids)
        {
            UserDetailService userdetail = new UserDetailService();
            if (fids == null) fids = "";
            var data = userdetail.getUserDetail(fids.Split(','));
            return ReturnJson(data);
        }
        public string searchUserDetail(string userName, string trueName, string fNumber, string kind, string fControlUnitID, string pager)
        {
            pager = pager ?? "";
            var _pager = pager.SafeJsonObjectByWeb<Api.Pagination>();
            UserDetailService meun = new UserDetailService();
            var _js = meun.searchUserDetail(userName, trueName, fNumber, kind, fControlUnitID, _pager);
            return ReturnJson(_js);
        }
        public string delUserDetail(string fids)
        {
            UserDetailService userDetail = new UserDetailService();
            if (fids == null) fids = "";
            var data = userDetail.delUser(fids.Split(','));
            return ReturnJson(data);
        }
        public string boolExist(string userName, string userNum)
        {
            // var _users = users.SafeJsonObject<List<UserDetailData>>();
            UserDetailService user = new UserDetailService();
            var data = user.existUser(userName, userNum);
            return ReturnJson(data);
        }
        public string newUserDetail(string users)
        {
            var _users = users.SafeJsonObjectByWeb<List<UserDetailData>>();
            // var _users = users.SafeJsonObject<List<UserDetailData>>();
            UserDetailService user = new UserDetailService();
            var data = user.newUser(_users);
            return ReturnJson(data);
        }
        public string updateUseDetail(string users)
        {
            var _users = users.SafeJsonObjectByWeb<IEnumerable<UserDetailData>>();
            UserDetailService user = new UserDetailService();
            var data = user.updateUser(_users);
            return ReturnJson(data);
        }

        public string DropDownListItem()
        {
            UserDetailService user = new UserDetailService();
            var data = user.DropDownListItem();
            return ReturnJson(data);
        }
    }
}