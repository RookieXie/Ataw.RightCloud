using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api.Data
{
    /// <summary>
    /// 权限分配实体
    /// </summary>
    public class RightGrantData
    {
        /// <summary>
        /// 新增的权限主体的dataid
        /// </summary>
        public string NewKey { get; set; }

        /// <summary>
        /// 已有权限主体的主键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 新增的菜单或按钮的dataid
        /// </summary>
        public List<string> NewRightIds { get; set; }

        /// <summary>
        /// 已有菜单或按钮的主键
        /// </summary>
        public List<string> RightIds { get; set; }

        /// <summary>
        /// 权限分配类别
        /// </summary>
        public string RightGrantType { get; set; }

        /// <summary>
        /// 是否按钮和子节点
        /// </summary>
        public string MenuType { get; set; }
    }

}
