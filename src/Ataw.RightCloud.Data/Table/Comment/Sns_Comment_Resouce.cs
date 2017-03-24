using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Data.Table
{
    /// <summary>
    /// 评论资源表
    /// </summary>
    public class Sns_Comment_Resouce : AtawBaseModel
    {
        /// <summary>
        /// 资源编号
        /// </summary>
        public string SnsCR_ResouceID { get; set; }
        /// <summary>
        /// 资源类型
        /// </summary>
        public string SnsCR_Type { get; set; }
        /// <summary>
        /// 评论数量
        /// </summary>
        public int? SnsCR_RepNum { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string SnsCR_Title { get; set; }
        /// <summary>
        /// 是否启用审核
        /// </summary>
        public int? IsAuditing { get; set; }
        /// <summary>
        /// 是否为凭证数据
        /// </summary>
        public int? IsProof { get; set; }
    }

}
