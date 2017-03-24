
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.Framework.Core;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.DB;
using Ataw.RightCloud.Data;
using Ataw.RightCloud.Api.Data;

namespace Ataw.RightCloud.BF
{
    public class BFRC_Group_tree : RightCloudBaseBF
    {
        /// <summary>
        /// 得到单个信息
        /// </summary>
        /// <param name="fid">ID</param>
        /// <returns></returns>
        public RC_Group_tree GetGroupInfo(string fid)
        {
            DARC_Group_tree _da = new DARC_Group_tree(this.UnitOfData);
            RC_Group_tree _atawGroup = _da.Get(a => a.FID == fid);
            return _atawGroup;
        }


        public RCNewRightGroup GetRightGroup(string groupCode)
        {
            DARC_Group_tree _da = new DARC_Group_tree(this.UnitOfData);
            RC_Group_tree RC_Group = null;
            RC_Group = _da.Get(a => a.FID == groupCode);
            RCNewRightGroup model = new RCNewRightGroup();
            CopyGroup(RC_Group, model);

            return model;
        }


        public void CopyGroup(RC_Group_tree model, RCNewRightGroup groupmodel)
        {
            groupmodel.OrgName = model.RCG_Name;
            groupmodel.FID = model.FID;
        }
        //检查重复
        public string checkname(string name,string pid)
        {
            DARC_Group_tree da = new DARC_Group_tree(this.UnitOfData);
            var Name =da.QueryDefault(a => a.RCG_Name == name && a.PID == pid).FirstOrDefault();

            if (Name != null)
            {
                return "Y";
            }
            else {
                return "N";
            }
        }
        //添加
        public string AddGroup(RCGroupTreeData group)
        {
            DARC_Group_tree da = new DARC_Group_tree(this.UnitOfData);
            var Name = da.QueryDefault(x => x.RCG_Name == group.RCG_Name).FirstOrDefault();
            var Code = da.QueryDefault(x => x.RCG_Code == group.RCG_Code).FirstOrDefault();
            var PFID = da.QueryDefault(a => a.FID == group.PID).FirstOrDefault();    
            PFID.IS_PARENT = true;
            DARC_Group_tree _da = new DARC_Group_tree(UnitOfData);
            RC_Group_tree model = new RC_Group_tree();
            if (Name != null)
            {
                return "1";
            }
            else if (Code != null)
            {
                return "2";
            }
            else
            {
                model.FID = da.GetUniId();
                model.RCG_Code = group.RCG_Code;
                model.RCG_Name = group.RCG_Name;
                model.PID = string.IsNullOrEmpty(group.PID)? "0":group.PID;
                model.IS_PARENT = false;
                _da.Add(model);
                return "0";
            }           
        }
        public string getUFid()
        {
            DARC_Group_tree _da = new DARC_Group_tree(this.UnitOfData);
            return _da.GetUniId();

        }

        public bool CheckHasChild(string p)
        {
            DARC_Group_tree _da = new DARC_Group_tree(this.UnitOfData);
            var list = _da.QueryMany(a => (a.PID == p)).ToList();
            if (list.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //更新组织机构
        public string GroupUpdate(string FID, string RCG_Code, string RCG_Name)
        {
            DARC_Group_tree da = new DARC_Group_tree(this.UnitOfData);
            var model = da.QueryDefault(a => a.FID == FID).FirstOrDefault();
            var Name = da.QueryDefault(x => x.RCG_Name ==RCG_Name).FirstOrDefault();
            var Code = da.QueryDefault(x => x.RCG_Code ==RCG_Code).FirstOrDefault();
            if (model == null)
            {
                return "1";
            }
            else if (Name != null)
            {
                return "2";
            }
            else
            {
                model.RCG_Name = RCG_Name;
                da.Update(model);
                return "0";
            }

        }
        public string GetFControlUnitIDByFID(string FID)
        {
            DARC_Group_tree _da = new DARC_Group_tree(this.UnitOfData);
            var roleModel = _da.Get(a => a.FID == FID);
            if (roleModel != null)
            {
                return roleModel.FID;
            }
            else
            {
                return "";
            }
        }
        public RC_Group_tree GerGroupByID(string FID)
        {
            DARC_Group_tree _da = new DARC_Group_tree(this.UnitOfData);
            var model = _da.QueryDefault(a => a.FID == FID).FirstOrDefault();
            return model;
        }
    }
}

