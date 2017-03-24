using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.Framework.Core;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.DB;
using Ataw.RightCloud.Data;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Core;
using Ataw.RightCloud.Api.Data;
using System.Data.SqlClient;
using System.Data;
using Ataw.Right.Api;
using Ataw.Framework.Web;


namespace Ataw.RightCloud.BF
{
    public class BFAtaw_Menus : RightCloudBaseBF
    {
        public PagerListData<MenuData> Pagination(Ataw.RightCloud.Api.Pagination pager, string partenid, string menuName)
        {
            int total = 0;
            PagerListData<MenuData> data = new PagerListData<MenuData>();
            DAAtaw_Menus _da = new DAAtaw_Menus(this.UnitOfData);
            ICollection<Ataw_Menus> ListMenusSql = null;
            Ataw_Menus partentmodel = null;

            if (pager == null)
            {
                pager = new Api.Pagination();
                pager.IsASC = "IsASC".AppKv<bool>(false);
                pager.PageNo = "PageNo".AppKv<int>(0);
                pager.PageSize = "PageSize".AppKv<int>(15);
                pager.TotalCount = 0;
            }

            if (pager.PageSize == 0)
            {
                pager.PageSize = "PageSize".AppKv<int>(15);
            }

            IQueryable<Ataw_Menus> _query = _da.QueryMany(a => 1 == 1);
            if (!partenid.IsAkEmpty())
            {
                _query = _da.QueryMany(a => a.ParentID == partenid);
                partentmodel = _da.QueryMany(a => (a.MenuID == partenid)).FirstOrDefault();
            }
            else
            {
                //  _query = _query.OrderByDescending(a => a.UDDATETIME);
            }
            if (!menuName.IsAkEmpty())
            {
                _query = _query.Where(a => a.RightKey.Contains(menuName));
            }
            //if (!partenid.IsAkEmpty())
            //{
            //ListMenusSql = _query.GetManyPage((a) => 1 == 1, a => a.UPDATE_TIME, !pager.IsASC, pager.PageNo + 1, pager.PageSize, out total);
            //}
            //else
            //{
            ListMenusSql = _query.GetManyPage((a) => 1 == 1, a => a.UPDATE_TIME, !pager.IsASC, pager.PageNo + 1, pager.PageSize, out total);
            //}

            var returnList = new List<MenuData>();
            if (partentmodel != null)
            {
                var partentmodelUI = new MenuData();
                CopyModel(partentmodel, partentmodelUI);
                returnList.Add(partentmodelUI);
            }
            List<MenuData> MenuList = new List<MenuData>();
            foreach (var Menu in ListMenusSql)
            {
                MenuData menudata = new MenuData();
                CopyModel(Menu, menudata);
                MenuList.Add(menudata);
            }
            //顺序添加

            returnList.AddRange(MenuList);
            // pager.PageNo = 
            pager.TableName = "Ataw_Menu";
            pager.TotalCount = total;
            data.Pager = pager;
            data.List = returnList;
            return data;
        }

        public MenuData getMenu(string fid)
        {
            Ataw_Menus model = new Ataw_Menus();

            if (!fid.IsAkEmpty())
            {
                DAAtaw_Menus _da = new DAAtaw_Menus(this.UnitOfData);
                model = _da.QueryMany(a => (a.MenuID == fid)).FirstOrDefault();
                if (model != null)
                {
                    MenuData menudata = new MenuData();
                    CopyModel(model, menudata);
                    return menudata;
                }
                return null;
            }
            return null;
        }

