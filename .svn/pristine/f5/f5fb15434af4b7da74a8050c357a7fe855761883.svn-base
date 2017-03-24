using Ataw.Framework.Core;
using Ataw.Framework.Web;
using Ataw.RightCloud.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug
{
    public abstract class RCBaseDataTreeSource : TreeDataTableSource
    {
        public override string ParentFieldName
        {
            get
            {
                return "PID";
            }
        }
        public override string IsParentFieldName
        {
            get
            {
                return "IS_PARENT";
            }
        }
        public override string TextFieldName
        {
            get
            {
                return "FID";
            }
        }

        public virtual string TableName
        {
            get { return this.RegName; }
        }
        public abstract string TreeCodeReganme
        {
            get;
        }

        public string Pid
        {
            set
            {
                CookieUtil.Add(TableName + "_PID", value);
            }
        }
        public string PidText
        {
            set
            {
                CookieUtil.Add(TableName + "_PidText", value);
            }
        }
        protected override string AdditionalConditionSql(string sql)
        {
            DataSet ds = this.PostDataSet;
            if (ds != null)
            {
                var _table = ds.Tables[TableName + "_Search"];
                Pid = "";
                PidText = "";
                if (_table != null && _table.Rows.Count > 0 && _table.Columns.Contains("FID"))
                {
                    string _pid = _table.Rows[0]["FID"].ToString();
                    PidText = TreeCodeReganme.GetTextByCD(_pid);
                    Pid = _pid;
                }
            }
            string _sql = base.AdditionalConditionSql(sql);
            return "{0} AND ((ISDELETE IS NULL) OR (ISDELETE = 0))".AkFormat(_sql);
            //if (GlobalVariable.FControlUnitID == "1")// && GlobalVariable.UserFID == "ataws")
            //{
            //    return "{0} AND ((ISDELETE IS NULL) OR (ISDELETE = 0))".AkFormat(_sql);
            //}
            //return "{0} AND FControlUnitID='{1}' AND ((ISDELETE IS NULL) OR (ISDELETE = 0))".AkFormat(_sql, GlobalVariable.FControlUnitID);
        }


        protected override string CreateInsertSql(ObjectData od, List<SqlParameter> sqlList, string key)
        {
            od.SetDataRowValue("CREATE_ID", GlobalVariable.UserId.Value<string>());
            od.SetDataRowValue("CREATE_TIME", DateTime.Now.Value<string>());
            od.SetDataRowValue("UPDATE_ID", GlobalVariable.UserId.Value<string>());
            od.SetDataRowValue("UPDATE_TIME", DateTime.Now.Value<string>());
            //   od.SetDataRowValue("ISDELETE",false);
            od.SetDataRowValue("FControlUnitID", GetFControlId(od));
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
            //要解除上下级关系
            string sql = " UPDATE   {0} SET   " + ParentFieldName + " = null,    ISDELETE  = 1,UPDATE_ID={1},UPDATE_TIME=GETDATE() WHERE {1}=@key AND 1=1 ";

            sqlList.Add(new SqlParameter("@key", key));
            sqlList.Add(new SqlParameter("@UPDATE_ID", GlobalVariable.UserId.Value<string>()));
            return sql.AkFormat(RegName, PrimaryKey);
        }

    }
}
