
using Ataw.Framework.Core;
using Ataw.RightCloud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DA
{
    public class DAAtaw_Menus : RightCloudRepository<Ataw_Menus>
    {
        public DAAtaw_Menus(IUnitOfData dbContext)
            : base(dbContext)
        {
        }


    }
}


