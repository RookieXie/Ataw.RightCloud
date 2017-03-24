
using Ataw.RightCloud.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api
{
    public interface IMenuButton
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="fids"></param>
        /// <returns></returns>
        ResponseData<IEnumerable<MenuButtonData>> getMenu(IEnumerable<string> fids);
        ResponseData<IEnumerable<MenuButtonData>> getMenuDetail(IEnumerable<string> fids);
        ResponseData<PagerListData<MenuButtonData>> searchMenuDetail(string text, string kind,Pagination pager);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="fids"></param>
        /// <returns></returns>
        ResponseData delMenubutton(IEnumerable<string> fids);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="menus"></param>
        /// <returns></returns>
        ResponseData<string[]> newMenubutton(IEnumerable<MenuData> menubuttons);

    }
}
