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
    public class SortCutController : AtawBaseController
    {
        SortCutService service = new SortCutService();
        /// <summary>
        /// 新增快捷
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public string AddShortCut(string Url, string Name)
        {
            var data = service.AddShortCut(Url, Name);
            return ReturnJson(data);
        }
        /// <summary>
        /// 获取快捷方式
        /// </summary>
        /// <returns></returns>
        public string GetSortCut()
        {
            var data = service.GetSortCut();
            return ReturnJson(data);
        }
        /// <summary>
        /// 保存快捷
        /// </summary>
        /// <param name="Submit"></param>
        /// <returns></returns>
        public string SubmitShortCut(string Submit)
        {
            List<MarkData> ListData = new List<MarkData>();
            ListData = Submit.SafeJsonObject<List<MarkData>>();

            var data = service.SubmitShortCut(ListData);
            return ReturnJson(data);
        }
        /// <summary>
        /// 获取快捷方式路由
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public string GetUrl(string fid)
        {
            var Url = service.GetUrl(fid);

            return ReturnJson(Url);
        }
        /// <summary>
        /// 获取收藏夹路由
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public string GetMarkUrl(string fid)
        {
            var Url = service.GetMarkUrl(fid);

            return ReturnJson(Url);
        }

        public string DeleteFile(string fid)
        {
            var data = service.DeleteFile(fid);

            return ReturnJson(data);
        }

        public string NewFile(string PID,string Name)
        {
            var data = service.NewFile(PID, Name);

            return ReturnJson(data);
        }


    }
}