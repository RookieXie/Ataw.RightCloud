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
    public class SortCutService : BaseService
    {
        BFAtaw_SortCut bf_sort = new BFAtaw_SortCut();
        BFXP_WebSite bf_mark = new BFXP_WebSite();
        public ResponseData<string> AddShortCut(string Url, string Name)
        {
            ResponseData<string> data = new ResponseData<string>();
            bf_sort.AddShortCut(Url, Name);
            bf_sort.Submit();

            data.Data = "ok";
            data = setData<string>(data);

            return data;
        }

        public List<MarkData> GetSortCut()
        {
            List<MarkData> data = bf_sort.GetSortCut();

            return data;
        }

        public ResponseData<string> SubmitShortCut(List<MarkData> MarkData)
        {
            ResponseData<string> data = new ResponseData<string>();
            bf_sort.SubmitShortCut(MarkData);
            bf_sort.Submit();

            data.Data = "ok";
            data = setData<string>(data);

            return data;
        }

        public ResponseData<string> GetUrl(string fid)
        {
            ResponseData<string> data = new ResponseData<string>();
            var Url =  bf_sort.GetUrl(fid);

            data.Data = Url;
            data = setData<string>(data);

            return data;

        }

        public ResponseData<string> GetMarkUrl(string fid)
        {
            ResponseData<string> data = new ResponseData<string>();
            var Url = bf_sort.GetMarkUrl(fid);

            data.Data = Url;
            data = setData<string>(data);

            return data;

        }

        public ResponseData<string> DeleteFile(string fid)
        {
            ResponseData<string> data = new ResponseData<string>();
            var Url = bf_mark.DeleteFile(fid);
            bf_mark.Submit();
            data.Data = Url;
            data = setData<string>(data);

            return data;

        }

        public ResponseData<string> NewFile(string PID,string Name)
        {
            ResponseData<string> data = new ResponseData<string>();
            var Url = bf_mark.NewFile(PID, Name);
            bf_mark.Submit();
            data.Data = Url;
            data = setData<string>(data);

            return data;

        }

    }
}
