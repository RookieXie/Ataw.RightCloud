using Ataw.Framework.Core;
using Ataw.Framework.Core.Instance;
using Ataw.Framework.Web;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.BF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Service
{
    public class RCRightConfigService: BaseService, IRCRightConfig
    {

        public ResponseData<RCGroupMenuData> initRCGroupMenuData()
        {
            var TreeData = "RCGroupCodeTable".PlugGet<CodeTable<CodeDataModel>>() as DbTreeCodeTable;//GroupCodeTable
            TreeCodeTableModel model = TreeData.GetAllTree();

            SetParentNodeOpen("20121204133633687A9C6B094A202745FEA39573AD9E10033F", model, model.Children.ToList(), false);

            // TreeCodeTableModel model = TreeData.GetDisplayTreeNode("20121204133633687A9C6B094A202745FEA39573AD9E10033F");
            RCGroupMenuData _groupMenuData = new RCGroupMenuData();
            _groupMenuData.GroupDataList = model;
            _groupMenuData.CurrentGroup = TreeData[GlobalVariable.FControlUnitID];
            //TreeData.GetDisplayTreeNode("20121204133633687A9C6B094A202745FEA39573AD9E10033F");
            //_groupMenuData.CurrentGroup = TreeData.GetChildrenNode("20121204133633873AA534462C6499452C9E2D594701E53240");

            var list = model.Children.Where(a => (a.CODE_VALUE == "0"));
            ResponseData<RCGroupMenuData> Data = new ResponseData<RCGroupMenuData>();
            Data.Data = _groupMenuData;
            Data = setData<RCGroupMenuData>(Data);
            return Data;
        }
        public ResponseData<RCDepartmentData> initRCRCDepartmentData()
        {
            var TreeData = "RCDepartmentCodeTable".PlugGet<CodeTable<CodeDataModel>>() as DbTreeCodeTable;//GroupCodeTable
            TreeCodeTableModel model = TreeData.GetAllTree();

            SetParentNodeOpen("20121204133633687A9C6B094A202745FEA39573AD9E10033F", model, model.Children.ToList(), false);

            // TreeCodeTableModel model = TreeData.GetDisplayTreeNode("20121204133633687A9C6B094A202745FEA39573AD9E10033F");
            RCDepartmentData _RCDepartmentData = new RCDepartmentData();
            _RCDepartmentData.RCDepartmentDataList = model;
            _RCDepartmentData.CurrentGroup = TreeData[GlobalVariable.FControlUnitID];
            //TreeData.GetDisplayTreeNode("20121204133633687A9C6B094A202745FEA39573AD9E10033F");
            //_groupMenuData.CurrentGroup = TreeData.GetChildrenNode("20121204133633873AA534462C6499452C9E2D594701E53240");

            var list = model.Children.Where(a => (a.CODE_VALUE == "0"));
            ResponseData<RCDepartmentData> Data = new ResponseData<RCDepartmentData>();
            Data.Data = _RCDepartmentData;
            Data = setData<RCDepartmentData>(Data);
            return Data;
        }
        /// <summary>
        /// 对树形数据进行处理，将open设置为true
        /// </summary>
        /// <param name="val">当前组织</param>
        /// <param name="root">所有数据</param>
        /// <param name="children"></param>
        /// <param name="isFinish"></param>
        public void SetParentNodeOpen(string val, TreeCodeTableModel root, List<TreeCodeTableModel> children, bool isFinish)
        {
            if (isFinish)
            {
                return;
            }
            foreach (TreeCodeTableModel model in children)
            {
                var childModel = model.Children.Where(a => a.CODE_VALUE == val).FirstOrDefault();
                if (childModel == null)
                {
                    SetParentNodeOpen(val, root, model.Children.ToList(), false);
                }
                else
                {
                    model.open = true;
                    SetParentNodeOpen(model.CODE_VALUE, root, root.Children.ToList(), model.ParentId.IsEmpty() ? true : false);
                }
            }
        }

        public string getFid()
        {
            var bf = new BFRC_Group_tree();
            return bf.getUFid();
        }
    }
}
