using Ataw.RightCloud.BF;
using Ataw.RightCloud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Service
{
    public class RCMenuTreeService
    {
        public bool CheckMenuName(string name,string pid)
        {
            BFRC_Menu_tree bfMenu = new BFRC_Menu_tree();
            var res = bfMenu.CheckMenuName(name, pid);
            return res;

        }
        public RC_Menu_tree GetMenuByFID(string fid)
        {
            BFRC_Menu_tree bfMenu = new BFRC_Menu_tree();
            return bfMenu.GetMenuByFID(fid);
        }
    }
}
