using Ataw.Framework.Core;
using Ataw.RightCloud.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug.Source
{
    [CodePlug("RCRoleDataSource", BaseClass = typeof(IListDataTable),
       CreateDate = "2016-09-27", Author = "xbg", Description = "RC角色数据源")]
    public class RCRoleDataSource : RCBaseDataSource
    {
        public override void InsertForeach(ObjectData data, DataRow row, string key)
        {
            RCRoleService roleService = new RCRoleService();
            var RCR_Code = "";
            if (data.MODEFY_COLUMNS.Contains("RCR_Code"))
            {
                RCR_Code = data.Row["RCR_Code"].Value<string>();
            }
            var RCR_Name = "";
            if (data.MODEFY_COLUMNS.Contains("RCR_Name"))
            {
                RCR_Name = data.Row["RCR_Name"].Value<string>();
            }
            var fControlUnitID = "1";
            if (data.MODEFY_COLUMNS.Contains("FControlUnitID"))
            {
                fControlUnitID = data.Row["FControlUnitID"].Value<string>();
            }
            if (roleService.CheckRoleCodeName(RCR_Code, RCR_Name, fControlUnitID))
            {

                base.InsertForeach(data, row, key);
            }
            else
            {
                throw new AtawException("同一组织下角色标识或者角色名称重复！", this);
            }
        }
        public override void UpdateForeach(ObjectData data, DataRow row, string key)
        {
            RCRoleService roleService = new RCRoleService();
            var RCR_Code = "";
            if (data.MODEFY_COLUMNS.Contains("RCR_Code"))
            {
                RCR_Code = data.Row["RCR_Code"].Value<string>();
            }
            var RCR_Name = "";
            if (data.MODEFY_COLUMNS.Contains("RCR_Name"))
            {
                RCR_Name = data.Row["RCR_Name"].Value<string>();
            }
            var fControlUnitID = "1";
            if (data.MODEFY_COLUMNS.Contains("FControlUnitID"))
            {
                fControlUnitID = data.Row["FControlUnitID"].Value<string>();
            }
            if (roleService.CheckRoleCodeName(RCR_Code, RCR_Name, fControlUnitID))
            {

                base.UpdateForeach(data, row, key);
            }
            else
            {
                throw new AtawException("同一组织下角色标识或者角色名称重复！", this);
            }
            
        }
    }
}
