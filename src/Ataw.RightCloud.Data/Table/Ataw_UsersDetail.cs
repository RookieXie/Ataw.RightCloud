
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
    public class Ataw_UsersDetail : AtawBaseModel
    {
        /// <summary>
        /// ����
        /// </summary>
        public string UserID { get; set; } 
     
        /// <summary>
        /// ͷ��
        /// </summary>
        public string UserAvatar { get; set; } 
     
        /// <summary>
        /// ͷ��
        /// </summary>
        public Byte[] Avatar { get; set; } 
     
        /// <summary>
        /// ����
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        /// ��¼��
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        public string Gender { get; set; } 
     
     
        /// <summary>
        /// �ֻ�
        /// </summary>
        public string Phone { get; set; } 
     
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } 
     
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime? Birthday { get; set; } 
     
        /// <summary>
        /// סַ
        /// </summary>
        public string Address { get; set; } 
     
        /// <summary>
        /// ��������
        /// </summary>
        public string FDepartmentID { get; set; } 
     
        /// <summary>
        /// ְλ
        /// </summary>
        public string POSITIONJOBID { get; set; } 
     
        /// <summary>
        /// ��ְ����
        /// </summary>
        public DateTime? EntryDate { get; set; } 
     
        /// <summary>
        /// ����
        /// </summary>
        public string FNumber { get; set; } 
     
        /// <summary>
        /// ��ְ״̬
        /// </summary>
        public int? FStatus { get; set; } 
     
        /// <summary>
        /// ѧ��
        /// </summary>
        public string Degree { get; set; } 
     
        /// <summary>
        /// ����ǩ��
        /// </summary>
        public string Signatures { get; set; } 
     
        /// <summary>
        /// ���֤��
        /// </summary>
        public string IDCard { get; set; } 
     
        /// <summary>
        /// ����
        /// </summary>
        public int? Age { get; set; } 
     
        /// <summary>
        /// ����
        /// </summary>
        public string Nationality { get; set; } 
     
        /// <summary>
        /// ������ò
        /// </summary>
        public string PoliticsStatus { get; set; } 
     
        /// <summary>
        /// ��������
        /// </summary>
        public int? Census { get; set; } 
     
        /// <summary>
        /// ��ͬ����
        /// </summary>
        public string ContractType { get; set; } 
     
        /// <summary>
        /// ��������
        /// </summary>
        public int? WageType { get; set; } 
     
        /// <summary>
        /// ��ҵѧУ
        /// </summary>
        public string GraduateSchool { get; set; } 
     
        /// <summary>
        /// רҵ
        /// </summary>
        public string Discipline { get; set; } 
     
        /// <summary>
        /// ��ҵ����
        /// </summary>
        public DateTime? GraduateDate { get; set; } 
     
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string Tel { get; set; } 
     
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; } 
     
        /// <summary>
        /// �Ƿ񹫿�
        /// </summary>
        public Boolean? IsPublic { get; set; } 
     
        /// <summary>
        /// ����
        /// </summary>
        public string Gcnumber { get; set; } 
     
        /// <summary>
        /// ְ��
        /// </summary>
        public string Position { get; set; } 
     
        /// <summary>
        /// ��λ
        /// </summary>
        public string Job { get; set; } 
     
        /// <summary>
        /// ���²���
        /// </summary>
        public double? Water { get; set; } 
     
        /// <summary>
        /// ס������
        /// </summary>
        public double? Housing { get; set; } 
     
        /// <summary>
        /// ��Ͳ���
        /// </summary>
        public double? SupperBase { get; set; } 
     
        /// <summary>
        /// ��������
        /// </summary>
        public double? BasicWage { get; set; } 
     
        /// <summary>
        /// ����
        /// </summary>
        public string MachineNo { get; set; } 
     
        /// <summary>
        /// ��ְ����
        /// </summary>
        public DateTime? LeaveDate { get; set; } 
     
        /// <summary>
        /// ת������
        /// </summary>
        public DateTime? FullTimeDate { get; set; } 
     
        /// <summary>
        /// �籣����
        /// </summary>
        public decimal? SocialSecurityBasic { get; set; } 
     
        /// <summary>
        /// ���������
        /// </summary>
        public decimal? ProvidentfundBasic { get; set; } 
     
        /// <summary>
        /// ��ͬ��ֹ����
        /// </summary>
        public DateTime? ContractEnd { get; set; } 
     
        /// <summary>
        /// ���ڿ���
        /// </summary>
        public string CardNumber { get; set; } 
     
        /// <summary>
        /// �����ڹ���
        /// </summary>
        public decimal? TrialWage { get; set; } 
     
        /// <summary>
        /// �Ӱಹ��
        /// </summary>
        public decimal? OverTimeBase { get; set; } 
     

    }

}
