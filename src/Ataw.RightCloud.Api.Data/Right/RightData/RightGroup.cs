using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api.Data
{
    public class RightGroup
    {
        public string FID { get; set; }
        public string OrgName { get; set; }

        //获取权限中按钮的FID的字符串
        public string Menu { get; set; }
    }
}
