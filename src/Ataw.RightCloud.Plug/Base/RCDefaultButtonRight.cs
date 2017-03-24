using Ataw.Framework.Core;

namespace Ataw.RightCloud.Plug
{
    [CodePlug("RCDefaultButtonRight", BaseClass = typeof(IButtonRight),
       CreateDate = "2015-12-02", Author = "cl", Description = "Button权限插件")]
    public class RCDefaultButtonRight : RCBaseButtonRight
    {
        //public override string GetButtons(ObjectData data, IEnumerable<ObjectData> listData)
        //{
        //    return "Update|Detail|Delete";
        //}
    }
}
