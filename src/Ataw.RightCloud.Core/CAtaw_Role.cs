using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Core
{
    class CAtaw_Role
    {
        /// <summary>
        /// 角色标示
        /// </summary>
        public String  RoleSign { get; set; }

        /// <summary>
        /// 角色名字
        /// </summary>
        public String  RoleName { get; set; }

        /// <summary>
        /// 组织机构名称
        /// </summary>
        public String FControlUnitID { get; set; }

        /// <summary>
        /// 是否公布
        /// </summary>
        public int IsPublic { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// 图标描述
        /// </summary>
        public String IconFile { get; set; }
    }
}
