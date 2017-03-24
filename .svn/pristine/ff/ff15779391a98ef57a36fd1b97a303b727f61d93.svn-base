
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ataw.Framework.Core;
using Ataw.RightCloud.DB;

namespace Ataw.RightCloud.BF
{
    public class RightCloudBaseBF : IDisposable
    {
        private IUnitOfData fUnitOfData;

        public void FixEfProviderServicesProblem()
        {

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public RightCloudBaseBF SetUnitOfData(string conn)
        {
            fUnitOfData = new RightCloudDBContext(conn);
            return this;
        }

        public RightCloudBaseBF SetUnitOfData(IUnitOfData unitOfData)
        {
            if (unitOfData != null)
            {
                fUnitOfData = unitOfData;
            }
            return this;
        }

        public IUnitOfData UnitOfData
        {
            get
            {
                if (fUnitOfData == null)
                {
                    fUnitOfData = new RightCloudDBContext();
                    // fUnitOfData.db
                }
                return fUnitOfData;
            }
        }

        public int Submit()
        {
            return UnitOfData.Submit();
        }

        public void Dispose()
        {
            if (fUnitOfData != null)
            {
                fUnitOfData.Dispose();
            }
            // throw new NotImplementedException();
        }

        public static RightCloudDBContext FetchDbContext()
        {
            return new RightCloudDBContext();
        }


    }
}

