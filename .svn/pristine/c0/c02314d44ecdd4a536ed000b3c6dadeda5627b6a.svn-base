using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug.ButtonRight
{

    [CodePlug("PL_PageLockButtonRight", BaseClass = typeof(IButtonRight),
          CreateDate = "2016-10-24", Author = "zhm", Description = "页面锁定Button权限插件")]
    public class PL_PageLockButtonRight : IButtonRight
    {
        public string GetButtons(ObjectData data, IEnumerable<ObjectData> listData)
        {
            return "Update|Detail|Delete|Insert|OpenCloseLock";
        }
    }
}
