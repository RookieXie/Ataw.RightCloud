
//这个是由Ataw.DEv自动生成的代码，如有建议请跟大平台开发组联系
using System;
using System.Collections.Generic;
using Ataw.Framework.Core;
//using System.ComponentModel.DataAnnotations.Schema;
namespace Ataw.RightCloud.Data
{
    /// <summary>
    /// Ataw_Menus_Group
    /// </summary>
    public class Ataw_Menus_Group 
    {

        public string FID { get; set; }


        public string FControlUnitID { get; set; }
        /// <summary>
        /// MenuID
        /// </summary>
        public string MenuID { get; set; } 
     
        /// <summary>
        /// FunctionRight
        /// </summary>
        public int? FunctionRight { get; set; } 
     
        /// <summary>
        /// FMyIcon
        /// </summary>
        public string FMyIcon { get; set; } 
     
        /// <summary>
        /// FMyRigh
        /// </summary>
        public string FMyRightKey { get; set; } 
     
        /// <summary>
        /// Remark
        /// </summary>
        public string Remark { get; set; }

        public string TIMESSTAMP { get; set; }
    }

}
