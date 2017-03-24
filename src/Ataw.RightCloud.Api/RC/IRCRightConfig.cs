using Ataw.RightCloud.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api
{
   public interface IRCRightConfig
    {
        /// 页面第一次初始化返回树形组织和菜单数据
        /// sq
        /// </summary>
        /// <returns></returns>
        //GroupMenuData initGroupMenuData();

        ResponseData<RCGroupMenuData> initRCGroupMenuData();
    }
}
