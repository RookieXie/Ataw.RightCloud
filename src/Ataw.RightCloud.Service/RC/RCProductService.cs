using Ataw.Framework.Core;
using Ataw.RightCloud.Api.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Ataw.RightCloud.Service
{
    public class RCProductService
    {
        //读取Product.xml
        //public RCProductData GetProductXml()
        //{
        //    RCProductData data = new RCProductData();
        //    XmlDocument doc = new XmlDocument();
        //    string real_path = "Areas\\RightCloud";
        //    string fpath= Path.Combine(AtawAppContext.Current.BinPath, real_path, "Product.xml");
        //    doc.Load(fpath);
        //    string product_xpath = "Products/Product";
        //    XmlNodeList productList = doc.SelectNodes(product_xpath);
        //    List<ProductData> products = new List<ProductData>();
        //    foreach (XmlNode item in productList)
        //    {
        //        List<Pro_RoleData> RolesListData = new List<Pro_RoleData>();
        //        List<Pro_Grant> pro_GrantList = new List<Pro_Grant>();
        //        ProductData productData = new ProductData();
        //        XmlNode nameNode =item.SelectSingleNode("Name");
        //        string name=nameNode.InnerText;
        //        XmlNode codeNode = item.SelectSingleNode("Code");
        //        string code = codeNode.InnerText;
        //        productData.Name = name;
        //        productData.Code = code;
        //        List<Pro_MenuData> MenusData = new List<Pro_MenuData>();
        //        //菜单、角色、菜单角色关联
        //        this.GetMenusXml(item, MenusData, RolesListData, pro_GrantList);
        //        productData.Menus = MenusData;
        //        productData.Roles = RolesListData;
        //        productData.Grant = pro_GrantList;
        //        products.Add(productData);

        //    }
        //    data.Products = products;
        //    return data;
        //}
        //public void GetMenusXml(XmlNode Node, List<Pro_MenuData> MenusData, List<Pro_RoleData> RolesListData, List<Pro_Grant> pro_GrantList)
        //{
            
        //    XmlNodeList MenuList = Node.SelectNodes("Menus/Menu");
        //    foreach (XmlNode item in MenuList)
        //    {
        //        Pro_MenuData menuData = new Pro_MenuData();
        //        XmlNode xmlMenuName=item.SelectSingleNode("Name");
        //        XmlNode xmlMenuCode = item.SelectSingleNode("Code");
        //        XmlNode xmlMenuURL = item.SelectSingleNode("URL");
        //        XmlNodeList RoleList = item.SelectNodes("Roles/Role");
        //        List<Pro_RoleData> Roles = new List<Pro_RoleData>();
        //        foreach (XmlNode role in RoleList)
        //        {
        //            Pro_RoleData roleData = new Pro_RoleData();
        //            XmlNode xmlroleName = role.SelectSingleNode("Name");
        //            XmlNode xmlroleCode = role.SelectSingleNode("Code");
        //            roleData.Name = xmlroleName.InnerText;
        //            roleData.Code = xmlroleCode.InnerText;
        //            Roles.Add(roleData);
        //            //相同角色归纳，只保留一个
        //            if (RolesListData.Count > 0)
        //            {
        //                foreach (var roleList in RolesListData)
        //                {
        //                    if (roleList.Name != roleData.Name && roleList.Code != roleData.Code)
        //                        RolesListData.Add(roleData);
        //                }
        //            }
        //            else
        //            {
        //                RolesListData.Add(roleData);
        //            }
        //            //角色菜单关联信息
        //            Pro_Grant pro_Grant = new Pro_Grant();
        //            pro_Grant.RoleCode = roleData.Code;
        //            pro_Grant.MenuUrl = xmlMenuURL.InnerText;
        //            pro_Grant.RoleName = roleData.Name;
        //            pro_Grant.MenuName = xmlMenuName.InnerText;
        //            pro_GrantList.Add(pro_Grant);
        //        }
        //        XmlNodeList BtnList = item.SelectNodes("Buttons/Button");
        //        List<Pro_ButtonData> btnsData = new List<Pro_ButtonData>();
        //        foreach (XmlNode btn in BtnList)
        //        {
        //            Pro_ButtonData btnData = new Pro_ButtonData();
        //            XmlNode xmlBtnCNName=btn.SelectSingleNode("CN_Name");
        //            XmlNode xmlBtnEGName = btn.SelectSingleNode("EG_Name");
        //            btnData.CN_Name = xmlBtnCNName.InnerText;
        //            btnData.EG_Name = xmlBtnEGName.InnerText;
        //            btnsData.Add(btnData);
        //        }
        //        List<Pro_MenuData> MenusDataChile = new List<Pro_MenuData>();
        //        //子菜单递归
        //        this.GetMenusXml(item, MenusDataChile, RolesListData, pro_GrantList);
        //        menuData.Name = xmlMenuName.InnerText;
        //        menuData.Code = xmlMenuCode.InnerText;
        //        menuData.URL = xmlMenuURL.InnerText;
        //        menuData.Buttons = btnsData;
        //        menuData.Menus = MenusDataChile;
        //        menuData.Roles = Roles;
        //        MenusData.Add(menuData);
        //    }
        //}

    }
}
