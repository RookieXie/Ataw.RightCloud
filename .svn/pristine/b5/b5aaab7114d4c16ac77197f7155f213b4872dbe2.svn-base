
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
using Ataw.RightCloud.Core;
using Ataw.RightCloud.Api;
using Ataw.Right.Api;

namespace Ataw.RightCloud.BF
{
    public class BFAtaw_Roles : RightCloudBaseBF
    {
        public Api.Data.RoleData getRole(string fid)
        {
            Ataw_Roles model = new Ataw_Roles();

            if (!fid.IsAkEmpty())
            {
                DAAtaw_Roles _da = new DAAtaw_Roles(this.UnitOfData);
                model = _da.QueryMany(a => (a.RoleID == fid)).FirstOrDefault();
                if (model != null)
                {
                    RoleData roledata = new RoleData();
                    CopyModel(model, roledata);
                    return roledata;
                }
                return null;
            }
            return null;
        }


        public PagerListData<RoleData> Pagination(Api.Pagination pager, string roleName, string roleSgin, string fControlUnitID, string kind)
        {
            int total = 0;
            PagerListData<RoleData> data = new PagerListData<RoleData>();
            DAAtaw_Roles _da = new DAAtaw_Roles(this.UnitOfData);
            ICollection<Ataw_Roles> ListMenusSql = null;

            if (pager == null)
            {
                pager = new Api.Pagination();
                pager.IsASC = "IsASC".AppKv<bool>(false);
                pager.PageNo = "PageNo".AppKv<int>(0);
                pager.PageSize = "PageSize".AppKv<int>(15);
                pager.TotalCount = 0;
            }

            if (pager.PageSize == 0)
            {
                pager.PageSize = "PageSize".AppKv<int>(15);
            }

            IQueryable<Ataw_Roles> _query = _da.QueryMany(a => 1 == 1);

            if (!roleName.IsAkEmpty())
            {
                _query = _query.Where(a => a.RoleName.Contains(roleName));
            }
            if (!roleSgin.IsAkEmpty())
            {
                _query = _query.Where(a => a.RoleSign.Contains(roleSgin));
            }
            if (!fControlUnitID.IsAkEmpty())
            {
                _query = _query.Where(a => a.FControlUnitID == fControlUnitID);
            }

            ICoreGroup _coreGroup = "RightCloudCoreGroup".CodePlugIn<ICoreGroup>();

            var _list = _coreGroup.GetRightControlUnits(AtawAppContext.Current.FControlUnitID);
            var _strs = _list.Select(a => a.CODE_VALUE).ToArray();

            _query = _query.Where(a => _strs.Contains(a.FControlUnitID));

            ListMenusSql = _query.GetManyPage((a) => 1 == 1, a => a.UPDATE_TIME, !pager.IsASC, pager.PageNo + 1, pager.PageSize, out total);



            List<RoleData> RoleList = new List<RoleData>();

            foreach (var Menu in ListMenusSql)
            {
                RoleData menudata = new RoleData();
                CopyModel(Menu, menudata);
                RoleList.Add(menudata);
            }

            pager.TableName = "Ataw_Roles";
            pager.TotalCount = total;
            data.Pager = pager;
            data.List = RoleList;
            return data;
        }

        private void CopyModel(Ataw_Roles model, RoleData roledata)
        {
            roledata.RoleID = model.RoleID;
            roledata.RoleName = model.RoleName;
            roledata.Description = model.Description;
            roledata.RoleSign = model.RoleSign;
            roledata.FControlUnitID = model.FControlUnitID;
            roledata.FControlUnitName = "GroupCodeTable".GetText(model.FControlUnitID);
            roledata.IsPublic = model.IsPublic;
            roledata.IconFile = model.IconFile;
            roledata.CreateTime = model.CREATE_TIME;
            roledata.UPDATE_TIME = model.UPDATE_TIME.ToString();
        }


