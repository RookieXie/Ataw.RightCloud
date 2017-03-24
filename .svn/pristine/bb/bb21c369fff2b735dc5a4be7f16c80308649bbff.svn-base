using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api.Data
{

    public class RCRightMenuButton
    {
        public string FID { get; set; }
        public string ButtonName { get; set; }
        public string ButtonValue { get; set; }
        public bool? IsHidden { get; set; }
        public string OriginalName { get; set; }
        public string Org { get; set; }
        public string Role { get; set; }
    }
    public class RCRightMenuData
    {
        public string FID { get; set; }
        public bool? isParent { get; set; }
        public bool? isLeaft { get; set; }
        public string MenuName { get; set; }
        public string OriginalName { get; set; }
        public bool? IsHidden { get; set; }
        public string RightValue { get; set; }
        public string Org { get; set; }
        public string Role { get; set; }
        public List<RCRightMenuData> Children { set; get; }
        public List<RCRightMenuButton> ButtonList { get; set; }
        public bool? isButton { get; set; }

    }
}
