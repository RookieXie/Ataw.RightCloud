using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api.Data
{
    public class MenuDetailData : MenuData
    {
 
        /// <summary>
        /// 菜单描述
        /// </summary>
      //  public string RightDesc { get; set; }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int? OrderId { get; set; }

        public string MenuKindId { get; set; }

        public string MenuKindName { get; set; }

        public string Operation { get; set; }

        public List<MenuButtonData> MenuButtonList { get; set; }


        public List<string> DeleteButtonList { get; set; }
    }
}
