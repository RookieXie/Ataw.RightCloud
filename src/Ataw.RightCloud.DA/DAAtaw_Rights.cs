
using Ataw.Framework.Core;
using Ataw.RightCloud.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DA
{
    public class DAAtaw_Rights : RightCloudRepository<Ataw_Rights>
    {
        public DAAtaw_Rights(IUnitOfData dbContext)
            : base(dbContext)
        {
        }

    }
}


