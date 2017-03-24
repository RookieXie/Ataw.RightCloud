using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ataw.RightCloud.Core
{

    public class RCProductData
    {
        public List<RCProductsDetail> Products { get; set; }
    }
    public class RCProductsDetail
    {
        public string xmlPath { get; set; }
        public ProductData ProductData { get; set; }
    }
    public class RCProductXmlData
    {
        public List<RCProductXml> productXmlList { get; set; }
    }
    public class RCProductXml
    {
        public string xmlPath { get; set; }
        public string xmlName { get; set; }
        public List<string> xmlContent { get; set; }
    }
}
