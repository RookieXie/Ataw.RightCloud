using Ataw.RightCloud.Api;
using Ataw.RightCloud.BF;
using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Service
{
    public class PageLockService : BaseService
    {
        BFAtaw_PageLock bf_pagelock = new BFAtaw_PageLock();
        public ResponseData<string> OpenLock(string Pwd)
        {
            ResponseData<string> data = new ResponseData<string>();
            var Data = bf_pagelock.OpenLock(Pwd);
            bf_pagelock.Submit();
            data.Data = Data;
            data = setData<string>(data);

            return data;
        }

        public ResponseData<string> PageLock()
        {
            ResponseData<string> data = new ResponseData<string>();
            var Data = bf_pagelock.PageLock();
            bf_pagelock.Submit();
            data.Data = Data;
            data = setData<string>(data);

            return data;
        }
        /// <summary>
        /// 获取收藏夹和页面锁定
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public ResponseData<ComboData> GetIsLock(string url)
        {
            ResponseData<ComboData> data = new ResponseData<ComboData>();
            ComboData Data = new ComboData();
            Data.IsLock = bf_pagelock.GetIsLock();
            Data.CollData = bf_pagelock.GetCollData(url);
            Data.ComboDataList = bf_pagelock.GetFile();
            Data.GroupDataList = bf_pagelock.GetTreeData();
            data.Data = Data;
            data = setData<ComboData>(data);

            return data;
        }

        public ResponseData<string> DeleteMark(string Url)
        {
            ResponseData<string> data = new ResponseData<string>();
            bf_pagelock.DeleteMark(Url);
            bf_pagelock.Submit();
            data.Data = "ok";
            data = setData<string>(data);

            return data;
        }

        public ResponseData<string> OpenCloseLock(string fid)
        {
            ResponseData<string> data = new ResponseData<string>();
            var Data = bf_pagelock.OpenCloseLock(fid);
            bf_pagelock.Submit();
            data.Data = Data;
            data = setData<string>(data);

            return data;
        }

        public ResponseData<string> SaveFavorite(MarkSubmitData SubmitData)
        {
            ResponseData<string> data = new ResponseData<string>();
            bf_pagelock.SaveFavorite(SubmitData);
            bf_pagelock.Submit();

            data.Data = "ok";
            data = setData<string>(data);

            return data;
        }

        public ResponseData<string> UpdateSubmit(MarkSubmitData SubmitData)
        {
            ResponseData<string> data = new ResponseData<string>();
            bf_pagelock.UpdateSubmit(SubmitData);
            bf_pagelock.Submit();

            data.Data = "ok";
            data = setData<string>(data);

            return data;
        }
    }
}
