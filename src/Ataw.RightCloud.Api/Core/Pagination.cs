using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api
{
  public  class Pagination
    {
        public string TableName
        {
            get;
            set;
        }
        /// <summary>
        /// 分页索引 从0开始
        /// </summary>
        public int PageNo
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        public int TotalCount
        {
            get;
            set;
        }
        public string SortName
        {
            get;
            set;
        }
        /// <summary>
        /// 默认值是false表示 倒序排列
        /// </summary>
        public bool IsASC
        {
            get;
            set;
        }

        public DateTime DataTime
        {
            get;
            set;
        }
    }
}
