using Ataw.Framework.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ataw.Framework.Core;
using Ataw.RightCloud.Service;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.Core;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data.Org;

namespace Ataw.RightCloud.Web
{
    [RightFilter]
    public class GroupController : AtawBaseController
    {
        // GET: Group
        public ActionResult Index()
        {
            return View();
        }
        #region 查询数据 searchGroupDetail
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="orgName"></param>
        /// <param name="orgCode"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public string searchGroupDetail(string parentID, string orgName, string orgCode, string pager)
        {
            var _pager = pager.SafeJsonObject<Api.Pagination>();
            GroupService _groupService = new GroupService();
            var _jsonData = _groupService.searchGroupDetail(parentID, orgName, orgCode, _pager);
            return ReturnJson(_jsonData);
        }
        #endregion

        #region 加载信息 getGroup
        /// <summary>
        /// 加载信息
        /// </summary>
        /// <param name="fids"></param>
        /// <returns></returns>
        public  string getGroup(string fids)
        {
            GroupService _groupService = new GroupService();
            string[] fidList = fids.Split(',');
            var _jsonData = _groupService.getGroup(fidList);
            return ReturnJson(_jsonData);
        }
        #endregion

        #region  详情信息  getGroupDetail
        public string getGroupDetail(string fids)
        {
            GroupService _groupService = new GroupService();
            string[] fidList = fids.Split(',');
            var _jsonData = _groupService.getGroupDetail(fidList);
            return ReturnJson(_jsonData);
        }
        #endregion

        #region   删除  delGroup
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strfid"></param>
        /// <returns></returns>
        public string delGroup(string fids)
        {
            GroupService _groupService = new GroupService();
            string[] fidList = fids.Split(',');
            var _jsonData = _groupService.delGroup(fidList);
            return ReturnJson(_jsonData);
        }
        #endregion

        #region  新增  newGroup
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="group">对象信息</param>
        /// <returns></returns>
        public string newGroup(string group)
        {
            var _groups = group.SafeJsonObject<List<GroupDetailData>>();
            GroupService _groupService = new GroupService();
            var _jsonData=_groupService.newGroup(_groups);
            return ReturnJson(_jsonData);
        }
        #endregion

        #region  编辑  Updata
        /// <summary>
        /// 编辑 
        /// </summary>
        /// <param name="group">对象信息</param>
        /// <returns></returns>
        public string Updata(string group)
        {
            var _groups = group.SafeJsonObject<List<GroupDetailData>>();
            GroupService _groupService = new GroupService();
            var _jsonData = _groupService.updateGroup(_groups);
            return ReturnJson(_jsonData);
        }
        #endregion

        #region  分配权限  GroupGrant
        /// <summary>
        /// 分配权限
        /// </summary>
        /// <param name="rightIds"></param>
        /// <param name="groupIds"></param>
        /// <returns></returns>
        public string GroupGrant(string rightIds, string groupIds)
        {
            GroupService _groupService = new GroupService();
            var _jsonData = _groupService.GroupGrant(rightIds,groupIds);
            DataCache.DeleteCache(DataCache.GetCacheType.Ataw_Menus_ButtonInfo_New);
            DataCache.DeleteCache(DataCache.GetCacheType.Ataw_RightsInfo_New);
            DataCache.DeleteCache(DataCache.GetCacheType.Ataw_RightsWithButtonInfo_New);
            return ReturnJson(_jsonData);
        }
        #endregion

        #region  权限树 InitRightsTree
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string InitRightsTree()
        {
            GroupService _groupService = new GroupService();
            var _jsonData = _groupService.RESERT_InitRightsTree();
            return ReturnJson(_jsonData);
        }

        #endregion

        public string GetGroupRightTree(string fControlUnitID, bool onlyId)
        {
            GroupService _groupService = new GroupService();
            var _jsonData = _groupService.GetGroupRightTree(fControlUnitID, onlyId);
            return ReturnJson(_jsonData);
        }
    }
}