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
    public class FavoritePageService : BaseService
    {
        BFAtaw_FavoritePage bf = new BFAtaw_FavoritePage();

        public ResponseData<string> SaveFavorite(string EName, string FolderName, string Url)
        {
            ResponseData<string> data = new ResponseData<string>();
            bf.SaveFavorite(EName, FolderName, Url);
            bf.Submit();

            data.Data = "ok";
            data = setData<string>(data);

            return data;
        }

        public ResponseData<IEnumerable<ComboData>> GetFile(string url)
        {
            ResponseData<IEnumerable<ComboData>> data = new ResponseData<IEnumerable<ComboData>>();
            List<ComboData> itemlsit = bf.GetFile();

            data.Content = bf.GetIsMark(url);
            data.Data = itemlsit;
            data = setData<IEnumerable<ComboData>>(data);

            return data;
        }
    }
}
