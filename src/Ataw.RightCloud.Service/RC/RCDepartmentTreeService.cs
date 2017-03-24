using Ataw.Framework.Core;
using Ataw.Framework.Web;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.BF.RC;
using Ataw.RightCloud.Data.Table;
using Ataw.RightCloud.DB;
using System.Collections.Generic;

namespace Ataw.RightCloud.Service.RC
{
    public class RCDepartmentTreeService
    {
        public RCDepartmentData getOrgCode(string code)
        {
            BFDepartment bf = new BFDepartment();
            var model = bf.GetDepartmentInfo(code);

            RCDepartmentData rightmodel = new RCDepartmentData();
            //rightmodel.CODE_TEXT = model.FName;
            //rightmodel.CODE_VALUE = model.FID;
            return rightmodel;
        }

        public RCDepartmentData init(string Department)
        {
            if (Department.IsAkEmpty())
            {
                Department = "1";
            }
            //1，初始化 ;
            //菜单数据初始化  
            BFDepartment bfgroup = new BFDepartment();
            //组织数据初始化
            var model = bfgroup.GetRightGroup(Department);
            return model;
        }
        public string NewUserRole(string UserRole)
        {
            var _UserRole = UserRole.SafeJsonObjectByWeb<List<RCUserRoleData>>(); ;
            var bf = new BFDepartment();
            var fid = "1";
            bf.clearUserRole();
            for (int i = 0; i < _UserRole.Count; i++)
            {
                bf.AddUserRole(_UserRole[i]);
            }
            try
            {
                bf.Submit();
                fid = "0";
            }
            catch (System.Exception)
            {
                throw;
            }          
            return fid;
        }
    }
}