        public void delRoles(string fid)
        {
            DAAtaw_Roles _da = new DAAtaw_Roles(this.UnitOfData);
            _da.Delete(a => a.RoleID == fid);
        }

        public string AddRole(RoleData role)
        {
            DAAtaw_Roles _da = new DAAtaw_Roles(this.UnitOfData);
            Ataw_Roles model = new Ataw_Roles();

            model.RoleID = UnitOfData.GetUniId();
            model.RoleSign = role.RoleSign;
            model.RoleName = role.RoleName;
            model.FControlUnitID = role.FControlUnitID;
            model.IsPublic = role.IsPublic;
            model.Description = role.Description;
            model.IconFile = role.IconFile;

            _da.Add(model);

            return model.RoleID;

        }

        public string update(RoleData role)
        {
            DAAtaw_Roles _da = new DAAtaw_Roles(this.UnitOfData);
            Ataw_Roles model = new Ataw_Roles();
            model = _da.QueryMany(a => (a.RoleID == role.RoleID)).FirstOrDefault();

            setVal((a) => model.RoleName = a, role.RoleName ?? model.RoleName);
            setVal((a) => model.RoleSign = a, role.RoleSign ?? model.RoleSign);
            setVal((a) => model.FControlUnitID = a, role.FControlUnitID ?? model.FControlUnitID);
            setVal((a) => model.IsPublic = a, role.IsPublic ?? model.IsPublic);
            setVal((a) => model.Description = a, role.Description ?? model.Description);
            setVal((a) => model.IconFile = a, role.IconFile ?? model.IconFile);
            _da.Update(model);

            return model.RoleID;
        }

        public static void setVal<T>(Action<T> action, T val)
        {
            action(val);
        }

        public string GetRoleNameByRoleID(string roleId)
        {
            DAAtaw_Roles _da = new DAAtaw_Roles(this.UnitOfData);
            Ataw_Roles ataw_Users = _da.Get(a => a.RoleID == roleId);
            if (ataw_Users != null)
            {
                return ataw_Users.RoleName;
            }
            else
            {
                return null;
            }
        }


        public string GetFControlUnitIDByRoleID(string roleId)
        {
            DAAtaw_Roles _da = new DAAtaw_Roles(this.UnitOfData);
            Ataw_Roles ataw_Users = _da.Get(a => a.RoleID == roleId);
            if (ataw_Users != null)
            {
                return ataw_Users.FControlUnitID;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 代分页的方法
        /// </summary>
        /// <param name="Group"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public List<RightRole> initRoleData(string Group)
        {
            if (Group.IsAkEmpty())
            {
                Group = "1";
            }

            DAAtaw_Roles _da = new DAAtaw_Roles(this.UnitOfData);
            var list = _da.QueryDefault(a => a.FControlUnitID == Group).ToList();

            var List = new List<RightRole>();
            foreach (var item in list)
            {
                RightRole model = new RightRole();
                CopyRight(item, model);
                List.Add(model);
            }

            return List;
        }

        public void CopyRight(Ataw_Roles model, RightRole rightmodel)
        {
            rightmodel.FID = model.RoleID;
            rightmodel.RoleName = model.RoleName;
            rightmodel.RoleSign = model.RoleSign;
            rightmodel.OriginalName = model.RoleName;
        }

        //角色添加
        public void AddRoleByModel(Ataw_Roles roles)
        {
            DAAtaw_Roles da = new DAAtaw_Roles(this.UnitOfData);
            var model = da.QueryDefault(a => a.RoleID == roles.RoleID).FirstOrDefault();
            if (model==null)
            {
                da.Add(roles);
            }
           
        }
        //角色修改
        public void UpdateRole(string roleID, string roleName)
        {
            DAAtaw_Roles da = new DAAtaw_Roles(this.UnitOfData);
            Ataw_Roles roleModel = new Ataw_Roles();
            roleModel = da.QueryDefault(a => a.RoleID == roleID).FirstOrDefault();
            roleModel.RoleName = roleName;
            da.Update(roleModel);
        }
    }
}

