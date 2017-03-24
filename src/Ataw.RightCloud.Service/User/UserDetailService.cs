using Ataw.RightCloud.Api.User;
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

namespace Ataw.RightCloud.Service
{
    [CodePlug("UserDetailService", BaseClass = typeof(IUserDetail), CreateDate = "2017-03-02", Author = "smm", Description = "用户详情接口服务")]
    public class UserDetailService : IUserDetail
    {

        public ResponseData<IEnumerable<Api.Data.UserDetailData>> getUserDetail(IEnumerable<string> fids)
        {
            var bf = new BFAtaw_UsersDetail();
            ResponseData<IEnumerable<UserDetailData>> Data = new ResponseData<IEnumerable<UserDetailData>>();

            List<UserDetailData> List = new List<UserDetailData>();
            String[] fidList = fids.ToArray();
            for (int i = 0; i < fidList.Count(); i++)
            {
                UserDetailData data = new UserDetailData();
                data = bf.getUserDetail(fidList[i]);
                //data.dropDownList = this.DropDownListItem();
                List.Add(data);
            }
            Data.Data = List;
            Data.Time = DateTime.Now;
            Data.ActionType = "OK";
            return Data;
        }
        public ResponseData<PagerListData<UserDetailData>> searchUserDetail(string userName, string trueName, string fNumber, string kind, string fControlUnitID, Api.Pagination pager)
        {
            //将参数传到BF 然后分页
            var bf = new BFAtaw_UsersDetail();

            var DetailData = bf.Pagination(userName, trueName, fNumber, kind, fControlUnitID, pager);

            ResponseData<PagerListData<UserDetailData>> Data = new ResponseData<PagerListData<UserDetailData>>();
            Data.Data = DetailData;

            Data.Time = DateTime.Now;
            Data.ActionType = "OK";
            return Data;
        }


        public ResponseData delUser(IEnumerable<string> fids)
        {
            ResponseData data = new ResponseData();
            var bf = new BFAtaw_UsersDetail();
            var bfuser = new BFAtaw_Users();
            string[] fid = fids.ToArray();
            try
            {
                for (int i = 0; i < fid.Length; i++)
                {
                    bf.delUserDetail(fid[i]);
                    var Data = bf.UnitOfData;
                    bfuser.SetUnitOfData(Data);
                    bfuser.delUser(fid[i]);
                }
                bf.Submit();
                data.Data = "删除成功";
            }
            catch (Exception)
            {
                data.Data = "删除失败";
                throw;
            }
            data.Time = DateTime.Now;
            return data;

        }

        public ResponseData<string[]> existUser(string userName, string userNum)
        {
            var bf = new BFAtaw_UsersDetail();
            ResponseData<string[]> data = new ResponseData<string[]>();
            bool existName = bf.existUserName(userName);
            bool existNum = bf.existUserNum(userNum);
            var Mess = "";
            data.Content = "ok";
            if (!existName)
            {
                Mess = "登录名已经存在！\n";
                data.Content = "no";
            }
            if (!existNum)
            {
                Mess = "工号已经存在！\n";
                data.Content = "no";
            }
            data.Time = DateTime.Now;
            data.ActionType = Mess;
            return data;
        }
        public ResponseData<string[]> newUser(IEnumerable<Api.Data.UserDetailData> users)
        {
            var bf = new BFAtaw_UsersDetail();

            ResponseData<string[]> data = new ResponseData<string[]>();
            List<string> list = new List<string>();
            foreach (var user in users)
            {
                string fid = bf.AddUserDetail(user);
                list.Add(fid);
            }
            bf.Submit();
            data.Data = list.ToArray();
            data.Time = DateTime.Now;
            data.Content = "ok";
            data.ActionType = "添加成功";
            return data;
        }

        public Api.ResponseData<string[]> updateUser(IEnumerable<Api.Data.UserDetailData> users)
        {
            var bf = new BFAtaw_UsersDetail();
            ResponseData<string[]> data = new ResponseData<string[]>();
            List<string> list = new List<string>();
            foreach (var userdetail in users)
            {
                string fid = bf.updateUser(userdetail);
                list.Add(fid);
            }
            bf.Submit();
            data.Data = list.ToArray();
            data.Content = "ok";
            data.Time = DateTime.Now;
            data.ActionType = "更新成功";
            return data;
        }



        ResponseData IUserDetail.delUser(IEnumerable<string> fids)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, IEnumerable<CodeDataModel>> DropDownListItem()
        {
            Dictionary<string, IEnumerable<CodeDataModel>> DictionData = new Dictionary<string, IEnumerable<CodeDataModel>>();
            DataSet ds = new DataSet();


            var ct = "User_sexType".PlugGet<CodeTable<CodeDataModel>>();
            EnumCodeTable enumct = ct as EnumCodeTable;
            IEnumerable<CodeDataModel> list = enumct.FillAllData(ds);
            DictionData.Add("User_sexType", list);

            ct = "User_WorkType".PlugGet<CodeTable<CodeDataModel>>();
            enumct = ct as EnumCodeTable;
            IEnumerable<CodeDataModel> list1 = enumct.FillAllData(ds);
            DictionData.Add("User_WorkType", list1);


            ct = "User_DegreeType".PlugGet<CodeTable<CodeDataModel>>();
            enumct = ct as EnumCodeTable;
            IEnumerable<CodeDataModel> list2 = enumct.FillAllData(ds);
            DictionData.Add("User_DegreeType", list2);

            ct = "User_NationalityType".PlugGet<CodeTable<CodeDataModel>>();
            enumct = ct as EnumCodeTable;
            IEnumerable<CodeDataModel> list3 = enumct.FillAllData(ds);
            DictionData.Add("User_NationalityType", list3);

            ct = "User_PoliticsStatusType".PlugGet<CodeTable<CodeDataModel>>();
            enumct = ct as EnumCodeTable;
            IEnumerable<CodeDataModel> list4 = enumct.FillAllData(ds);
            DictionData.Add("User_PoliticsStatusType", list4);

            ct = "User_CensusType".PlugGet<CodeTable<CodeDataModel>>();
            enumct = ct as EnumCodeTable;
            IEnumerable<CodeDataModel> list5 = enumct.FillAllData(ds);
            DictionData.Add("User_CensusType", list5);


            ct = "PositionCodeData".PlugGet<CodeTable<CodeDataModel>>();
            IEnumerable<CodeDataModel> list6 = enumct.FillAllData(ds);
            DictionData.Add("PositionCodeData", list6);
            return DictionData;
        }

        public List<RCUsersData> GetUsers(string UserIDs) {
            BFAtaw_UsersDetail bf = new BFAtaw_UsersDetail();
         var list=bf.GetUsers(UserIDs);
            return list;
        }
    }
}
