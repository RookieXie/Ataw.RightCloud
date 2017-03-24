using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api.Data
{
   public class UserDetailData:UserData
    {
       // public String UserID { get; set; } //用户ID
        public String UserAvatar { get; set; }//用户头像
        public string TrueName { get; set; } //用户姓名
        public string Gender { get; set; }//性别

        //public String UserName { get; set; }//登录名
        public String Phone { get; set; }//手机
        public String Email { get; set; }//邮箱
        public DateTime? Birthday { get; set; }//出生日期
        public String Address { get; set; }//住址
        public String FDepartmentID { get; set; }//所属部门
        public String POSITIONJOBID { get; set; }//职位

        public String POSITIONJOBName { get; set; }//职位
        public DateTime? EntryDate { get; set; }//入职日期
        public String FNumber { get; set; }//工号

        public String FStatus { get; set; }//在职状态
        public string FStatusKindId { get; set; }
        public string FStatusKindName { get; set; }

        //public String Degree { get; set; }//学历
        public string DegreeKindId { get; set; }
        public string DegreeKindName { get; set; }
        public String Signatures { get; set; }//个性签名
        public String IDCard { get; set; }//身份证号
        public String Age { get; set; }//年龄

        //public String Nationality { get; set; }//民族
        public string NationalityKindId { get; set; }
        public string NationlityKindName { get; set; }

        //public String PoliticsStatus { get; set; }//政治面貌
        public string PoliticsStatusKindId { get; set; }
        public string PoliticsStatusKindName { get; set; }

        //public String Census { get; set; }//户口类型
        public string CensusKindId { get; set; }
        public string CensusKindName { get; set; }
        public String GraduateSchool { get; set; }//毕业学校
        public String Discipline { get; set; }//专业
        public DateTime? GraduateDate { get; set; }//毕业时间
        public String Tel { get; set; }//联系电话
        public String QQ { get; set; }//qqs
        public Dictionary<string, IEnumerable<CodeDataModel>> dropDownList { get; set; }
    }
}
