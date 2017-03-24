using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Data.Table
{
    public class ComboData
    {
        public TreeCodeTableModel GroupDataList { get; set; }
        /// <summary>
        /// 文件夹目录
        /// </summary>
        public List<CombData> ComboDataList;
        /// <summary>
        /// 是否已锁定
        /// </summary>
        public bool? IsLock { get; set; }

        public ColData CollData;
        public class ColData
        {
            /// <summary>
            /// 是否被收藏
            /// </summary>
            public bool? IsMark { get; set; }

            /// <summary>
            /// 文件夹FID
            /// </summary>
            public string FileVale { get; set; }
            /// <summary>
            /// 收藏夹名
            /// </summary>
            public string ColName { get; set; }
        }
        public class CombData
        {
            public string Value { get; set; }
            public string Text { get; set; }
        }
    }

}
