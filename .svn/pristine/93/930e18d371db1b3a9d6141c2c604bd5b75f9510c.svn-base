using Ataw.Framework.Core;
using Ataw.Framework.Web;
using Ataw.RightCloud.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ataw.RightCloud.Web
{
    public class XmlController : AtawBaseController
    {
        public string GetProductXml(string xml)
        {
            XmlService servive = new XmlService();
            var m = servive.getProductXml(xml);
            return ReturnJson(m);
        }
        [ValidateInput(false)]
        public string SaveProductXml(string xml, string data)
        {
            XmlService service = new XmlService();
            List<string> ModuleXmlStrList = data.SafeJsonObject<List<string>>();
            var res = service.saveProductXml(xml, ModuleXmlStrList);
            return ReturnJson(res);
        }
        //GET: Xml
        public ActionResult Index()
        {
            return View();
        }

        public string GetXmlFileContent(string xmlPath)
        {
            XmlService servive = new XmlService();
            var m = servive.GetXmlFileContent(xmlPath);
            return ReturnJson(m);
        }
        [ValidateInput(false)]
        public string SaveXmlFile(string xml, string data)
        {
            XmlService service = new XmlService();
            List<string> ModuleXmlStrList = data.SafeJsonObject<List<string>>();
            var res = service.SaveXmlFile(xml, ModuleXmlStrList);
            return ReturnJson(res);
        }
    }
}