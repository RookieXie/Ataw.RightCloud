
//这个是由Ataw.DEv自动生成的代码，如有建议请跟大平台开发组联系
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
        /// 主键
        /// </summary>
        public string UserID { get; set; } 
     
        /// <summary>
        /// 头像
        /// </summary>
        public string UserAvatar { get; set; } 
     
        /// <summary>
        /// 头像
        /// </summary>
        public Byte[] Avatar { get; set; } 
     
        /// <summary>
        /// 姓名
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; } 
     
     
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; } 
     
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } 
     
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birthday { get; set; } 
     
        /// <summary>
        /// 住址
        /// </summary>
        public string Address { get; set; } 
     
        /// <summary>
        /// 所属部门
        /// </summary>
        public string FDepartmentID { get; set; } 
     
        /// <summary>
        /// 职位
        /// </summary>
        public string POSITIONJOBID { get; set; } 
     
        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime? EntryDate { get; set; } 
     
        /// <summary>
        /// 工号
        /// </summary>
        public string FNumber { get; set; } 
     
        /// <summary>
        /// 在职状态
        /// </summary>
        public int? FStatus { get; set; } 
     
        /// <summary>
        /// 学历
        /// </summary>
        public string Degree { get; set; } 
     
        /// <summary>
        /// 个性签名
        /// </summary>
        public string Signatures { get; set; } 
     
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCard { get; set; } 
     
        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; } 
     
        /// <summary>
        /// 民族
        /// </summary>
        public string Nationality { get; set; } 
     
        /// <summary>
        /// 政治面貌
        /// </summary>
        public string PoliticsStatus { get; set; } 
     
        /// <summary>
        /// 户口类型
        /// </summary>
        public int? Census { get; set; } 
     
        /// <summary>
        /// 合同类型
        /// </summary>
        public string ContractType { get; set; } 
     
        /// <summary>
        /// 工资类型
        /// </summary>
        public int? WageType { get; set; } 
     
        /// <summary>
        /// 毕业学校
        /// </summary>
        public string GraduateSchool { get; set; } 
     
        /// <summary>
        /// 专业
        /// </summary>
        public string Discipline { get; set; } 
     
        /// <summary>
        /// 毕业日期
        /// </summary>
        public DateTime? GraduateDate { get; set; } 
     
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel { get; set; } 
     
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; } 
     
        /// <summary>
        /// 是否公开
        /// </summary>
        public Boolean? IsPublic { get; set; } 
     
        /// <summary>
        /// 机号
        /// </summary>
        public string Gcnumber { get; set; } 
     
        /// <summary>
        /// 职称
        /// </summary>
        public string Position { get; set; } 
     
        /// <summary>
        /// 岗位
        /// </summary>
        public string Job { get; set; } 
     
        /// <summary>
        /// 高温补助
        /// </summary>
        public double? Water { get; set; } 
     
        /// <summary>
        /// 住房补助
        /// </summary>
        public double? Housing { get; set; } 
     
        /// <summary>
        /// 午餐补助
        /// </summary>
        public double? SupperBase { get; set; } 
     
        /// <summary>
        /// 基本工资
        /// </summary>
        public double? BasicWage { get; set; } 
     
        /// <summary>
        /// 机号
        /// </summary>
        public string MachineNo { get; set; } 
     
        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime? LeaveDate { get; set; } 
     
        /// <summary>
        /// 转正日期
        /// </summary>
        public DateTime? FullTimeDate { get; set; } 
     
        /// <summary>
        /// 社保基数
        /// </summary>
        public decimal? SocialSecurityBasic { get; set; } 
     
        /// <summary>
        /// 公积金基数
        /// </summary>
        public decimal? ProvidentfundBasic { get; set; } 
     
        /// <summary>
        /// 合同截止日期
        /// </summary>
        public DateTime? ContractEnd { get; set; } 
     
        /// <summary>
        /// 考勤卡号
        /// </summary>
        public string CardNumber { get; set; } 
     
        /// <summary>
        /// 试用期工资
        /// </summary>
        public decimal? TrialWage { get; set; } 
     
        /// <summary>
        /// 加班补助
        /// </summary>
        public decimal? OverTimeBase { get; set; } 
     

    }

}
