
//这个是由Ataw.DEv自动生成的代码，如有建议请跟大平台开发组联系
using System;
using System.Collections.Generic;
using Ataw.Framework.Core;
//using System.ComponentModel.DataAnnotations.Schema;
namespace Ataw.RightCloud.Data
{
    /// <summary>
    /// 菜单-角色
    /// </summary>
    public class RC_Menu_Role : AtawBaseModel
    {

     
        /// <summary>
        /// 菜单编号
        /// </summary>
        public string RCMR_MenuFID { get; set; } 
     
        /// <summary>
        /// 角色编号
        /// </summary>
        public string RCMR_RoleFID { get; set; } 
     
        /// <summary>
        /// 组织机构编号
        /// </summary>
        public string RCMR_FControlUnitID { get; set; } 
        /// <summary>
        /// 菜单按钮
        /// </summary>
        public string RCMR_Button { get; set; }

    }

}
