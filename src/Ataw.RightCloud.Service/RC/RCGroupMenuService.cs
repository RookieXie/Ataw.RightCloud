using Ataw.Framework.Core;
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
    public class RCGroupMenuService
    {
        public RCRightMenuGroup init(string Group)
        {
            if (Group.IsAkEmpty())
            {
                Group = "1";
            }
            //1，初始化 
            RCRightMenuGroup model = new RCRightMenuGroup();
            BFRC_Menu_tree bf = new BFRC_Menu_tree();
            //菜单数据初始化
            model.MenuData = bf.initRCMenuData("0", Group);
            BFRC_Group_tree bfgroup = new BFRC_Group_tree();
            //组织数据初始化
            var dd = bfgroup.GetRightGroup(Group);
            BFRC_Menu_Group bfgroupMenu = new BFRC_Menu_Group();
            //菜单组织数据初始化
            model.Menu_Org = bfgroupMenu.GetModelbyGroup(Group);
            model.OrgData = new List<RCNewRightGroup> { dd };
            return model;

        }
        public bool modify(GroupRightSubmitData data)
        {
            var db = new RightCloudDBContext();

            var res = false;

            BFRC_Group_tree bfGroup = new BFRC_Group_tree();
            BFRC_Menu_tree bfMenu = new BFRC_Menu_tree();
            BFRC_Menu_Group bfMG = new BFRC_Menu_Group();
            bfGroup.SetUnitOfData(db);
            bfMenu.SetUnitOfData(db);
            bfMG.SetUnitOfData(db);
            try
            {
                int length = data.GroupRightDataList.Count;


                for (int i = 0; i < length - 1; i++)
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
                            RC_Menu_tree menuModel = new RC_Menu_tree();
                            if (menuType == "Button")
                            {
                                var btnList= bfMenu.GetMenuModelByFID(parentID);
                               // RC_ButtonList btnList = new RC_ButtonList();
                                RCMenu_button btnModel = new RCMenu_button();                                
                                btnModel.CN_Name = menuName;
                                btnModel.EG_Name = rightValue;
                                btnList.RCMenu_button.Add(btnModel);
                                var btnjson=btnList.ToJson();
                                menuModel.FID = parentID;
                                menuModel.RCM_ButtonList=btnjson;
                                
                                
                                //mbModel.FName = menuName;

                                //mbModel.ParentRightValue = rightValue;
                                ////添加按钮
                                bfMenu.AddMenuButton(menuModel);
                            }
                            if (menuType == "Menu")
                            {
                                menuModel.FID = FID;
                                menuModel.PID = parentID;
                                menuModel.RCM_Name = menuName;
                                menuModel.RCM_Dir = rightValue;
                               
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
                                //添加节点菜单
                                bfMenu.AddMenu(menuModel);
                            }
                        }

                        if (grantDataList.Count > 0)
                        {

                            var menuID = grantDataList[0].NewKey;
                            var gtype = grantDataList[0].RightGrantType;
                            var rightid = grantDataList[0].RightIds; //组织ID集合
                            var menuType = grantDataList[0].MenuType;
                            if (menuType == "Menu")
                            {
                                for (int k = 0; k < rightid.Count; k++)
                                {
                                    var fControlUnitID = rightid[k];
                                    if (menuID != "" && fControlUnitID != "")
                                    {
                                        if (gtype == "Add")
                                        {

                                            bfMG.AddMenuGroup(fControlUnitID, menuID);


                                        }
                                        if (gtype == "Del")
                                        {

                                        }
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
                                RC_Menu_tree menuModel = new RC_Menu_tree();
                                menuModel.FID = fid[1];
                                menuModel.RCM_ButtonList = btnjson;
                                //修改按钮
                                bfMenu.AddMenuButton(menuModel);
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

                                        bfMG.AddMenuGroup(fControlUnitID, menuID);

                                    }
                                    if (gtype == "Del")
                                    {

                                        bfMG.DeleteMenuGroup(fControlUnitID, menuID);

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
                                var resMenu = bfMenu.deleteMenu(FID);
                                if (resMenu)
                                {
                                    //判断节点下的按钮，并删除
                                    //bfmb.DelMenuButton(rightValue);

                                    //同时删除权限
                                    bfMG.DelMenuGroupByMenuID(FID);
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

                                        bfMG.AddMenuGroup(fControlUnitID, menuID);

                                    }
                                    if (gtype == "Del")
                                    {

                                        bfMG.DeleteMenuGroup(fControlUnitID, menuID);


                                    }
                                }
                            }

                        }

                        #endregion
                    }
                }
                //提交
                db.Submit();
                res = true;
            }
            catch
            {

                res = false;
            }


            return res;
        }
        public List<Object> GetGroupRightsList(string FID,bool onlyId)
        {
            //    List<RightsRole> tree = new List<RightsRole>();
            BFRC_Menu_Group bfMR = new BFRC_Menu_Group();
            BFRC_Menu_tree bfMenu = new BFRC_Menu_tree();
            var MRList = bfMR.GetGroupMenuList(FID);
            List<Object> tt = new List<object>();
           
            foreach (var item in MRList)
            {
                if (onlyId)
                {
                    tt.Add(new { id = item.RCMG_MenuFID });
                }
                else
                {
                    
                    var menuModel = bfMenu.GetMenuByFID(item.RCMG_MenuFID);
                    if (menuModel != null)
                    {
                        tt.Add(new { id = menuModel.FID, pid = menuModel.PID, name = menuModel.RCM_Name });
                    }
                }
            }
            return tt;
        }
        public void DeleteByFID(string FID)
        {
            var _db = new RightCloudDBContext();
            BFRC_Menu_Group bfMR = new BFRC_Menu_Group();
            bfMR.SetUnitOfData(_db);
            bfMR.DeleteByFID(FID);
            _db.Submit();
        }
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
        public void InsertGroupMenu(RC_Menu_Group model)
        {
            var _db = new RightCloudDBContext();
            BFRC_Menu_Group bfMR = new BFRC_Menu_Group();
            bfMR.SetUnitOfData(_db);
            bfMR.InsertRoleMenu(model);
            _db.Submit();
        }
    }
}
