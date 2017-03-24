using Ataw.Framework.Core;
using Ataw.Framework.Core.Instance;
using Ataw.Framework.Web;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.Api.Data.RightConfig;
using Ataw.RightCloud.Api.RightConfig;
using Ataw.RightCloud.BF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Service
{
    public class RightConfigService : BaseService, IRightConfig
    {
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

        public List<InitMenuData> GetMenuData(String FControlUnitID)
        {
            var bf_rightconfig = new BFRightCofig();
            List<InitMenuData> _MenuDetailDataList = bf_rightconfig.GetMenuData(FControlUnitID);
            return _MenuDetailDataList;
        }
        public string SaveMenuData(List<InitMenuData> mode)
        {
            var bf_rightconfig = new BFRightCofig();
            var data = bf_rightconfig.SaveMenuData(mode);
            return data;
        }
        public string GroupSubmit()
        {
            throw new NotImplementedException();
        }

        public string GroupEdit()
        {
            throw new NotImplementedException();
        }
        public ResponseData<GroupMenuData> initGroupidCode(string Group)
        {
            var TreeData = "GroupCodeTable".PlugGet<CodeTable<CodeDataModel>>() as DbTreeCodeTable;
            GroupMenuData _groupMenuData = new GroupMenuData();
            BFRightCofig _rightcofig = new BFRightCofig();

            //if (group.IsAkEmpty())
            //{
            //    _groupMenuData.CurrentGroup = TreeData[GlobalVariable.FControlUnitID];
            //}
            //else
            _groupMenuData.CurrentGroup = TreeData[Group];

            ResponseData<GroupMenuData> Data = new ResponseData<GroupMenuData>();
            Data.Data = _groupMenuData;
            Data = setData<GroupMenuData>(Data);
            return Data;
        }

        public ResponseData<GroupMenuData> initGroupMenuData()
        {
            var TreeData = "GroupCodeTable".PlugGet<CodeTable<CodeDataModel>>() as DbTreeCodeTable;//GroupCodeTable
            TreeCodeTableModel model = TreeData.GetAllTree();

            SetParentNodeOpen("20121204133633687A9C6B094A202745FEA39573AD9E10033F", model, model.Children.ToList(), false);

            // TreeCodeTableModel model = TreeData.GetDisplayTreeNode("20121204133633687A9C6B094A202745FEA39573AD9E10033F");
            GroupMenuData _groupMenuData = new GroupMenuData();
            _groupMenuData.GroupDataList = model;
            _groupMenuData.CurrentGroup = TreeData[GlobalVariable.FControlUnitID];
            //TreeData.GetDisplayTreeNode("20121204133633687A9C6B094A202745FEA39573AD9E10033F");
            //_groupMenuData.CurrentGroup = TreeData.GetChildrenNode("20121204133633873AA534462C6499452C9E2D594701E53240");

            var list = model.Children.Where(a => (a.CODE_VALUE == "0"));
            ResponseData<GroupMenuData> Data = new ResponseData<GroupMenuData>();
            Data.Data = _groupMenuData;
            Data = setData<GroupMenuData>(Data);
            return Data;
        }

        public PagerListData<MenuRoleUserData> initMenuRoleUserData(string GroupID, Api.Pagination pager)
        {

            throw new NotImplementedException();
        }

        public MenuRoleUserData initMenuRoleUserData(string GroupID)
        {
            throw new NotImplementedException();
        }

        public string GroupAddSubmit(GroupData data)
        {
            throw new NotImplementedException();
        }

        public string GroupDeleteSubmit(GroupData data)
        {
            throw new NotImplementedException();
        }

        public string GroupEdit(GroupData data)
        {
            throw new NotImplementedException();
        }


        public MenuUserRoleResponseData MenuUserRoleSubmit(MenuUserRoleSubmitData data)
        {
            throw new NotImplementedException();
        }


        public MenuRoleUserData initMenuRoleUserData()
        {
            throw new NotImplementedException();
        }


        public GroupRightResponseData RightGroupSubmit(GroupRightSubmitData data)
        {
            throw new NotImplementedException();
        }
    }
}
