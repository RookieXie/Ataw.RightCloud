using Ataw.Framework.Core;
using Ataw.Framework.Web;
using Ataw.Right.Api.Data;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.Api.RC;
using Ataw.RightCloud.Service;
using Ataw.RightCloud.Service.RC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug.ColdeTable
{
    [CodePlug("RCUsers", BaseClass = typeof(IRCUsers), CreateDate = "2016-10-25", Author = "xbg", Description = "用户信息插件")]
    public class RCUsers : IRCUsers
    {
        public DepUserRoleData GetRCUsers(string UserIDs, string RoleIDs, string DepartmentID)
        {
            string FControlUnitID = GlobalVariable.FControlUnitID;//当前组织
            DepUserRoleData PageData = new DepUserRoleData();

            var Users = this.GetAllUsers(UserIDs);
            PageData.UserDataList = Users;

            var Role = this.GetAllRole(RoleIDs);
            PageData.RoleDataList = Role;

            var UserRole = this.GetAllUserRole();
            PageData.UserRoleDataList = UserRole;

            //var sql1 = "select FID,RCUR_RoleFID,RCUR_UserFID from RC_User_Role where FControlUnitID='{0}' AND ISDELETE is NULL";
            //DataSet ds1 = AtawAppContext.Current.UnitOfData.QueryDataSet(sql1.AkFormat(FControlUnitID));
            //List<RCUserRoleData> UserRole = new List<RCUserRoleData>();
            //for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            //{
            //    RCUserRoleData RCUserRoleData = new RCUserRoleData();

            //    RCUserRoleData.UserID = ds1.Tables[0].Rows[i]["RCUR_UserFID"].Value<string>();
            //    RCUserRoleData.RoleID = ds1.Tables[0].Rows[i]["RCUR_RoleFID"].Value<string>();
            //    RCUserRoleData.UserRoleFID = RCUserRoleData.UserID + RCUserRoleData.RoleID;
            //    UserRole.Add(RCUserRoleData);
            //}

            return PageData;
        }
        public List<RCUsersData> GetAllUsers(string UserIDs)
        {
            UserDetailService US = new UserDetailService();
            var UserData = US.GetUsers(UserIDs);
            return UserData;
        }
        public List<RCRoleData> GetAllRole(string RoleIDs)
        {
          RCRoleService RS = new RCRoleService();
            var RoleData = RS.GetRole(RoleIDs);
            return RoleData;
         }
        public List<RCUserRoleData> GetAllUserRole() {
            RCUserRoleService USS = new RCUserRoleService();
            var UserRoleData = USS.GetUserRole();
            return UserRoleData;
        }
    }
}
