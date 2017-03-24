using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Ataw.RightCloud.BF;
using Ataw.RightCloud.Service;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.Plug
{
    [CodePlug("RCGroupTreeDataSource", BaseClass = typeof(IListDataTable),
       CreateDate = "2016-09-27", Author = "xbg", Description = "RC组织机构数据源")]
    public class RCGroupTreeDataSource : RCBaseDataTreeSource
    {

        public override string TableName
        {
            get { return "RC_Group_tree"; }
        }
        public RCGroupTreeDataSource()
            : base()
        {
        }
        public override string TreeCodeReganme
        {
            get { return "RCGroupCodeTable"; }
        }

        public override void InsertForeach(ObjectData data, DataRow row, string key)
        {
            var pid = "0";
            if (data.MODEFY_COLUMNS.Contains("PID"))
            {
                pid = data.Row["PID"].Value<string>();
            }
            var RCG_Code = "";
            if (data.MODEFY_COLUMNS.Contains("RCG_Code"))
            {
                RCG_Code = data.Row["RCG_Code"].Value<string>();
            }
            var name = data.Row["RCG_Name"].Value<string>();

            string strSql = "SELECT Count(*) FROM RC_Group_tree WHERE RCG_Code=@RCG_Code ";
            SqlParameter para = new SqlParameter("@RCG_Code", RCG_Code);
            int count = DbContext.QueryObject(strSql, para).Value<int>();
            BFRC_Group_tree bf = new BFRC_Group_tree();
            var Name = bf.checkname(name, pid);
            if (count > 0)
            {
                throw new AtawException("机构标识已经存在", this);
            }
            else if (Name == "Y")
            {
                throw new AtawException("同一层级下类别名称不能重复！", this);
            }
            else
            {
                base.InsertForeach(data, row, key);
            }
        }
        public override void UpdateForeach(ObjectData data, DataRow row, string key)
        {
            BFRC_Group_tree bf = new BFRC_Group_tree();
            RCGroupTreeService menuService = new RCGroupTreeService();
            RC_Group_tree model = menuService.GetGroupByFID(key);
            var name = data.MODEFY_COLUMNS.Contains("RCG_Name") ? data.Row["RCG_Name"].Value<string>() : model.RCG_Name;
            var pid = data.MODEFY_COLUMNS.Contains("PID") ? data.Row["PID"].Value<string>() : model.PID;

            if (bf.checkname(name, pid) == "N")
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
