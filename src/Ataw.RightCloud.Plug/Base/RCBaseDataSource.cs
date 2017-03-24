using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ataw.Framework.Core;
using Ataw.Framework.Web;

namespace Ataw.RightCloud.Plug
{
    public abstract class RCBaseDataSource : BaseDataTableSource
    {
        private readonly bool fNeedFilterByGroup;
        protected RCBaseDataSource(bool needFilterByGroup = true)
        {
            fNeedFilterByGroup = needFilterByGroup;
        }
        protected override string AdditionalConditionSql(string sql)
        {
            string _sql = base.AdditionalConditionSql(sql);
            if (GlobalVariable.FControlUnitID == "1" || !fNeedFilterByGroup)// && GlobalVariable.UserFID == "ataws")
            {
                return "{0} AND ((ISDELETE IS NULL) OR (ISDELETE = 0))".AkFormat(_sql);
            }

            //return "{0} AND ((ISDELETE IS NULL) OR (ISDELETE = 0))".AkFormat(_sql);
            return "{0} AND FControlUnitID='{1}' AND ((ISDELETE IS NULL) OR (ISDELETE = 0))".AkFormat(_sql, GlobalVariable.FControlUnitID);
        }


        protected override string CreateInsertSql(ObjectData od, List<SqlParameter> sqlList, string key)
        {
            od.SetDataRowValue("CREATE_ID", GlobalVariable.UserId.Value<string>());
            od.SetDataRowValue("CREATE_TIME", DateTime.Now.Value<string>());
            od.SetDataRowValue("UPDATE_ID", GlobalVariable.UserId.Value<string>());
            od.SetDataRowValue("UPDATE_TIME", DateTime.Now.Value<string>());
            //   od.SetDataRowValue("ISDELETE",false);
            if (!od.MODEFY_COLUMNS.Contains("FControlUnitID"))
            {
                od.SetDataRowValue("FControlUnitID", GetFControlId(od));
            }
            //od.SetDataRowValue("FControlUnitID", GlobalVariable.FControlUnitID);
            return base.CreateInsertSql(od, sqlList, key);
        }

        protected virtual string GetFControlId(ObjectData od)
        {
            return GlobalVariable.FControlUnitID;
        }

        public override void UpdateForeach(ObjectData data, System.Data.DataRow row, string key)
        {
            data.SetDataRowValue("UPDATE_ID", GlobalVariable.UserId.Value<string>());
            data.SetDataRowValue("UPDATE_TIME", DateTime.Now.Value<string>());
            base.UpdateForeach(data, row, key);
        }

        protected override string CreateDeleteSql(string key, List<SqlParameter> sqlList)
        {

            // return base.CreateDeleteSql(key, sqlList);
            string sql = " UPDATE   {0} SET  ISDELETE  = 1,UPDATE_ID={1},UPDATE_TIME=GETDATE() WHERE {1}=@key AND 1=1 ";

            sqlList.Add(new SqlParameter("@key", key));
            sqlList.Add(new SqlParameter("@UPDATE_ID", GlobalVariable.UserId.Value<string>()));
            //sql = string.Format(ObjectUtil.SysCulture, sql, RegName, PrimaryKey, key);
            //sql = string.Format(ObjectUtil.SysCulture, sql, RegName, PrimaryKey);

            //return sql;
            return sql.AkFormat(RegName, PrimaryKey);
        }


    }
}
