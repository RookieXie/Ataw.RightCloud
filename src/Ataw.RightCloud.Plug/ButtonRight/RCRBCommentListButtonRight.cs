using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug.ButtonRight
{
    [CodePlug("RCRBCommentListButtonRight", BaseClass = typeof(IButtonRight),
  CreateDate = "2016-10-17", Author = "zhm", Description = "已删除评论Button权限插件")]
    public class RCRBCommentListButtonRight : IButtonRight
    {
        public string GetButtons(ObjectData data, IEnumerable<ObjectData> listData)
        {
            return "RemoveDelete|Detail|ReallyDelete";
        }
    }
}
