using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug.Source
{
    [CodePlug("SnsCommentDataSource", BaseClass = typeof(IListDataTable),
      CreateDate = "2016-09-27", Author = "sq", Description = "RC角色数据源")]
    public class SnsCommentDataSource : RCBaseDataSource
    {
        protected override string AdditionalConditionSql(string sql)
        {
            if (AtawAppContext.Current.UserId == "ataws")
            {
                return base.AdditionalConditionSql(sql);
            }
            else
            {
                string where = "";
                where += " AND SnsC_User= '" + AtawAppContext.Current.UserId + "'";
                return where;
            }
        }
    }
}
