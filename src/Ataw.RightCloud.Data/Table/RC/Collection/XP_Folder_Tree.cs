using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Data.Table
{
    public class XP_Folder_Tree : AtawBaseModel
    {
        /// <summary>
        /// 文件夹名称
        /// </summary>
        public string F_Name { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string F_UserID { get; set; }
        /// <summary>
        /// 上级
        /// </summary>
        public string PID { get; set; }
        /// <summary>
        /// 是否父节点
        /// </summary>
        public bool? IS_PARENT { get; set; }

        /// <summary>
        /// 是否叶节点
        /// </summary>
        public bool? ISLEAF { get; set; }

        /// <summary>
        /// 树状支持符号
        /// </summary>
        public string ARRANGE { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? TREEORDER { get; set; }
    }
}
