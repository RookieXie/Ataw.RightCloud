
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.Framework.Core;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.DB;
using Ataw.RightCloud.Data;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Data.Table;

namespace Ataw.RightCloud.BF
{
    public class BFAtaw_User_Roles : RightCloudBaseBF
    {
        public Boolean checkUserRole(string userid, string roleId)
        {
            DAAtaw_User_Roles _da = new DAAtaw_User_Roles(this.UnitOfData);
            List<Ataw_User_Roles> list = _da.QueryMany(a => (a.UserID == userid && a.RoleID == roleId)).ToList();
            if (list.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void AddRole(string fid, string roleid, string fcontrolunitid)
        {
            DAAtaw_User_Roles _da = new DAAtaw_User_Roles(this.UnitOfData);
            Ataw_User_Roles model = new Ataw_User_Roles();
            //首先要判断一下是否有这个数据
            model.UserRoleID = this.UnitOfData.GetUniId();
            model.UserID = fid;
            model.RoleID = roleid;
            model.FControlUnitID = fcontrolunitid;
            _da.Add(model);
        }



        public string GetRoleID(string key)
        {
            DAAtaw_User_Roles _da = new DAAtaw_User_Roles(this.UnitOfData);
            List<Ataw_User_Roles> AuRoleList = _da.QueryMany(a => a.UserID == key).ToList();
            string roleIds = "";
            if (AuRoleList != null)
            {
                foreach (var item in AuRoleList)
                {
                    roleIds += "'" + item.RoleID + "',";
                }
            }
            roleIds = roleIds.TrimEnd(',');
            return roleIds;
        }

        public List<SimpleRoleData> getRoleName(string userid)
        {
            if (!userid.IsAkEmpty())
            {
                List<SimpleRoleData> Roles = new List<SimpleRoleData>();
                DAAtaw_User_Roles _da = new DAAtaw_User_Roles(this.UnitOfData);
                List<Ataw_User_Roles> AuRoleList = _da.QueryMany(a => (a.UserID == userid)).ToList();
                BFAtaw_Roles bf = new BFAtaw_Roles();
                for (int i = 0; i < AuRoleList.Count; i++)
                {
                    var Role = AuRoleList[i].RoleID;
                    SimpleRoleData model = new SimpleRoleData();
                    var _rolemodel = bf.getRole(Role);
                    model.RoleID = _rolemodel.RoleID;
                    model.RoleName = _rolemodel.RoleName;
                    Roles.Add(model);
                }

                return Roles;
            }
            return null;

        }

        public List<string> getUserRole(string userid)
        {
            if (!userid.IsAkEmpty())
            {
                List<string> Roles = new List<string>();
                DAAtaw_User_Roles _da = new DAAtaw_User_Roles(this.UnitOfData);
                List<Ataw_User_Roles> AuRoleList = _da.QueryMany(a => (a.UserID == userid)).ToList();
                BFAtaw_Roles bf = new BFAtaw_Roles();
                for (int i = 0; i < AuRoleList.Count; i++)
                {
                    Roles.Add(AuRoleList[i].RoleID);
                }

                return Roles;
            }
            return null;
        }

        public void UpdateData(List<ChangeRoleData> list, string p, string FControlUnitID)
        {
            foreach (var item in list)
            {
                if (item.changeValue != item.originalValue || item.ActionType == "remove")
                {
                    //要对情况进行分析
                    if (item.ActionType == "remove")
                    {
                        Remove(item.changeValue, p);
                    }
                    else if (item.ActionType == "add")
                    {
                        if (!checkUserRole(p, item.changeValue))
                        {
                            AddRole(p, item.changeValue, FControlUnitID);
                        }
                        else
                        {
                            throw new AtawException("请不要选择重复角色", this);
                        }
                    }
                    else
                    {
                        Remove(item.originalValue, p);
                        if (!checkUserRole(p, item.changeValue))
                        {
                            AddRole(p, item.changeValue, FControlUnitID);
                        }
                        else
                        {
                            throw new AtawException("请不要选择重复角色", this);
                        }
                    }
                }
            }
        }


        public void Remove(string roleid, string userid)
        {
            DAAtaw_User_Roles _da = new DAAtaw_User_Roles(this.UnitOfData);
            var model = _da.QueryMany(a => (a.RoleID == roleid && a.UserID == userid)).FirstOrDefault();
            _da.Delete(model);
        }

        public List<RightRole_User> GetUserRoleByGroup(string Group, Api.Pagination pager)
        {
            PagerListData<RightRole_User> data = new PagerListData<RightRole_User>();
            DAAtaw_User_Roles _da = new DAAtaw_User_Roles(this.UnitOfData);
            BFAtaw_Users users = new BFAtaw_Users();

            if (Group.IsAkEmpty())
            {
                Group = "1";
            }
            var userspation = users.initUserData(Group, pager);

            var List = new List<RightRole_User>();
            foreach (var item in userspation.List)
            {

                var userList = _da.QueryDefault(a => (a.UserID == item.FID)).ToList();
                foreach (var item1 in userList)
                {
                    RightRole_User model = new RightRole_User();
                    CopyModel(item1, model);
                    List.Add(model);
                }
            }
            return List;
        }

        public void CopyModel(Ataw_User_Roles model, RightRole_User Rightmodel)
        {
            Rightmodel.Role = model.RoleID;
            Rightmodel.User = model.UserID;
        }

        //删除用户和角色中间表信息
        public void UserRoleDeleteByUserID(string userID)
        {
            DAAtaw_User_Roles _da = new DAAtaw_User_Roles(this.UnitOfData);
            Ataw_User_Roles urModel = new Ataw_User_Roles();
            urModel = _da.QueryDefault(a => a.UserID == userID).FirstOrDefault();
            if (urModel!=null)
            {
                _da.Delete(urModel);
            }
            
        }
        public void UserRoleDeleteByRoleID(string roleID)
        {
            DAAtaw_User_Roles _da = new DAAtaw_User_Roles(this.UnitOfData);
            Ataw_User_Roles urModel = new Ataw_User_Roles();
            urModel = _da.QueryDefault(a => a.RoleID == roleID).FirstOrDefault();
            if (urModel!=null)
            {
                _da.Delete(urModel);
            }
            
        }

        public void UserRoleDelete(string userID, string roleID, string FControlUnitID)
        {
            DAAtaw_User_Roles _da = new DAAtaw_User_Roles(this.UnitOfData);
            Ataw_User_Roles urModel = new Ataw_User_Roles();
            urModel = _da.QueryDefault(a => a.RoleID == roleID && a.UserID==userID &&a.FControlUnitID==FControlUnitID).FirstOrDefault();
            if (urModel!=null)
            {
                _da.Delete(urModel);
            }
            
        }

        public List<RCUserRoleData> GetUserRoleAll() {

            DAUserRole _da = new DAUserRole(this.UnitOfData);
            var list = _da.QueryDefault(a => a.ISDELETE ==null).ToList();
            var List = new List<RCUserRoleData>();
            foreach (var item in list)
            {
                RCUserRoleData model = new RCUserRoleData();
                CopyRight(item, model);
                List.Add(model);
            }

            return List;
        }
        public void CopyRight(RC_UserRole model, RCUserRoleData rightmodel)
        {
            rightmodel.UserRoleFID = model.UserID+model.RoleID;
            rightmodel.RoleID = model.RoleID;
            rightmodel.UserID = model.UserID;
        }
    }
}

