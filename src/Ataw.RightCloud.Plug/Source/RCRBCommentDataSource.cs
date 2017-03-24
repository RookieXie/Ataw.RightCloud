using Ataw.Framework.Core;
using Ataw.Framework.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug.Source
{
    [CodePlug("RCRBCommentDataSource", BaseClass = typeof(IListDataTable),
  CreateDate = "2016-10-17", Author = "zhm", Description = "RC已删除评论数据源")]
    public class RCRBCommentDataSource : RCBaseDataSource
    {
        protected override string AdditionalConditionSql(string sql)
        {
            if (GlobalVariable.FControlUnitID == "1")
            {
                return " and (ISDELETE = 1)";
            }

            return "and FControlUnitID='{0}' AND (ISDELETE = 1)".AkFormat(GlobalVariable.FControlUnitID); 
        }
    }
}
