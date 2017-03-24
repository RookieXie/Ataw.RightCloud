using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.BF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Service
{
   public  class RCUserRoleService
    {
       public List<RCUserRoleData> GetUserRole()
        {
            BFAtaw_User_Roles bf = new BFAtaw_User_Roles();
            var UserRoleData = bf.GetUserRoleAll();
            return UserRoleData;
        }
    }
}
