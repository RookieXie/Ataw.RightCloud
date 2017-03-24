using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Plug.ColdeTable
{
    [CodePlug("XmlFilesTreeCodeTable", BaseClass = typeof(CodeTable<CodeDataModel>),
       CreateDate = "2017-03-13", Author = "xbg", Description = "xml浏览")]
    public class XmlFilesTreeCodeTable : SimpleDataTreeCodeTable
    {

        private List<TreeCodeTableModel> fFileDataList;
        protected override IEnumerable<TreeCodeTableModel> SimpleDataList
        {
            get;
            set;
        }
        public XmlFilesTreeCodeTable()
        {
            fFileDataList = new List<TreeCodeTableModel>();
            fFileDataList.Add(new TreeCodeTableModel()
            {
                ParentId = "0",
                CODE_TEXT = "xml",
                CODE_VALUE = "xml",
                isParent = true,
                IsLeaf = false
            });


            SimpleDataList = fFileDataList.OrderByDescending(a => a.Order);
        }
        public override TreeCodeTableModel GetChildrenNode(string key)
        {
            List<TreeCodeTableModel> TreeChile = new List<TreeCodeTableModel>();
            string _webRoot = AtawAppContext.Current.BinPath;
            string _filePath = Path.Combine(_webRoot, "../");
            DirectoryInfo _root = new DirectoryInfo(_filePath);
            DirectoryInfo[] dirs = _root.GetDirectories();

            foreach (var dir in dirs)
            {
                if (dir.Name == "xml")
                {
                    TreeChile = getChildrenNodeList(dir);
                    key = dir.Name;
                }
            }
            TreeCodeTableModel root = new TreeCodeTableModel()
            {
                CODE_TEXT = "",
                CODE_VALUE = key,
                IsLeaf = false,
                isParent = true,
                nocheck = true
                //IsSelect = true
            };
            root.Children = TreeChile;

            return root;
        }

        public List<TreeCodeTableModel> getChildrenNodeList(DirectoryInfo dir)
        {
            List<TreeCodeTableModel> TreeChile = new List<TreeCodeTableModel>();
            var dirs = dir.GetDirectories();
            var files = dir.GetFiles();
            foreach (var item in dirs)
            {
                if (!item.Attributes.HasFlag(FileAttributes.Hidden) && !item.Attributes.HasFlag(FileAttributes.System))
                {
                    try
                    {
                        var _dirs = item.GetDirectories();
                        var hasfile = false;
                        var _files = item.GetFiles();
                        foreach (var _file in _files)
                        {
                            if (_file.Extension == "." + this.Param)
                            {
                                hasfile = true;
                            }
                        }
                        if (hasfile)
                        {
                            var _root = this.getChildrenNodeList(item);
                            TreeChile.Add(new TreeCodeTableModel()
                            {
                                ParentId = dir.Name,
                                CODE_TEXT = item.Name,
                                CODE_VALUE = item.FullName,
                                isParent = _dirs.Length > 0 || hasfile ? true : false,
                                IsLeaf = false,
                                Children = _root,
                                Order = 2
                            });
                        }

                    }
                    catch (Exception)
                    {
                        //什么都不做 
                    }
                }
            }
            foreach (var _file in files)
            {
                if (_file.Extension == "." + this.Param)
                {
                    TreeChile.Add(new TreeCodeTableModel()
                    {
                        ParentId = dir.Name,
                        CODE_TEXT = _file.Name,
                        CODE_VALUE = _file.FullName,
                        isParent = false,
                        IsLeaf = false,
                        Order = 1,
                    });
                }
            }

            return TreeChile;

        }
    }
}
