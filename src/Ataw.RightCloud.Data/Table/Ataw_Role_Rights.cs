
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
    public class Ataw_Role_Rights : AtawBaseModel
    {

     
        /// <summary>
        /// ����
        /// </summary>
        public string RoleRigthID { get; set; } 
     
        /// <summary>
        /// ��ɫID
        /// </summary>
        public string RoleID { get; set; } 
     
        /// <summary>
        /// ����Ȩ��
        /// </summary>
        public string RightID { get; set; } 
     
        /// <summary>
        /// Ȩֵ
        /// </summary>
        public int? FunctionRight { get; set; } 
     
        /// <summary>
        /// ��������Ȩ�޵�
        /// </summary>
        public string UserRight { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        public string Remark { get; set; }

    }

}
