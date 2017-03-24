
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.Framework.Core;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.DB;
using Ataw.RightCloud.Data;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.Core;
using Ataw.Framework.Web;
using System.Data.Entity.Core.Objects;
using Ataw.Right.Api;

namespace Ataw.RightCloud.BF
{
    public class BFAtaw_UsersDetail : RightCloudBaseBF
    {
        public PagerListData<UserDetailData> Pagination(string userName, string trueName, string fNumber, string kind, string fControlUnitID, Api.Pagination pager)
        {
            int total = 0;
            PagerListData<UserDetailData> data = new PagerListData<UserDetailData>();
            DAAtaw_UsersDetail _da = new DAAtaw_UsersDetail(this.UnitOfData);
            ICollection<Ataw_UsersDetail> ListMenuSql = null;
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
            IQueryable<Ataw_UsersDetail> _query = _da.QueryMany(a => 1 == 1);

            if (!fNumber.IsAkEmpty())
            {
                _query = _query.Where(a => a.FNumber.Contains(fNumber));
            }
            if (!trueName.IsAkEmpty())
            {
                _query = _query.Where(a => a.TrueName.Contains(trueName));
            }
            if (!userName.IsAkEmpty())
            {
                _query = _query.Where(a=>a.UserName.Contains(userName));
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

            
            ListMenuSql = _query.GetManyPage((a) => a.FControlUnitID == AtawAppContext.Current.FControlUnitID, a => a.UPDATE_TIME, true, pager.PageNo + 1, pager.PageSize, out total);

            List<UserDetailData> UsersDetailList = new List<UserDetailData>();
            foreach (var Menu in ListMenuSql)
            {
                UserDetailData menudata = new UserDetailData();
                CopyModel(Menu, menudata);
                UsersDetailList.Add(menudata);
            }

            pager.TableName = "Ataw_UsersDetail";
            pager.TotalCount = total;
            data.Pager = pager;
            data.List = UsersDetailList;
            return data;
        }
        public bool existUserName(string userName)
        {
            DAAtaw_UsersDetail _da = new DAAtaw_UsersDetail(this.UnitOfData);
            IQueryable<Ataw_UsersDetail> _query = _da.QueryMany(a => 1 == 1);

            if (!userName.IsAkEmpty() || userName !="")
            {
                _query = _query.Where(a => a.UserName.Contains(userName));
                if (_query.Count() > 0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool existUserNum(string userNum)
        {
            DAAtaw_UsersDetail _da = new DAAtaw_UsersDetail(this.UnitOfData);
            IQueryable<Ataw_UsersDetail> _query = _da.QueryMany(a => 1 == 1);

            if (!userNum.IsAkEmpty() || userNum != "")
            {
                _query = _query.Where(a => a.UserID.Contains(userNum));
                if (_query.Count() > 0)
                {
                    return false;
                }
            }

            return true;
        }
        public UserDetailData getUserDetail(string fid)
        {
            Ataw_UsersDetail model = new Ataw_UsersDetail();

            if (!fid.IsAkEmpty())
            {
                DAAtaw_UsersDetail _da = new DAAtaw_UsersDetail(this.UnitOfData);

                model = _da.QueryMany(a => (a.UserID == fid)).FirstOrDefault();
                if (model != null)
                {
                    UserDetailData userdd = new UserDetailData();
                    CopyModel(model, userdd);
                    return userdd;

                }
                return null;
            }
            return null;
        }
        private void CopyModel(Ataw_UsersDetail model, UserDetailData userdd)
        {
            userdd.UserID = model.UserID;
            userdd.UserAvatar = model.UserAvatar;
            userdd.TrueName = model.TrueName;
            userdd.Gender = model.Gender;
            userdd.Phone = model.Phone;
            userdd.UserName = model.UserName;
            userdd.EntryDate = model.EntryDate;
            userdd.Email = model.Email;
            userdd.Birthday = model.Birthday;
            userdd.Address = model.Address;
            userdd.FDepartmentID = model.FDepartmentID;
            userdd.POSITIONJOBID = model.POSITIONJOBID;
            //PositionCodeData
            userdd.POSITIONJOBName = "PositionCodeData".GetText(model.POSITIONJOBID);
            userdd.FNumber = model.FNumber;
            userdd.FStatusKindId = model.FStatus.ToString();
            userdd.FStatusKindName = "User_WorkType".GetText(userdd.FStatusKindId);// "FStatus".GetText(model.FStatus);
            userdd.DegreeKindId = model.Degree;
            userdd.DegreeKindName = "User_DegreeType".GetText(userdd.DegreeKindId);// "Degree".GetText(model.Degree);
            userdd.Signatures = model.Signatures;
            userdd.IDCard = model.IDCard;
            userdd.Age = model.Age.ToString();
            userdd.NationalityKindId = model.Nationality;
            userdd.NationlityKindName = "User_NationalityType".GetText(userdd.NationalityKindId);// "Nationality".GetText(model.Nationality);
            userdd.PoliticsStatusKindId = model.PoliticsStatus;
            userdd.PoliticsStatusKindName = "User_PoliticsStatusType".GetText(model.PoliticsStatus);//"PoliticsStatus".GetText(model.PoliticsStatus);
            userdd.CensusKindId = model.Census.ToString();
            userdd.CensusKindName = "User_CensusType".GetText(userdd.CensusKindId);//"Census".GetText(model.Census);
            userdd.GraduateSchool = model.GraduateSchool;
            userdd.Discipline = model.Discipline;
            userdd.GraduateDate = model.GraduateDate;
            userdd.Tel = model.Tel;
            userdd.QQ = model.QQ;
            userdd.UPDATE_TIME = model.UPDATE_TIME.ToString();
        }

        public void delUserDetail(string fid)
        {
            DAAtaw_UsersDetail _da = new DAAtaw_UsersDetail(this.UnitOfData);
            _da.Delete(a => a.UserID == fid);
        }
        public string AddUserDetail(UserDetailData user)
        {
            DAAtaw_UsersDetail _da = new DAAtaw_UsersDetail(this.UnitOfData);
            Ataw_UsersDetail model = new Ataw_UsersDetail();
            model.UserID = UnitOfData.GetUniId();
            //model.UserName = user.UserName;
            model.TrueName = user.TrueName;
            model.UserName = user.UserName;
            model.UserAvatar = user.UserAvatar;
            model.Gender = user.Gender;
            model.Phone = user.Phone;
            model.Email = user.Email;
            model.Birthday = user.Birthday;
            model.Address = user.Address;
            model.FDepartmentID = user.FDepartmentID;
            model.POSITIONJOBID = user.POSITIONJOBID;
            model.EntryDate = user.EntryDate;
            model.FNumber = user.FNumber;
            model.FStatus = user.FStatusKindId.Value<int?>();
            model.Degree = user.DegreeKindId;
            model.Signatures = user.Signatures;
            model.IDCard = user.IDCard;
            model.Age = user.Age.Value<int?>();
            model.Nationality = user.NationalityKindId;
            model.PoliticsStatus = user.PoliticsStatusKindId;
            model.Census = user.CensusKindId.Value<int?>();
            model.GraduateSchool = user.GraduateSchool;
            model.Discipline = user.Discipline;
            model.GraduateDate = user.GraduateDate;
            model.Tel = user.Tel;
            model.QQ = user.QQ;

            DAAtaw_Users da = new DAAtaw_Users(this.UnitOfData);
            Ataw_Users usermodel = new Ataw_Users();

            usermodel.UserID = model.UserID;

            usermodel.NickName = user.TrueName;
            usermodel.UserName = user.UserName;

            //usermodel.NickName =model.TrueName;

            usermodel.UserName = model.UserName;
            usermodel.Password = WebCommonClass.EncryptString("123456", Ataw.Framework.Core.keyUtil.MRPkey);
            usermodel.Area = model.Address;
            usermodel.Remark = "¹ØÁªÌí¼Ó";
            usermodel.IsActive = true;
            usermodel.UserType = "1";

            da.Add(usermodel);
            _da.Add(model);

            return model.UserID;
        }

        public string updateUser(UserDetailData user)
        {
            DAAtaw_UsersDetail _da = new DAAtaw_UsersDetail(this.UnitOfData);
            Ataw_UsersDetail model = new Ataw_UsersDetail();
            model = _da.QueryMany(a => (a.UserID == user.UserID)).FirstOrDefault();

            setVal((a) => model.UserAvatar = a, user.UserAvatar);
            setVal((a) => model.UserName = a, user.UserName);
            setVal((a) => model.Gender = a, user.Gender);
            setVal((a) => model.Phone = a, user.Phone);
            setVal((a) => model.Email = a, user.Email);
            setVal((a) => model.Birthday = a, user.Birthday);
            setVal((a) => model.Address = a, user.Address);
            setVal((a) => model.FDepartmentID = a, user.FDepartmentID);
            setVal((a) => model.POSITIONJOBID = a, user.POSITIONJOBID);
            setVal((a) => model.EntryDate = a, user.EntryDate);
            setVal((a) => model.FNumber = a, user.FNumber);
            setVal((a) => model.FStatus = a, user.FStatusKindId.Value<int?>());
            setVal((a) => model.Degree = a, user.DegreeKindId);
            setVal((a) => model.Signatures = a, user.Signatures);
            setVal((a) => model.IDCard = a, user.IDCard);
            setVal((a) => model.Age = a, user.Age.Value<int?>());
            setVal((a) => model.Nationality = a, user.NationalityKindId);
            setVal((a) => model.IDCard = a, user.IDCard);
            setVal((a) => model.PoliticsStatus = a, user.PoliticsStatusKindId);
            setVal((a) => model.Census = a, user.CensusKindId.Value<int?>());
            setVal((a) => model.GraduateSchool = a, user.GraduateSchool);
            setVal((a) => model.Discipline = a, user.Discipline);
            setVal((a) => model.GraduateDate = a, user.GraduateDate);
            setVal((a) => model.Tel = a, user.Tel);
            setVal((a) => model.QQ = a, user.QQ);
            setVal((a) => model.TrueName = a, user.TrueName);

            _da.Update(model);
            return model.UserID;
        }
        public static void setVal<T>(Action<T> action, T val)
        {
           action(val);      
        }
        public List<RCUsersData> GetUsers( string UsersId) {
            DAAtaw_UsersDetail da = new DAAtaw_UsersDetail(this.UnitOfData);

            var list = da.QueryDefault(a => a.FControlUnitID == "1").ToList();

            var List = new List<RCUsersData>();

            foreach (var item in list)
            {
                RCUsersData model=new RCUsersData();
                CopyRight(item, model);
                List.Add(model);
            }
            return List;
        }
               public void CopyRight(Ataw_UsersDetail model, RCUsersData rightmodel)
        {
            rightmodel.UserID = model.UserID;
            rightmodel.TrueName = model.TrueName;
            rightmodel.UserName = model.UserName;
            rightmodel.DepartmentID = model.FDepartmentID;
        }
    }
}

