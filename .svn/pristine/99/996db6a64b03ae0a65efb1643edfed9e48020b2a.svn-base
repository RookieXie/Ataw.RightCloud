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
    public class RoleMenuUserService : IRoleMenuUser
    {
        public RightUserMenuRole init(string Group, Pagination _pager)
        {


            BFAtaw_Users userbf = new BFAtaw_Users();
            BFAtaw_Roles rolebf = new BFAtaw_Roles();
            BFAtaw_Menus menubf = new BFAtaw_Menus();
            BFAtaw_Role_Rights right_Rolebf = new BFAtaw_Role_Rights();
            BFAtaw_User_Roles user_rolebf = new BFAtaw_User_Roles();

            RightUserMenuRole data = new RightUserMenuRole();
            data.MenuData = menubf.initMenuData("0", Group);
            data.RoleData = rolebf.initRoleData(Group);
            data.UserData = userbf.initUserData(Group, _pager);
            data.Role_Menu = right_Rolebf.GetRoleMenuByGroup(Group);
            data.Role_User = user_rolebf.GetUserRoleByGroup(Group, _pager);

            return data;
        }
        /// <summary>
        /// 菜单/角色/用户关系提交方法
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>

        public bool modify(MenuUserRoleSubmitData data)
        {

            var db = new RightCloudDBContext();

            BFAtaw_Menus bfMenu = new BFAtaw_Menus(); //菜单节点
            BFAtaw_Menus_Button bfMB = new BFAtaw_Menus_Button(); //菜单按钮
            BFAtaw_Roles bfRoles = new BFAtaw_Roles();  //角色
            BFAtaw_Users bfUsers = new BFAtaw_Users(); //用户
            BFAtaw_User_Roles bfUR = new BFAtaw_User_Roles(); //用户和角色中间表
            BFAtaw_Role_Rights bfRR = new BFAtaw_Role_Rights();//菜单和角色中间表

            BFAtaw_Menus_Group bfMG = new BFAtaw_Menus_Group();//菜单和组织的中间表

            bfMenu.SetUnitOfData(db);
            bfMB.SetUnitOfData(db);
            bfRoles.SetUnitOfData(db);
            bfUsers.SetUnitOfData(db);
            bfUR.SetUnitOfData(db);
            bfRR.SetUnitOfData(db);

            bool res = false;
            var checkRoleID = "";
            var GroupID = data.GroupData.Data.GroupID;
            var GroupName = data.GroupData.Data.GroupName;
            int count = data.MenuUserRoleDataList.Count();
            try
            {
                for (int i = 0; i < count; i++)
                {
                    var grantDataList = data.MenuUserRoleDataList[i].GrantDataList;
                    var menuDataList = data.MenuUserRoleDataList[i].MenuDataList;
                    var roleDataList = data.MenuUserRoleDataList[i].RoleDataList;
                    var userDataList = data.MenuUserRoleDataList[i].UserDataList;
                    var MenuUserRoleOperation = data.MenuUserRoleDataList[i].Operation;

                    #region 用户操作
                    for (int j = 0; j < userDataList.Count(); j++)
                    {
                        var userID = userDataList[j].Data.UserID;
                        var userName = userDataList[j].Data.UserName;
                        var operation = userDataList[j].Data.Operation;
                        var fControlUnitID = GroupID;
                        if (operation == "Add")
                        {
                            bfUsers.UserAdd(userID, userName, fControlUnitID);
                        }
                        if (operation == "Update")
                        {
                            bfUsers.UserUpdate(userID, userName);
                        }
                        if (operation == "Del")
                        {
                            bfUsers.UserDelete(userID);
                            //删除和角色的中间表信息
                            bfUR.UserRoleDeleteByUserID(userID);
                        }
                    }
                    #endregion

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
                        Ataw_Menus menuModel = new Ataw_Menus();
                        menuModel.MenuID = FID;
                        menuModel.RightKey = menuName;
                        menuModel.ParentID = parentID;
                        menuModel.RightValue = rightValue;
                        menuModel.RightDesc = rightDesc;
                        menuModel.FControlUnitID = GroupID;//新加
                        Ataw_Menus_Button mbModel = new Ataw_Menus_Button();
                        mbModel.FID = FID;
                        mbModel.ParentRightValue = parentID;
                        mbModel.FName = menuName;
                        mbModel.FControlUnitID = GroupID;//新加

                        if (menuType == "Menu")
                        {
                            if (operation == "Add")
                            {
                                //还需要添加菜单和组织的中间表?
                                bfMG.AddMenuGroup(fControlUnitID, FID);
                                bfMenu.AddMenu(menuModel);
                            }
                            if (operation == "Del")
                            {
                                bfMenu.delMenu(FID);
                                //删除和角色的中间表信息
                                bfRR.delRightByRightID(FID);

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
                                bfMB.AddMenuButton(mbModel);
                            }
                            if (operation == "Update")
                            {
                                bfMB.UpdateMenuButton(FID, menuName);
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
                            Ataw_Roles roleModel = new Ataw_Roles();
                            roleModel.RoleID = roleID;
                            //需要加一个FControlUnitID
                            roleModel.FControlUnitID = fControlUnitID;
                            roleModel.RoleName = roleName;
                            //判断roleID是否重复
                            if (checkRoleID != roleID)
                            {
                                checkRoleID = roleID;
                                if (operation == "Add")
                                {
                                    //需要判断是否已经存在该角色
                                    bfRoles.AddRoleByModel(roleModel);
                                }
                            }
                            if (operation == "Del")
                            {
                                bfRoles.delRoles(roleID);
                                //删除中间表
                                bfRR.delRight(roleID);
                                bfUR.UserRoleDeleteByRoleID(roleID);
                            }
                            if (operation == "Update")
                            {
                                bfRoles.UpdateRole(roleID, roleName);
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
                            if (menuType == "User")
                            {
                                if (rightGrantType == "Add")
                                {
                                    bfUR.AddRole(key, rightIds, GroupID);

                                }
                                if (rightGrantType == "Del")
                                {
                                    bfUR.UserRoleDelete(key, rightIds, GroupID);
                                }
                            }
                            if (menuType == "Menu")
                            {
                                Ataw_Role_Rights rrModel = new Ataw_Role_Rights();
                                rrModel.RightID = key;
                                rrModel.RoleID = rightIds;
                                rrModel.FControlUnitID = GroupID;
                                if (rightGrantType == "Add")
                                {
                                    bfRR.add(rrModel);
                                }
                                if (rightGrantType == "Del")
                                {
                                    bfRR.DelteByUserIDRoleID(key, rightIds, GroupID);
                                }
                            }
                        }
                    }
                    #endregion



                }
                var result =db.Submit();
                res = true;
            }
            catch (Exception)
            {
                res = false;
                throw;
            }
            return res;
        }


        public RightUserMenuRole RoleexportMenu(string Menu, string Group)
        {

            RightUserMenuRole data = new RightUserMenuRole();
            BFAtaw_Menus menubf = new BFAtaw_Menus();
            data.MenuData = menubf.initMenuData(Menu, Group);

            BFAtaw_Role_Rights Rightbf = new BFAtaw_Role_Rights();
            data.Role_Menu = Rightbf.initRoleMenuConnect(data.MenuData.Children);

            return data;
        }

        /// <summary>
        /// 角色分页
        /// </summary>
        /// <param name="Group"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        //public RightUserMenuRole Rolepaging(string Group, Pagination page)
        //{
        //    BFAtaw_Users userbf = new BFAtaw_Users();
        //    RightUserMenuRole data = new RightUserMenuRole();
        //    BFAtaw_User_Roles user_rolebf = new BFAtaw_User_Roles();
        //    data.UserData = userbf.initUserData(Group, page);
        //    data.Role_User = user_rolebf.GetUserRoleByGroup(Group, page);
        //    return data;
        //}


        public RightUserMenuRole Rolepaging(string Group, Pagination page)
        {
            PagerListData<RightUserMenuRole> pagedata = new PagerListData<RightUserMenuRole>();
            BFAtaw_Users userbf = new BFAtaw_Users();
            RightUserMenuRole data = new RightUserMenuRole();
            BFAtaw_User_Roles user_rolebf = new BFAtaw_User_Roles();
            data.UserData = userbf.initUserData(Group, page);
            data.Role_User = user_rolebf.GetUserRoleByGroup(Group, page);
            return data;
        }
    }
}
