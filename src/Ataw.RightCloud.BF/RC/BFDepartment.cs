using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.Data;
using Ataw.RightCloud.Data.Table;
using System.Data.SqlClient;
using System.Linq;

namespace Ataw.RightCloud.BF.RC
{
    public class BFDepartment : RightCloudBaseBF
    {
        /// <summary>
        /// 得到单个信息
        /// </summary>
        /// <param name="fid">ID</param>
        /// <returns></returns>
        public RC_Department GetDepartmentInfo(string fid)
        {
            DARC_Department _da = new DARC_Department(this.UnitOfData);
            RC_Department _atawDepartment = _da.Get(a => a.FID == fid);
            return _atawDepartment;
        }
        public RCDepartmentData GetRightGroup(string DepartmentCode)
        {
            DARC_Department _da = new DARC_Department(this.UnitOfData);
            RC_Department RC_Group = _da.GetByKey(DepartmentCode);
            RCDepartmentData model = new RCDepartmentData();
            CopyGroup(RC_Group, model);

            return model;
        }
        public void CopyGroup(RC_Department model, RCDepartmentData groupmodel)
        {
        }
        //清空原关联表
        public void clearUserRole()
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=TestDB;User ID=sa;Pwd=12");
            string sql = "delete from RC_User_Role";
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
        //添加
        public void AddUserRole(RCUserRoleData UserRole)
        {
            DAUserRole da = new DAUserRole(this.UnitOfData);
            var model = da.QueryDefault(a => a.UserID == UserRole.UserID && a.RoleID == UserRole.RoleID).FirstOrDefault();
            if (model == null)
            {
                RC_UserRole newModel= new RC_UserRole();
                newModel.UserRoleFID = da.GetUniId();
                newModel.UserID = UserRole.UserID;
                newModel.RoleID = UserRole.RoleID;
                da.Add(newModel);
            }

        }
    }
}
