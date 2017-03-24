using Ataw.Framework.Core;
using Ataw.RightCloud.Core;
using Ataw.RightCloud.Data.View.App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Service.App
{
   public class AppService
    {

       public AppMenu getAllAppMenu()
       {
           return this.fGetAllAppMenu();
       }

       private List<ProductData> getAllProductData()
       {
           List<ProductData> list = new List<ProductData>();
           var path = Path.Combine(AtawAppContext.Current.BinPath, AtawApplicationConfig.REAL_PATH, "Product");
           var filese = Directory.GetFiles(path);
           foreach (var filePath in filese)
           {
              var    productData = ProductData.ReadConfig(AtawAppContext.Current.BinPath, filePath);
              list.Add(productData);
           }
           return list;
       }




       private AppMenu fGetAllAppMenu()
       {
           AppMenu app = new AppMenu();
           app.Children = new List<AppMenu>();
           var _pList = this.getAllProductData();
           foreach (ProductData p in _pList) {
               this.mergeTree(app,p.Menus);
              // p.Menus
           
           }


           return app;
       }



       private bool fIsEqMenu(AppMenu app,Pro_MenuData pro)
       {
           if (app.Children != null && pro.Children != null )
           {
               return app.Name == pro.Name;
           }
           else {
               return app.Url == pro.URL;
           }
       }
       /// <summary>
       /// 深度合并太难写 用浅合并吧
       /// </summary>
       /// <param name="app"></param>
       /// <param name="p"></param>
       private void mergeTree(AppMenu app, List<Pro_MenuData> pMenus)
       {
           List<AppMenu> addMenusList = new List<AppMenu>();

           foreach (var _pMenu in pMenus)
           {
               bool isExit = false;
               foreach (var _aMenu in app.Children) {
                  
                   if ( this.fIsEqMenu(   _aMenu, _pMenu)) {
                       isExit = true;
                       if (_pMenu.Children != null)
                       {
                           this.mergeTree(_aMenu, _pMenu.Children);
                       }
                       
                       break;
                   }
               }

               if (!isExit) {
                   addMenusList.Add(this.intoAppMenu(_pMenu));
               }
           }
           if (app.Children == null)
               app.Children = new List<AppMenu>();

           app.Children.AddRange(addMenusList);
       }

       private AppMenu intoAppMenu(Pro_MenuData pMenu)
       {
           AppMenu app = new AppMenu();
           app.Name = pMenu.Name ;
           app.Url = pMenu.URL ;
           if(pMenu.Children != null ){
           
             pMenu.Children.ForEach((p)=>{
                  if(app.Children == null){
                    app.Children = new List<AppMenu>();
                  }
                 app.Children.Add(intoAppMenu(p));

             });
           }
           return app ;
       }

    }
}
