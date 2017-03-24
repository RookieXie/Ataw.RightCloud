using Ataw.RightCloud.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api.User
{
    public interface IUserDetail
    {
        ResponseData<IEnumerable<UserDetailData>> getUserDetail(IEnumerable<string> fids);
        ResponseData<PagerListData<UserDetailData>> searchUserDetail(string trueName, string kind, string userName, string fNumber, string fControlUnitID, Pagination pager);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="fids"></param>
        /// <returns></returns>
        ResponseData delUser(IEnumerable<string> fids);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="menus"></param>
        /// <returns></returns>
        ResponseData<string[]> newUser(IEnumerable<UserDetailData> users);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="menus"></param>   
        /// <returns></returns>
        ResponseData<string[]> updateUser(IEnumerable<UserDetailData> users);



    }
}
