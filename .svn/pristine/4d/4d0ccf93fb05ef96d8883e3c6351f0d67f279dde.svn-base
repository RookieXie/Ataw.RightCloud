using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data;
using Ataw.Framework.Web;
using Ataw.RightCloud.BF;
using Ataw.Framework.Core;
using Ataw.RightCloud.Data;
using Ataw.RightCloud.DB;

namespace Ataw.RightCloud.Service
{
    public class GroupMenuService : IGroupMenu
    {
        public RightMenuGroup init(string Group)
        {
            if (Group.IsAkEmpty())
            {
                Group = "1";
            }
            //1，初始化 
            RightMenuGroup model = new RightMenuGroup();
            BFAtaw_Menus bf = new BFAtaw_Menus();
            //菜单数据初始化
            model.MenuData = bf.initMenuData("0", Group);
            BFAtaw_Gruop bfgroup = new BFAtaw_Gruop();
            //组织数据初始化
            var dd = bfgroup.GetRightGroup(Group);
            BFAtaw_Menus_Group bfgroupMenu = new BFAtaw_Menus_Group();
            //菜单组织数据初始化
            model.Menu_Org = bfgroupMenu.GetModelbyGroup(Group);
            model.OrgData = new List<RightGroup> { dd };
            return model;

        }

