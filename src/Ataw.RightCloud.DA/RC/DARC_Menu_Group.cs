
using Ataw.Framework.Core;
using Ataw.RightCloud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DA
{
    public class DARC_Menu_Group : RightCloudRepository<RC_Menu_Group>
    {
        public DARC_Menu_Group(IUnitOfData dbContext)
            : base(dbContext)
        {
        }
    }
}


