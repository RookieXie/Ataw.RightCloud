using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.BF;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Data;
using Ataw.Framework.Core;
using System.Data;
using Ataw.RightCloud.DB;
using Ataw.RightCloud.Api.Data.Org;
using Ataw.Right.Api.Data;
using Ataw.RightCloud.Api.Data.User;
using Ataw.Framework.Web;

namespace Ataw.RightCloud.Service
{
    public class UserService : BaseService, IUser
    {
        public ResponseData<IEnumerable<Api.Data.UserData>> getUser(IEnumerable<string> fids)
        {
            var bf = new BFAtaw_Users();
            ResponseData<IEnumerable<UserData>> Data = new ResponseData<IEnumerable<UserData>>();

            List<UserData> List = new List<UserData>();
            String[] fidList = fids.ToArray();
            for (int i = 0; i < fidList.Count(); i++)
            {
                UserData data = new UserData();
                data = bf.getUser(fidList[i]);
                var user = data.NickName;
                if (user == "")
                {
                    throw new AtawException("用户名{0}不能为空 ".AkFormat(data.UserID), this);
                }
                List.Add(data);
            }
            Data.Data = List;
            //Data = setData<IEnumerable<UserData>>(Data);
            Data.Time = DateTime.Now;
            Data.ActionType = "OK";

            return Data;
        }

        public ResponseData delUser(IEnumerable<string> fids)
        {
            ResponseData Data = new ResponseData();
            var bf = new BFAtaw_Users();
            string[] fid = fids.ToArray();

            //首先要去判断一下  它是否有角色赋给他
            bool ishaveRole = false;
            for (int i = 0; i < fid.Length; i++)
            {
                var bfRoleUser = new BFAtaw_User_Roles();
                string role = bfRoleUser.GetRoleID(fid[i]);
                if (!role.IsAkEmpty())
                {
                    ishaveRole = true;
                }
            }
            if (ishaveRole)
            {
                Data.Content = "删除失败！请先删除该用户的角色.";
                Data.Data = "";
            }
            else
            {
                try
                {
                    for (int i = 0; i < fid.Length; i++)
                    {
                        bf.delUser(fid[i]);
                    }
                    bf.Submit();
                    Data.Content = "成功";
                    Data.Data = "ok";
                }
                catch (Exception)
                {
                    Data.Content = "删除失败";
                    Data.Data = "error";
                    throw;
                }
            }


            Data.Time = DateTime.Now;

            return Data;
        }

        public ResponseData<string[]> updateUser(IEnumerable<UserData> users)
        {
            RightCloudDBContext db = new RightCloudDBContext();
            var bf = new BFAtaw_Users();
            bf.SetUnitOfData(db);
            var roleuserbf = new BFAtaw_User_Roles();
            roleuserbf.SetUnitOfData(db);
            ResponseData<string[]> data = new ResponseData<string[]>();
            List<string> list = new List<string>();
            try
            {
                foreach (var user in users)
                {
                    string fid = bf.update(user);
                    roleuserbf.UpdateData(user.userRoles, user.UserID, user.FControlUnitID);
                    list.Add(fid);
                }
                bf.Submit();
                data.Data = list.ToArray(); //添加之后的fid集合
                //data = setData<string[]>(data);
                data.Time = DateTime.Now;
                data.ActionType = "更新成功";
                data.Content = "ok";
            }
            catch (Exception e)
            {
                data.Content = "error";
                data.Data = new string[] { e.ToString() };
                throw e;
            }

            return data;
        }


        public ResponseData<PagerListData<UserData>> searchUserDetail(string fControlUnitID, string kind, string userName, Api.Pagination pager)
        {
            //将参数传到BF 然后分页
            var bf = new BFAtaw_Users();

            var DetailData = bf.Pagination(pager, userName, fControlUnitID, kind);

            ResponseData<PagerListData<UserData>> Data = new ResponseData<PagerListData<UserData>>();
            Data.Data = DetailData;

            // Data = setData<PagerListData<MenuData>>(Data);
            Data.Time = DateTime.Now;
            Data.ActionType = "OK";
            return Data;
        }


