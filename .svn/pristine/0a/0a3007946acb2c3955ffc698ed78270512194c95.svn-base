using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Ataw.RightCloud.Plug.Source
{
    [CodePlug("XPWeSiteDataSource", BaseClass = typeof(IListDataTable),
   CreateDate = "2016-10-25", Author = "pz", Description = "页面收藏数据源")]
    public class XPWeSiteDataSource : RCBaseDataSource
    {
        public override void InsertForeach(ObjectData data, DataRow row, string key)
        {
            //登录人
            if (!row.Table.Columns.Contains("Ws_UserID"))
            {
                data.SetDataRowValue("Ws_UserID", AtawAppContext.Current.UserName);
            }
            base.InsertForeach(data, row, key);
        }
    }
}