        //菜单分组权限操作
        public bool modify(GroupRightSubmitData data)
        {
            //返回值 实体
            //GroupRightResponseData grrdModel = new GroupRightResponseData();
            var db = new RightCloudDBContext();

            var res = false;
            BFAtaw_Menus_Group bfmg = new BFAtaw_Menus_Group();
            BFAtaw_Menus bfMenu = new BFAtaw_Menus();
            BFAtaw_Menus_Button bfmb = new BFAtaw_Menus_Button();

            bfmb.SetUnitOfData(db);
            bfMenu.SetUnitOfData(db);
            bfmg.SetUnitOfData(db);

            Ataw_Menus menusModel = new Ataw_Menus();
            Ataw_Menus_Button mbModel = new Ataw_Menus_Button();
            Ataw_Menus_Group mgModel = new Ataw_Menus_Group();
            try
            {
                //var res = "";
                int length = data.GroupRightDataList.Count;


                for (int i = 0; i < length-1; i++)
                {
                    var grantDataList = data.GroupRightDataList[i].GrantDataList;
                    var groupDataList = data.GroupRightDataList[i].GroupDataList;
                    var menuDataList = data.GroupRightDataList[i].MenuDataList;
                    var operation = data.GroupRightDataList[i].Operation;

                    if (operation == "Add")
                    {
                        #region 添加

                       
                        if (menuDataList.Count > 0)
                        {
                            var FID = menuDataList[0].Data.FID;
                            var menuType = menuDataList[0].Data.MenuType;
                            var menuName = menuDataList[0].Data.MenuName;
                            var parentID = menuDataList[0].Data.ParentId;

                            var rightDesc = menuDataList[0].Data.RightDesc;
                            var rightValue = menuDataList[0].Data.RightValue;
                          
                            if (menuType == "Button")
                            {
                                mbModel.FID = FID;
                                mbModel.FName = menuName;
                                
                                mbModel.ParentRightValue = rightValue;
                                //添加按钮
                                bfmb.AddMenuButton(mbModel);
                            }
                            if (menuType == "Menu")
                            {
                                menusModel.MenuID = FID;
                                menusModel.ParentID = parentID;
                                menusModel.RightKey = menuName;
                                menusModel.RightValue = rightValue;
                                //添加节点菜单
                                bfMenu.AddMenu(menusModel);
                            }
                        }

                        if (grantDataList.Count > 0)
                        {

                            var menuID = grantDataList[0].NewKey;
                            var gtype = grantDataList[0].RightGrantType;
                            var rightid = grantDataList[0].RightIds; //组织ID集合
                            var menuType = grantDataList[0].MenuType;

                            for (int k = 0; k < rightid.Count; k++)
                            {
                                var fControlUnitID = rightid[k];
                                if (menuID != "" && fControlUnitID != "")
                                {
                                    if (gtype == "Add")
                                    {
                                        
                                        bfmg.AddMenuGroup(fControlUnitID, menuID);


                                    }
                                    if (gtype == "Del")
                                    {
                                        
                                    }
                                }
                            }
                        }
                        
                        #endregion

                    }
                    else if (operation == "Update")
                    {
                        #region 修改
                        
                        if (menuDataList.Count > 0)
                        {
                            var FID = menuDataList[0].Data.FID;
                            var menuType = menuDataList[0].Data.MenuType;
                            var menuName = menuDataList[0].Data.MenuName;
                            var rightDesc = menuDataList[0].Data.RightDesc;
                            var rightValue = menuDataList[0].Data.RightValue;
                            if (menuType == "Button")
                            {
                                //修改按钮
                                bfmb.UpdateMenuButton(FID, menuName);
                            }
                            if (menuType == "Menu")
                            {
                                //修改节点菜单
                                bfMenu.UpdateMenuData(FID, menuName);
                            }
                        }

                        if (grantDataList.Count > 0)
                        {

                            var menuID = grantDataList[0].Key;
                            var gtype = grantDataList[0].RightGrantType;
                            var rightid = grantDataList[0].RightIds; //组织ID集合
                            var menuType = grantDataList[0].MenuType;

                            for (int k = 0; k < rightid.Count; k++)
                            {
                                var fControlUnitID = rightid[k];
                                if (menuID != "" && fControlUnitID != "")
                                {
                                    if (gtype == "Add")
                                    {

                                        bfmg.AddMenuGroup(fControlUnitID, menuID);

                                    }
                                    if (gtype == "Del")
                                    {

                                        bfmg.AddMenuGroup(fControlUnitID, menuID);

                                    }
                                }
                            }
                        }
                   
                        #endregion

                    }
                    else if (operation == "Del")
                    {
                        #region 删除
            

                        if (menuDataList.Count > 0)
                        {
                            var FID = menuDataList[0].Data.FID;
                            var menuType = menuDataList[0].Data.MenuType;
                            var menuName = menuDataList[0].Data.MenuName;
                            var rightDesc = menuDataList[0].Data.RightDesc;
                            var rightValue = menuDataList[0].Data.RightValue;
                            if (menuType == "Button")
                            {
                                //删除按钮

                                //同时删除权限


                            }
                            if (menuType == "Menu")
                            {
                                //删除节点菜单
                                 res=bfMenu.delMenu(FID);
                                 if (res)
                                 {
                                     //判断节点下的按钮，并删除
                                     bfmb.DelMenuButton(rightValue);

                                     //同时删除权限
                                     bfmg.DelMenuGroup(FID);
                                 }
                                
                            }
                        }
                       
                        #endregion

                    }
                    else
                    {
                        #region operation=""的情况
                        if (grantDataList.Count > 0)
                        {
                           
                            var menuID = grantDataList[0].Key;
                            var gtype = grantDataList[0].RightGrantType;
                            var rightid = grantDataList[0].RightIds; //组织ID集合
                            var menuType = grantDataList[0].MenuType;
                            for (int k = 0; k < rightid.Count; k++)
                            {
                                var fControlUnitID = rightid[k];
                                if (menuID != "" && fControlUnitID != "")
                                {
                                    if (gtype == "Add")
                                    {

                                        bfmg.AddMenuGroup(fControlUnitID, menuID);

                                    }
                                    if (gtype == "Delete")
                                    {

                                        bfmg.DelMenuGroup(fControlUnitID, menuID);


                                    }
                                }
                            }

                        }
                       
                        #endregion
                    }
                }
                //提交
                bfmg.Submit();
                res = true;
            }
            catch
            {

                res = false;
            }

            
            return res;
        }


        public RightMenuGroup GroupexportMenu(string Menu, string Group)
        {
            RightMenuGroup data = new RightMenuGroup();
            BFAtaw_Menus menubf = new BFAtaw_Menus();

            data.MenuData = menubf.initMenuData(Menu, Group);
            BFAtaw_Menus_Group MenuGroupbf = new BFAtaw_Menus_Group();

            data.Menu_Org = MenuGroupbf.initMenuGroupConnect(data.MenuData.Children);
            return data;
        }

        public bool CheckHasChild(string menuID)
        {
            BFAtaw_Menus bf = new BFAtaw_Menus();
            var res = bf.CheckHasChild(menuID);
            return res;
        }
    }
}