        //public ResponseData<string[]> newUser(IEnumerable<UserData> users)
        //{
        //    var bf = new BFAtaw_Users();
        //    ResponseData<string[]> data = new ResponseData<string[]>();
        //    List<string> list = new List<string>();
        //    try
        //    {
        //        foreach (var user in users)
        //        {
        //            string fid = bf.AddUser(user);
        //            list.Add(fid);
        //        }
        //        bf.Submit();
        //        data.Data = list.ToArray(); //添加之后的fid集合
        //        data.Content = "ok";
        //        data.ActionType = "添加成功";
        //    }
        //    catch (Exception e)
        //    {
        //        data.Content = "error";
        //        data.Data = new String[] { e.ToString() };
        //        throw e;
        //    }
        //    //data = setData<string[]>(data);
        //    data.Time = DateTime.Now;
        //    return data;
        //}





        //重置密码
        public ResponseData RPassword(IEnumerable<string> fids)
        {
            String[] fidList = fids.ToArray();

            ResponseData data = new ResponseData();
            var bf = new BFAtaw_Users();

            for (int i = 0; i < fidList.Count(); i++)
            {
                bf.RPassword(fidList[i]);
            }

            bf.Submit();
            data.Data = "ok";
            data.Content = "重置成功";
            data.ActionType = "OK";
            data.Time = DateTime.Now;
            return data;
        }

        public ResponseData CheckUser(string fids)
        {
            ResponseData data = new ResponseData();
            string userfids = "";
            var DbContext = new RightCloudDBContext();
            //首先要检查角色是否在统一组织下面

            if (fids != null && !fids.Equals(""))
            {
                StringBuilder str = new StringBuilder();
                String[] fid = fids.Split(',');
                for (int i = 0; i < fid.Count(); i++)
                {
                    str.Append("'" + fid[i] + "',");
                }

                userfids = str.ToString().TrimEnd(',');
            }
            string sql = string.Format("select FControlUnitID from Ataw_Users where UserID in ({0}) group by FControlUnitID", userfids);
            DataSet dataSet = DbContext.QueryDataSet(sql);
            if (dataSet != null && dataSet.Tables[0] != null && dataSet.Tables[0].Rows.Count > 1)
            {
                data.Content = "所选用户不在同以组织下面，不能统一分配角色";
            }
            else
            {
                data.Data = dataSet.Tables[0].Rows[0]["FControlUnitID"].ToString();
                data.Content = "ok";
            }

            return data;

        }


        //批量分配角色
        public ResponseData AddUserRoleBA(string roleid, string fids)
        {
            ResponseData data = new ResponseData();

            var DbContext = new RightCloudDBContext();

            var _fids = fids.Split(',').ToList();

            try
            {
                BFAtaw_User_Roles _bf = new BFAtaw_User_Roles();
                var _rolebf = new BFAtaw_Roles();
                foreach (var fid in _fids)
                {
                    //首先要判断一下是否有这个数据
                    if (!_bf.checkUserRole(fid, roleid))
                    {
                        var _rolemodel = _rolebf.getRole(roleid);
                        _bf.AddRole(fid, roleid, _rolemodel.FControlUnitID);
                    }
                }
                _bf.Submit();
                data.Content = "ok";

            }
            catch (Exception e)
            {
                data.Content = "error";
                data.Data = e.ToString();
                throw e;
            }
            data.Time = DateTime.Now;
            return data;
        }

