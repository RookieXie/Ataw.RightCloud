using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Ataw.RightCloud.BF.RC.Collection;

namespace Ataw.RightCloud.Plug.Source
{
    [CodePlug("XPFolderTreeDataSource", BaseClass = typeof(IListDataTable),
       CreateDate = "2016-10-24", Author = "pz", Description = "RC组织机构数据源")]
    public class XPFolderTreeDataSource : RCBaseDataTreeSource
    {
        public override string TableName
        {
            get { return "XP_Folder_Tree"; }
        }
        public XPFolderTreeDataSource()
            : base()
        {
        }
        public override string TreeCodeReganme
        {
            get { return "XPFolderTreeCodeTable"; }
        }
        public override void InsertForeach(ObjectData data, DataRow row, string key)
        {
            var pid = "0";
            if (data.MODEFY_COLUMNS.Contains("PID"))
            {
                pid = data.Row["PID"].Value<string>();
            }
            var name = data.Row["F_Name"].Value<string>();
            BFXP_Folder_Tree bf = new BFXP_Folder_Tree();
            var Name = bf.Checkname(name, pid);
            if (Name == "Y")
            {
                throw new AtawException("同一层级下文件夹名称不能重复！", this);
            }
            //登录人
            if (!row.Table.Columns.Contains("F_UserID"))
            {
                data.SetDataRowValue("F_UserID", AtawAppContext.Current.UserName);
            }
            base.InsertForeach(data, row, key);
        }
    }
}
