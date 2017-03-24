using Ataw.Framework.Web;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.BF
{
    public class BFAtaw_Users_State: RightCloudBaseBF
    {
        public void OnlineState(string userID)
        {
            DAAtaw_Users_State da = new DAAtaw_Users_State(UnitOfData);
            Ataw_Users_State model = new Ataw_Users_State();
            model.ID = UnitOfData.GetUniId();
            model.UserID = userID;
            model.IP = WebCommonClass.GetIPAddress();
            model.LifeStart = DateTime.Now;
            model.IsOnline = 1;
            model.LifeEnd = DateTime.Now.AddDays(1);
            //model.Mac=WebCommonClass
            da.Add(model);
           // Submit();

        }
        public void OutlineState(string userID)
        {
            DAAtaw_Users_State da = new DAAtaw_Users_State(UnitOfData);            
            var model=da.QueryDefault(a => a.UserID == userID && a.IsOnline==1).FirstOrDefault();
            if (model != null)
            {
                model.IsOnline = 0;
                da.Update(model);
            }
           // Submit();
        }
    }
}
