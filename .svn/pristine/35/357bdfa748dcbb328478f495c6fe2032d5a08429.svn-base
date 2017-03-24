
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.Framework.Core;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.DB;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.Core;
using Ataw.RightCloud.Data;
using Ataw.Framework.Web;
using Ataw.Right.Api;

namespace Ataw.RightCloud.BF
{
    public class BFAtaw_Users : RightCloudBaseBF
    {

        public UserData getUser(string fid)
        {
            Ataw_Users model = new Ataw_Users();
            if (!fid.IsAkEmpty())
            {
                DAAtaw_Users _da = new DAAtaw_Users(this.UnitOfData);
                BFAtaw_User_Roles bf = new BFAtaw_User_Roles();
                model = _da.QueryMany(a => (a.UserID == fid)).FirstOrDefault();
                if (model != null)
                {
                    UserData userdata = new UserData();
                    CopyModel(model, userdata);

                    List<SimpleRoleData> rolelst = bf.getRoleName(userdata.UserID);
                    userdata.RoleNames = rolelst;

                    return userdata;
                }
                return null;
            }
            return null;
        }
        public static void CopyModel(Ataw_Users user, UserData userdata)
        {
            userdata.UserID = user.UserID;
            userdata.NickName = user.NickName;
            userdata.UserName = user.UserName;
            userdata.Area = user.Area;
            userdata.UserKindId = user.UserType;
            userdata.UserKindName = "UserType".GetText(user.UserType);
            userdata.IsActive = user.IsActive;
            userdata.CreateTime = user.CreateTime;
            userdata.Creater = user.Creater;
            userdata.CreaterName = "MRPUserCodeData".GetText(user.Creater);
            userdata.Remark = user.Remark;
            userdata.MEID = user.MEID;
            userdata.FControlUnitID = user.FControlUnitID;
            userdata.FControlUnitName = "GroupCodeTable".GetText(user.FControlUnitID);
            userdata.UPDATE_TIME = user.UPDATE_TIME.ToString();
        }


        public void delUser(string u)
        {
            DAAtaw_Users _da = new DAAtaw_Users(this.UnitOfData);
            _da.Delete(a => a.UserID == u);
        }
        public string update(UserData user)
        {
            DAAtaw_Users _da = new DAAtaw_Users(this.UnitOfData);
            Ataw_Users model = new Ataw_Users();
            model = _da.QueryMany(a => (a.UserID == user.UserID)).FirstOrDefault();

            setVal((a) => model.NickName = a, user.NickName);
            setVal((a) => model.UserName = a, user.UserName);
            setVal((a) => model.Area = a, user.Area);
            setVal((a) => model.IsActive = a, user.IsActive);
            setVal((a) => model.UserType = a, user.UserKindId);
            setVal((a) => model.Remark = a, user.Remark);
            setVal((a) => model.MEID = a, user.MEID);
            setVal((a) => model.FControlUnitID = a, user.FControlUnitID);

            _da.Update(model);

            return model.UserID;
        }

        public static void setVal<T>(Action<T> action, T val)
        {
            action(val);
        }

        public Ataw_Users LoginUser(string userName, string pass, string orgCode, ref string res)
        {
            Ataw_Users _user = null;
            string _pass = RightCloudUtil.EncryptString(pass);
            DAAtaw_Users da = new DAAtaw_Users(this.UnitOfData);
            var _q = da.QueryMany(a => a.UserName == userName && a.Password == _pass && a.FControlUnitID == orgCode);
            var _list = _q.ToList();
            // string _res = "";
            if (_list.Count > 0)
            {
                var isable = false;
                Ataw_Users user = null;
                _list.ForEach((a) =>
                {
                    user = a;
                    if (user.ISDELETE != true && user.IsActive != false)
                    {
                        //只有没有被删除的才能赋给_user
                        _user = user;
                        isable = true;
                    }
                });

                if (isable)
                {
                    res= "ok";
                }
                else {
                    res = "该用户已经被禁用或被删除";
                }

            }
            else
            {
                res = "账号名或者密码错误";
            }

            return _user;
        }


        public void RPassword(string p)
        {
            var password = WebCommonClass.EncryptString("123456", Ataw.Framework.Core.keyUtil.MRPkey);
            var _da = new DAAtaw_Users(this.UnitOfData);
            var usermodel = _da.QueryMany(a => a.UserID == p).FirstOrDefault();
            usermodel.Password = password;
            _da.Update(usermodel);
        }
        public string ModifyPassword(string OldPwd, string NewPwd, ref string res)
        {
            if (OldPwd == NewPwd)
            {
                res = "no";
                return "";
            }
            var password = WebCommonClass.EncryptString(NewPwd, Ataw.Framework.Core.keyUtil.MRPkey);
            var _da = new DAAtaw_Users(this.UnitOfData);
            var usermodel = _da.QueryMany(a => a.UserID == AtawAppContext.Current.UserId).FirstOrDefault();
            usermodel.Password = password;
            _da.Update(usermodel);
            res = "ok";
            Submit();
            return usermodel.UserID;
        }


