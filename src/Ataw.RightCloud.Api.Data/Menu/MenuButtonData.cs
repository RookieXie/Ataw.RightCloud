using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api.Data
{
    public class MenuButtonData
    {
        public String FID { get; set; }


        public string ParentRightValue { get; set; }
        /// <summary>
        /// 按钮名字
        /// </summary>
        public String FName { get; set; }
        /// <summary>
        /// 按钮值
        /// </summary>
        public String FKey { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public String FValue { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public String OrderId { get; set; }
    }
}
