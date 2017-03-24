using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug.ColdeTable
{
    [CodePlug("ResouceIDSelector", BaseClass = typeof(CodeTable<CodeDataModel>),
 CreateDate = "2016-09-30", Author = "zhm", Description = "评论资源树数据源")]
    public class ResouceIDSelector : RCBaseSingleCodeTable
    {
        public ResouceIDSelector()
        {
            fValueField = "FID";
            fTableName = "Sns_Comment_Resouce";
            fTextField = "SnsCR_ResouceID";
            fRegName = "ResouceIDSelector";
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
