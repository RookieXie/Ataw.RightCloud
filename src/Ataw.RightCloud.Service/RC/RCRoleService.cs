using Ataw.Framework.Core;
using Ataw.Framework.Web;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.BF;
using Ataw.RightCloud.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Service
{
    public class RCRoleService
    {
       
        /// <summary>
        /// 初始化空间树
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public DataTable InitRoleRightsTree(string roleid)
        {
            //ResponseData<DataTable> data = new ResponseData<DataTable>();
            string unitID = "";
            string strWhere = "";
            DataTable dt = new DataTable();
            try
            {
                if (!roleid.IsEmpty())
                {
                    var bf = new BFRC_Role();
                    unitID = bf.GetFControlUnitIDByRoleID(roleid);
                    strWhere = "  FControlUnitID ='{0}' ".AkFormat(unitID);
                }

                var rightbf = new BFRC_Menu_tree();
                dt = rightbf.GetGroupMenusTree1(unitID, strWhere);
             
            }
            catch (Exception)
            {
               // data.Content = "error";
                throw;
            }
            //data.Time = DateTime.Now;
            return dt;
        }
        /// <summary>
        /// 获取角色（单个）
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public RC_Role GetRoleByID(string roleID)
        {
            BFRC_Role bf = new BFRC_Role();
            var model =bf.GerRoleByID(roleID);
            return model;
        }

        /// <summary>
        /// 检查角色标识和名称是否重复
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckRoleCodeName(string code,string name,string fControlUnitID)
        {
            BFRC_Role bfRole = new BFRC_Role();
            var res=bfRole.CheckRoleCodeName(code, name,fControlUnitID);
            return res;
        }
        public List<RCRoleData> GetRole(string RoleID)
        {
            BFRC_Role bfRole = new BFRC_Role();
            var Role = bfRole.GetRoleAll(RoleID);
            return Role;
        }
    }
}
