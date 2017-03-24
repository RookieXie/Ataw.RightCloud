using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug.ButtonRight
{
    [CodePlug("RCProductButtonRight", BaseClass = typeof(IButtonRight),
      CreateDate = "2016-09-23", Author = "xbg", Description = "产品管理Button权限插件")]
    public class RCProductButtonRight : IButtonRight
    {
        public string GetButtons(ObjectData data, IEnumerable<ObjectData> listData)
        {
            return "Update|Detail|Delete";
        }
    }
}
