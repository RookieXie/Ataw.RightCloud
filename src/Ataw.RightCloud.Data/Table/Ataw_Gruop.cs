
//�������Ataw.DEv�Զ����ɵĴ��룬���н��������ƽ̨��������ϵ
using System;
using System.Collections.Generic;
using Ataw.Framework.Core;
//using System.ComponentModel.DataAnnotations.Schema;
namespace Ataw.RightCloud.Data
{
    /// <summary>
    /// ��֯������
    /// </summary>
    public class Ataw_Gruop : AtawBaseModel
    {

        
        /// <summary>
        /// �Ƿ񸸽ڵ�
        /// </summary>
        public bool? IsParent { get; set; } 
     
        /// <summary>
        /// ��֯����
        /// </summary>
        public string GroupID { get; set; } 
     
        /// <summary>
        /// �ϼ�����
        /// </summary>
        public string FParentFID { get; set; } 
     
        /// <summary>
        /// ��������
        /// </summary>
        public string GroupName { get; set; } 
     
        /// <summary>
        /// ��������
        /// </summary>
        public string GroupCode { get; set; } 
     
        /// <summary>
        /// ��������
        /// </summary>
        public string GroupDescrible { get; set; } 
     
        /// <summary>
        /// ��ַ
        /// </summary>
        public string FAddress { get; set; } 
     
        /// <summary>
        /// ������Ʒ
        /// </summary>
        public string ProductFIDs { get; set; } 
     
        /// <summary>
        /// ��ϵ��ʽ
        /// </summary>
        public string FPhone { get; set; } 
     
        /// <summary>
        /// ����
        /// </summary>
        public string Fax { get; set; } 
     
        /// <summary>
        /// ��������
        /// </summary>
        public string Post { get; set; } 
     
        /// <summary>
        /// ������
        /// </summary>
        public string FCreateUser { get; set; } 
     
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? FCreateTime { get; set; } 
     

    }

}
