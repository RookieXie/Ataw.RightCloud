
//�������Ataw.DEv�Զ����ɵĴ��룬���н��������ƽ̨��������ϵ
using System;
using System.Collections.Generic;
using Ataw.Framework.Core;
//using System.ComponentModel.DataAnnotations.Schema;
namespace Ataw.RightCloud.Data
{
    /// <summary>
    /// ��ɫ
    /// </summary>
    public class RC_Role : AtawBaseModel
    {

     
        /// <summary>
        /// ��ɫ��ʶ
        /// </summary>
        public string RCR_Code { get; set; } 
     
        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string RCR_Name { get; set; } 
     
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string RCR_ProductList { get; set; } 
     

    }

}
