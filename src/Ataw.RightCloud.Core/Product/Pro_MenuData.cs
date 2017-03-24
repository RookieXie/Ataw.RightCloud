using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ataw.RightCloud.Core
{    
    public class Pro_MenuData
    {
        public Pro_MenuData()
        {
            this.Children = new List<Pro_MenuData>();
        }
        [XmlAttribute("IsLeaf")]
        public bool IsLeaf { get; set; }
        [XmlAttribute("IsHidden")]
        public bool IsHidden { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string URL { get; set; }
        [XmlArrayItem("Grant")]
        public List<Pro_GrantData> Grants { get; set; }
        [XmlArrayItem("Button")]
        public List<Pro_ButtonData> Buttons { get; set; }
        [XmlArrayItem("Menu")]
        public List<Pro_MenuData> Children { get; set; }
    }
}
