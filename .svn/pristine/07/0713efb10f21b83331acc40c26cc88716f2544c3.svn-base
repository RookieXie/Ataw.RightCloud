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
    //[RightFilter]
    public class RoleController : AtawBaseController
    {
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 返回一个简单的role对象
        /// </summary>
        /// <param name="fids">fid逗号相连的字符串</param>
        /// <returns></returns>
        public string getRole(string fids)
        {
            RoleService role = new RoleService();
            if (fids == null) fids = "";
            var data = role.getRole(fids.Split(','));
            return ReturnJson(data);
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="RoleName">角色名字</param>
        /// <param name="FControlUnitID"></param>
        /// <param name="kind"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public string searchRoleDetail(string roleName,string roleSign, string fControlUnitID, string kind, string pager)
        {
            var _pager = pager.SafeJsonObject<Api.Pagination>();
            RoleService meun = new RoleService();
            var _js = meun.searchRoleDetail(roleName,roleSign, fControlUnitID, kind, _pager);
            return ReturnJson(_js);
        }


        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="fids"></param>
        /// <returns></returns>
        public string delRole(string fids)
        {
            RoleService role = new RoleService();
            if (fids == null) fids = "";
            var data = role.delRole(fids.Split(','));
            return ReturnJson(data);
        }


        public string newRole(string roles)
        {
            var _roles = roles.SafeJsonObjectByWeb<List<RoleData>>(); ;
            RoleService role = new RoleService();
            var data = role.newRole(_roles);
            return ReturnJson(data);
        }

        public string update(string roles)
        {
            var _roles = roles.SafeJsonObject<List<RoleData>>();
            RoleService role = new RoleService();
            var data = role.updateRole(_roles);
            return ReturnJson(data);
        }


        public string RoleGrant(string rightids, string roleid)
        {
            RoleService role = new RoleService();
            var data = role.RoleGrant(rightids, roleid);
            return ReturnJson(data);
        }

        public string CheckUserRole(string rolid)
        {
            RoleService role = new RoleService();
            var data = role.CheckUserRole(rolid);
            return ReturnJson(data);
        }


        public string InitRightsTree(string roleid)
        {
            RoleService role = new RoleService();
            var data = role.InitRightsTree(roleid);
            return ReturnJson(data);
        }

        public string GetRoleRightsList(string roleid)
        {
            RoleService role = new RoleService();
            var data = role.GetRoleRightsList(roleid);
            return ReturnJson(data);
        }


    }
}