using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ataw.RightCloud.Core
{
    public class Pro_GrantData
    {
        [XmlAttribute("Enable")]
        public bool Enable { get; set; }
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        [XmlArrayItem("ButtonCode")]
        public List<string> G_ButtonsCode { get; set; }
    }
}
