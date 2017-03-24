using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Data.Table
{
  public  class RC_UserRole : AtawBaseModel
    {
        public string UserRoleFID { get; set; }
        public string UserID { get; set; }
        public string RoleID { get; set; }
    }
}
