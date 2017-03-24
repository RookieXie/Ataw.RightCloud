using Ataw.Framework.Core;
using Ataw.Framework.Core.Instance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug
{
    [CodePlug("RCMenuTreeCodeTable", BaseClass = typeof(CodeTable<CodeDataModel>),
    CreateDate = "2016-09-12", Author = "xbg", Description = "组织机构树数据源")]
    public class RCMenuTreeCodeTable : DbTreeCodeTable
    {
        /// <summary>
        /// 表名
        /// </summary>
        public override string TableName
        {
            get { return "RC_Menu_tree"; }
        }
        /// <summary>
        /// 是否单选
        /// </summary>
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
            get { return "RCM_Name"; }
        }

        public override string ParentIdField
        {
            get { return "PID"; }
        }

        public override string IsParentField
        {
            get { return "IS_PARENT"; }
        }

        //protected override string where()
        //{
        //    string sql = base.where();
        //    return string.Format(ObjectUtil.SysCulture, "{0} AND FID in ('{1}') AND ((ISDELETE IS NULL) OR (ISDELETE = 0))", sql, GlobalVariable.FControlUnitID);
        //}
    }
}
