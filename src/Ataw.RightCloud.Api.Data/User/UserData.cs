using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api.Data
{
    public class UserData
    {
        public String UserID { get; set; }
        public String  NickName { get; set; } //名称
        public String UserName { get; set; } //登录名
        public String Area { get; set; } //地区
        public string UserKindId { get; set; }//用户类型ID
        public string UserKindName { get; set; }//用户类型名称
        public Boolean? IsActive { get; set; } //是否启用
        public DateTime? CreateTime { get; set; } //创建时间
        public String Creater { get; set; } //创建人
        public String CreaterName { get; set; }//创建人名字
        public String Remark { get; set; } //备注	
        public String MEID { get; set; } //手机MEID号	
        public String FControlUnitID { get; set; } //组织机构
        public string FControlUnitName { get; set; }

        public string Operation { get; set; }//操作类型
        public List<SimpleRoleData> RoleNames { get; set; }
        public List<ChangeRoleData> userRoles { get; set; }
        public String UPDATE_TIME { get; set; }
    }
}
