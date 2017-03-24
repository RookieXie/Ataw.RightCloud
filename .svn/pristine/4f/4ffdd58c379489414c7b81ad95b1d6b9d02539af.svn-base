using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.BF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.Framework.Core;
using Ataw.RightCloud.Data;
using System.Data.Entity.Validation;
using Ataw.Framework.Web;
using System.Data;

namespace Ataw.RightCloud.Service
{
    public class RoleService : IRole
    {
        public ResponseData<IEnumerable<Api.Data.RoleData>> getRole(IEnumerable<string> fids)
        {
            var bf = new BFAtaw_Roles();

            ResponseData<IEnumerable<RoleData>> Data = new ResponseData<IEnumerable<RoleData>>();

            List<RoleData> List = new List<RoleData>();
            String[] fidList = fids.ToArray();
            for (int i = 0; i < fidList.Count(); i++)
            {
                RoleData data = new RoleData();
                data = bf.getRole(fidList[i]);
                List.Add(data);
            }

            Data.Data = List;
            //Data = setData<IEnumerable<RoleData>>(Data);
            Data.Time = DateTime.Now;
            Data.ActionType = "OK";
            return Data;
        }

        public ResponseData<IEnumerable<Api.Data.RoleData>> getRoleDetail(IEnumerable<string> fids)
        {
            throw new NotImplementedException();
        }

        public ResponseData<PagerListData<RoleData>> searchRoleDetail(string roleName, string roleSign,string fControlUnitID, string kind, Api.Pagination pager)
        {
            //将参数传到BF 然后分页
            var bf = new BFAtaw_Roles();

            var DetailData = bf.Pagination(pager, roleName,roleSign, fControlUnitID, kind);

            ResponseData<PagerListData<RoleData>> Data = new ResponseData<PagerListData<RoleData>>();
            Data.Data = DetailData;

            // Data = setData<PagerListData<MenuData>>(Data);
            Data.Time = DateTime.Now;
            Data.ActionType = "OK";
            return Data;
        }


        public ResponseData<string> delRole(IEnumerable<string> fids)
        {
            ResponseData<string> data = new ResponseData<string>();
            var bf = new BFAtaw_Roles();
            string[] fid = fids.ToArray();
            try
            {
                for (int i = 0; i < fid.Length; i++)
                {
                    bf.delRoles(fid[i]);
                }

                bf.Submit();
                data.Content = "ok";
                data.Data = "删除成功";
            }
            catch (Exception)
            {
                data.Content = "error";
                data.Data = "删除失败";
                throw;
            }

            //data = setData<string>(data);

            data.Time = DateTime.Now;

            return data;
        }

        public ResponseData<string[]> newRole(IEnumerable<Api.Data.RoleData> roles)
        {
            var bf = new BFAtaw_Roles();
            ResponseData<string[]> data = new ResponseData<string[]>();
            List<string> list = new List<string>();
            try
            {
                foreach (var role in roles)
                {
                    string fid = bf.AddRole(role);
                    list.Add(fid);
                }
                bf.Submit();
                data.Data = list.ToArray(); //添加之后的fid集合
                data.Content = "ok";
                data.ActionType = "添加成功";
            }
            catch (Exception e)
            {
                data.Content = "error";
                data.Data = new String[] { e.ToString() };
                throw e;
            }
            //data = setData<string[]>(data);
            data.Time = DateTime.Now;
            return data;


        }

        public ResponseData<string[]> updateRole(IEnumerable<RoleData> roles)
        {
            var bf = new BFAtaw_Roles();
            ResponseData<string[]> data = new ResponseData<string[]>();
            List<string> list = new List<string>();
            try
            {
                foreach (var role in roles)
                {
                    string fid = bf.update(role);
                    list.Add(fid);
                }
                bf.Submit();
                data.Data = list.ToArray(); //添加之后的fid集合
                //data = setData<string[]>(data);
                data.Time = DateTime.Now;
                data.Content = "ok";
                data.ActionType = "更新成功";
            }
            catch (Exception e)
            {
                data.Content = "error";
                data.Data = new string[] { e.ToString() };
                throw e;
            }
            return data;
        }

