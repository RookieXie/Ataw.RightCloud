using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug
{
    [CodePlug("RCCommentListButtonRight", BaseClass = typeof(IButtonRight),
CreateDate = "2016-10-11", Author = "zhm", Description = "评论资源Button权限插件")]
    public class RCCommentListButtonRight : IButtonRight
    {
        public string GetButtons(ObjectData data, IEnumerable<ObjectData> listData)
        {
            return "Update|Detail|Delete|ShowAllComment|OpenClose";
        }
    }
}
