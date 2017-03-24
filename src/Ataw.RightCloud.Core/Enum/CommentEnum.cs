using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Core
{
   
    [CodePlug("ResouceType", Author = "zhm", Description = "评论资源类型")]
    public enum ResouceType
     {
        [Description("文本")]
        Text = 0,
        [Description("图片")]
        Photo = 1,
        [Description("页面")]
        Page = 2,
     }
    [CodePlug("IsAuditingType", Author = "zhm", Description = "是否审核通过类型")]
    public enum IsAuditingType
    {
        [Description("未审核")]
        yes = 0,
        [Description("已审核")]
        no = 1,
    }
    [CodePlug("IsUseAuditingType", Author = "zhm", Description = "是否启用审核")]
    public enum IsUseAuditingType
    {
        [Description("禁用")]
        yes = 0,
        [Description("启用")]
        no = 1,
    }
    [CodePlug("IsLock", Author = "zhm", Description = "是否锁定")]
    public enum IsLock
    {
        [Description("已解锁")]
        yes = 0,
        [Description("已锁定")]
        no = 1,

    }

}
