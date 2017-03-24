using Ataw.Framework.Web;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.BF
{
    public class BFAtaw_SortCut : RightCloudBaseBF
    {
        public string AddShortCut(string Url, string Name)
        {
            DAPM_PageMark da = new DAPM_PageMark(UnitOfData);
            PM_PageMark data = new PM_PageMark();
            data.FID = UnitOfData.GetUniId();
            data.Web_Link = Url;
            data.Web_Name = Name;
            data.Web_Author = GlobalVariable.UserFID;
            da.Add(data);

            return data.FID;
        }

        public List<MarkData> GetSortCut()
        {
            DAPM_PageMark da = new DAPM_PageMark(UnitOfData);

            List<MarkData> list = new List<MarkData>();
            var model = da.QueryMany(a => a.ISDELETE == false || a.ISDELETE == null).ToList();

            foreach (var data in model)
            {
                MarkData MarkData = new MarkData();
                MarkData.FID = data.FID;
                MarkData.IsDelete = false;
                MarkData.Link = data.Web_Link;
                MarkData.Title = data.Web_Name;

                list.Add(MarkData);
            }

            return list;
        }

        public void SubmitShortCut(List<MarkData> ListData)
        {
            DAPM_PageMark da = new DAPM_PageMark(UnitOfData);

            foreach (var data in ListData)
            {
                var model = da.GetByKey(data.FID);
                if (data.IsDelete == true)
                {
                    model.ISDELETE = true;
                }
                if (model.Web_Name != data.Title)
                {
                    model.Web_Name = data.Title;
                }
                da.Update(model);
            }

        }

        public string GetUrl(string fid)
        {
            DAPM_PageMark da = new DAPM_PageMark(UnitOfData);
            var modle = da.GetByKey(fid);
            if (modle != null)
            {
                return modle.Web_Link;
            }
            else return "";
        }

        public string GetMarkUrl(string fid)
        {
            DAXP_Website da = new DAXP_Website(UnitOfData);
            var modle = da.GetByKey(fid);
            if (modle != null)
            {
                return modle.Ws_Url;
            }
            else return "";
        }

    }
}
