using Ataw.RightCloud.Api;
using Ataw.RightCloud.BF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Service
{
    public class BaseService 
    {
        public ResponseData<T> setData<T>(ResponseData<T> data)
        {
            data.Time = DateTime.Now;
            data.ActionType = "ok";
            return data;
        }
    }
}
