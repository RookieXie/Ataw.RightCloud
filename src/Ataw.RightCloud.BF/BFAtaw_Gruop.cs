using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.Framework.Core;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.DB;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Data;
using Ataw.RightCloud.Core;
using System.Data;
using Ataw.RightCloud.Api.Data.Org;
using Ataw.Framework.Web;
using Ataw.Right.Api;
using System.Data.SqlClient;

namespace Ataw.RightCloud.BF
{
    public class BFAtaw_Gruop : RightCloudBaseBF
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parentID">父节点ID</param>
        /// <param name="orgName">机构名称</param>
        /// <param name="orgCode">机构编码</param>
        /// <param name="pager">分页参数</param>
        /// <returns></returns>
        public PagerListData<GroupData> searchGroupDetail(string parentID, string orgName, string orgCode, Ataw.RightCloud.Api.Pagination pager)
        {
            int total = 0;
            PagerListData<GroupData> data = new PagerListData<GroupData>();
            DAAtaw_Gruop _daGroup = new DAAtaw_Gruop(this.UnitOfData);
            ICollection<Ataw_Gruop> ataw_GroupList = null;
            Ataw_Gruop _parentGroupModel = null;
            if (pager == null)
            {
                pager = new Api.Pagination();
                pager.IsASC = "IsASC".AppKv<bool>(false);
                pager.PageNo = "PageNo".AppKv<int>(0);
                pager.PageSize = "PageSize".AppKv<int>(15);
                pager.TotalCount = 0;
            }
            if (pager.PageSize == 0)
            {
                pager.PageSize = "PageSize".AppKv<int>(15);
            }
            IQueryable<Ataw_Gruop> _query = _daGroup.QueryMany(a => 1 == 1);
            if (!parentID.IsAkEmpty())
            {
                _parentGroupModel = _daGroup.Get(a => a.GroupID == parentID);//父节点
                _query = _daGroup.QueryMany(a => a.FParentFID == parentID);//子节点
            }
            if (!orgName.IsAkEmpty())
            {
                _query = _query.Where(a => a.GroupName.Contains(orgName));
            }
            if (!orgCode.IsAkEmpty())
            {
                _query = _query.Where(a => a.GroupCode.Contains(orgCode));
            }
            //<<<<<<< .mine
            //ataw_GroupList = _query.GetManyPage(a => 1 == 1, a => a.UPDATE_TIME, pager.IsASC, pager.PageNo + 1, pager.PageSize, out total);
            //=======

            ICoreGroup _coreGroup = "RightCloudCoreGroup".CodePlugIn<ICoreGroup>();

            var _list = _coreGroup.GetRightControlUnits(AtawAppContext.Current.FControlUnitID);
            var _strs = _list.Select(a => a.CODE_VALUE).ToArray();

            _query = _query.Where(a => _strs.Contains(a.GroupID));

            ataw_GroupList = _query.GetManyPage(a => true, a => a.CREATE_TIME, pager.IsASC, pager.PageNo + 1, pager.PageSize, out total);
            var returnList = new List<GroupData>();
            if (_parentGroupModel != null)
            {
                GroupData Model = new GroupData();
                CopyModel(_parentGroupModel, Model);
                returnList.Add(Model);
            }
            List<GroupData> groupDataList = new List<GroupData>();
            foreach (var _groupData in ataw_GroupList)
            {
                GroupData groupModel = new GroupData();
                CopyModel(_groupData, groupModel);
                groupDataList.Add(groupModel);
            }
            returnList.AddRange(groupDataList);
            pager.TableName = "Ataw_Group";
            pager.TotalCount = total;
            data.Pager = pager;
            data.List = returnList;
            return data;
        }

        /// <summary>
        /// 得到单个信息
        /// </summary>
        /// <param name="fid">ID</param>
        /// <returns></returns>
        public Ataw_Gruop GetGroupInfo(string fid)
        {
            DAAtaw_Gruop _da = new DAAtaw_Gruop(this.UnitOfData);
            Ataw_Gruop _atawGroup = _da.Get(a => a.GroupID == fid);
            return _atawGroup;
        }

