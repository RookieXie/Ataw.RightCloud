using Ataw.Framework.Core;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.Api.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Service
{
    public class TestFeed : IFeed
    {

        public ResponseData<FeedData> getFirstFeed()
        {
            var res = new ResponseData<FeedData>();
            res.Data = getData(null) ;

            return res;
        }


        private FeedData getData(DateTime? time)
        {
            AtawDbContext db = AtawAppContext.Current.CreateDbContext();
            DataSet ds;
            if (time == null)
            {
                 ds = db.QueryDataSet(" select top 20 n.FID,  n.USERID, u.NickName , n.SACT_SUBCONTENT,n.CREATE_TIME from SNS_ACTIVITIES n "
                + " inner join Ataw_Users u on u.UserID = n.USERID  where n.FControlUnitID = '{0}'  order by n.FID desc ".AkFormat(AtawAppContext.Current.FControlUnitID));
            }
            else {
                ds = db.QueryDataSet(" select top 20 n.FID,  n.USERID, u.NickName , n.SACT_SUBCONTENT,n.CREATE_TIME from SNS_ACTIVITIES n "
              + " inner join Ataw_Users u on u.UserID = n.USERID  where n.FControlUnitID = '{0}' AND   n.CREATE_TIME < @time order by n.FID desc ".AkFormat(AtawAppContext.Current.FControlUnitID), new SqlParameter()
              { 
               DbType = DbType.DateTime , Value = time , ParameterName = "@time"
              });
            }

            DataTable dt = ds.Tables[0];
            List<NewData> list = new List<NewData>();
            foreach (DataRow row in dt.Rows)
            {
                NewData _new = new NewData();
                _new.FID = row["FID"].ToString();
                _new.Content = row["SACT_SUBCONTENT"].ToString() ;
                _new.CreateDateTime = row["CREATE_TIME"].Value<DateTime>();
                _new.FromUserId = row["USERID"].ToString();
                _new.FromUserName = row["NickName"].ToString();
                _new.DayString = _new.CreateDateTime.Date.ToString();
                list.Add(_new);

            }

            var _groups = list.GroupBy(a => a.DayString).ToList();
            FeedData data = new FeedData();
            data.DayNewList = new List<DayNewData>();
            _groups.ForEach((a) =>
            {
                DayNewData _day = new DayNewData();
                _day.DayString = a.Key;
                _day.NewDataList = new List<NewData>();
                a.ToList().ForEach((n) =>
                {
                    _day.NewDataList.Add(n);
                });

                data.DayNewList.Add(_day);
            });
            return data;
        }

        public ResponseData<FeedData> getFeed(DateTime lastTime)
        {
            var res = new ResponseData<FeedData>();
            res.Data = getData(lastTime);
            return res;
        }
    }
}
