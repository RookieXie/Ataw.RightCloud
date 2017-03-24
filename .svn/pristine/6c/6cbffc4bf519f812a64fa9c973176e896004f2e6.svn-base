using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug.ColdeTable
{
    [CodePlug("RCDepartmentCodeTable", BaseClass = typeof(CodeTable<CodeDataModel>),
     CreateDate = "2016-11-17", Author = "zjj", Description = "部门树数据源")]
    public class RCDepartmentCodeTable : RCBaseDbTreeCodeTable
    {
        /// <summary>
        /// 表名
        /// </summary>
        public override string TableName
        {
            get { return "MRP_Department"; }
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
            get { return "FName"; }
        }

        public override string ParentIdField
        {
            get { return "FParentFID"; }
        }

        public override string IsParentField
        {
            get { return "IsParent"; }
        }

        //protected override string where()
        //{
        //    string sql = base.where();
        //    return string.Format(ObjectUtil.SysCulture, "{0} AND FID in ('{1}') AND ((ISDELETE IS NULL) OR (ISDELETE = 0))", sql, GlobalVariable.FControlUnitID);
        //}
    }
}
