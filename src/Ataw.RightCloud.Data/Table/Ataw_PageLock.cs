using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Data
{
    public class Ataw_PageLock : AtawBaseModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string PL_UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PL_Pwd { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int? PL_IsLock { get; set; }

    }
}
