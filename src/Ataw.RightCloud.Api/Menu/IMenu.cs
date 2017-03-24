
using Ataw.RightCloud.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api
{
    public interface IMenu
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="fids"></param>
        /// <returns></returns>
        ResponseData<IEnumerable<MenuData>> getMenu(IEnumerable<string> fids);
        ResponseData<IEnumerable<MenuDetailData>> getMenuDetail(IEnumerable<string> fids);
        ResponseData<PagerListData<MenuData>> searchMenuDetail(string parentid, string text, string kind, Pagination pager);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="fids"></param>
        /// <returns></returns>
        ResponseData<string> delMenu(IEnumerable<string> fids);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="menus"></param>
        /// <returns></returns>
        ResponseData<string[]> newMenu(IEnumerable<MenuDetailData> menus);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="menus"></param>   
        /// <returns></returns>
        ResponseData<string[]> updateMenu(IEnumerable<MenuDetailData> menus);

        ResponseData<ParentsMenuData> getParentMenuDetail(string fid);

    }
}
