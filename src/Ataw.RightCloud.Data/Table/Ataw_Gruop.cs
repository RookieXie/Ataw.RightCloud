
//这个是由Ataw.DEv自动生成的代码，如有建议请跟大平台开发组联系
using System;
using System.Collections.Generic;
using Ataw.Framework.Core;
//using System.ComponentModel.DataAnnotations.Schema;
namespace Ataw.RightCloud.Data
{
    /// <summary>
    /// 组织机构表
    /// </summary>
    public class Ataw_Gruop : AtawBaseModel
    {

        
        /// <summary>
        /// 是否父节点
        /// </summary>
        public bool? IsParent { get; set; } 
     
        /// <summary>
        /// 组织机构
        /// </summary>
        public string GroupID { get; set; } 
     
        /// <summary>
        /// 上级机构
        /// </summary>
        public string FParentFID { get; set; } 
     
        /// <summary>
        /// 机构名称
        /// </summary>
        public string GroupName { get; set; } 
     
        /// <summary>
        /// 机构编码
        /// </summary>
        public string GroupCode { get; set; } 
     
        /// <summary>
        /// 机构描述
        /// </summary>
        public string GroupDescrible { get; set; } 
     
        /// <summary>
        /// 地址
        /// </summary>
        public string FAddress { get; set; } 
     
        /// <summary>
        /// 所属产品
        /// </summary>
        public string ProductFIDs { get; set; } 
     
        /// <summary>
        /// 联系方式
        /// </summary>
        public string FPhone { get; set; } 
     
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; } 
     
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string Post { get; set; } 
     
        /// <summary>
        /// 创建人
        /// </summary>
        public string FCreateUser { get; set; } 
     
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? FCreateTime { get; set; } 
     

    }

}
