
using Ataw.Framework.Core;
using Ataw.RightCloud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DA
{
    public class DAAtaw_Gruop : RightCloudRepository<Ataw_Gruop>
    {
        public DAAtaw_Gruop(IUnitOfData dbContext)
            : base(dbContext)
        {
        }
    }
}


