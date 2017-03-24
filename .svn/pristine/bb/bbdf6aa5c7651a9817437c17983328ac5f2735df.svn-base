using Ataw.Framework.Core;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.BF;
using Ataw.RightCloud.Data;
using Ataw.RightCloud.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Service
{
    public class RCRoleMenuService
    {

        public RCRightMenuRoleData init(string Group)
        {



            BFRC_Role rolebf = new BFRC_Role();
            BFRC_Menu_tree menubf = new BFRC_Menu_tree();
            BFRC_Menu_Role right_Rolebf = new BFRC_Menu_Role();

            RCRightMenuRoleData data = new RCRightMenuRoleData();
            data.MenuData = menubf.initRCMenuData("0", Group);
            data.RoleData = rolebf.initRCRoleData(Group);
            data.Role_Menu = right_Rolebf.GetRCRoleMenuByGroup(Group);
            return data;
        }

        public bool modify(RCRoleMenuSubmit data)
        {

            var db = new RightCloudDBContext();
            bool res = false;
            BFRC_Menu_tree bfMenu = new BFRC_Menu_tree();
            BFRC_Menu_Role bfMR = new BFRC_Menu_Role();
            BFRC_Role bfRole = new BFRC_Role();
            bfMenu.SetUnitOfData(db);
            bfMR.SetUnitOfData(db);
            bfRole.SetUnitOfData(db);

            var checkRoleID = "";
            var GroupID = data.GroupData.Data.GroupID;
            var GroupName = data.GroupData.Data.GroupName;
            int count = data.MenuRoleDataList.Count();
            try
            {
                for (int i = 0; i < count; i++)
                {
                    var grantDataList = data.MenuRoleDataList[i].GrantDataList;
                    var menuDataList = data.MenuRoleDataList[i].MenuDataList;
                    var roleDataList = data.MenuRoleDataList[i].RoleDataList;
                    var MenuUserRoleOperation = data.MenuRoleDataList[i].Operation;



                    #region 菜单操作
                    for (int j = 0; j < menuDataList.Count(); j++)
                    {
                        var menuType = menuDataList[j].Data.MenuType;
                        var operation = menuDataList[j].Data.Operation;
                        var menuName = menuDataList[j].Data.MenuName;
                        var rightDesc = menuDataList[j].Data.RightDesc;
                        var rightValue = menuDataList[j].Data.RightValue;
                        var FID = menuDataList[j].Data.FID;
                        var fControlUnitID = GroupID;//新加
                        var parentID = menuDataList[j].Data.ParentId;
                        RC_Menu_tree menuModel = new RC_Menu_tree();
                        menuModel.FID = FID;
                        menuModel.RCM_Name = menuName;
                        menuModel.PID = parentID;
                        menuModel.RCM_Dir = rightValue;
                        menuModel.FControlUnitID = GroupID;
                        //新加
                        //Ataw_Menus_Button mbModel = new Ataw_Menus_Button();
                        //mbModel.FID = FID;
                        //mbModel.ParentRightValue = parentID;
                        //mbModel.FName = menuName;
                        //mbModel.FControlUnitID = GroupID;//新加

                        if (menuType == "Menu")
                        {
                            if (operation == "Add")
                            {
                                RC_ButtonList RCbtnList = new RC_ButtonList();
                                List<RCMenu_button> btnList = new List<RCMenu_button>();
                                if (!string.IsNullOrEmpty(rightDesc))
                                {
                                    var btns = rightDesc.Split(',');
                                    for (int k = 1; k < btns.Length; k++)
                                    {
                                        var btns_sec = btns[k].Split(':');
                                        RCMenu_button btnModel = new RCMenu_button();
                                        btnModel.CN_Name = btns_sec[0];
                                        btnModel.EG_Name = btns_sec[1];
                                        btnList.Add(btnModel);
                                    }
                                }
                                RCbtnList.RCMenu_button = btnList;
                                var btnjson = RCbtnList.ToJson();
                                menuModel.RCM_ButtonList = btnjson;
                                //bfMG.AddMenuGroup(fControlUnitID, FID);                                
                                bfMenu.AddMenu(menuModel);
                            }
                            if (operation == "Del")
                            {
                                var resMenu = bfMenu.deleteMenu(FID);
                                if (resMenu)
                                {
                                    //同时删除权限
                                    bfMR.DeleteByMenuID(FID);
                                }

                            }
                            if (operation == "Update")
                            {
                                bfMenu.UpdateMenuData(FID, menuName);
                            }
                        }
                        if (menuType == "Button")
                        {
                            if (operation == "Add")
                            {

                                var btnList = bfMenu.GetMenuModelByFID(parentID);
                                // RC_ButtonList btnList = new RC_ButtonList();
                                RCMenu_button btnModel = new RCMenu_button();
                                btnModel.CN_Name = menuName;
                                btnModel.EG_Name = FID;
                                btnList.RCMenu_button.Add(btnModel);
                                var btnjson = btnList.ToJson();
                                menuModel.FID = parentID;
                                menuModel.RCM_ButtonList = btnjson;


                                //mbModel.FName = menuName;

                                //mbModel.ParentRightValue = rightValue;
                                ////添加按钮
                                bfMenu.AddMenuButton(menuModel);
                                //bfMB.AddMenuButton(mbModel);
                            }
                            if (operation == "Update")
                            {
                                string[] fid = FID.Split(',');
                                var btnList = bfMenu.GetMenuModelByFID(fid[1]);
                                // RC_ButtonList btnList = new RC_ButtonList();
                                RCMenu_button btnModel = new RCMenu_button();
                                foreach (var item in btnList.RCMenu_button)
                                {
                                    if (item.EG_Name == fid[0])
                                    {
                                        item.CN_Name = menuName;
                                    }
                                }
                                var btnjson = btnList.ToJson();
                                //RC_Menu_tree menuModel = new RC_Menu_tree();
                                menuModel.FID = fid[1];
                                menuModel.RCM_ButtonList = btnjson;
                                //修改按钮
                                bfMenu.AddMenuButton(menuModel);
                                //bfMB.UpdateMenuButton(FID, menuName);
                            }
                        }
                    }
                    #endregion


                    #region 角色操作
                    for (int j = 0; j < roleDataList.Count(); j++)
                    {
                        if (roleDataList[j] != null)
                        {
                            var operation = roleDataList[j].Data.Operation;
                            var roleID = roleDataList[j].Data.RoleID;
                            var roleName = roleDataList[j].Data.RoleName;
                            var fControlUnitID = GroupID;
                            RC_Role roleModel = new RC_Role();
                            roleModel.FID = roleID;
                            //需要加一个FControlUnitID
                            roleModel.FControlUnitID = fControlUnitID;
                            roleModel.RCR_Name = roleName;
                            //判断roleID是否重复
                            if (checkRoleID != roleID)
                            {
                                checkRoleID = roleID;
                                if (operation == "Add")
                                {
                                    //需要判断是否已经存在该角色
                                    bfRole.AddRoleByModel(roleModel);
                                }
                            }
                            if (operation == "Del")
                            {
                                bfRole.delRoles(roleID);
                                //删除中间表
                                bfMR.delRight(roleID);
                                //bfUR.UserRoleDeleteByRoleID(roleID);
                            }
                            if (operation == "Update")
                            {
                                bfRole.UpdateRole(roleID, roleName);
                            }
                        }
                    }
                    #endregion

                    var iskey = "";
                    var isrightIds = "";
                    #region 权限操作
                    for (int j = 0; j < grantDataList.Count(); j++)
                    {

                        var key = grantDataList[j].Key == "" ? grantDataList[j].NewKey : grantDataList[j].Key;
                        var rightGrantType = grantDataList[j].RightGrantType;
                        var rightIds = grantDataList[j].RightIds.Count() > 0 ? grantDataList[j].RightIds[0] : grantDataList[j].NewRightIds[0];
                        var menuType = grantDataList[j].MenuType;
                        if (iskey != key && isrightIds != rightIds)
                        {
                            iskey = key;
                            isrightIds = rightIds;
                            if (menuType == "Menu")
                            {
                                var MenuOrbutton = key;
                                var str=key.Split(',');
                                if (str.Length == 1) //菜单
                                {
                                    RC_Menu_Role mrModel = new RC_Menu_Role();
                                    mrModel.RCMR_MenuFID = key;
                                    mrModel.RCMR_RoleFID = rightIds;
                                    mrModel.RCMR_FControlUnitID = GroupID;
                                    if (rightGrantType == "Add")
                                    {
                                        bfMR.ADDRight(mrModel);
                                    }
                                    if (rightGrantType == "Del")
                                    {
                                        bfMR.DelteByRoleID(key, rightIds, GroupID);
                                    }
                                }
                                else //按钮
                                {
                                    var menuFID = str[1];
                                    var EG_button = str[0];
                                    RC_Menu_Role mrModel = new RC_Menu_Role();
                                    mrModel.RCMR_MenuFID = menuFID;
                                    mrModel.RCMR_RoleFID = rightIds;
                                    mrModel.RCMR_FControlUnitID = GroupID;
                                    mrModel.RCMR_Button = EG_button;
                                    if (rightGrantType == "Add")
                                    {
                                        bfMR.ADDRightButton(mrModel);
                                    }
                                    if (rightGrantType == "Del")
                                    {
                                        bfMR.DeleteBtn(key, rightIds, GroupID, EG_button);
                                    }
                                }
                                
                            }
                        }
                    }
                    #endregion



                }
                db.Submit();
                res = true;
            }
            catch (Exception)
            {
                res = false;
                throw;
            }
            return res;
        }

        public List<Object> GetRoleRightsList(string roleId)
        {
            //    List<RightsRole> tree = new List<RightsRole>();
            BFRC_Menu_Role bfMR = new BFRC_Menu_Role();
            var MRList = bfMR.GetRoleMenuList(roleId);
            List<Object> tt = new List<object>();
            foreach (var item in MRList)
            {
                tt.Add(new { id = item.RCMR_MenuFID });
            }
            return tt;
        }
        /// <summary>
        /// 删除角色关联菜单权限
        /// </summary>
        /// <param name="roleID"></param>
        public void DeleteByRoleID(string roleID)
        {
            var _db = new RightCloudDBContext();
            BFRC_Menu_Role bfMR = new BFRC_Menu_Role();
            bfMR.SetUnitOfData(_db);
            bfMR.DeleteByRoleID(roleID);
            _db.Submit();
        }
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public List<RC_Menu_tree> GetMenuList(string[] fid)
        {
            List<RC_Menu_tree> list = new List<RC_Menu_tree>();
            BFRC_Menu_tree bf = new BFRC_Menu_tree();
            foreach (var item in fid)
            {
                var model = bf.GetMenuById(item);
                list.Add(model);
            }
            return list;
        }

        public void InsertRoleMenu(RC_Menu_Role model)
        {
            var _db = new RightCloudDBContext();
            BFRC_Menu_Role bfMR = new BFRC_Menu_Role();
            bfMR.SetUnitOfData(_db);
            bfMR.InsertRoleMenu(model);
            _db.Submit();
        }
    }
}
