
//这个是由Ataw.DEv自动生成的代码，如有建议请跟大平台开发组联系
using System;
using System.Collections.Generic;
using Ataw.Framework.Core;
//using System.ComponentModel.DataAnnotations.Schema;
namespace Ataw.RightCloud.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class Ataw_Users : AtawBaseModel
    {

     
        /// <summary>
        /// 主键
        /// </summary>
        public string UserID { get; set; } 
     
        /// <summary>
        /// 姓名
        /// </summary>
        public string NickName { get; set; } 
     
        /// <summary>
        /// 登录名
        /// </summary>
        public string UserName { get; set; } 
     
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } 
     
        /// <summary>
        /// 所在地区
        /// </summary>
        public string Area { get; set; } 
     
        /// <summary>
        /// 用户类型
        /// </summary>
        public string UserType { get; set; } 
     
        /// <summary>
        /// 启用账号
        /// </summary>
        public bool? IsActive { get; set; } 
     
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; } 
     
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creater { get; set; } 
     
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } 
     
        /// <summary>
        /// 手机MEID号
        /// </summary>
        public string MEID { get; set; } 
     
        /// <summary>
        /// **
        /// </summary>
        public string UserConfig { get; set; } 
     

    }

}
