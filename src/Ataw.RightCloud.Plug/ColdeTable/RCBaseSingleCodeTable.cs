using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug
{
   
    public abstract class RCBaseSingleCodeTable : SingleCodeTable<CodeDataModel>
    {
        protected virtual string SetWhereSql(string whereSql)
        {

            if (whereSql.IsEmpty()) whereSql = " 1 =1 ";

            return "{0} AND   ((ISDELETE IS NULL) OR (ISDELETE = 0))".AkFormat(whereSql);
        }

        private string fWhere;
        public override string Where
        {
            get
            {
                if (fWhere.IsEmpty())
                {
                    string sql = base.Where;
                    string res = SetWhereSql(sql);
                    //  return res;
                    fWhere = res;
                    return fWhere;
                }
                else
                {

                    return fWhere;
                }
            }
            set
            {
                fWhere = value;
            }
        }
    }
}
