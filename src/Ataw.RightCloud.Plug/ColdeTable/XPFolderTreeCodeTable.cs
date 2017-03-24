using Ataw.Framework.Core;
using Ataw.Framework.Core.Instance;
using Ataw.Framework.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug.ColdeTable
{
    [CodePlug("XPFolderTreeCodeTable", BaseClass = typeof(CodeTable<CodeDataModel>),
    CreateDate = "2016-10-24", Author = "pz", Description = "组织机构树数据源")]
    public class XPFolderTreeCodeTable : DbTreeCodeTable
    {
        public override string TableName
        {
            get { return "XP_Folder_Tree"; }
        }
        public override bool OnlyLeafCheckbox
        {
            get { return false; }
        }

        public override string CodeValueField
        {
            get { return "FID"; }
        }

        public override string CodeTextField
        {
            get { return "F_Name"; }
        }

        public override string ParentIdField
        {
            get { return "PID"; }
        }

        public override string IsParentField
        {
            get { return "IS_PARENT"; }
        }
        protected override string where()
        {
            string sql = base.where();
            if (sql.IsAkEmpty()) {
                sql = "1=1";
            }
            if (GlobalVariable.FControlUnitID == "1") {
                return ("   {0} AND ((ISDELETE IS NULL) OR (ISDELETE = 0))").AkFormat(sql ,AtawAppContext.Current.UserId );
            }
            else
            return string.Format(ObjectUtil.SysCulture, "{0} AND FID in ('{1}') AND ((ISDELETE IS NULL) OR (ISDELETE = 0))", sql, GlobalVariable.FControlUnitID);
        }

        public override TreeCodeTableModel GetAllTree()
        {
            return base.GetAllTree();
        }

        
    }
}
