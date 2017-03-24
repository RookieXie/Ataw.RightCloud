
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.Framework.Core;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.DB;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Data;
using Ataw.RightCloud.Api.Data;

namespace Ataw.RightCloud.BF
{
    public class BFRC_Menu_Group : RightCloudBaseBF
    {
        public List<RCRightMenu_Org> GetModelbyGroup(string Group)
        {
            if (Group.IsAkEmpty())
            {
                Group = "1";
            }

            DARC_Menu_Group daMenuGroup = new DARC_Menu_Group(this.UnitOfData);

            var list = daMenuGroup.QueryDefault(a => a.RCMG_FControlUnitID == Group).ToList();
            List<RCRightMenu_Org> List = new List<RCRightMenu_Org>();
            foreach (var item in list)
            {
                RCRightMenu_Org model = new RCRightMenu_Org();
                CopyModel(item, model);
                List.Add(model);
            }

            return List;
        }

        public void CopyModel(RC_Menu_Group model, RCRightMenu_Org Rightmodel)
        {
            Rightmodel.Menu = model.RCMG_MenuFID;
            Rightmodel.Org = model.RCMG_FControlUnitID;
        }
        public List<RC_Menu_Group> GetGroupMenuList(string FID)
        {
            DARC_Menu_Group _da = new DARC_Menu_Group(this.UnitOfData);
            var list = _da.QueryDefault(a => a.RCMG_FControlUnitID == FID).ToList();
            return list;
        }
        /// <summary>
        /// 删除角色关联菜单权限
        /// </summary>
        /// <param name="FID"></param>
        public void DeleteByFID(string FID)
        {
            DARC_Menu_Group _da = new DARC_Menu_Group(this.UnitOfData);
            _da.Delete(a => a.FID == FID);
        }
        public void InsertRoleMenu(RC_Menu_Group model)
        {
            DARC_Menu_Group _da = new DARC_Menu_Group(this.UnitOfData);
            model.FID = _da.GetUniId();
            _da.Add(model);
        }
        //添加角色菜单权限
        public void AddMenuGroup(string fControlUnitID,string menuID)
        {
            DARC_Menu_Group _da = new DARC_Menu_Group(this.UnitOfData);
            var fid=_da.GetUniId();
            RC_Menu_Group model = new RC_Menu_Group();
            model.FID = fid;
            model.RCMG_FControlUnitID = fControlUnitID;
            model.RCMG_MenuFID = menuID;
            _da.Add(model);
        }

        //删除角色菜单权限
        public void DeleteMenuGroup(string fControlUnitID,string MenuID)
        {
            DARC_Menu_Group _da = new DARC_Menu_Group(this.UnitOfData);
            _da.Delete(a => a.RCMG_FControlUnitID == fControlUnitID && a.RCMG_MenuFID == MenuID);
        }
        //根据菜单id删除角色菜单权限
        public void DelMenuGroupByMenuID(string menuID)
        {
            DARC_Menu_Group _da = new DARC_Menu_Group(this.UnitOfData);
            _da.Delete(a => a.RCMG_MenuFID == menuID);
        }
    }
}

