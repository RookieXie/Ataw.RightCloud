using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.BF;
using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.RightCloud.Api.Data.Org;
using Ataw.Right.Api.Data;
using Ataw.RightCloud.Data;
using System.Data;
using Ataw.Framework.Web;


namespace Ataw.RightCloud.Service
{
    public class GroupService : BaseService, IGroup
    {
        #region  加载信息getGroup
        /// <summary>
        /// 加载信息
        /// </summary>
        /// <param name="fids"></param>
        /// <returns></returns>
        public ResponseData<IEnumerable<RightCloud.Api.Data.GroupData>> getGroup(IEnumerable<string> fids)
        {
            var bfataw_Group = new BFAtaw_Gruop();
            ResponseData<IEnumerable<RightCloud.Api.Data.GroupData>> Data = new ResponseData<IEnumerable<RightCloud.Api.Data.GroupData>>();
            List<RightCloud.Api.Data.GroupData> groupDataList = bfataw_Group.getGroup(fids);
            Data.Data = groupDataList;
            Data = setData<IEnumerable<RightCloud.Api.Data.GroupData>>(Data);
            return Data;
        }
        #endregion

        #region  查看详情 getGroupDetail
        /// <summary>
        /// 查看详情
        /// </summary>
        /// <param name="fids">多个ID</param>
        /// <returns></returns>
        public ResponseData<IEnumerable<GroupDetailData>> getGroupDetail(IEnumerable<string> fids)
        {
            var bfataw_Group = new BFAtaw_Gruop();
            ResponseData<IEnumerable<GroupDetailData>> Data = new ResponseData<IEnumerable<GroupDetailData>>();
            List<GroupDetailData> _groupDetailDataList = bfataw_Group.getGroupDetail(fids);
            Data.Data = _groupDetailDataList;
            Data = setData<IEnumerable<GroupDetailData>>(Data);
            return Data;
        }
        #endregion

        #region  查询 searchGroupDetail
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="orgFid">父节点ID</param>
        /// <param name="orgName">机构名称</param>
        /// <param name="orgCode">组织编码</param>
        /// <param name="pager">分页参数</param>
        /// <returns></returns>
        public ResponseData<PagerListData<RightCloud.Api.Data.GroupData>> searchGroupDetail(string orgFid, string orgName, string orgCode, Ataw.RightCloud.Api.Pagination pager)
        {
            var bf_Ataw_Group = new BFAtaw_Gruop();
            var DetailData = bf_Ataw_Group.searchGroupDetail(orgFid, orgName, orgCode, pager);
            ResponseData<PagerListData<RightCloud.Api.Data.GroupData>> Data = new ResponseData<PagerListData<RightCloud.Api.Data.GroupData>>();
            Data.Data = DetailData;
            Data = setData<PagerListData<RightCloud.Api.Data.GroupData>>(Data);
            return Data;
        }
        #endregion

        public ResponseData<IEnumerable<RightCloud.Api.Data.GroupData>> searchGroupbyName(string GroupName)
        {
            ResponseData<IEnumerable<RightCloud.Api.Data.GroupData>> Data = new ResponseData<IEnumerable<RightCloud.Api.Data.GroupData>>();
            return Data;
        }

        public ResponseData<IEnumerable<RightCloud.Api.Data.GroupData>> searchGroupbyFControlUnitID(string FControlUnitID)
        {
            ResponseData<IEnumerable<RightCloud.Api.Data.GroupData>> Data = new ResponseData<IEnumerable<RightCloud.Api.Data.GroupData>>();
            return Data;
        }

        #region 删除操作 delGroup
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="fids"></param>
        /// <returns></returns>
        public ResponseData<string> delGroup(IEnumerable<string> fids)
        {
            var bfataw_Group = new BFAtaw_Gruop();
            string[] fidList = fids.ToArray();
            ResponseData<string> Data = new ResponseData<string>();

            try
            {
                for (int i = 0; i < fidList.Length; i++)
                {
                    if (bfataw_Group.CheckHasChild(fidList[i]))
                    {
                        bfataw_Group.delGroup(fidList[i]);
                    }
                    else
                    {
                        Ataw_Gruop _atawGroup = bfataw_Group.GetGroupInfo(fidList[i]);
                        throw new AtawException("“{0}” 下有子节点不能删除，若要删除的话请删除子节点".AkFormat(_atawGroup.GroupName), this);
                    }
                    //获取节点自身的信息
                    string FParentID = bfataw_Group.SearchOwenInfo(fidList[i]);
                    if(FParentID!=null)
                    {
                         //子节点的父节点是否还有子节点
                        if (bfataw_Group.CheckHasBrother(FParentID))
                        {
                            bfataw_Group.UpdateGroupByGroupIDFalse(FParentID);
                        }
                    }
                   

                }
                bfataw_Group.Submit();
                Data.Data = "ok";
            }
            catch (Exception ex)
            {
                Data.Content = "删除失败";
                throw ex;
            }
            Data = setData<string>(Data);
            return Data;
        }
        #endregion

