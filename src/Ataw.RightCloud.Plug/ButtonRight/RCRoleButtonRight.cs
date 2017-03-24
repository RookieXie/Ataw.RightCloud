using Ataw.Framework.Core;
using System;
using Ataw.Framework.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug
{
    [CodePlug("RCRoleButtonRight", BaseClass = typeof(IButtonRight),
       CreateDate = "2016-09-22", Author = "xbg", Description = "角色管理Button权限插件")]
    public class RCRoleButtonRight : IButtonRight
    {
        public string GetButtons(ObjectData data, IEnumerable<ObjectData> listData)
        {
            return "Update|Detail|Delete|GrantRoleRights";
        }
    }
}
