using Ataw.RightCloud.Api.Data.RightConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.Data;
using Ataw.Framework.Web;
using Ataw.RightCloud.Api.Data;

namespace Ataw.RightCloud.BF
{
    public class BFRightCofig : RightCloudBaseBF
    {
        public string SaveMenuData(List<InitMenuData> listmode)
        {
            List<MenuDetailData> addListMenuData = new List<MenuDetailData>();
            List<MenuDetailData> updateListMenuData = new List<MenuDetailData>();
            List<string> delListfids = new List<string>();
            for (var num = 0; num < listmode.Count;num++ )
            {
                MenuDetailData model = new MenuDetailData();
                model.FID = listmode[num].FID;
                if (listmode[num].ActionType == "add")
                {
                    if (listmode[num].isDelete != true)
                    {

                        List<MenuButtonData> listBtnData = new List<MenuButtonData>();
                        if (listmode[num].ButtonList.Count > 0)
                        {
                            for (int index = 0; index < listmode[num].ButtonList.Count; index ++ )
                            {
                                MenuButtonData btnData = new MenuButtonData();
                                btnData.FName = listmode[num].ButtonList[index].ButtonName;
                                listBtnData.Add(btnData);
                            }

                        }
                        model.MenuButtonList = listBtnData;

                    }
                    addListMenuData.Add(model);
                }
                else if (listmode[num].ActionType == "del")
                {
                    delListfids.Add(listmode[num].FID);
                }
                else if (listmode[num].ActionType == "update")
                {
                    if (listmode[num].ButtonList.Count > 0)
                    {
                        for (int i = 0; i < listmode[num].ButtonList.Count; i++)
                        {

                            if (listmode[num].ButtonList[i].ActionType == "add")
                            {

                            }
                            else if (listmode[num].ButtonList[i].ActionType == "update")
                            {

                            }

                        }
                    }
                    updateListMenuData.Add(model);
                }

            }
            return "";
        }
        public List<InitMenuData> GetMenuData(string FControlUnitID)
        {
            DAAtaw_Menus da = new DAAtaw_Menus(UnitOfData);
            List<InitMenuData> _List = new List<InitMenuData>();
            //获取当前组织机构下的菜单以及子菜单所有数据
            List<Ataw_Menus> _menuList = da.GetMany(a => (a.FControlUnitID == FControlUnitID && a.ParentID == "0")).ToList();
            for (int i = 0; i < _menuList.Count; i++)
            {
                InitMenuData _menuData = new InitMenuData();
                _menuData.FID = _menuList[i].MenuID;
                _menuData.MenuName = _menuList[i].RightKey;
                _menuData.ParentId = _menuList[i].ParentID;
                _menuData.isParent = _menuList[i].IsParent;
                _menuData.isLeaft = !_menuList[i].IsParent;
                _menuData.IsHidden = false;
                if (_menuList[i].FControlUnitID != null)
                {
                    _menuData.Org = _menuList[i].FControlUnitID;
                }
                else
                {
                    _menuData.Org ="";
                }
                _menuData.RightValue = _menuList[i].RightValue;
                GetChildreMenuDataDataByFID(_menuData);
                _List.Add(_menuData);
            }
            return _List;
        }
        public void GetChildreMenuDataDataByFID(InitMenuData data)
        {
            DAAtaw_Menus da = new DAAtaw_Menus(UnitOfData);
            List<InitMenuData> _navChileList = new List<InitMenuData>();
            List<Ataw_Menus> _childrenList = da.GetMany(a => a.ParentID == data.FID).ToList();
            if (_childrenList.Count > 0)
            {
                for (int i = 0; i < _childrenList.Count; i++)
                {
                    InitMenuData _menuData = new InitMenuData();
                    _menuData.FID = _childrenList[i].MenuID;
                    _menuData.MenuName = _childrenList[i].RightKey;
                    _menuData.ParentId = _childrenList[i].ParentID;
                    _menuData.isParent = _childrenList[i].IsParent;
                    _menuData.isLeaft = !_childrenList[i].IsParent;
                    _menuData.RightValue = _childrenList[i].RightValue;
                    _menuData.IsHidden = false;
                    if (_childrenList[i].FControlUnitID != null)
                    {
                        _menuData.Org = _childrenList[i].FControlUnitID;
                    }
                    else
                    {
                        _menuData.Org = "";
                    }
                    GetChildreMenuDataDataByFID(_menuData);
                    _navChileList.Add(_menuData);
                }
                data.Children = _navChileList;
            }
            else
            {
                var bfbutton = new BFAtaw_Menus_Button();
                List<MenuButtonData> ButtonList = bfbutton.getbuttoninfo(data.RightValue);
                List<IMenuButtonData> _btnList = new List<IMenuButtonData>();
                if (ButtonList != null)
                {
                  foreach (var bb in ButtonList)
                  {
                    IMenuButtonData _btn = new IMenuButtonData();
                    _btn.Fid = bb.FID;
                    _btn.ButtonName = bb.FName;
                    _btn.Org = "";
                    _btnList.Add(_btn);
                  }
                 data.ButtonList = _btnList;
               }
            }
        }
    }
}