        #region  新增操作 newGroup
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="groupList"></param>
        /// <returns></returns>
        public ResponseData<List<string>> newGroup(IEnumerable<GroupDetailData> groupList)
        {
            BFAtaw_Gruop bfataw_group = new BFAtaw_Gruop();
            BFAtaw_Users bfataw_user = new BFAtaw_Users();
            List<string> fids = new List<string>();
            ResponseData<List<string>> Data = new ResponseData<List<string>>();
            var role = "Role".PlugGet<Ataw.Right.Api.IRole>();
            //如果上级有值直接改变上级的isparent属性
            var value = true;
                foreach (var group in groupList)
                {
                    value = bfataw_group.GetGroupDataByCode(group.GroupCode);
                    //判断是否有父节点
                    if (!group.FParentFID.IsAkEmpty())
                    {
                        bfataw_group.UpdateGroupByGroupIDTrue(group.FParentFID);

                    }
                    if (value != true)
                    {
                        throw new AtawException(" 机构编码“{0}”不能重复".AkFormat(group.GroupCode), this);
                    }
                    //string FCreateTime = DateTime.Now.ToString();
                    //string FCreateUser = GlobalVariable.UserFID;
                    //role.NewRoleByGroupRole(group.GroupID, FCreateUser, FCreateTime, group.ProductFIDs); 
                    string fid = bfataw_group.newGroup(group);
                    string rid = bfataw_group.AddUserByGroup(group.GroupCode, group.GroupID);
                    fids.Add(fid);
                }
                if (value == true)
                {
                    bfataw_group.Submit();
                }
                else
                {
                    fids = null;
                }
                Data.Data = fids;
                Data.Content = "ok";

        
            Data = setData<List<string>>(Data);
            return Data;
        }
        #endregion

        #region 修改操作 updateGroup
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="groupList"></param>
        /// <returns></returns>
        public ResponseData<string[]> updateGroup(IEnumerable<GroupDetailData> groupList)
        {
            List<string> list = new List<string>();
            BFAtaw_Gruop bfataw_group = new BFAtaw_Gruop();
            ResponseData<string[]> Data = new ResponseData<string[]>();
            try
            {
                foreach (var group in groupList)
                {
                    string str=bfataw_group.updateGroup(group);
                    list.Add(str);
                }

                bfataw_group.Submit();
                Data.Content = "ok";
                Data.Data = list.ToArray();

            }
            catch (Exception ex)
            {
                Data.Content = "修改失败";
                throw ex;
            }

            Data = setData <string[]>(Data);
            return Data;
        }
        #endregion

        #region  分配权限 GroupGrant
        /// <summary>
        /// 分配权限
        /// </summary>
        /// <param name="rightIds"></param>
        /// <param name="fids"></param>
        /// <returns></returns>
        public ResponseData<string> GroupGrant(string rightIds, string fids)
        {
            ResponseData<string> Data = new ResponseData<string>();
            string[] fidArray = fids.Split(',');
            var role = "Role".PlugGet<Ataw.Right.Api.IRole>();
            rightIds = rightIds.Replace("\"","'");
            IList<Ataw.Right.Api.Data.MenuData> rights = role.GetMenuList(rightIds);
            try
            {
                if (fidArray.Length > 0)
                {
                    for (int i = 0; i < fidArray.Length; i++)
                    {
                        foreach (Ataw.Right.Api.Data.MenuData rmodel in rights)
                        {
                            //赋予权限前需要删除原有的菜单权限

                           role.InsertMenu_Group(rmodel.MenuID, fidArray[i].Replace("'", ""), rmodel.FunctionRight);
                        }
                    }
                }
                Data.Data = "ok";
            }
            catch (Exception ex)
            {
                Data.Content = "error";
                throw ex;
            }
            Data = setData<string>(Data);
            return Data;
        }
        #endregion

