using Ataw.Framework.Core;
using Ataw.Framework.Web;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.Core;
using Ataw.RightCloud.Data;
using Ataw.RightCloud.Plug.ColdeTable;
using Ataw.RightCloud.Service;
using Ataw.RightCloud.Service.RC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Ataw.RightCloud.Web
{
    public class NewRightConfigController : AtawBaseController
    {
        // GET: NewRightConfig
        public ActionResult Index()
        {
            return View();
        }
        //页面初始化数据显示
        /// <summary>
        /// 提供 树形和 组织和菜单的数据  会发送一个组织的Id过来
        /// </summary>
        /// <returns></returns>
        public string fristinit(string Groups, string codes)
        {
            RCRightConfigService rightserver = new RCRightConfigService();
            RCGroupMenuService menuservice = new RCGroupMenuService();
            RCGroupTreeService groupservice = new RCGroupTreeService();
            var menudata = menuservice.init(Groups);
            var right = rightserver.initRCGroupMenuData();
            var _code = groupservice.getOrgCode(Groups);
            var dd = new
            {
                MenuOrgTable = menudata,
                GroupTree =right,
                Group = _code
            };
            return ReturnJson(dd);
        }
        /// <summary>
        /// 初始化话角色，菜单信息
        /// </summary>
        /// <returns></returns>
        public string secodeinit(string Groups, string pager)
        {
            RCRoleMenuService menuservice = new RCRoleMenuService();
            RCGroupTreeService groupservice = new RCGroupTreeService();
            //var _pager = pager.SafeJsonObject<Api.Pagination>();
            var data = menuservice.init(Groups);
            var _code = groupservice.getOrgCode(Groups);
            var dd = new { MenuUserTable = data, Group = _code };
            return ReturnJson(dd);
        }
        //提交按钮
        public string Groupsubmit(string group)
        {
            var _group = group.SafeJsonObjectByWeb<List<RCGroupTreeData>>(); ;
            RCGroupTreeService service = new RCGroupTreeService();
            var data = service.newgroup(_group[0]);
            return ReturnJson(data);
        }
        //用户权限提交
        public string Departmentsubmit(string UserRole) {                 
            RCDepartmentTreeService service = new RCDepartmentTreeService();
            var  data=service.NewUserRole(UserRole);   
            return ReturnJson(data);
        }

        /// <summary>
        /// 获取roleid
        /// </summary>
        /// <returns></returns>
        public string getFid()
        {
            RCRightConfigService service = new RCRightConfigService();
            return service.getFid();
        }
        /// <summary>
        /// 节点下是否有子节点
        /// </summary>
        /// <param name="MenuID"></param>
        /// <returns></returns>
        public string CheckHasChild(string menuID)
        {
            RCGroupTreeService service = new RCGroupTreeService();
            var res = service.CheckHasChild(menuID);
            return ReturnJson(res);
        }
        /// <summary>
        /// 菜单组织提交方法
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string MenuOrgSubmit(string data)
        {
            var _data = data.SafeJsonObject<GroupRightSubmitData>();
            RCGroupMenuService service = new RCGroupMenuService();
            var responsedata = service.modify(_data);
            return ReturnJson(responsedata);
        }
        /// <summary>
        /// 更新组织机构
        /// </summary>
        /// <param name="MenuID"></param>
        /// <returns></returns>
        public string GroupUpdate(string FID, string GroupName, string GroupCode)
        {
            RCGroupTreeService service = new RCGroupTreeService();
            var res = "";
            res = service.GroupUpdate(FID,GroupName, GroupCode);
            return ReturnJson(res);
        }
        /// <summary>
        /// 角色 菜单提交方法
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string RoleMenuSubmit(string data)
        {
            var _data = data.SafeJsonObject<RCRoleMenuSubmit>();
            RCRoleMenuService service = new RCRoleMenuService();
            var responseData = service.modify(_data);
            return ReturnJson(responseData);
        }

        /// <summary>
        /// 角色分配权限初始化
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public string InitRoleRightsTree(string roleid)
        {
            RCRoleService role = new RCRoleService();
            var data = role.InitRoleRightsTree(roleid);
            string result = JsonConvert.SerializeObject(data);
            return result;
        }
        /// <summary>
        /// 菜单分配权限初始化
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public string GrantGroupRights(string FID)
        {
            RCGroupTreeService service = new RCGroupTreeService();
            var data = service.InitGroupRightsTree(FID);
            string result = JsonConvert.SerializeObject(data);
            return result;
        }
        /// <summary>
        /// 获取当前角色的菜单权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public string GetRoleRightsList(string roleId)
        {
            //    List<RightsRole> tree = new List<RightsRole>();
            RCRoleMenuService service = new RCRoleMenuService();
            var res=service.GetRoleRightsList(roleId);
            return FastJson(res);
        }
        /// <summary>
        /// 获取当前菜单的菜单权限
        /// </summary>
        /// <param name="FID"></param>
        /// <returns></returns>
        public string GetGroupRightsList(string FID,bool onlyId)
        {
            //    List<RightsRole> tree = new List<RightsRole>();
            RCGroupMenuService service = new RCGroupMenuService();
            var res = service.GetGroupRightsList(FID, onlyId);
            return FastJson(res);
        }
        /// <summary>
        /// 角色和菜单权限添加
        /// </summary>
        /// <param name="rightIds"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public string RoleMenuAdd(string rightIds, string roleID)
        {
            try
            {
                RCRoleMenuService RMService = new RCRoleMenuService();
                RCRoleService roleService = new RCRoleService();
                //先删除该角色的权限
                RMService.DeleteByRoleID(roleID);
                //获取当前角色信息
                RC_Role model=roleService.GetRoleByID (roleID);

                string _FControlUnitID= model.FControlUnitID; //此角色的组织机构代码
                if (!string.IsNullOrEmpty(rightIds) && rightIds != null)
                {
                    string[] fid = null;
                    fid = rightIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    List<RC_Menu_tree> t = RMService.GetMenuList(fid);
                    RC_Menu_Role info = new RC_Menu_Role();
                    foreach (var item in t)
                    {
                        info.FControlUnitID = _FControlUnitID;
                        info.RCMR_RoleFID = roleID;
                        info.RCMR_MenuFID = item.FID;
                        RMService.InsertRoleMenu(info);
                    }
                }
                return "1";
            }
            catch (Exception)
            {
                return "2";
            }
        }
        /// <summary>
        ///菜单权限添加
        /// </summary>
        /// <param name="rightIds"></param>
        /// <param name="FID"></param>
        /// <returns></returns>
        public string GroupMenuAdd(string rightIds, string FID)
        {
            try
            {
                RCGroupMenuService RMService = new RCGroupMenuService();
                RCGroupTreeService Service = new RCGroupTreeService();
                //先删除该角色的权限
                RMService.DeleteByFID(FID);
                //获取当前角色信息
                RC_Group_tree model = Service.GetGroupByFID(FID);

                string _FControlUnitID = model.FControlUnitID; //此角色的组织机构代码
                if (!string.IsNullOrEmpty(rightIds) && rightIds != null)
                {
                    string[] fid = null;
                    fid = rightIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    List<RC_Menu_tree> t = RMService.GetMenuList(fid);
                    RC_Menu_Group info = new RC_Menu_Group();
                    foreach (var item in t)
                    {
                        info.FControlUnitID = _FControlUnitID;
                        info.RCMG_FControlUnitID = FID;
                        info.RCMG_MenuFID = item.FID;
                        RMService.InsertGroupMenu(info);
                    }
                }
                return "1";
            }
            catch (Exception)
            {
                return "2";
            }
        }

        /// <summary>
        ///初始化根据实体生成xml(ProductDataConfig.xml)
        /// </summary>
        /// <returns></returns>
        public void GetProductXml()
        {
            List<Pro_MenuData> menus = new List<Pro_MenuData>();
            List<Pro_GrantData> grants = new List<Pro_GrantData>();
            List<Pro_MenuData> menusChildren = new List<Pro_MenuData>();
            List<Pro_ButtonData> buttons = new List<Pro_ButtonData>();
            for (int i = 0; i < 4; i++)
            {
                Pro_ButtonData buttonData = new Pro_ButtonData();
                buttonData.CN_Name = "新增"+i;
                buttonData.EG_Name = "Insert"+i;
                buttonData.IsLeaf = true;
                buttonData.IsHidden = true;
                buttons.Add(buttonData);
            }
            for (int i = 0; i < 3; i++)
            {
                Pro_MenuData menuData = new Pro_MenuData();
                menuData.Name = "新权限管理" + i;
                menuData.URL = "#" + i;
                menuData.Buttons = buttons;
                menuData.IsLeaf = true;
                menuData.IsHidden = true;         
                menusChildren.Add(menuData);
            }
            for (int i = 0; i < 3; i++)
            {
                List<string> btncode = new List<string>();
                btncode.Add("Insert");
                Pro_GrantData grantData = new Pro_GrantData();
                grantData.RoleName = "系统管理员" + i;
                grantData.RoleCode = "Admin"+i;
                grantData.G_ButtonsCode = btncode;
                grants.Add(grantData);
            }
            for (int i = 0; i < 3; i++)
            {
                Pro_MenuData menuData = new Pro_MenuData();
                menuData.Name = "新权限管理"+i;
                menuData.URL = "#" + i;
                menuData.Buttons = buttons;
                menuData.Children = menusChildren;
                menuData.Grants = grants;
                menus.Add(menuData);
            }
            ProductData productData = new ProductData();
            productData.Name = "杭州信使网络科技有限公司";
            productData.Code = "1";
            productData.Menus = menus;
            productData.SaveFileByName("Product/ProductDataConfig.xml");
            //return ReturnJson(data);
        }

        /// <summary>
        /// ProductDataConfig.xml转化为json数据
        /// </summary>
        /// <returns></returns>
        public string GetProductDataConfigXml()
        {
            var path = Path.Combine(AtawAppContext.Current.BinPath, AtawApplicationConfig.REAL_PATH,"Product");
            var filese = Directory.GetFiles(path);
            RCProductData ProductDataConfig = new RCProductData();
            List<RCProductsDetail> products = new List<RCProductsDetail>();
            ProductData productData = new ProductData();
            foreach (var filePath in filese)
            {
                var productsDetail = new RCProductsDetail();
                productData = ProductData.ReadConfig(AtawAppContext.Current.BinPath, filePath);
                productsDetail.ProductData = productData;
                productsDetail.xmlPath = filePath.Substring(filePath.IndexOf("xml")+4);
                products.Add(productsDetail);
            }
            ProductDataConfig.Products = products;
            return ReturnJson(ProductDataConfig);
        }



        public string GetUser(string departmentID,string userIDs="", string roleIDs="")
        {
            RCRightConfigService rightserver = new RCRightConfigService();
            RCDepartmentTreeService departmentservice = new RCDepartmentTreeService();
            RCUsers rcUser = new RCUsers();

            var right = rightserver.initRCRCDepartmentData();
            var data= rcUser.GetRCUsers(userIDs, roleIDs, departmentID);

            var dd = new
            {
                DepartmentTree = right,
                data=data,
            };
            return ReturnJson(dd);

        }
        public string getUserDetail(string fids)
        {
            UserDetailService userdetail = new UserDetailService();
            if (fids == null) fids = "";
            var data = userdetail.getUserDetail(fids.Split(','));
            return ReturnJson(data);
        }
    }
} 