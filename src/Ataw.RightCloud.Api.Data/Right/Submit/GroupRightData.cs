using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api.Data
{
    /// <summary>
    /// 组织权限实体
    /// </summary>
    public class GroupRightData
    {
        public string Operation { get; set; }

        public List<GroupExtData> GroupDataList { get; set; }

        public List<MenuExtData> MenuDataList { get; set; }

        public List<RightGrantData> GrantDataList { get; set; }
    }
}
