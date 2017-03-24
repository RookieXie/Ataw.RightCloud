using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Ataw.RightCloud.Service;

namespace Ataw.RightCloud.Plug.Source
{
    [CodePlug("RCAdminCommentDataSource", BaseClass = typeof(IListDataTable),
CreateDate = "2016-10-10", Author = "zhm", Description = "RC评论组件信息数据源")]
    public class RCAdminCommentDataSource : RCBaseDataSource
    {
        public override void AppendTo(DataSet ds)
        {
            DataTable dt = DataSet.Tables[RegName];

            dt.Columns.Add("SnsCR_RepNum");

            foreach (DataRow row in dt.Rows)
            {
                CommentService service = new CommentService();
                string num = service.GetRepNum(row["FID"].ToString(),"Admin");
                if (num != null)
                {
                    row["SnsCR_RepNum"] = num;
                }

            }
            base.AppendTo(ds);
        }
    }
}
