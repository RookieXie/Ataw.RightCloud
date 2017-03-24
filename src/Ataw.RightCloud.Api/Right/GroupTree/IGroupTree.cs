using Ataw.RightCloud.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api
{
    public interface IGroupTree
    {
        /// <summary>
        /// 初始化组织
        /// </summary>
        /// <returns></returns>
        RightGrouTree init();

        /// <summary> 
        /// 修改组织
        /// </summary>
        /// <returns></returns>
        string modify(GroupData data);
    }
}
