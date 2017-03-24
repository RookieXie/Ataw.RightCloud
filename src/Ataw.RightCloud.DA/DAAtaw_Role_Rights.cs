
using Ataw.Framework.Core;
using Ataw.RightCloud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DA
{
    public class DAAtaw_Role_Rights : RightCloudRepository<Ataw_Role_Rights>
    {
        public DAAtaw_Role_Rights(IUnitOfData dbContext)
            : base(dbContext)
        {
        }
    }
}