        #region  获取组织权限  GetGroupRightTree
        /// <summary>
        /// 获取组织权限
        /// </summary>
        /// <param name="fControlUnitID">组织机构</param>
        /// <param name="onlyId"></param>
        /// <returns></returns>
        public ResponseData<PagerListData<GroupButtonData>> GetGroupRightTree(string fControlUnitID, bool onlyId)
        {
            List<GroupButtonData> _groupButtonList = new List<GroupButtonData>();
            var role = "Role".PlugGet<Ataw.Right.Api.IRole>();
            List<Ataw.Right.Api.Data.RightData> _rightDataList = role.GetRightModel_Group("FControlUnitID='" + fControlUnitID + "'", "OrderID");
            //老版调用的是表 Ataw_Rights
            List<Ataw.Right.Api.Data.MenuButtonData> _menuButtonList = new List<Right.Api.Data.MenuButtonData>();
            //接口都一样的
            if (_rightDataList.Count > 0)
            {
                foreach (var info in _rightDataList)
                {
                    var k_menuButtonList = role.GetMenuButton_Group(info.RightID, info.FunctionRight);
                    //取按钮值
                    foreach (var item in k_menuButtonList)
                    {
                        _menuButtonList.Add(item);
                    }
                    if (onlyId)
                    {
                        GroupButtonData _groupButton = new GroupButtonData();
                        _groupButton.RightID = info.RightID;
                        _groupButtonList.Add(_groupButton);
                    }
                    else
                    {
                        GroupButtonData _groupButton = new GroupButtonData();
                        _groupButton.RightID = info.RightID;
                        _groupButton.ParentID = info.ParentID;
                        _groupButton.RightKey = info.RightKey;
                        _groupButtonList.Add(_groupButton);
                    }
                }
                var _menuDataList = role.GetAll();
                foreach (var menuItem in _menuDataList)
                {
                    foreach (var menuObj in _menuButtonList)
                    {
                        if (menuObj.ParentRightValue == menuItem.RightValue)
                        {
                            if (onlyId)
                            {
                                GroupButtonData _groupButton = new GroupButtonData();
                                _groupButton.RightID = menuObj.FID;
                                _groupButtonList.Add(_groupButton);
                            }
                            else
                            {
                                GroupButtonData _groupButton = new GroupButtonData();
                                _groupButton.RightID = menuObj.FID;
                                _groupButton.ParentID = menuItem.MenuID;
                                _groupButton.RightKey = menuObj.FName;
                                _groupButtonList.Add(_groupButton);
                            }
                        }
                    }
                }
            }
            else
            {
                GroupButtonData _groupButton = new GroupButtonData();
                _groupButton.RightID = "-1";
                _groupButton.ParentID = "-1";
                _groupButton.RightKey = "当前组织无权限";
                _groupButtonList.Add(_groupButton);
            }
            PagerListData<GroupButtonData> data = new PagerListData<GroupButtonData>();
            data.List = _groupButtonList;
            ResponseData<PagerListData<GroupButtonData>> Data = new ResponseData<PagerListData<GroupButtonData>>();
            Data.Data = data;
            return Data;
        }

        #endregion

        #region 获取权限树 InitRightsTree
        public ResponseData<IEnumerable<GroupButtonData>> InitRightsTree()
        {
            string unitID = GlobalVariable.FControlUnitID;
            string strWhere = "menuid in (select distinct RightID from view_UserRoleRight where FControlUnitID = '" + unitID + "' and userid='" + GlobalVariable.UserFID + "'  )";
            BFAtaw_Gruop bfataw_Group = new BFAtaw_Gruop();
            List<GroupButtonData> _groupButtonDList = null;
            var role = "Role".PlugGet<Ataw.Right.Api.IRole>();
            DataTable rightList = role.InitRightsTree(strWhere, unitID);
            DataView dv = rightList.DefaultView;
            dv.Sort = "orderid asc";
            _groupButtonDList = bfataw_Group.copyGroupButtonModel(dv.ToTable());
            ResponseData<IEnumerable<GroupButtonData>> Data = new ResponseData<IEnumerable<GroupButtonData>>();
            Data.Data = _groupButtonDList;
            Data = setData<IEnumerable<GroupButtonData>>(Data);
            return Data;
        }
        #endregion

        #region 获取权限树返回string  RESERT_InitRightsTree
        public ResponseData<string> RESERT_InitRightsTree()
        {
            string unitID = GlobalVariable.FControlUnitID;
            string strWhere = "menuid in (select distinct RightID from view_UserRoleRight where FControlUnitID = '" + unitID + "' and userid='" + GlobalVariable.UserFID + "'  )";
            BFAtaw_Gruop bfataw_Group = new BFAtaw_Gruop();
            string _groupButtonDList = null;
            var role = "Role".PlugGet<Ataw.Right.Api.IRole>();
            DataTable rightList = role.InitRightsTree(strWhere, unitID);
            DataView dv = rightList.DefaultView;
            dv.Sort = "orderid asc";
            _groupButtonDList = bfataw_Group.copyStringModel(dv.ToTable());
            ResponseData<string> Data = new ResponseData<string>();
            Data.Data = _groupButtonDList;
            Data = setData<string>(Data);
            return Data;
        }
        #endregion

        //修改组织
        public bool GroupUpdate(string groupName, string groupID)
        {
            BFAtaw_Gruop bfGroup = new BFAtaw_Gruop();            
            try
            {
                bfGroup.GroupUpdate(groupID,groupName);
                bfGroup.Submit();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

    }
}
