
using Ataw.Framework.Core;
using Ataw.RightCloud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DA
{
    public class DARC_Product : RightCloudRepository<RC_Product>
    {
        public DARC_Product(IUnitOfData dbContext)
            : base(dbContext)
        {
        }
    }
}


