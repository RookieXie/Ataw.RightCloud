
using Ataw.Framework.Core;
using Ataw.RightCloud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DA
{
    public class DAAtaw_Menus_Button : RightCloudRepository<Ataw_Menus_Button>
    {
        public DAAtaw_Menus_Button(IUnitOfData dbContext)
            : base(dbContext)
        {
        }


    }
}


