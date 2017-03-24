using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api.Data
{
    /// <summary>
    /// 前台初始化实体
    /// sq
    /// </summary>
    public class GroupMenuData
    {
        public TreeCodeTableModel GroupDataList { get; set; }
        public List<MenuData> MenuDataList { get; set; }
        public CodeDataModel CurrentGroup { get; set; } //用户选中前组织信息
    }

}
