
using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Service
{
    public class XmlService
    {
        public List<string> getProductXml(string xml)
        {
            string _param;
            string path = Xml(xml, out _param);
            var list = this.getCodeFile(path).ToList();
            return list;
        }

        public string Xml(string xml, out string param)
        {
            if (xml.IndexOf("-") > 1)
            {
                string[] _paramList = xml.Split('-');
                xml = _paramList[0];
                param = _paramList[1];
            }
            else
            {
                param = "";
            }
            if (xml.IndexOf(".xml") == -1)
            {
                xml = xml + ".xml";
            }
            return xml;
        }

        public string[] getCodeFile(string path)
        {
            string _root = AtawAppContext.Current.BinPath;
            AtawDebug.Assert(!path.IsAkEmpty() && path[0] != '/' && path.IndexOf("..") < 0,
                "不可以访问其他目录", this);
            string _filePath = Path.Combine(_root, "../", "xml/");
            _filePath = _filePath + path;
            string strs = FileUtil.ReadStringByFile(_filePath);
            string[] sp = new string[] { Environment.NewLine };
            var list = strs.Split(sp, StringSplitOptions.None);
            return list;
        }

        public bool saveProductXml(string xml, List<string> ModuleXmlStrList)
        {
            try
            {
                string _param;
                string xmlpath = Xml(xml, out _param);
                string _root = AtawAppContext.Current.BinPath;
                AtawDebug.Assert(!xmlpath.IsAkEmpty() && xmlpath[0] != '/' && xmlpath.IndexOf("..") < 0, "不可以访问其他目录", this);
                string _ModelPath = Path.Combine(_root, "../", "xml", xmlpath);
                string contentMode = "";
                foreach (var item in ModuleXmlStrList)
                {
                    contentMode += item + Environment.NewLine;
                }

                FileUtil.VerifySaveFile(_ModelPath, contentMode, Encoding.UTF8);
                return true;
            }
            catch (Exception)
            {
                return true;
                throw;
            }
        }

        public List<string> GetXmlFileContent(string xmlPath)
        {
            string _param;
            string path = Xml(xmlPath, out _param);
            var list = this.getXmlFile(path).ToList();
            return list;
        }
        public string[] getXmlFile(string path)
        {
            string _root = AtawAppContext.Current.BinPath;
            AtawDebug.Assert(!path.IsAkEmpty() && path[0] != '/' && path.IndexOf("..") < 0,
                "不可以访问其他目录", this);
            string strs = FileUtil.ReadStringByFile(path);
            string[] sp = new string[] { Environment.NewLine };
            var list = strs.Split(sp, StringSplitOptions.None);
            return list;
        }

        public bool SaveXmlFile(string xml, List<string> ModuleXmlStrList)
        {
            try
            {
                string _param;
                string xmlpath = Xml(xml, out _param);
                string _root = AtawAppContext.Current.BinPath;
                AtawDebug.Assert(!xmlpath.IsAkEmpty() && xmlpath[0] != '/' && xmlpath.IndexOf("..") < 0, "不可以访问其他目录", this);
                string _ModelPath = xmlpath;
                string contentMode = "";
                foreach (var item in ModuleXmlStrList)
                {
                    contentMode += item + Environment.NewLine;
                }

                FileUtil.VerifySaveFile(_ModelPath, contentMode, Encoding.UTF8);
                return true;
            }
            catch (Exception)
            {
                return true;
                throw;
            }
        }
    }
}
