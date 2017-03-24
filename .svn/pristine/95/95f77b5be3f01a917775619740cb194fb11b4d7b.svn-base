using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Ataw.RightCloud.Service;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.Plug.Source
{
    
    [CodePlug("RCMenuTreeDataSource", BaseClass = typeof(IListDataTable),
       CreateDate = "2016-09-27", Author = "xbg", Description = "RC菜单数据源")]
    public class RCMenuTreeDataSource : TreeDataTableSource
    {
      
        public override void InsertForeach(ObjectData data, DataRow row, string key)
        {
            var pid = "0";
            if (data.MODEFY_COLUMNS.Contains("PID"))
            {
                pid = data.Row["PID"].Value<string>();
            }

            var name = data.Row["RCM_Name"].Value<string>();

            RCMenuTreeService menuService = new RCMenuTreeService();
            if (menuService.CheckMenuName(name, pid))
            {

                base.InsertForeach(data, row, key);
            }
            else
            {
                throw new AtawException("同一层级下菜单名称不能重复！", this);
            }
        }
        public override void UpdateForeach(ObjectData data, DataRow row, string key)
        {
            RCMenuTreeService menuService = new RCMenuTreeService();
            RC_Menu_tree model = menuService.GetMenuByFID(key);
            var name = data.MODEFY_COLUMNS.Contains("RCM_Name") ? data.Row["RCM_Name"].Value<string>() : model.RCM_Name;
            var pid = data.MODEFY_COLUMNS.Contains("PID") ? data.Row["PID"].Value<string>() : model.PID;

            if (menuService.CheckMenuName(name, pid))
            {
                base.UpdateForeach(data, row, key);
            }
            else
            {
                throw new AtawException("同一层级下菜单名称不能重复！", this);
            }
        }
    }
}
