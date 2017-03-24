using Ataw.Framework.Core;
using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DA.Comment
{
    public class DAAtaw_Replay: RightCloudRepository<Sns_Replay>
    {
        public DAAtaw_Replay(IUnitOfData dbContext)
            : base(dbContext)
        { }
    }
}
