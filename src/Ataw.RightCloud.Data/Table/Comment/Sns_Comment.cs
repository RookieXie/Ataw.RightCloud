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
    public class Sns_Comment : AtawBaseModel
    {
        /// <summary>
        /// 资源编号
        /// </summary>
        public string SnsC_ResouceID { get; set; }
        /// <summary>
        /// 资源类型
        /// </summary>
        public string SnsC_ResouceType { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string SnsC_Content { get; set; }
        /// <summary>
        /// 评论发表人ID
        /// </summary>
        public string SnsC_User { get; set; }
        /// <summary>
        /// 评论发表人昵称
        /// </summary>
        //public string SnsC_UserName { get; set; }
        /// <summary>
        /// 回复人
        /// </summary>
        public string SnsC_ToUser { get; set; }
        /// <summary>
        /// 是否审核通过
        /// </summary>
        public int? IsAuditing { get; set; }
        /// <summary>
        /// 回复人名称
        /// </summary>
        //public string SnsC_ToUserName { get; set; }
    }
}
