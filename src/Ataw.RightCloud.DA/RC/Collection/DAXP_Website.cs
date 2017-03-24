using Ataw.Framework.Core;
using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DA
{
    public class DAXP_Website : RightCloudRepository<XP_WebSite>
    {
        public DAXP_Website(IUnitOfData dbContext)
            : base(dbContext)
        {
        }
    }
}