        /// <summary>
        /// 分配角色额外权限
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ResponseData<IEnumerable<GroupButtonData>> GetPermissionsList(string key)
        {
            BFAtaw_User_Roles bfAu_Roles = new BFAtaw_User_Roles();
            BFAtaw_Roles bfAtaw_Roles = new BFAtaw_Roles();
            List<GroupButtonData> _groupButtonDList = null;
            List<IdAndRoleIdData> rightList = null;
            BFAtaw_Gruop bfataw_Group = new BFAtaw_Gruop();
            string roleIds = bfAu_Roles.GetRoleID(key);
            string unitID = "";
            string strWhere = "";
            var role = "Role".PlugGet<Ataw.Right.Api.IRole>();
            if (!string.IsNullOrEmpty(roleIds))
            {
                unitID = role.GetUserInfo(key).FControlUnitID;//当前选中用户的控制单元
                strWhere = "menuid in (select distinct RightID from view_UserRoleRight where FControlUnitID = '{0}')".AkFormat(unitID);
            }
            DataTable dt = role.InitRightsTree_Send(strWhere, unitID);
            DataView dv = dt.DefaultView;
            dv.Sort = "orderid asc";
            _groupButtonDList = bfataw_Group.copyGroupButtonModel(dv.ToTable());
            if (roleIds == null || roleIds.Equals(""))
            {
                rightList = role.GetRolePermissionsList(" RoleID in(" + roleIds + ")", "");
            }
            if (_groupButtonDList != null && rightList != null)
            {
                for (int i = 0; i < _groupButtonDList.Count; i++)
                {
                    for (int j = 0; j < rightList.Count; j++)
                    {
                        if (rightList[j].id.ToString().Equals(_groupButtonDList[i].ID))
                        {
                            if (_groupButtonDList[i].Name.ToString().IndexOf("角色：") != -1)
                            {
                                _groupButtonDList[i].Name += "," + bfAtaw_Roles.GetRoleNameByRoleID(rightList[j].roleId);
                            }
                            else
                            {
                                _groupButtonDList[i].Name = _groupButtonDList[i].Name.ToString() + "(角色：" + bfAtaw_Roles.GetRoleNameByRoleID(rightList[j].roleId);
                            }
                        }
                    }
                    if (_groupButtonDList[i].Name.IndexOf("角色:") != -1)
                    {
                        _groupButtonDList[i].Name = _groupButtonDList[i].Name + " 自带权限)";
                    }
                }
            }
            ResponseData<IEnumerable<GroupButtonData>> Data = new ResponseData<IEnumerable<GroupButtonData>>();
            Data.Data = _groupButtonDList;
            Data = setData<IEnumerable<GroupButtonData>>(Data);
            return Data;

        }



        /// <summary>
        /// 部门的一些操作？
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public ResponseData<IEnumerable<DataRightTree>> GetDataRightTree(string userID, string type)
        {
            ResponseData<IEnumerable<DataRightTree>> Data = new ResponseData<IEnumerable<DataRightTree>>();
            var role = "Role".PlugGet<Ataw.Right.Api.IRole>();
            if (type == "1")
            {
                List<DataRightTree> list = new List<DataRightTree>();
                DataRightTree model = new DataRightTree();
                string unitID = role.GetUserInfo(userID).FControlUnitID;
                Right.Api.Data.RGroupData groupInfo = role.GetGroupDataModel(unitID);
                model.GroupID = groupInfo.GroupID;
                model.PID = "0";
                model.GroupName = groupInfo.GroupName;
                model.Nocheck = true;
                model.Open = true;
                list.Add(model);
                string strWhere = "";
                if (GlobalVariable.IsAtawSuperUser)
                    strWhere = "FControlUnitID='" + unitID + "'";
                else
                    strWhere = GetDepartmentQueryString(unitID);
                List<DepartmentInfoData> _departmentInfo = new List<DepartmentInfoData>();
                foreach (var item in _departmentInfo)
                {
                    DataRightTree _dataRightTreeModel = new DataRightTree();
                    _dataRightTreeModel.GroupID = item.FID;
                    _dataRightTreeModel.PID = item.FParentFID;
                    if (item.FParentFID == "" || item.FParentFID == "0")
                        _dataRightTreeModel.PID = unitID;
                    _dataRightTreeModel.GroupName = item.FName;
                    _dataRightTreeModel.Nocheck = false;
                    list.Add(_dataRightTreeModel);
                }
                Data.Data = list;
            }
            Data = setData<IEnumerable<DataRightTree>>(Data);
            return Data;

        }


