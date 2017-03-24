using Ataw.Framework.Web;
using Ataw.RightCloud.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ataw.Framework.Core;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data;

namespace Ataw.RightCloud.Web
{
    [RightFilter]
    public class MenuController : AtawBaseController
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public string searchMenuDetail(string partenId, string menuName, string kind, string pager)
        {
            var _pager = pager.SafeJsonObject<Api.Pagination>();
            MenuService meun = new MenuService();
            var _js = meun.searchMenuDetail(partenId, menuName, kind, _pager);
            return ReturnJson(_js);
        }

        //多个fid用逗号隔开相连
        public string getMenu(string fids)
        {
            MenuService meun = new MenuService();
            if (fids == null) fids = "";
            var data = meun.getMenu(fids.Split(','));
            return ReturnJson(data);
        }

        public string getMenuDetail(string fids)
        {
            MenuService meun = new MenuService();
            if (fids == null) fids = "";
            var data = meun.getMenuDetail(fids.Split(','));
            return ReturnJson(data);
        }


        public string delMenu(string fids)
        {
            MenuService meun = new MenuService();
            if (fids == null) fids = "";
            var data = meun.delMenu(fids.Split(','));
            return ReturnJson(data);
        }

        public string newMenu(string menus)
        {
            var _menus = menus.SafeJsonObject<List<MenuDetailData>>();
            MenuService meun = new MenuService();
            var data = meun.newMenu(_menus);
            return ReturnJson(data);
        }

        public ActionResult TestMenuAdd()
        {
            return View();
        }

        public string updateMenu(string menus)
        {
            var _menus = menus.SafeJsonObject<List<MenuDetailData>>();
            MenuService meun = new MenuService();
            var data = meun.updateMenu(_menus);
            return ReturnJson(data);
        }

        public string getParentMenuDetail(string fids)
        {

            MenuService meun = new MenuService();
            var data = meun.getParentMenuDetail(fids);
            return ReturnJson(data);
        }
    }
}