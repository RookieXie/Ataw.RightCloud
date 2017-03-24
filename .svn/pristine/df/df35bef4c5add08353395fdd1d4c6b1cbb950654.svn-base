using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug
{

    [CodePlug("RCProductListCodeTable", BaseClass = typeof(CodeTable<CodeDataModel>),
CreateDate = "2016-09-23", Author = "xbg", Description = "显示产品列表")]
    public class RCProductListCodeTable : RCBaseSingleCodeTable
    {

        public RCProductListCodeTable()
        {
            fValueField = "FID";
            fTableName = "RC_Product";
            fTextField = "RCP_Name";
            fRegName = "RCProductListCodeTable";

        }

        private string fRegName;
        public override string RegName
        {
            get
            {
                return fRegName;
            }
            set
            {
                fRegName = value;
            }
        }

        private string fTableName;
        public override string TableName
        {
            get
            {
                return fTableName;
            }
            set
            {
                fTableName = value;
            }
        }

        private string fTextField;
        public override string TextField
        {
            get
            {
                return fTextField;
            }
            set
            {
                fTextField = value;
            }
        }

        private string fValueField;
        public override string ValueField
        {
            get
            {
                return fValueField;
            }
            set
            {
                fValueField = value;
            }
        }
    }
}