        private static void CopyModel(Ataw_Menus menu, MenuData menudata)
        {
            menudata.FID = menu.MenuID;
            string MenuName = "MenuCodeTable".GetText(menu.MenuID);
            menudata.MenuName = MenuName;
            menudata.RightDesc = menu.RightDesc;
            menudata.ParentId = menu.ParentID;
            string ParentName = "MenuCodeTable".GetText(menu.ParentID);
            menudata.ParentName = ParentName;
            menudata.RightKindId = menu.RightType;
            menudata.RightKindName = "RightType".GetText(menu.RightType);
            menudata.IconUrl = menu.Icon;
            if (menu.Icon != null)
            {
                menudata.IconName = "ICONCodeData".GetText(menu.Icon);
            }
            menudata.Key = menu.RightValue;
            menudata.KeyType = "MenuType".GetText(menu.KeyType.ToString());
            menudata.MenuName = menu.RightKey;
            menudata.UPDATE_TIME = menu.UPDATE_TIME.ToString();
        }

        public MenuDetailData getMenuDetail(string fid)
        {
            DAAtaw_Menus _da = new DAAtaw_Menus(this.UnitOfData);
            Ataw_Menus Menu = new Ataw_Menus();
            MenuDetailData menudata = new MenuDetailData();

            Menu = _da.QueryMany(a => (a.MenuID == fid)).FirstOrDefault();
            if (Menu != null)
            {

                menudata.FID = Menu.MenuID;
                string MenuName = "MenuCodeTable".GetText(Menu.MenuID);
                menudata.MenuName = MenuName;
                menudata.ParentId = Menu.ParentID;
                var model = getMenu(Menu.ParentID);
                if (model != null)
                {
                    string ParentName = model.MenuName;
                    menudata.ParentName = ParentName;
                }
                else
                {
                    menudata.ParentName = "";
                }

                menudata.RightKindId = Menu.RightType;
                menudata.RightKindName = "RightType".GetText(Menu.RightType);
                menudata.IconUrl = Menu.Icon;
                if (Menu.Icon != null)
                {
                    menudata.IconName = "ICONCodeData".GetText(Menu.Icon);
                }
                menudata.Key = Menu.RightValue;
                menudata.MenuName = Menu.RightKey;

                menudata.MenuKindId = Menu.KeyType.ToString();
                menudata.MenuKindName = "MenuType".GetText(Menu.KeyType.ToString());
                menudata.RightDesc = Menu.RightDesc;

                menudata.OrderId = Menu.OrderId ?? 0;

                //如果有按钮的话 查出来 RightValue
                var bfbutton = new BFAtaw_Menus_Button();
                List<MenuButtonData> ButtonList = bfbutton.getbuttoninfo(Menu.RightValue);

                menudata.MenuButtonList = ButtonList;
                return menudata;
            }

            return null;
        }

        public void delMenuList(string[] keys)
        {
            DAAtaw_Menus _da = new DAAtaw_Menus(this.UnitOfData);
            _da.DeleteByKey(keys);
        }
        //菜单组织权限中菜单删除
        public bool delMenu(string p)
        {
            bool res = false;
            DAAtaw_Menus _da = new DAAtaw_Menus(this.UnitOfData);
            Ataw_Menus model = _da.QueryMany(b => b.ParentID == p).FirstOrDefault();
            if (model == null)
            {
                _da.Delete(a => a.MenuID == p);
                res = true;
            }
            return res;
        }

        public string AddMenu(MenuDetailData menu)
        {
            DAAtaw_Menus _da = new DAAtaw_Menus(this.UnitOfData);
            Ataw_Menus model = new Ataw_Menus();
            AtawDebug.AssertNotNullOrEmpty(menu.Key, "菜单权值不能为空", this);
            AtawDebug.AssertNotNullOrEmpty(menu.MenuName, "菜单名称不能为空", this);

            model.MenuID = UnitOfData.GetUniId();
            model.RightValue = menu.Key;
            model.RightKey = menu.MenuName;
            model.RightType = menu.RightKindId == null ? "1" : menu.RightKindId;
            model.KeyType = menu.MenuKindId.IsAkEmpty() ? 1 : menu.MenuKindId.Value<int?>();

            if (menu.ParentId.IsAkEmpty())
            {
                model.ParentID = "0";
            }
            else
            {
                model.ParentID = menu.ParentId;
                var Parentmodel = _da.QueryMany(a => (a.MenuID == menu.ParentId)).FirstOrDefault();
                if (Parentmodel != null)
                {
                    Parentmodel.IsParent = true;
                    _da.Update(Parentmodel);
                }
            }
            model.IsParent = false;
            model.Icon = menu.IconName;
            model.RightDesc = menu.RightDesc;


            _da.Add(model);

            return model.MenuID;
        }

