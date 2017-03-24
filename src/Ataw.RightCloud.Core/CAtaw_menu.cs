using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Core
{
    public class CAtaw_menu
    {
        /// <summary>
        /// 父节点Id
        /// </summary>
        public String ParentID { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public String RightKey { get; set; }


        /// <summary>
        /// 菜单权值
        /// </summary>
        public String RightValue { get; set; }


        /// <summary>
        /// 菜单描述
        /// </summary>
        public String  RightDesc { get; set; }


        /// <summary>
        /// 权限类别
        /// </summary>
        public String RightType { get; set; }

        /// <summary>
        /// 排序编号
        /// </summary>
        public String OrderId { get; set; }


        public IEnumerable<CAtaw_menu_button> MenuIEnumerable { get; set; }
    }
}
