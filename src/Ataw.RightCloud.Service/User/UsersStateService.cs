using Ataw.RightCloud.BF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Service
{
    public class UsersStateService
    {
        public void OutlineState(string userID)
        {
            BFAtaw_Users_State bf = new BFAtaw_Users_State();
            bf.OutlineState(userID);
            bf.Submit();
        }
        public void OnlineState(string userID)
        {
            BFAtaw_Users_State bf = new BFAtaw_Users_State();
            bf.OnlineState(userID);
            bf.Submit();
        }
    }
}
