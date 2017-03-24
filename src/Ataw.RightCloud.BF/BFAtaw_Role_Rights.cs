
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.Framework.Core;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.DB;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.BF
{
    public class BFAtaw_Role_Rights : RightCloudBaseBF
    {
        public void add(Data.Ataw_Role_Rights roleRightModel)
        {
            DAAtaw_Role_Rights _da = new DAAtaw_Role_Rights(this.UnitOfData);
            roleRightModel.RoleRigthID = UnitOfData.GetUniId();
            _da.Add(roleRightModel);
        }

        public void delRight(string RoleId)
        {
            DAAtaw_Role_Rights _da = new DAAtaw_Role_Rights(this.UnitOfData);
            _da.Delete(a => (a.RoleID == RoleId));
        }
        //通过菜单ID来删除中间表信息
        public void delRightByRightID(string rightID)
        {
            DAAtaw_Role_Rights _da = new DAAtaw_Role_Rights(this.UnitOfData);
            _da.Delete(a => (a.RightID == rightID));
        }
        public string getFControlUnitIdByRoleID(string RoleId)
        {
            DAAtaw_Role_Rights _da = new DAAtaw_Role_Rights(this.UnitOfData);
            var rolemodel = _da.QueryMany(a => (a.RoleID == RoleId)).FirstOrDefault();
            return rolemodel.FControlUnitID;
        }


        public List<Ataw_Role_Rights> getRoleRight(string roleid)
        {
            DAAtaw_Role_Rights _da = new DAAtaw_Role_Rights(this.UnitOfData);

            List<Ataw_Role_Rights> list = _da.QueryMany(a => (a.RoleID == roleid)).ToList();

            return list;
        }



        public List<Api.Data.RightRole_Menu> GetRoleMenuByGroup(string Group)
        {
            DAAtaw_Role_Rights _da = new DAAtaw_Role_Rights(this.UnitOfData);
            if (Group.IsAkEmpty())
            {
                Group = "1";
            }
            List<Ataw_Role_Rights> list = _da.QueryMany(a => (a.FControlUnitID == Group)).ToList();
            List<Api.Data.RightRole_Menu> List = new List<Api.Data.RightRole_Menu>();
            foreach (var item in list)
            {
                Api.Data.RightRole_Menu model = new Api.Data.RightRole_Menu();
                CopyModel(item, model);
                List.Add(model);
            }

            return List;
        }

        public void CopyModel(Ataw_Role_Rights model, Api.Data.RightRole_Menu Rightmodel)
        {
            Rightmodel.Menu = model.RightID;
            Rightmodel.Role = model.RoleID;
        }

        public List<Api.Data.RightRole_Menu> initRoleMenuConnect(List<Api.Data.RightMenu> list)
        {
            List<Api.Data.RightRole_Menu> List = new List<Api.Data.RightRole_Menu>();
            if (list != null)
            {
                foreach (var item in list)
                {
                    Api.Data.RightRole_Menu model = new Api.Data.RightRole_Menu();
                    Ataw_Role_Rights RightModel = getModelByRole(item.FID);
                    if (RightModel != null)
                    {
                        CopyModel(RightModel, model);
                    }
                    List.Add(model);
                }
            }
            return List;
        }

        public Ataw_Role_Rights getModelByRole(string p)
        {
            DAAtaw_Role_Rights _da = new DAAtaw_Role_Rights(this.UnitOfData);
            var model = _da.QueryMany(a => a.RightID == p).FirstOrDefault();
            return model;
        }

        //通过用户ID和角色ID删除
        public void DelteByUserIDRoleID(string userID, string roleID, string fControlUnitID)
        {
            DAAtaw_Role_Rights _da = new DAAtaw_Role_Rights(this.UnitOfData);
            var model = _da.QueryDefault(a => a.RightID == userID && a.RoleID == roleID && a.FControlUnitID == fControlUnitID).FirstOrDefault();
            if (model != null)
            {
                _da.Delete(model);
            }
        }

    }
}

