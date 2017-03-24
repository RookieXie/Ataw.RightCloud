using Ataw.RightCloud.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.BF.RC.Collection
{
    public class BFXP_Folder_Tree : RightCloudBaseBF
    {
        public string Checkname(string name, string pid)
        {
            DAXP_Folder_Tree da = new DAXP_Folder_Tree(this.UnitOfData);
            var Name = da.QueryDefault(a => a.F_Name == name && a.PID == pid).FirstOrDefault();
            if (Name != null)
            {
                return "Y";
            }
            else {
                return "N";
            }
        }
    }
}
