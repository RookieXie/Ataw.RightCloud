using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api.Data
{
    public class MenuData
    {
        public string FID { get; set; }
        public string MenuName { get; set; }
        public string RightValue { get; set; }
        public string ParentId { get; set; }
        public string ParentName { get; set; }
        public string RightKindId { get; set; }
        public string RightKindName { get; set; }
        public string RightDesc { get; set; }
        public string Key { get; set; }
        public string IconUrl { get; set; }
        public string IconName { get; set; }
        public string KeyType { get; set; }
        public string UPDATE_TIME { get; set; }
        public bool? IsParent { get; set; }
        public string FControlUnitID { get; set; }

        public string MenuType { get; set; }
        

    }
}
