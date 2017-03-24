using Ataw.Framework.Core;
using Ataw.RightCloud.BF;
using Ataw.RightCloud.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug
{
    [CodePlug("RoleTreeCodeTable", BaseClass = typeof(CodeTable<CodeDataModel>),
     CreateDate = "2016-3-16", Author = "sq", Description = "角色树形插件数据源")]
    public class RoleTreeColdeTable : SimpleDataTreeCodeTable
    {
        public RoleTreeColdeTable()
        {
           // SimpleDataList = GetDataList();
        }

        private IEnumerable<TreeCodeTableModel> fSimpleDataList;

        public IEnumerable<TreeCodeTableModel> GetDataList()
        {
            
            RoleService role = new RoleService();
            String roleids = Param.Value<string>();
            string[] roleid;
            string unitID = "";
            string strWhere = "";

            List<TreeCodeTableModel> result = new List<TreeCodeTableModel>();
            try
            {
                roleid = roleids.Split(',');
                for (int i = 0; i < roleid.Length; i++)
                {
                    if (!roleid[i].IsEmpty())
                    {
                        var bf = new BFAtaw_Roles();
                        unitID = bf.GetFControlUnitIDByRoleID(roleid[i]);//获取权限组织
                        strWhere = "  FControlUnitID ='{0}' ".AkFormat(unitID);//组织权限
                    }
                    var rightbf = new BFAtaw_Menus();
                    var dbset = rightbf.GetGroupMenusTree1(unitID, strWhere);
                    var dt = dbset.Tables[0];
                    if (dt == null)
                        return result;
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
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override IEnumerable<TreeCodeTableModel> SimpleDataList
        {
            get {
                if (fSimpleDataList == null) {
                    fSimpleDataList = this.GetDataList();
                }
                return fSimpleDataList;
            }
            set {
                this.fSimpleDataList = value;
            }
        }
    }
}
