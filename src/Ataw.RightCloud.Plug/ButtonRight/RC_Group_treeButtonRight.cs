using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug
{
    [CodePlug("RC_Group_treeButtonRight", BaseClass = typeof(IButtonRight),
          CreateDate = "2016-09-22", Author = "zjj", Description = "组织机构菜单Button权限插件")]
   public class RC_Group_treeButtonRight : IButtonRight
    {
        public string GetButtons(ObjectData data, IEnumerable<ObjectData> listData)
        {
            return "Update|Detail|Delete|RCGrantGroupRights|ViewGroupRights";
        }
    }
}
