using Ataw.Framework.Core;
using Ataw.RightCloud.Data;
using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DA
{
    public class DAAtaw_PageLock : RightCloudRepository<Ataw_PageLock>
    {
        public DAAtaw_PageLock(IUnitOfData dbContext)
            : base(dbContext)
        {
        }
    }
}
