using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.BF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.RightCloud.Core;
using Ataw.Framework.Core;
using System.Web;
using System.IO;

namespace Ataw.RightCloud.Service
{
    public class AuthService : IAuth
    {
        public ResponseData<CurrentUserData> logIn(string userName, string pass, string orgCode)
        {
            AtawDebug.AssertArgumentNullOrEmpty(userName,"登录名不能为空",this);
            AtawDebug.AssertArgumentNullOrEmpty(pass, "密码不能为空", this);
            AtawDebug.AssertArgumentNullOrEmpty(orgCode, "组织机构不能为空", this);
            string _res = "";
            BFAtaw_Users bf = new BFAtaw_Users();
            var  _user =  bf.LoginUser(userName,pass,orgCode,ref _res );
            CurrentUserData userdata = new CurrentUserData();
            if(_res == "ok"){
                     userdata.FID = _user.UserID ;
                     userdata.LoginName = _user.UserName ;
                     userdata.NickName = _user.NickName ;
                     userdata.FControlUnitID = _user.FControlUnitID;
                     userdata.FControlUnitName = "GroupCodeTable".GetText(_user.FControlUnitID);  
                   // userdata.f
                     //userdata.
            }


            ResponseData<CurrentUserData> _data = new ResponseData<CurrentUserData>();
            _data.Content = _res;
            _data.Data = userdata;
         //   _data.Data = _res;
            return _data;
        }

        public ResponseData logOut()
        {
            return new ResponseData();
        }

        public ResponseData<CurrentUserData> getCurrentUserData()
        {
            throw new NotImplementedException();
        }

        public ResponseData changePassword(string oldPass, string newPass)
        {
            ResponseData Data = new ResponseData();
            BFAtaw_Users bf = new BFAtaw_Users();

            string _res = "";
             Data.Data = bf.ModifyPassword(oldPass, newPass,ref _res);
            Data.Content = _res;
            return Data;
        }
    }
}
