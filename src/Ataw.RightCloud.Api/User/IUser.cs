
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.Api.Data.Org;
using Ataw.RightCloud.Api.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api
{
    public interface IUser
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="fids"></param>
        /// <returns></returns>
        ResponseData<IEnumerable<UserData>> getUser(IEnumerable<string> fids);

        ResponseData<PagerListData<UserData>> searchUserDetail(string fControlUnitID, string kind, string userName,Pagination pager);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="fids"></param>
        /// <returns></returns>
        ResponseData delUser(IEnumerable<string> fids);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="menus"></param>   
        /// <returns></returns>
        ResponseData<string[]> updateUser(IEnumerable<UserData> users);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="menus"></param>
        /// <returns></returns>
        //ResponseData<string[]> newUser(IEnumerable<UserData> roles);

        /// <summary>
        ///  重制密码
        /// </summary>
        /// <param name="fids">用户ID</param>
        /// <returns></returns>
        ResponseData RPassword(IEnumerable<String> fids);

        /// <summary>
        /// 批量添加角色
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="fids"></param>
        /// <returns></returns>
        ResponseData AddUserRoleBA(String roleid, string fids);
        /// <summary>
        /// 分配角色额外权限
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>

        ResponseData<IEnumerable<GroupButtonData>> GetPermissionsList(string key);
        /// <summary>
        /// 分配数据权限
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        ResponseData<IEnumerable<DataRightTree>> GetDataRightTree(string userID, string type);

        ResponseData<string> UserDataRightsGrant(string fids,string userID,string type);

        ResponseData<string> GetUserDataRights(string userID, string type);

        ResponseData<string> SetUserScreenMode(string screenMode);

        ResponseData<string> GetUserScreenMode();

    }
}
