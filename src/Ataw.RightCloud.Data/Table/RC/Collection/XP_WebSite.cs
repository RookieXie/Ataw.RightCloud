using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Data.Table
{
    public class XP_WebSite : AtawBaseModel
    {
        /// <summary>
        /// 外键
        /// </summary>
        public string Ws_id { get; set; }
        /// <summary>
        /// 网站名称
        /// </summary>
        public string Ws_Name { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Ws_UserID { get; set; }
        /// <summary>
        /// url路径
        /// </summary>
        public string Ws_Url { get; set; }
        /// <summary>
        /// 文件夹名称
        /// </summary>
        public string Ws_FolderID { get; set; }
    }
}