        /// <summary>
        /// 加载信息
        /// </summary>
        /// <param name="fid">fids</param>
        /// <returns></returns>
        public List<GroupData> getGroup(IEnumerable<string> fids)
        {
            DAAtaw_Gruop _da = new DAAtaw_Gruop(this.UnitOfData);
            List<GroupData> _groupDataList = new List<GroupData>();
            string[] fidList = fids.ToArray();
            for (int i = 0; i < fidList.Length; i++)
            {
                Ataw_Gruop _atawGroupModel = new Ataw_Gruop();
                GroupData _groupDataModel = new GroupData();
                var groupid = fidList[i];
                _atawGroupModel = _da.QueryMany(a => a.GroupID == groupid).FirstOrDefault();
                if (_atawGroupModel != null)
                {
                    CopyModel(_atawGroupModel, _groupDataModel);
                    _groupDataList.Add(_groupDataModel);
                }
            }
            return _groupDataList;

        }

        /// <summary>
        /// 查看详情信息
        /// </summary>
        /// <param name="fid">fids</param>
        /// <returns></returns>
        public List<GroupDetailData> getGroupDetail(IEnumerable<string> fids)
        {
            DAAtaw_Gruop _da = new DAAtaw_Gruop(this.UnitOfData);
            List<GroupDetailData> _groupDetailDataList = new List<GroupDetailData>();
            string[] fidList = fids.ToArray();
            for (int i = 0; i < fidList.Length; i++)
            {
                Ataw_Gruop _atawGroup = new Ataw_Gruop();
                GroupDetailData _groupDetailDModel = new GroupDetailData();
                var id = fidList[i];
                _atawGroup = _da.Get(a => a.GroupID == id);
                if (_atawGroup != null)
                {
                    _groupDetailDModel.GroupID = _atawGroup.GroupID;
                    _groupDetailDModel.FParentFID = _atawGroup.FParentFID;
                    _groupDetailDModel.FParentFName = "GroupCodeTable".GetText(_atawGroup.FParentFID);
                    _groupDetailDModel.GroupName = _atawGroup.GroupName;
                    _groupDetailDModel.GroupCode = _atawGroup.GroupCode;
                    _groupDetailDModel.GroupDescrible = _atawGroup.GroupDescrible;
                    _groupDetailDModel.FAddress = _atawGroup.FAddress;
                    _groupDetailDModel.ProductFIDs = _atawGroup.ProductFIDs;
                    _groupDetailDModel.FPhone = _atawGroup.FPhone;
                    _groupDetailDModel.Fax = _atawGroup.Fax;
                    _groupDetailDModel.Post = _atawGroup.Post;
                    _groupDetailDataList.Add(_groupDetailDModel);
                }
            }
            return _groupDetailDataList;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="fid"></param>
        public void delGroup(string fid)
        {
            DAAtaw_Gruop _da = new DAAtaw_Gruop(this.UnitOfData);

            _da.Delete(a => a.GroupID == fid);

        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="groupDetailData">对象信息</param>
        public string newGroup(GroupDetailData groupDetailData)
        {
            DAAtaw_Gruop _da = new DAAtaw_Gruop(this.UnitOfData);
            Ataw_Gruop ataw_Group = new Ataw_Gruop();
            ataw_Group.GroupID = groupDetailData.GroupCode;
            copyDetailModel(ataw_Group, groupDetailData);
            _da.Add(ataw_Group);
            string FCreateTime = DateTime.Now.ToString();
            string FCreateUser = GlobalVariable.UserFID;
            var param1 = new SqlParameter("@FControlUnitID", groupDetailData.GroupID);
            var param2 = new SqlParameter("@FCreateUser", FCreateUser);
            var param3 = new SqlParameter("@FCreateTime", FCreateTime);
            var param4 = new SqlParameter("@FProductID", "");
            if (groupDetailData.ProductFIDs != null)
            {
                param4 = new SqlParameter("@FProductID", groupDetailData.ProductFIDs.ToString().Replace("\"", ""));
            }

            UnitOfData.RegisterStored("usp_GF_GroupSystemInitial", param1, param2, param3, param4);
            var param = new SqlParameter("@FControlUnitID", groupDetailData.GroupID);
            UnitOfData.RegisterStored("usp_Ataw_Role_Rights_AddRoleRight", param);
            DataCache.DeleteCache(DataCache.GetCacheType.Ataw_GroupInfo_New);
            return ataw_Group.GroupID;
        }
        /// <summary>
        /// 新增组织机构生成默认用户我的秘书
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string AddUserByGroup(string key, string fControlUnitID)
        {
            UserData user = new UserData();
            DAAtaw_Users _da = new DAAtaw_Users(this.UnitOfData);
            string password = WebCommonClass.EncryptString("123456", Ataw.Framework.Core.keyUtil.MRPkey);
            Ataw_Users model = new Ataw_Users();
            model.UserID = "atawsmysecret_" + key;
            model.NickName = "我的秘书";
            model.UserName = "mysecret";
            model.CreateTime = DateTime.Now;
            model.Creater = "ataws";
            model.Password = password;
            model.UserType = "0";
            model.IsActive = true;
            model.FControlUnitID = fControlUnitID;

            _da.Add(model);
            return model.UserID;

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="groupDetailData">对象信息</param>
        public string updateGroup(GroupDetailData groupDetailData)
        {
            DAAtaw_Gruop _da = new DAAtaw_Gruop(this.UnitOfData);
            Ataw_Gruop ataw_Group = new Ataw_Gruop();
            ataw_Group = _da.Get(a => a.GroupID == groupDetailData.GroupID);
            copyDetailModel(ataw_Group, groupDetailData);
            _da.Update(ataw_Group);
            return ataw_Group.GroupID;

        }
        /// <summary>
        /// 改变isparent值
        /// </summary>
        /// <returns></returns>
        public bool UpdateGroupByGroupIDTrue(string groupID)
        {
            DAAtaw_Gruop _da = new DAAtaw_Gruop(this.UnitOfData);
            Ataw_Gruop ataw_Group = new Ataw_Gruop();
            ataw_Group = _da.Get(a => a.GroupID == groupID);
            ataw_Group.IsParent = true;
            _da.Update(ataw_Group);
            return true;
        }
        /// <summary>
        /// 改变isparnt值
        /// </summary>
        /// <param name="PID"></param>
        public bool UpdateGroupByGroupIDFalse(string groupID)
        {
            DAAtaw_Gruop _da = new DAAtaw_Gruop(this.UnitOfData);
            Ataw_Gruop ataw_Group = new Ataw_Gruop();
            ataw_Group = _da.Get(a => a.GroupID == groupID);
            ataw_Group.IsParent = false;
            _da.Update(ataw_Group);
            return true;
        }


        public IList<MenuDetailData> GetAll(string WhereCondition, string OrderByExpression)
        {
            return null;
        }

        /// <summary>
        /// 是否存在子节点
        /// </summary>
        /// <param name="groupID">父节点ID</param>
        /// <returns></returns>
        public bool CheckHasChild(string groupID)
        {
            DAAtaw_Gruop _da = new DAAtaw_Gruop(this.UnitOfData);
            List<Ataw_Gruop> ataw_Group = null;
            ataw_Group = _da.QueryMany(a => a.FParentFID == groupID).ToList();
            if (ataw_Group.Count > 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 查询本节点信息
        /// </summary>
        /// <param name="groupID">组织机构ID</param>
        /// <returns></returns>
        /// 
        public string SearchOwenInfo(string GroupID)
        {
            DAAtaw_Gruop _da = new DAAtaw_Gruop(this.UnitOfData);
            Ataw_Gruop ataw_Group = _da.Get(a => a.GroupID == GroupID);
            if (ataw_Group != null)
            {
                return ataw_Group.FParentFID;
            }
            return null;

        }
        /// <summary>
        /// 是否存在多个子节点
        /// </summary>
        /// <param name="FParentFID"></param>
        /// <returns></returns>
        public bool CheckHasBrother(string FParentFID)
        {

            DAAtaw_Gruop _da = new DAAtaw_Gruop(this.UnitOfData);
            List<Ataw_Gruop> ataw_Group = null;
            ataw_Group = _da.QueryMany(a => a.FParentFID == FParentFID).ToList();
            if (ataw_Group.Count > 1)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 转化
        /// </summary>
        /// <param name="ataw_Group"></param>
        /// <param name="groupData"></param>
        public void CopyModel(Ataw_Gruop ataw_Group, GroupData groupData)
        {


            groupData.GroupID = ataw_Group.GroupID;
            groupData.FParentFID = ataw_Group.FParentFID;
            groupData.FParentFName = "GroupCodeTable".GetText(ataw_Group.FParentFID);
            groupData.GroupCode = ataw_Group.GroupCode;
            groupData.GroupName = ataw_Group.GroupName;
            groupData.FPhone = ataw_Group.FPhone;
            groupData.FControlUnitID = ataw_Group.FControlUnitID;
            groupData.FControlUnitName = "GroupCodeTable".GetText(ataw_Group.FControlUnitID);
            groupData.UPDATE_TIME = ataw_Group.UPDATE_TIME.ToString();
        }
        /// <summary>
        /// 转化
        /// </summary>
        /// <param name="ataw_Group"></param>
        /// <param name="_groupDetailData"></param>
        public void copyDetailModel(Ataw_Gruop ataw_Group, GroupDetailData _groupDetailData)
        {
            ataw_Group.FParentFID = ataw_Group.FParentFID;
            ataw_Group.GroupCode = _groupDetailData.GroupCode;
            //当Param1的值为空时（不选中任何组织机构新增）,为最大的组织机构
            var fid = AtawAppContext.Current.FControlUnitID;
            if (_groupDetailData.FParentFID.IsAkEmpty())
                ataw_Group.FParentFID = fid;
            else
                ataw_Group.FParentFID = _groupDetailData.FParentFID;
            ataw_Group.FPhone = _groupDetailData.FPhone;
            ataw_Group.Fax = _groupDetailData.Fax;
            ataw_Group.FAddress = _groupDetailData.FAddress;
            ataw_Group.GroupDescrible = _groupDetailData.GroupDescrible;
            ataw_Group.GroupName = _groupDetailData.GroupName;
            ataw_Group.Post = _groupDetailData.Post;
            ataw_Group.ProductFIDs = _groupDetailData.ProductFIDs;
        }
        /// <summary>
        /// 转化
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<GroupButtonData> copyGroupButtonModel(DataTable dt)
        {

            List<GroupButtonData> _groupButtonDList = new List<GroupButtonData>();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GroupButtonData _groupButtonDModel = new GroupButtonData();
                    _groupButtonDModel.ID = dt.Rows[i]["ID"].ToString();
                    _groupButtonDModel.Name = dt.Rows[i]["Name"].ToString();
                    //_groupButtonDModel.RightValue = dt.Rows[i]["RightValue"].ToString();
                    //_groupButtonDModel.RightType = dt.Rows[i]["RightType"].ToString();
                    //_groupButtonDModel.RightDesc = dt.Rows[i]["RightDesc"].ToString();
                    _groupButtonDModel.Pid = dt.Rows[i]["Pid"].ToString();
                    //_groupButtonDModel.Icon = dt.Rows[i]["Icon"].ToString();
                    _groupButtonDModel.OrderID = dt.Rows[i]["OrderID"].ToString();
                    //_groupButtonDModel.Uniquekey = dt.Rows[i]["Uniquekey"].ToString();
                    _groupButtonDModel.KeyType = dt.Rows[i]["KeyType"].ToString();
                    //_groupButtonDModel.FcontrolUnitID = dt.Rows[i]["FcontrolUnitID"].ToString();
                    _groupButtonDList.Add(_groupButtonDModel);
                }
            }
            //PagerListData<GroupButtonData> _pageListData = new PagerListData<GroupButtonData>();
            //_pageListData.List = _groupButtonDList;
            return _groupButtonDList;
        }
        /// <summary>
        /// 转化
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string copyStringModel(DataTable dt)
        {
            List<GroupButtonData> _groupButtonDList = new List<GroupButtonData>();
            List<MenuButtonData> _menuButtonDList = new List<MenuButtonData>();
            if (dt != null && dt.Rows.Count > 0)
            {
                if (GlobalVariable.IsAtawSuperUser)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        MenuButtonData _menuButtonData = new MenuButtonData();
                        _menuButtonData.FID = dt.Rows[i]["ID"].ToString();
                        _menuButtonData.FKey = dt.Rows[i]["Pid"].ToString();
                        _menuButtonData.FName = dt.Rows[i]["Name"].ToString();
                        _menuButtonData.FValue = dt.Rows[i]["keytype"].ToString();
                        _menuButtonData.OrderId = dt.Rows[i]["OrderId"].ToString();
                        _menuButtonDList.Add(_menuButtonData);
                    }
                    return _menuButtonDList.ToJson();
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        GroupButtonData _groupButtonDModel = new GroupButtonData();
                        _groupButtonDModel.ID = dt.Rows[i]["ID"].ToString();
                        _groupButtonDModel.Name = dt.Rows[i]["Name"].ToString();
                        _groupButtonDModel.RightValue = dt.Rows[i]["RightValue"].ToString();
                        _groupButtonDModel.RightType = dt.Rows[i]["RightType"].ToString();
                        _groupButtonDModel.RightDesc = dt.Rows[i]["RightDesc"].ToString();
                        _groupButtonDModel.Pid = dt.Rows[i]["Pid"].ToString();
                        _groupButtonDModel.Icon = dt.Rows[i]["Icon"].ToString();
                        _groupButtonDModel.OrderID = dt.Rows[i]["OrderID"].ToString();
                        _groupButtonDModel.Uniquekey = dt.Rows[i]["Uniquekey"].ToString();
                        _groupButtonDModel.KeyType = dt.Rows[i]["KeyType"].ToString();
                        _groupButtonDModel.FcontrolUnitID = dt.Rows[i]["FcontrolUnitID"].ToString();
                        _groupButtonDList.Add(_groupButtonDModel);
                    }
                    return _groupButtonDList.ToJson();
                }
            }
            return null;
            //PagerListData<GroupButtonData> _pageListData = new PagerListData<GroupButtonData>();
            //_pageListData.List = _groupButtonDList;
        }

        /// <summary>
        /// 组织机构编码、当前组织条件查询
        /// </summary>
        /// <returns></returns>
        public bool GetGroupDataByCode(string groupCode)
        {
            DAAtaw_Gruop _da = new DAAtaw_Gruop(this.UnitOfData);
            Ataw_Gruop ataw_Group = null;
            ataw_Group = _da.Get(a => a.GroupID == groupCode);
            if (ataw_Group == null)
                return true;
            return false;
        }

        public RightGroup GetRightGroup(string groupCode)
        {
            DAAtaw_Gruop _da = new DAAtaw_Gruop(this.UnitOfData);
            Ataw_Gruop ataw_Group = null;
            ataw_Group = _da.Get(a => a.GroupID == groupCode);
            RightGroup model = new RightGroup();
            CopyGroup(ataw_Group, model);


            return model;
        }


        public void CopyGroup(Ataw_Gruop model, RightGroup groupmodel)
        {
            groupmodel.OrgName = model.GroupName;
            groupmodel.FID = model.GroupID;
        }
        public void GroupUpdate(string groupID,string groupName)
        {
            DAAtaw_Gruop da = new DAAtaw_Gruop(this.UnitOfData);
            var model = da.QueryDefault(a => a.GroupID == groupID).FirstOrDefault();
            if (model !=null)
            {
                model.GroupName = groupName;
                da.Update(model);
            }           
            
        }
    }

}

