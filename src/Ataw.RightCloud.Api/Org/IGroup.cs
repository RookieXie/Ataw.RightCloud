
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.Api.Data.Org;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api
{
    public interface IGroup
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="fids"></param>
        /// <returns></returns>
        ResponseData<IEnumerable<GroupData>> getGroup(IEnumerable<string> fids);
        ResponseData<IEnumerable<GroupDetailData>> getGroupDetail(IEnumerable<string> fids);
        ResponseData<PagerListData<GroupData>> searchGroupDetail(string orgFid,string orgName, string orgCode, Pagination pager);

        /// <summary>
        /// 根据机构名称查询
        /// </summary>
        /// <param name="MenuName">机构名</param>
        /// <returns></returns>
        ResponseData<IEnumerable<GroupData>> searchGroupbyName(string GroupName);

        /// <summary>
        /// 根据机构标示查询
        /// </summary>
        /// <param name="MenuName">机构编码</param>
        /// <returns></returns>
        ResponseData<IEnumerable<GroupData>> searchGroupbyFControlUnitID(string FControlUnitID);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="fids"></param>
        /// <returns></returns>
        ResponseData<string> delGroup(IEnumerable<string> fids);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="menus"></param>
        /// <returns></returns>
        ResponseData<List<string>> newGroup(IEnumerable<GroupDetailData> groups);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="menus"></param>   
        /// <returns></returns>
        ResponseData<string[]> updateGroup(IEnumerable<GroupDetailData> groups);

        /// <summary>
        /// 分配权限
        /// </summary>
        /// <param name="rightIds">权限的ID</param>
        /// <param name="groupIds">组织标示</param>
        /// <returns></returns>
        ResponseData<string> GroupGrant(String rightIds, String groupId);

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="fControlUnitID"></param>
        /// <param name="onlyId"></param>
        /// <returns></returns>
        ResponseData<PagerListData<GroupButtonData>> GetGroupRightTree(string fControlUnitID, bool onlyId);
        /// <summary>
        /// 获取权限树
        /// </summary>
        /// <returns></returns>
        ResponseData<IEnumerable<GroupButtonData>> InitRightsTree();

        ResponseData<string> RESERT_InitRightsTree();
    }
}
