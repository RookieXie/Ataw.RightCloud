using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api.Data
{
    /// <summary>
    /// 返回 菜单/角色/用户 实体
    /// </summary>
    public class MenuRoleUserData
    {
        public List<RoleData> RoleDataList { get; set; }
        public List<MenuData> MenuDataList { get; set; }
        public List<UserData> UserDataList { get; set; }
        public GroupData CurrentGroup { get; set; } //用户选中前组织信息
    }
}
