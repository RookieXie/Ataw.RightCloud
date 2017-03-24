
using Ataw.RightCloud.Api.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api
{
    public interface IRole
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="fids"></param>
        /// <returns></returns>
        ResponseData<IEnumerable<RoleData>> getRole(IEnumerable<string> fids);
        ResponseData<IEnumerable<RoleData>> getRoleDetail(IEnumerable<string> fids);
        ResponseData<PagerListData<RoleData>> searchRoleDetail(string RoleName,string RoleSign, string FControlUnitID, string kind, Pagination pager);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="fids"></param>
        /// <returns></returns>
        ResponseData<string> delRole(IEnumerable<string> fids);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="menus"></param>
        /// <returns></returns>
        ResponseData<string[]> newRole(IEnumerable<RoleData> roles);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="menus"></param>   
        /// <returns></returns>
        ResponseData<string[]> updateRole(IEnumerable<RoleData> roles);

        /// <summary>
        /// 分配权限
        /// </summary>
        /// <param name="rightIds">权限的ID</param>
        /// <param name="RoleId">角色id</param>
        /// <returns></returns>
        ResponseData RoleGrant(string rightIds, String roleId);

        /// <summary>
        /// 检查角色是否被使用
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        ResponseData CheckUserRole(String roleId);

        ResponseData<DataSet> InitRightsTree(string roleId);

        ResponseData<List<string>> GetRoleRightsList(string roleId);
       
    }
}
