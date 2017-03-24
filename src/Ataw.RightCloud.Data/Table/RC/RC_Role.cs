
//这个是由Ataw.DEv自动生成的代码，如有建议请跟大平台开发组联系
using System;
using System.Collections.Generic;
using Ataw.Framework.Core;
//using System.ComponentModel.DataAnnotations.Schema;
namespace Ataw.RightCloud.Data
{
    /// <summary>
    /// 角色
    /// </summary>
    public class RC_Role : AtawBaseModel
    {

     
        /// <summary>
        /// 角色标识
        /// </summary>
        public string RCR_Code { get; set; } 
     
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RCR_Name { get; set; } 
     
        /// <summary>
        /// 产品集合
        /// </summary>
        public string RCR_ProductList { get; set; } 
     

    }

}
