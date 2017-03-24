
//�������Ataw.DEv�Զ����ɵĴ��룬���н��������ƽ̨��������ϵ
using System;
using System.Collections.Generic;
using Ataw.Framework.Core;
//using System.ComponentModel.DataAnnotations.Schema;
namespace Ataw.RightCloud.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class Ataw_Roles : AtawBaseModel
    {

     
        /// <summary>
        /// ����
        /// </summary>
        public string RoleID { get; set; } 
     
        /// <summary>
        /// ��ɫ��ʶ
        /// </summary>
        public string RoleSign { get; set; } 
     
        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string RoleName { get; set; } 
     
        /// <summary>
        /// �Ƿ񷢲�
        /// </summary>
        public bool? IsPublic { get; set; } 
     
        /// <summary>
        /// ��Ҫ����
        /// </summary>
        public string Description { get; set; } 
     
        /// <summary>
        /// **
        /// </summary>
        public bool? AutoAssignment { get; set; } 
     
        /// <summary>
        /// ͼ������
        /// </summary>
        public string IconFile { get; set; } 
     
        /// <summary>
        /// ͼ��
        /// </summary>
        public string ICON_PIC { get; set; } 
     
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? CreatedOn { get; set; } 
     
        /// <summary>
        /// ���Ʊ��
        /// </summary>
        public int? UnitID { get; set; } 
     

    }

}
