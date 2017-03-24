using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api.Data
{
    public class RCRoleMenuSubmit
    {
        public List<MenuRoleData> MenuRoleDataList { get; set; }
        public GroupExtData GroupData { get; set; }
    }
    public class  MenuRoleData
    {
        public string Operation { get; set; }

        public List<RoleExtData> RoleDataList { get; set; }

        public List<MenuExtData> MenuDataList { get; set; }      

        public List<RightGrantData> GrantDataList { get; set; }
    }
}
