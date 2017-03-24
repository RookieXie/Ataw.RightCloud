
﻿using Ataw.RightCloud.Api.Data.RightConfig;
using System;
﻿using Ataw.RightCloud.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api.RightConfig
{
    /// <summary>
    /// 权限配置接口规范
    /// </summary>
    public interface IRightConfig
    {
        /// 页面第一次初始化返回树形组织和菜单数据
        /// sq
        /// </summary>
        /// <returns></returns>
        //GroupMenuData initGroupMenuData();

        ResponseData<GroupMenuData> initGroupMenuData();

        /// <summary>
        /// 点击Tab时返回角色菜单用户数据
        /// sq
        /// </summary>
        /// <returns></returns>
        PagerListData<MenuRoleUserData> initMenuRoleUserData(string GroupID, Pagination pager);

        MenuRoleUserData initMenuRoleUserData(string GroupID);

        /// <summary>
        /// 对树形组织的增加提交方法
        /// </summary>
        /// <returns></returns>
        string GroupAddSubmit(GroupData data);

        /// <summary>
        /// 对组织删除
        /// </summary>
        /// <returns></returns>
        string GroupDeleteSubmit(GroupData data);

        /// <summary>
        /// 对组织编辑
        /// </summary>
        /// <returns></returns>
        string GroupEdit(GroupData data);

        /// <summary>
        /// 组织权限前台提交数据时调用的方法
        /// sq
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        GroupRightResponseData RightGroupSubmit(GroupRightSubmitData data);

        /// <summary>
        /// 用户角色菜单权限前台提交数据时调用的方法
        /// sq
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        MenuUserRoleResponseData MenuUserRoleSubmit(MenuUserRoleSubmitData data);
    }
}
