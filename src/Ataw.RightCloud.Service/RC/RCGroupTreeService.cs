using Ataw.Framework.Core;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.BF;
using Ataw.RightCloud.Data;
using Ataw.RightCloud.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Service
{
    public class RCGroupTreeService
    {

        public RCNewRightGroup getOrgCode(string code)
        {
            BFRC_Group_tree bf = new BFRC_Group_tree();
            var model = bf.GetGroupInfo(code);

            RCNewRightGroup rightmodel = new RCNewRightGroup();
            rightmodel.FID = model.FID;
            rightmodel.OrgName = model.RCG_Name;
            rightmodel.OrgCode = model.RCG_Code;
            return rightmodel;
        }
        //添加
        public string newgroup(RCGroupTreeData groups)
        {
            var db =new  RightCloudDBContext();
            var bf = new BFRC_Group_tree();
            bf.SetUnitOfData(db);
            var  fid = bf.AddGroup(groups);
            db.Submit();
            return fid;
        }
        public bool CheckHasChild(string menuID)
        {
            BFRC_Group_tree bf = new BFRC_Group_tree();
            var res = bf.CheckHasChild(menuID);
            return res;
        }
        //更新组织机构
        public string GroupUpdate(string FID, string groupName, string GroupCode)
        {
            BFRC_Group_tree bfGroup = new BFRC_Group_tree();
            try
            {
               string a=bfGroup.GroupUpdate(FID, GroupCode, groupName);
                if (a == "1")
                {
                    return "节点不存在";
                }
                else if (a=="2")
                {
                    return "名称已存在";
                }
                else
                {               
                bfGroup.Submit();
                return "更改名称成功";
                }
            }
            catch (Exception)
            {
                return "更改名称失败";
                throw;
            }
        }
        public DataTable InitGroupRightsTree(string FID)
        {
            //ResponseData<DataTable> data = new ResponseData<DataTable>();
            string unitID = "";
            string strWhere = "";
            DataTable dt = new DataTable();
            try
            {
                if (!FID.IsEmpty())
                {
                    var bf = new BFRC_Group_tree();
                    unitID = bf.GetFControlUnitIDByFID(FID);
                    strWhere = " FControlUnitID ='{0}' ".AkFormat(unitID);
                }

                var rightbf = new BFRC_Menu_tree();
                dt = rightbf.GetGroupMenusTree1(unitID, strWhere);

            }
            catch (Exception)
            {
                // data.Content = "error";
                throw;
            }
            //data.Time = DateTime.Now;
            return dt;
        }
        public RC_Group_tree GetGroupByFID(string FID)
        {
            BFRC_Group_tree bf = new BFRC_Group_tree();
            var model = bf.GerGroupByID(FID);
            return model;
        }
    }
}
