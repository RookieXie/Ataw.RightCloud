using Ataw.RightCloud.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api
{
    public interface IRoleMenuUser
    {
        /// <summary>
        /// 初始化角色和菜单  Pagination 因为要分页
        /// </summary>
        /// <returns></returns>
         RightUserMenuRole init(string Groupe,Pagination data);
        /// <summary>
        /// 对角色和菜单进行修改
        /// </summary>
        /// <returns></returns>
        bool modify(MenuUserRoleSubmitData data);

        /// <summary>
        /// 展开节点的方法
        /// </summary>
        /// <param name="Menu"></param>
        /// <param name="Group"></param>
        /// <returns></returns>
        RightUserMenuRole RoleexportMenu(string Menu,string Group);

        /// <summary>
        /// 角色分页方法
        /// </summary>
        /// <param name="Group"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        RightUserMenuRole Rolepaging(string Group, Pagination page);
    }
}
