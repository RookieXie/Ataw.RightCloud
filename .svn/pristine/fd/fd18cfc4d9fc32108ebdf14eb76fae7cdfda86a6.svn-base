using Ataw.Framework.Web;
using Ataw.RightCloud.Api.Data.RightConfig;
using Ataw.RightCloud.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ataw.Framework.Core;
using Ataw.RightCloud.Api.Data;
namespace Ataw.RightCloud.Web
{
    public class RightConfigController : AtawBaseController
    {
        // GET: RightConfig
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 得到树形所需数据
        /// </summary>
        /// <returns></returns>
        public string GetDataList(string fids)
        {
            RightConfigService rightconfig = new RightConfigService();
            var data = rightconfig.initGroupMenuData();
            return ReturnJson(data);
        }
        public string initGroupMenuData()
        {
            RightConfigService rightconfig = new RightConfigService();
            var data = rightconfig.initGroupMenuData();
            return ReturnJson(data);
        }
        public string GetMenuData(string FControlUnitID)
        {
            RightConfigService rightconfig = new RightConfigService();
            var data = rightconfig.GetMenuData(FControlUnitID);
            return ReturnJson(data);
        }
        public string SaveMenuData(string dataList)
        {
            var _data = dataList.SafeJsonObject<List<InitMenuData>>();
            RightConfigService rightconfig = new RightConfigService();
            var data = rightconfig.SaveMenuData(_data);
            return ReturnJson(data);
        }

        public string sqtest()
        {
            RightMenuGroup data = new RightMenuGroup();
            //data.OrgData = new RightGroup();
            //data.OrgData.FID = "ss";
            var dd = new { MenuOrgTable = data };
            return ReturnJson(dd);
        }

        // -----------------------------------------------------------------------------
        
        #region 初始化
        /// <summary>
        /// 提供 树形和 组织和菜单的数据  会发送一个组织的Id过来
        /// </summary>
        /// <returns></returns>
        public string fristinit(string Groups, string codes)
        {
            RightConfigService rightserver = new RightConfigService();
            GroupMenuService menuservice = new GroupMenuService();
            GroupTreeService groupservice = new GroupTreeService();
            var menudata = menuservice.init(Groups);
            var right = rightserver.initGroupMenuData();
            var _code = groupservice.getOrgCode(Groups);
            var dd = new
            {
                MenuOrgTable = menudata,
                GroupTree = right,
                Group = _code
            };
            return ReturnJson(dd);
        }
        /// <summary>
        /// 编码机构
        /// </summary>
        /// <param name="Group"></param>
        /// <returns></returns>
        public string initgroup(string Group)
        {
            RightConfigService rightserver = new RightConfigService();
            GroupTreeService groupservice = new GroupTreeService();
            var data = rightserver.initGroupidCode(Group);
            var right = rightserver.initGroupMenuData();
            var _code = groupservice.getOrgCode(Group);
            var dd = new { Group = _code, GroupTree = right };
            return ReturnJson(dd);
        }

        /// <summary>
        /// 初始化话角色，菜单，用户信息
        /// </summary>
        /// <returns></returns>
        public string secodeinit(string Groups, string pager)
        {
            RoleMenuUserService menuservice = new RoleMenuUserService();
            GroupTreeService groupservice = new GroupTreeService();
            var _pager = pager.SafeJsonObject<Api.Pagination>();
            var data = menuservice.init(Groups, _pager);
            var _code = groupservice.getOrgCode(Groups);
            var dd = new { MenuUserTable = data, Group = _code };
            return ReturnJson(dd);
        }


        /// <summary>
        /// 角色表格中菜单展开事件
        /// </summary>
        /// <param name="Menu"></param>
        /// <returns></returns>
        public string RoleexportMenu(string Menu, string Group)
        {
            RoleMenuUserService menuservice = new RoleMenuUserService();
            var data = menuservice.RoleexportMenu(Menu, Group);
            var dd = new { MenuUserTable = data };
            return ReturnJson(dd);
        }


        /// <summary>
        /// 组织表格中菜单的展开事件
        /// </summary>
        /// <param name="Menu"></param>
        /// <param name="Group"></param>
        /// <returns></returns>
        public string GroupexportMenu(string Menu, string Group)
        {
            GroupMenuService menuservice = new GroupMenuService();
            var data = menuservice.GroupexportMenu(Menu, Group);
            var dd = new { MenuUserTable = data };
            return ReturnJson(dd);
        }



        public string RolePageing(string Group, string pager)
        {
            RoleMenuUserService menuservice = new RoleMenuUserService();
            var _pager = pager.SafeJsonObject<Api.Pagination>();
            var data = menuservice.Rolepaging(Group, _pager);
            var dd = new { MenuUserTable = data };
            return ReturnJson(dd);
        }

        #endregion

        //三部分的submit事件---------------------------------------------------------------------


        #region 提交方法
        /// <summary>
        /// 菜单组织部分提交方法
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string MenuOrgSubmit(string data)
        {
            //要将实体转化成什么呢？
            var _data = data.SafeJsonObject<GroupRightSubmitData>();
            GroupMenuService service = new GroupMenuService();
            var responsedata=service.modify(_data);
            return ReturnJson(responsedata);
        }


        

        /// <summary>
        /// 角色 菜单 人员提交方法
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string RoleMenuUserSubmit(string data)
        {
            var _data = data.SafeJsonObject<MenuUserRoleSubmitData>();
            RoleMenuUserService service = new RoleMenuUserService();
            var responseData = service.modify(_data);
            return ReturnJson(responseData);
        }


        /// <summary>
        /// 组织修改提交方法
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GroupSubmit(string GroupName,string GroupKey)
        {
            GroupService groupService = new GroupService();
            var res = false;
            res=groupService.GroupUpdate(GroupName,GroupKey);
            return ReturnJson(res);
        }


        /// <summary>
        /// 树形组织添加删除
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GroupTreeSubmit(string data)
        {
            return "";
        }


        public string getFid()
        {
            MenuService service = new MenuService();
            return service.getFid();
        }

        /// <summary>
        /// 节点下是否有子节点
        /// </summary>
        /// <param name="MenuID"></param>
        /// <returns></returns>
        public string CheckHasChild(string menuID)
        {
            GroupMenuService service = new GroupMenuService();
            var res = service.CheckHasChild(menuID);
            return ReturnJson(res);
        }
        #endregion
    }
}