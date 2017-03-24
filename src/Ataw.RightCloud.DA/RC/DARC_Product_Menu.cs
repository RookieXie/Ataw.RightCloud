
using Ataw.Framework.Core;
using Ataw.RightCloud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DA
{
    public class DARC_Product_Menu : RightCloudRepository<RC_Product_Menu>
    {
        public DARC_Product_Menu(IUnitOfData dbContext)
            : base(dbContext)
        {
        }
    }
}


