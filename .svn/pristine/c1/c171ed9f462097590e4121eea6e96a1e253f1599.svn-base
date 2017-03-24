
using Ataw.Framework.Core;
using Ataw.Framework.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.RightCloud.DB;
namespace Ataw.RightCloud.DA
{
    public class RightCloudRepository<T> : Repository<T, RightCloudDBContext>, IRepository<T> where T : class
    {
        public RightCloudRepository(IUnitOfData dbContext)
            : base(dbContext as AtawDbContext)
        { 
        }       
    }
}


