using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ataw.Framework.Core.Instance;
using Ataw.Framework.Core;

namespace Ataw.RightCloud.Plug
{
    public abstract class RCBaseDbTreeCodeTable : DbTreeCodeTable
    {
        protected override string where()
        {
            string sql = base.where();
            
            string res = "{0} AND   ((ISDELETE IS NULL) OR (ISDELETE = 0))".AkFormat(sql);
            //  return res;
            return sql;
        }
    }
}
