
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
    public class BFAtaw_Menus_Group : RightCloudBaseBF
    {
        public List<Api.Data.RightMenu_Org> GetModelbyGroup(string Group)
        {
            if (Group.IsAkEmpty())
            {
                Group = "1";
            }

            DAAtaw_Menus_Group bfGroup = new DAAtaw_Menus_Group(this.UnitOfData);

            var list = bfGroup.QueryDefault(a => a.FControlUnitID == Group).ToList();
            List<Api.Data.RightMenu_Org> List = new List<RightMenu_Org>();
            foreach (var item in list)
            {
                Api.Data.RightMenu_Org model = new RightMenu_Org();
                CopyModel(item, model);
                List.Add(model);
            }

            return List;
        }

        public void CopyModel(Ataw_Menus_Group model, RightMenu_Org Rightmodel)
        {
            Rightmodel.Menu = model.MenuID;
            Rightmodel.Org = model.FControlUnitID;
        }


        public List<RightMenu_Org> initMenuGroupConnect(List<RightMenu> menulist)
        {

            DAAtaw_Menus_Group bfGroup = new DAAtaw_Menus_Group(this.UnitOfData);
            List<Api.Data.RightMenu_Org> List = new List<RightMenu_Org>();
            if (menulist != null)
            {
                foreach (var item in menulist)
                {
                    var list = bfGroup.QueryDefault(a => a.MenuID == item.FID).ToList();
                    foreach (var item1 in list)
                    {
                        Api.Data.RightMenu_Org model = new RightMenu_Org();
                        CopyModel(item1, model);
                        List.Add(model);
                    }
                }

            }
            return List;
        }

        //菜单组织权限中中间表Ataw_Menus_Group 添加
        public void AddMenuGroup(string fControlUnitID, string menuID)
        {
            DAAtaw_Menus_Group da = new DAAtaw_Menus_Group(this.UnitOfData);
            Ataw_Menus_Group model = new Ataw_Menus_Group();
            model.FID = UnitOfData.GetUniId();
            model.FControlUnitID = fControlUnitID;
            model.MenuID = menuID;
            model.FunctionRight = 0;
            model.FMyRightKey = null;
            model.FMyIcon = null;
            model.Remark = null;
            model.TIMESSTAMP = null;

            da.Add(model);
            // return model.MenuID;
        }
        //菜单组织权限 中间表删除
        public void DelMenuGroup(string fControlUnitID, string menuID)
        {
            DAAtaw_Menus_Group da = new DAAtaw_Menus_Group(this.UnitOfData);
            da.Delete(a => a.FControlUnitID == fControlUnitID && a.MenuID == menuID);
            //return "";
        }
        //菜单组织权限 中间表删除 根据（operation='del' 的 菜单ID）
        public void DelMenuGroup(string menuID)
        {
            DAAtaw_Menus_Group da = new DAAtaw_Menus_Group(this.UnitOfData);
            da.Delete(a => a.MenuID == menuID);
            //return "";
        }
        
    }
}