        public PagerListData<UserData> Pagination(Api.Pagination pager, string userName, string fControlUnitID, string kind)
        {
            int total = 0;
            PagerListData<UserData> data = new PagerListData<UserData>();
            DAAtaw_Users _da = new DAAtaw_Users(this.UnitOfData);
            ICollection<Ataw_Users> ListUserSql = null;
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

            IQueryable<Ataw_Users> _query = _da.QueryMany(a => 1 == 1);
            if (!userName.IsAkEmpty())
            {
                _query = _query.Where(a => a.UserName.Contains(userName));
            }
            if (!fControlUnitID.IsAkEmpty())
            {
                _query = _query.Where(a => a.FControlUnitID == fControlUnitID);
            }

            ICoreGroup _coreGroup = "RightCloudCoreGroup".CodePlugIn<ICoreGroup>();

            var _list = _coreGroup.GetRightControlUnits(AtawAppContext.Current.FControlUnitID);
            var _strs = _list.Select(a => a.CODE_VALUE).ToArray();

            _query = _query.Where(a => _strs.Contains(a.FControlUnitID));
            _query = _query.Where(a => a.ISDELETE == null || a.ISDELETE == false);

            ListUserSql = _query.GetManyPage((a) => 1 == 1, a => a.UPDATE_TIME, true, pager.PageNo + 1, pager.PageSize, out total);

            List<UserData> UserList = new List<UserData>();

            foreach (var User in ListUserSql)
            {
                UserData userdata = new UserData();
                CopyModel(User, userdata);
                UserList.Add(userdata);
            }

            pager.TableName = "Ataw_Users";
            pager.TotalCount = total;
            data.Pager = pager;
            data.List = UserList;
            return data;
        }
        //public string AddUser(UserData user)
        //{
        //    DAAtaw_Users _da = new DAAtaw_Users(this.UnitOfData);
        //    Ataw_Users model = new Ataw_Users();
        //    model.UserID = UnitOfData.GetUniId();
        //    model.NickName = user.NickName;
        //    model.UserName = user.UserName;
        //    model.Password = "rNnHJ15ciBI=";
        //    model.Area = user.Area;
        //    model.UserType = user.UserKindId;
        //    model.IsActive = user.IsActive  == null? true:user.IsActive;
        //    model.CreateTime = user.CreateTime == null ? DateTime.Now : user.CreateTime;
        //    model.Creater = GlobalVariable.UserFID;
        //    model.Remark = user.Remark;
        //    model.MEID = user.MEID;
        //    _da.Add(model);
        //    return model.UserID;
        //}


        public PagerListData<RightUser> initUserData(string Group, Api.Pagination pager)
        {
            int total = 0;
            ICollection<Ataw_Users> ListMenusSql = null;
            PagerListData<RightUser> data = new PagerListData<RightUser>();

            if (Group.IsAkEmpty())
            {
                Group = "1";
            }

            if (pager == null)
            {
                pager = new Api.Pagination();
                pager.IsASC = "IsASC".AppKv<bool>(false);
                pager.PageNo = "PageNo".AppKv<int>(0);
                pager.PageSize = "PageSize".AppKv<int>(5);
                pager.TotalCount = 0;
            }

            if (pager.PageSize == 0)
            {
                pager.PageSize = "PageSize".AppKv<int>(5);
            }

            DAAtaw_Users da = new DAAtaw_Users(this.UnitOfData);
            var list = da.QueryDefault(a => a.FControlUnitID == Group);

            ListMenusSql = list.GetManyPage((a) => 1 == 1, a => a.UPDATE_TIME, !pager.IsASC, pager.PageNo + 1, pager.PageSize, out total);
            List<RightUser> List = new List<RightUser>();

            foreach (var item in ListMenusSql)
            {
                RightUser model = new RightUser();
                CopyRight(item, model);
                List.Add(model);
            }

            pager.TableName = "Ataw_Role";
            pager.TotalCount = total;
            data.Pager = pager;
            data.List = List;

            return data;
        }


        public void CopyRight(Ataw_Users model, RightUser rightmodel)
        {
            rightmodel.FID = model.UserID;
            rightmodel.UserName = model.NickName;
            rightmodel.UserSign = model.UserName;
            rightmodel.OriginalName = model.UserName;

        }

        //用户添加
        public void UserAdd(string userID, string userName, string fControlUnitID)
        {
            DAAtaw_Users da = new DAAtaw_Users(this.UnitOfData);
            Ataw_Users userModel = new Ataw_Users();
            var password = "ataws";
            userModel.FControlUnitID = fControlUnitID;
            userModel.Password = RightCloudUtil.EncryptString(password);
            userModel.UserID = userID;
            userModel.UserName = userName;
            da.Add(userModel);
        }
        //用户修改
        public void UserUpdate(string userID, string userName)
        {
            DAAtaw_Users da = new DAAtaw_Users(this.UnitOfData);
            Ataw_Users userModel = new Ataw_Users();
            userModel = da.QueryDefault(a => a.UserID == userID).FirstOrDefault();
            userModel.UserName = userName;
            da.Update(userModel);
        }
        //用户删除
        public void UserDelete(string userID)
        {
            DAAtaw_Users da = new DAAtaw_Users(this.UnitOfData);
            Ataw_Users userModel = new Ataw_Users();
            userModel = da.QueryDefault(a => a.UserID == userID).FirstOrDefault();
            if (userModel != null)
            {
                da.Delete(userModel);
            }

        }
    }
}

