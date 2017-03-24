
using Ataw.RightCloud.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api
{
    public interface IAuth
    {
        ResponseData<CurrentUserData> logIn(string userName, string pass, string OrgCode);
        ResponseData logOut();
        ResponseData<CurrentUserData> getCurrentUserData();
        ResponseData changePassword(string oldPass, string newPass);
    }
}
