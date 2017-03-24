using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ataw.RightCloud.Core
{
    [Serializable]
    [XmlRoot("ProductDataConfig")]
    public class ProductData: FileXmlConfigBase
    {

        public static ProductData ReadConfig(string binPath, string filePath)
        {
            return XmlUtil.ReadFromFile<ProductData>(filePath);
        }
        public string Name { get; set; }
        public string Code { get; set; }
        [XmlArrayItem("Menu")]
        public List<Pro_MenuData> Menus { get; set; }
    }
}
