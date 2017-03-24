
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.Framework.Core;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.DB;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.BF
{
    public class BFRC_Role : RightCloudBaseBF
    {
        /// <summary>
        /// 代分页的方法  角色
        /// </summary>
        /// <param name="Group"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public List<RCRoleData> initRCRoleData(string Group)
        {
            if (Group.IsAkEmpty())
            {
                Group = "1";
            }

            DARC_Role _da = new DARC_Role(this.UnitOfData);
            var list = _da.QueryDefault(a => a.FControlUnitID == Group).ToList();

            var List = new List<RCRoleData>();
            foreach (var item in list)
            {
                RCRoleData model = new RCRoleData();
                CopyRight(item, model);
                List.Add(model);
            }

            return List;
        }
        public List<RCRoleData> GetRoleAll(string RoleID) {
            DARC_Role _da = new DARC_Role(this.UnitOfData);
            var list = _da.QueryDefault(a => a.FID != "1").ToList();
            var List = new List<RCRoleData>();
            foreach (var item in list)
            {
                RCRoleData model = new RCRoleData();
                CopyRight(item, model);
                List.Add(model);
            }

            return List;
        }
        public void CopyRight(RC_Role model, RCRoleData rightmodel)
        {
            rightmodel.FID = model.FID;
            rightmodel.RoleName = model.RCR_Name;
            rightmodel.RoleSign = model.RCR_Code;
            rightmodel.OriginalName = model.RCR_Name;
        }

        public string GetFControlUnitIDByRoleID(string roleId)
        {
            DARC_Role _da = new DARC_Role(this.UnitOfData);
            var  roleModel = _da.Get(a => a.FID == roleId);
            if (roleModel != null)
            {
                return roleModel.FControlUnitID;
            }
            else
            {
                return "";
            }
        }

        public RC_Role GerRoleByID(string roleID)
        {
            DARC_Role _da = new DARC_Role(this.UnitOfData);
            var model=_da.QueryDefault(a => a.FID == roleID).FirstOrDefault();
            return model;
        }

        //添加角色
        public void AddRoleByModel(RC_Role model)
        {
            DARC_Role _da = new DARC_Role(this.UnitOfData);
            _da.Add(model);
        }
        //删除角色
        public void delRoles(string roleID)
        {
            DARC_Role _da = new DARC_Role(this.UnitOfData);
            _da.Delete(a => a.FID == roleID);
        }

        //修改角色
        public void UpdateRole(string roleID,string roleName)
        {
            DARC_Role _da = new DARC_Role(this.UnitOfData);
            var model = _da.QueryDefault(a => a.FID == roleID).FirstOrDefault();
            model.RCR_Name = roleName;
            _da.Update(model);
        }

        //检查是否重复
        public bool CheckRoleCodeName(string code,string name,string fControlUnitID)
        {
            DARC_Role _da = new DARC_Role(this.UnitOfData);
            var model = _da.QueryDefault(a => (a.RCR_Code == code ||a.RCR_Name==name) && a.FControlUnitID == fControlUnitID).FirstOrDefault();
            if (model != null)
            {
                return false;
            }else
            {
                return true;
            }
        }
    }
}

