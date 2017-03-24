using Ataw.RightCloud.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api
{
    public interface IGroupMenu
    {
        /// <summary>
        /// 初始化组织
        /// </summary>
        /// <returns></returns>
        RightMenuGroup init(string Group);

        /// <summary> 
        /// 修改组织
        /// </summary>
        /// <returns></returns>
        bool modify(GroupRightSubmitData data);

        /// <summary>
        /// 组织菜单权限展开的按钮
        /// </summary>
        /// <param name="Menu"></param>
        /// <param name="Group"></param>
        /// <returns></returns>
        RightMenuGroup GroupexportMenu(string Menu, string Group);
    }
}
