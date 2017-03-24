using Ataw.Framework.Core;
using Ataw.RightCloud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DA
{
    public class DAAtaw_Users_State : RightCloudRepository<Ataw_Users_State>
    {
        public DAAtaw_Users_State(IUnitOfData dbContext)
            : base(dbContext)
        {

        }
    }
}


