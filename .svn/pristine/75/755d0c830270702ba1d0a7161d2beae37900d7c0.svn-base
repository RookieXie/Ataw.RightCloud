using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.BF;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.Service
{
    public class GroupTreeService : IGroupTree
    {
        public Api.Data.RightGrouTree init()
        {
            throw new NotImplementedException();
        }

        public string modify(Api.Data.GroupData data)
        {
            throw new NotImplementedException();
        }

        public RightGroup getOrgCode(string code)
        {
            BFAtaw_Gruop bf = new BFAtaw_Gruop();
            Ataw_Gruop model = bf.GetGroupInfo(code);

            RightGroup rightmodel = new RightGroup();
            rightmodel.FID = model.GroupID;
            rightmodel.OrgName = model.GroupName;
            return rightmodel;
        }


    }
}