        //菜单组织权限中菜单添加
        public void AddMenu(Ataw_Menus model)
        {
            DAAtaw_Menus da = new DAAtaw_Menus(this.UnitOfData);
            da.Add(model);
        }
        //菜单组织权限中菜单修改
        public void UpdateMenuData(string fid, string menuName)
        {
            DAAtaw_Menus da = new DAAtaw_Menus(this.UnitOfData);
            Ataw_Menus model = new Ataw_Menus();
            model = da.QueryMany(a => a.MenuID == fid).FirstOrDefault();
            model.RightKey = menuName;
            da.Edit(model);
        }
        public string UpdateMenu(MenuDetailData menu)
        {
            DAAtaw_Menus _da = new DAAtaw_Menus(this.UnitOfData);
            if (!menu.FID.IsAkEmpty())
            {
                Ataw_Menus model = new Ataw_Menus();
                model = _da.QueryMany(a => (a.MenuID == menu.FID)).FirstOrDefault();

                if (menu.Key != null)
                {
                    model.RightValue = menu.Key;
                }
                if (menu.MenuName != null)
                {
                    model.RightKey = menu.MenuName;
                }
                //if (menu.RightKindId != null)
                //{
                //    model.RightType = menu.RightKindId;
                //}
                if (menu.MenuKindId != null)
                {
                    model.KeyType = menu.MenuKindId.Value<int?>();
                }

                if (menu.OrderId != null)
                {
                    model.OrderId = menu.OrderId.Value<int?>();
                }
                //if (menu.ParentId != null)
                //{
                //    model.ParentID = menu.ParentId;
                //    this.UpdataParent(menu.ParentId);
                //}
                if (menu.IconName != null)
                {
                    model.Icon = menu.IconName;
                }
                if (menu.RightDesc != null)
                {
                    model.RightDesc = menu.RightDesc;
                }
                _da.Edit(model);

                return model.MenuID;
            }
            return "";
        }

