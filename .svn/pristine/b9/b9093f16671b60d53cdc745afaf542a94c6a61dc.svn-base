using Ataw.Framework.Core;
using Ataw.Framework.Web;
using Ataw.RightCloud.BF;
using Ataw.RightCloud.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ataw.RightCloud.Plug.ColdeTable
{
    [CodePlug("RightCloudGroupColdeTable", BaseClass = typeof(CodeTable<CodeDataModel>),
    CreateDate = "2016-3-16", Author = "sq", Description = "组织权限插件")]
    public class RightCloudGroupColdeTable : SimpleDataTreeCodeTable
    {

        public RightCloudGroupColdeTable()
        {
            //if (GlobalVariable.IsAtawSuperUser) {
            //    throw new AtawException("该用户是超级管理员，不可以进行分配",this);            
            //}
           // SimpleDataList = GetDataList();
        }

        public IEnumerable<TreeCodeTableModel> GetDataList()
        {
            RoleService role = new RoleService();
            String roleid = Param.Value<string>();

            string unitID = "";
            string strWhere = "";

            List<TreeCodeTableModel> result = new List<TreeCodeTableModel>();
            try
            {
                unitID = GlobalVariable.FControlUnitID;
                strWhere = "menuid in (select distinct RightID from view_UserRoleRight where FControlUnitID = '" + unitID + "' and userid='" + GlobalVariable.UserFID + "'  )";
                BFAtaw_Gruop bfataw_Group = new BFAtaw_Gruop();
                //string _groupButtonDList = null;
                var roleplug = "Role".PlugGet<Ataw.Right.Api.IRole>();
                DataTable rightList = roleplug.InitRightsTree(strWhere, unitID);
                var dt = rightList;
                if (dt == null)
                    return result;
                int s = dt.Rows.Count;

                foreach (DataRow row in dt.Rows)
                {
                    //var ispare = row["pid"].ToString() == "0" ? true : false;
                    var isLeaf = row["keytype"].ToString() == "3" ? true : false;
                    var id = row["id"].ToString();
                    var isParent = false;
                    if (!isLeaf)
                    {
                        var rows = dt.Select("pid='{0}'".AkFormat(id));
                        isParent = rows.Length > 0 ? true : false;
                    }
                    result.Add(new TreeCodeTableModel()
                    {
                        CODE_TEXT = row["name"].ToString(),
                        CODE_VALUE = id,
                        IsLeaf = isLeaf,
                        isParent = isParent,
                        ParentId = row["pid"].ToString()
                    });
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private IEnumerable<TreeCodeTableModel> fSimpleDataList;

        protected override IEnumerable<TreeCodeTableModel> SimpleDataList
        {
            get {
                if (this.fSimpleDataList == null) {
                    this.fSimpleDataList = this.GetDataList();
                }
                return this.fSimpleDataList;
            }
            set {
                this.fSimpleDataList = value;
            }

        }
    }
}
