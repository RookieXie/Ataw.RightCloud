
using Ataw.Framework.Core;
using Ataw.RightCloud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DA
{
    public class DARC_Product_Role : RightCloudRepository<RC_Product_Role>
    {
        public DARC_Product_Role(IUnitOfData dbContext)
            : base(dbContext)
        {
        }
    }
}