        public void UpdataParent(string Parentid)
        {
            DAAtaw_Menus _da = new DAAtaw_Menus(this.UnitOfData);
            Ataw_Menus model = new Ataw_Menus();
            model = _da.QueryMany(a => (a.MenuID == Parentid)).FirstOrDefault();
            model.ParentID = "1";

            _da.Update(model);
        }
        public bool CheckHasChild(string p)
        {
            DAAtaw_Menus _da = new DAAtaw_Menus(this.UnitOfData);
            var list = _da.QueryMany(a => (a.ParentID == p)).ToList();
            if (list.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataSet GetGroupMenusTree1(string unitID, string strWhere)
        {
            var _da = new DAAtaw_Menus(this.UnitOfData);

            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@strwhere", strWhere);
            parameter[1] = new SqlParameter("@fcontrolunitid", unitID);
            //调用存储过程
            //_da.DataContext.Database.ExecuteSqlCommand("exec usp_Ataw_GetGroupMenusTree @strwhere,@fcontrolunitid", parameter);
            //var table = _da.DataContext.Database.SqlQuery<Ataw_Menus>("exec usp_Ataw_GetGroupMenusTree @strwhere,@fcontrolunitid", parameter).ToList();
            AtawDbContext db = AtawAppContext.Current.CreateDbContext();
            var data = db.QueryDataSet("exec usp_Ataw_GetGroupMenusTree @strwhere,@fcontrolunitid", parameter);

            return data;
            // _da.DataContext.Database.SqlQuery(,"exec usp_Ataw_GetGroupMenusTree @strwhere,@fcontrolunitid", parameter)
        }
        /// <summary>
        ///  1,初始化菜单 权限
        /// </summary>
        /// <param name="parentId">父级菜单ID 第一次默认为0</param>
        /// <param name="Group">当前组织，为空默认为1</param>
        /// <returns></returns>
        public RightMenu initMenuData(string parentId, string Group)
        {
            if (Group.IsAkEmpty())
            {
                Group = "1";
            }
            var dd = GetMenuByParentId(parentId, Group);
            return dd;
        }
        //获取菜单子节点  循环调用
        public RightMenu GetMenuByParentId(string PartId, string Group)
        {
            RightMenu root = new RightMenu();
            DAAtaw_Menus _da = new DAAtaw_Menus(this.UnitOfData);
            //将父节点先装起来
            string unitID = "";
            string strWhere = "";
            DataTable rightList = null;
            Right.Api.IRole _coreGroup = "Role".CodePlugIn<Right.Api.IRole>();

            if (!GlobalVariable.IsAtawSuperUser)
            {
                unitID = GlobalVariable.FControlUnitID;
                strWhere = "menuid in (select distinct RightID from view_UserRoleRight where FControlUnitID = '" + unitID + "' and userid='" + GlobalVariable.UserFID + "'  )";

                // and ParentID='" + PartId + "'
                rightList = _coreGroup.InitRightsTree_Send(strWhere, unitID);
            }
            else
            {
                rightList = _coreGroup.GetMenusTree();
            }

            DataView dv = rightList.DefaultView;
            dv.Sort = "orderid asc";
            rightList = dv.ToTable();

            if (!GlobalVariable.IsAtawSuperUser)
            {
                this.tranFormRigth(root, rightList);
            }
            else
            {
                //管理员
                this.tranFormRigth(root, rightList);
            }

            return root;
        }

        private void tranFormMenu(RightMenu root, DataTable rightList)
        {
            if (rightList.Rows.Count != 0)
            {
                if (root.FID.IsAkEmpty())//是最开始的节点
                {
                    root.FID = "0";
                }

                List<RightMenu> list = new List<RightMenu>();
                for (int i = 0; i < rightList.Rows.Count; i++)
                {
                    if (rightList.Rows[i]["pid"].ToString() == root.FID)
                    {
                        RightMenu model = new RightMenu();
                        CopyMenuforDataRow(rightList.Rows[i], model);
                        if (ishasChildDataTable(model, rightList))
                        {
                            model.isParent = true;
                            model.isLeaft = false;
                            this.tranFormMenu(model, rightList);
                        }
                        else
                        {
                            model.isParent = false;
                            model.isLeaft = true;
                        }
                        list.Add(model);
                    }
                    root.Children = list;
                }
            }
        }

        public bool ishasChildDataTable(RightMenu model, DataTable rightList)
        {
            var haschild = false;
            for (int i = 0; i < rightList.Rows.Count; i++)
            {
                if (rightList.Rows[i]["pid"].ToString() == model.FID)
                {
                    haschild = true;
                }
            }
            return haschild;
        }

        private void tranFormRigth(RightMenu root, DataTable rightList)
        {
            if (rightList.Rows.Count != 0)
            {
                if (root.FID.IsAkEmpty())//是最开始的节点
                {
                    root.FID = "0";
                }

                DAAtaw_Menus _da = new DAAtaw_Menus(this.UnitOfData);
                List<RightMenu> list = new List<RightMenu>();
                List<RightMenuButton> buttonList = new List<RightMenuButton>();
                for (int i = 0; i < rightList.Rows.Count; i++)
                {
                    if (rightList.Rows[i]["pid"].ToString() == root.FID)
                    {
                        RightMenu model = new RightMenu();
                        CopyRightforDataRow(rightList.Rows[i], model, _da);
                        if (ishasChildDataTable(model, rightList))
                        {
                            model.isParent = true;
                            model.isLeaft = false;
                            this.tranFormRigth(model, rightList);
                        }
                        else
                        {
                            model.isParent = false;
                            model.isLeaft = true;
                        }
                        if (model.isButton==true)
                        {
                            RightMenuButton mbModel = new RightMenuButton();
                            mbModel.ButtonName = model.MenuName;
                            mbModel.IsHidden = model.IsHidden;
                            mbModel.FID = model.FID;
                            buttonList.Add(mbModel);
                        }else{
                            list.Add(model);
                        }
                        
                      
                    }
                    root.Children = list.Count>0 ? list:null; ;
                    root.ButtonList = buttonList.Count >0 ? buttonList:null;
                }

            }
        }

        private void CopyMenuforDataRow(DataRow dataRow, RightMenu model)
        {
            model.FID = dataRow["id"].ToString(); ;
            model.IsHidden = true;
            //model.isParent = this.haschild(dataRow["id"].ToString(), dataRow["rightvalue"].ToString());
            model.MenuName = dataRow["name"].ToString();
            model.RightValue = dataRow["rightvalue"].ToString();
            model.OriginalName = dataRow["name"].ToString();
        }
        private void CopyRightforDataRow(DataRow dataRow, RightMenu model, DAAtaw_Menus da)
        {
            model.FID = dataRow["id"].ToString();
            model.IsHidden = true;
            //model.isParent = this.haschild(dataRow["id"].ToString(), dataRow["rightvalue"].ToString());
            model.MenuName = dataRow["name"].ToString();
            //需要写个方法
            string fid = model.FID;
            string rightvalue = "";
            var menumodel = da.QueryMany(a => a.MenuID == fid).FirstOrDefault();
            if (menumodel == null)
            {
                BFAtaw_Menus_Button bfbtn = new BFAtaw_Menus_Button();
                rightvalue = bfbtn.getRigthKey(fid);
                model.isButton = true;
                
            }
            else
            {
                model.isButton = false;
                rightvalue = menumodel.RightKey;
            }
            model.RightValue = rightvalue;
            model.OriginalName = dataRow["name"].ToString();
        }

        //获得菜单的按钮
        public List<RightMenuButton> GetMenuButtonByRightValue(string RightValue)
        {
            DAAtaw_Menus_Button _da = new DAAtaw_Menus_Button(this.UnitOfData);
            var List = _da.QueryDefault(a => a.ParentRightValue == RightValue).ToList();

            List<RightMenuButton> list = new List<RightMenuButton>();
            if (List.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (var item in List)
                {
                    RightMenuButton model = new RightMenuButton();
                    CopyButton(item, model);
                    list.Add(model);
                }
                return list;
            }
        }
        //还是要写个递归
        public void CopyRight(Ataw_Menus menumodel, RightMenu model)
        {
            model.FID = menumodel.MenuID;
            model.IsHidden = true;
            model.isParent = menumodel.IsParent;
            model.MenuName = menumodel.RightKey;
            model.RightValue = menumodel.RightValue;
            model.OriginalName = menumodel.RightKey;
        }
        public void CopyButton(Ataw_Menus_Button button, RightMenuButton rightbutton)
        {
            rightbutton.FID = button.FID;
            rightbutton.ButtonName = button.FName;
            rightbutton.OriginalName = button.FName;
        }
        public bool haschild(string MenuId, string KeyVaue)
        {
            //按钮和菜单都要判断
            DAAtaw_Menus _da = new DAAtaw_Menus(this.UnitOfData);
            var List = _da.QueryMany(a => a.ParentID == MenuId).ToList();
            BFAtaw_Menus_Button BFButton = new BFAtaw_Menus_Button();
            bool hasbutton = BFButton.hasButton(KeyVaue);
            if (List.Count == 0 && !hasbutton)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string getUFid()
        {
            DAAtaw_Menus _da = new DAAtaw_Menus(this.UnitOfData);
            return _da.GetUniId();
        }
    }
}