        public static string GetDepartmentQueryString(string fControlUnitID = "")
        {
            string unitID = fControlUnitID.IsEmpty() ? GlobalVariable.FControlUnitID : fControlUnitID;
            string fids = " select FOrgFID from  Ataw_DmPermission where userID='" + GlobalVariable.UserFID + "' and FDmPermTypeID='" + 1 + "' ";
            fids = "(" + fids + " union select FDepartmentID as FOrgFID from dbo.Ataw_UsersDetail where UserID = '" + GlobalVariable.UserFID + "' ) ";
            string strWhere = "IsDelete='false' and FID in(" + fids + ")";
            strWhere += " and FControlUnitID='" + unitID + "'";
            return strWhere;
        }
        public ResponseData<string> UserDataRightsGrant(string fids, string userID, string type)
        {
            var role = "Role".PlugGet<Ataw.Right.Api.IRole>();
            ResponseData<string> Data = new ResponseData<string>();
            try
            {
                //先删除该用户的权限
                string uFControlUnitID = role.GetUserInfo(userID).FControlUnitID;
                role.DeleteByWhere(" UserID='" + userID + "' and FDmPermTypeID='" + type + "' and FControlUnitID='" + uFControlUnitID + "' ");
                string[] FNumber = fids.Replace("'", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in FNumber)
                {
                    RDmPermissionData dpInfo = new RDmPermissionData();
                    dpInfo.UserID = userID;
                    dpInfo.FControlUnitID = uFControlUnitID;
                    dpInfo.FDmPermTypeID = type;
                    if (type == "1")
                    {
                        var dm = role.DepartmentGet(item);
                        dpInfo.FNumber = dm.FNumber;
                        dpInfo.FName = dm.FName;
                        dpInfo.FOrgFID = item;
                    }
                    role.DmPermissionInsert(dpInfo);
                }
                Data.Data = "ok";
            }
            catch (Exception)
            {
                Data.Content = "error";
                throw;
            }
            Data = setData<string>(Data);
            return Data;
        }
        public ResponseData<string> GetUserDataRights(string userID, string type)
        {
            var role = "Role".PlugGet<Ataw.Right.Api.IRole>();
            IList<Object> _Olist = role.GetUserDataRights(userID, type);
            ResponseData<string> Data = new ResponseData<string>();
            Data.Data = _Olist.ToJson();
            Data = setData<string>(Data);
            return Data;

        }


        public ResponseData<string> SetUserScreenMode(string screenMode)
        {
            var role = "Role".PlugGet<Ataw.Right.Api.IRole>();
            String strData = role.SetUserScreenMode(screenMode);
            ResponseData<string> Data = new ResponseData<string>();
            Data.Data = strData;
            Data = setData<string>(Data);
            return Data;
        }


        public ResponseData<string> GetUserScreenMode()
        {
            var role = "Role".PlugGet<Ataw.Right.Api.IRole>();
            String strData = role.GetUserScreenMode();
            ResponseData<string> Data = new ResponseData<string>();
            Data.Data = strData;
            Data = setData<string>(Data);
            return Data;
        }

        public ResponseData<string> GetUserRole(string userid)
        {
            BFAtaw_User_Roles bf = new BFAtaw_User_Roles();
            ResponseData<string> Data = new ResponseData<string>();
            List<string> list = bf.getUserRole(userid);
            Data.Data = list.JoinString();
            Data = setData<string>(Data);
            return Data;
        }
        public List<UserData> GetUser(string orgId)
        {
            var _context = AtawAppContext.Current.UnitOfData;
            if (orgId.IsAkEmpty())
            {
                orgId = "1";
            }
            var sql = "select UserID,NickName from Ataw_Users where IsActive = 1 and FControlUnitID = '{0}' and(ISDELETE = 0 or ISDELETE is null)".AkFormat(orgId);
           var dataSet=_context.QueryDataSet(sql);
            var table = dataSet.Tables[0];
            List<UserData> userList = new List<UserData>();
            if (table.Rows.Count > 0)
            {
                var rows = table.Rows;
                for (int i = 0; i < rows.Count; i++)
                {
                    UserData user = new UserData();
                    user.UserID = rows[i]["UserID"].Value<string>();
                    user.NickName = rows[i]["NickName"].Value<string>();
                    userList.Add(user);
                }

            }
            return userList;
        }
    }
}
