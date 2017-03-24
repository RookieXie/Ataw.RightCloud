using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug.ButtonRight
{
 
   [CodePlug("PM_PageMarkButtonRight", BaseClass = typeof(IButtonRight),
         CreateDate = "2016-10-24", Author = "wjx", Description = "页面快捷Button权限插件")]
   public class PM_PageMarkButtonRight : IButtonRight
   {
       public string GetButtons(ObjectData data, IEnumerable<ObjectData> listData)
       {
           return "Update|Detail|Delete|Insert|GoToUrl";
       }
   }
}
