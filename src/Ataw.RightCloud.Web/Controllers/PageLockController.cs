using Ataw.Framework.Core;
using Ataw.Framework.Web;
using Ataw.RightCloud.Data.Table;
using Ataw.RightCloud.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ataw.RightCloud.Web
{
    public class PageLockController : AtawBaseController
    {
        PageLockService service = new PageLockService();
        /// <summary>
        /// 解锁 
        /// </summary>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public string OpenLock(string Pwd)
        {
            var data = service.OpenLock(Pwd);
            return ReturnJson(data);
        }
        /// <summary>
        /// 锁定页面
        /// </summary>
        /// <returns></returns>
        public string PageLock()
        {
            var data = service.PageLock();
            return ReturnJson(data);
        }
        /// <summary>
        /// 获取页面锁定收藏数据
        /// </summary>
        /// <returns></returns>
        public string GetIsLock(string url)
        {
            var data = service.GetIsLock(url);
            return ReturnJson(data);
        }

        public string DeleteMark(string Url)
        {
            var data = service.DeleteMark(Url);
            return ReturnJson(data);
        }
        /// <summary>
        /// 页面锁定配置页面按钮
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public string OpenCloseLock(string fid)
        {
            var data = service.OpenCloseLock(fid);
            return ReturnJson(data);
        }
        /// <summary>
        /// 保存收藏夹
        /// </summary>
        /// <param name="EName"></param>
        /// <param name="FolderName"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        public string SaveFavorite(string Submit)
        {
            var submit = Submit.SafeJsonObject<MarkSubmitData>();
            var data = service.SaveFavorite(submit);
            return ReturnJson(data);
        }
    }
}