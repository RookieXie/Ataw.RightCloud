
//�������Ataw.DEv�Զ����ɵĴ��룬���н��������ƽ̨��������ϵ
using System;
using System.Collections.Generic;
using Ataw.Framework.Core;
//using System.ComponentModel.DataAnnotations.Schema;
namespace Ataw.RightCloud.Data
{
    /// <summary>
    /// �˵�-��ɫ
    /// </summary>
    public class RC_Menu_Role : AtawBaseModel
    {

     
        /// <summary>
        /// �˵����
        /// </summary>
        public string RCMR_MenuFID { get; set; } 
     
        /// <summary>
        /// ��ɫ���
        /// </summary>
        public string RCMR_RoleFID { get; set; } 
     
        /// <summary>
        /// ��֯�������
        /// </summary>
        public string RCMR_FControlUnitID { get; set; } 
        /// <summary>
        /// �˵���ť
        /// </summary>
        public string RCMR_Button { get; set; }

    }

}