        public ResponseData RoleGrant(string rightIds, string RoleId)
        {
            ResponseData data = new ResponseData();

            if (!RoleId.IsAkEmpty())
            {
                try
                {
                    //首先删除所有的数据 然后再添加
                    BFAtaw_Role_Rights bf = new BFAtaw_Role_Rights();
                    bf.delRight(RoleId);

                    //string _FControlUnitID = bf.getFControlUnitIdByRoleID(RoleId);
                    var roleData = new BFAtaw_Roles().getRole(RoleId);
                    string _FControlUnitID = roleData == null ? "" : roleData.FControlUnitID;
                    var role = "Role".PlugGet<Ataw.Right.Api.IRole>();

                    if (!string.IsNullOrEmpty(rightIds) && rightIds != null)
                    {
                        string[] fid = null;
                        fid = rightIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        string fids = "";
                        foreach (var item in fid)
                        {
                            fids += "'" + item + "',";
                        }
                        fids = fids.TrimEnd(',');
                        List<Right.Api.Data.MenuData> list = role.GetMenuList(fids);

                        for (int i = 0; i < list.Count; i++)
                        {
                            Ataw_Role_Rights roleRightModel = new Ataw_Role_Rights();
                            roleRightModel.FControlUnitID = _FControlUnitID;
                            roleRightModel.RoleID = RoleId;
                            roleRightModel.RightID = list[i].MenuID;
                            roleRightModel.FunctionRight = list[i].FunctionRight;
                            roleRightModel.Remark = DateTime.Now.ToString();
                            bf.add(roleRightModel);
                        }
                        data.Content = "ok";
                    }
                    bf.Submit();
                }
                catch (Exception dbEx)
                {
                    data.Content = "error";
                    data.Data = dbEx.ToString();
                    throw dbEx;
                }

            }
            else
            {
                data.Content = "RoldId不能为空";
            }
            data.Time = DateTime.Now;
            return data;

        }

        public ResponseData CheckUserRole(string roleId)
        {
            ResponseData data = new ResponseData();
            BFAtaw_User_Roles bf = new BFAtaw_User_Roles();
            string userid = GlobalVariable.UserFID;
            if (bf.checkUserRole(userid, roleId))
            {
                data.ActionType = "fail";
                data.Content = "不能对自己的角色赋权限";
            }
            else
            {
                data.ActionType = "OK";
                data.Content = "可以赋权限";
            }

            data.Time = DateTime.Now;

            return data;
        }

        /// <summary>
        /// 初始化空间树
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public ResponseData<DataSet> InitRightsTree(string roleid)
        {
            ResponseData<DataSet> data = new ResponseData<DataSet>();
            string unitID = "";
            string strWhere = "";
            try
            {
                if (!roleid.IsEmpty())
                {
                    var bf = new BFAtaw_Roles();
                    unitID = bf.GetFControlUnitIDByRoleID(roleid);
                    strWhere = "  FControlUnitID ='{0}' ".AkFormat(unitID);
                }

                var rightbf = new BFAtaw_Menus();
                var dbset = rightbf.GetGroupMenusTree1(unitID, strWhere);
                data.Data = dbset;
                data.Content = "ok";
            }
            catch (Exception)
            {
                data.Content = "error";
                throw;
            }
            data.Time = DateTime.Now;
            return data;
        }

        /// <summary>
        /// 初始化空间树
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public ResponseData<List<string>> GetRoleRightsList(string roleId)
        {
            ResponseData<List<string>> data = new ResponseData<List<string>>();

            var bf = new BFAtaw_Role_Rights();
            List<Ataw_Role_Rights> list = bf.getRoleRight(roleId);

            List<Ataw_Menus_Button> listbutton = new List<Ataw_Menus_Button>();
            var bfbutton = new BFAtaw_Menus_Button();
            List<string> rightIdList = new List<string>();
            foreach (var info in list)
            {
                var bfMenu = new BFAtaw_Menus();
                var obj = bfMenu.getMenu(info.RightID);
                if (obj != null)
                {
                    var kk = bfbutton.GetMenus_Button(obj.Key, info.FunctionRight.Value<int>());

                    foreach (var hh in kk)
                    {
                        listbutton.Add(hh);
                    }
                }
                rightIdList.Add(info.RightID);
            }
            foreach (var item in listbutton)
            {
                rightIdList.Add(item.FID);
            }

            data.Data = rightIdList;

            data.Time = DateTime.Now;
            return data;
        }
    }
}
