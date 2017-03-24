using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.BF;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.DB;
using Ataw.Framework.Core;


namespace Ataw.RightCloud.Service
{
    public class MenuService : BaseService, IMenu
    {
        public ResponseData<IEnumerable<MenuData>> getMenu(IEnumerable<string> fids)
        {
            var bf = new BFAtaw_Menus();

            ResponseData<IEnumerable<MenuData>> Data = new ResponseData<IEnumerable<MenuData>>();

            List<MenuData> List = new List<MenuData>();
            String[] fidList = fids.ToArray();
            for (int i = 0; i < fidList.Count(); i++)
            {
                MenuData data = new MenuData();
                data = bf.getMenu(fidList[i]);
                List.Add(data);
            }

            Data.Data = List;
            Data = setData<IEnumerable<MenuData>>(Data);
            return Data;
        }

        public ResponseData<IEnumerable<MenuDetailData>> getMenuDetail(IEnumerable<string> fids)
        {
            var bf = new BFAtaw_Menus();

            ResponseData<IEnumerable<MenuDetailData>> Data = new ResponseData<IEnumerable<MenuDetailData>>();

            List<MenuDetailData> List = new List<MenuDetailData>();
            String[] fidList = fids.ToArray();
            for (int i = 0; i < fidList.Count(); i++)
            {
                MenuDetailData data = new MenuDetailData();
                data = bf.getMenuDetail(fidList[i]);
                List.Add(data);
            }

            Data.Data = List;
            Data = setData<IEnumerable<MenuDetailData>>(Data);
            return Data;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="text"></param>
        /// <param name="kind"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public ResponseData<PagerListData<MenuData>> searchMenuDetail(string partenId, string menuName, string kind, Ataw.RightCloud.Api.Pagination pager)
        {
            //将参数传到BF 然后分页
            var bf = new BFAtaw_Menus();

            var DetailData = bf.Pagination(pager, partenId, menuName);

            ResponseData<PagerListData<MenuData>> Data = new ResponseData<PagerListData<MenuData>>();
            Data.Data = DetailData;

            Data = setData<PagerListData<MenuData>>(Data);

            return Data;

        }



        public ResponseData<string> delMenu(IEnumerable<string> fids)
        {
            ResponseData<string> data = new ResponseData<string>();
            var bf = new BFAtaw_Menus();
            string[] fid = fids.ToArray();

            //首先判断是否有子菜单
            try
            {
                for (int i = 0; i < fid.Length; i++)
                {
                    if (bf.CheckHasChild(fid[i]))
                    {
                        bf.delMenu(fid[i]);
                    }
                    else
                    {
                        var model = bf.getMenu(fid[i]);
                        throw new AtawException("“{0}” 下有子节点不能删除，若要删除的话请删除子节点".AkFormat(model.MenuName), this);
                    }

                }
                bf.Submit();
                data.Data = "ok";
                data = setData<string>(data);
            }
            catch (Exception ex)
            {
                data.Data = "error";
                data.Data = ex.ToString();
                throw ex;
            }


            return data;

        }

        public ResponseData<string[]> newMenu(IEnumerable<MenuDetailData> menus)
        {
            var context = new RightCloudDBContext();
            var bf = new BFAtaw_Menus();
            var bfbutton = new BFAtaw_Menus_Button();
            ResponseData<string[]> data = new ResponseData<string[]>();
            List<string> list = new List<string>();
            bf.SetUnitOfData(context);
            bfbutton.SetUnitOfData(context);
            try
            {
                foreach (var menu in menus)
                {
                    string fid = bf.AddMenu(menu);
                    bfbutton.AddMenuButton(menu.MenuButtonList, menu.Key);
                    list.Add(fid);
                }
                bf.Submit();
                data.Data = list.ToArray(); //添加之后的fid集合
                data = setData<string[]>(data);
                data.Content = "ok";
            }
            catch (Exception e)
            {
                data.Content = "error";
                data.Data = new string[] { e.ToString() };
                throw e;
            }

            return data;
        }

        public ResponseData<string[]> updateMenu(IEnumerable<MenuDetailData> menus)
        {
            RightCloudDBContext db = new RightCloudDBContext();
            var bf = new BFAtaw_Menus();
            bf.SetUnitOfData(db);
            var bfbutton = new BFAtaw_Menus_Button();
            bfbutton.SetUnitOfData(db);
            ResponseData<string[]> data = new ResponseData<string[]>();
            List<string> list = new List<string>();
            try
            {
                foreach (var menu in menus)
                {
                    string fid = bf.UpdateMenu(menu);
                    if (menu.MenuButtonList != null)
                    {
                        //判断 增加 或者 删除
                        bfbutton.UpdateMenuButton(menu.MenuButtonList, menu.FID);
                    }

                    if (menu.DeleteButtonList != null)
                    {
                        bfbutton.deleteButtonList(menu.DeleteButtonList);
                    }

                    list.Add(fid);
                }
                bf.Submit();
                data.Data = list.ToArray(); //添加之后的fid集合
                data = setData<string[]>(data);
                data.Content = "ok";
            }
            catch (Exception e)
            {
                data.Content = "error";
                data.Data = new string[] { e.ToString() };
                throw e;
            }

            return data;
        }




        public ResponseData<ParentsMenuData> getParentMenuDetail(string fid)
        {
            ResponseData<ParentsMenuData> data = new ResponseData<ParentsMenuData>();
            var bf = new BFAtaw_Menus();

            var model = bf.getMenu(fid);
            var _model = new ParentsMenuData();
            if (model != null)
            {
                _model.fid = model.FID;
                _model.Name = model.MenuName;
            }
            data.Data = _model;
            data.Content = "ok";
            data.Time = DateTime.Now;

            return data;
        }


        public string getFid()
        {
            var bf = new BFAtaw_Menus();
            return bf.getUFid();

        }
    }
}
