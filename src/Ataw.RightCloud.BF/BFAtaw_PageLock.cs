using Ataw.Framework.Core;
using Ataw.Framework.Core.Instance;
using Ataw.Framework.Web;
using Ataw.RightCloud.Core;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.Data;
using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.BF
{
    public class BFAtaw_PageLock : RightCloudBaseBF
    {
        public string OpenLock(string Pwd)
        {
            DAAtaw_PageLock da = new DAAtaw_PageLock(UnitOfData);
            DAAtaw_Users da1 = new DAAtaw_Users(this.UnitOfData);
            string fid = GlobalVariable.UserFID;
            string orgCode = GlobalVariable.FControlUnitID;
            string data = "";
            string _pass = RightCloudUtil.EncryptString(Pwd);

            var _list = da1.QueryMany(a => a.UserID == fid && a.Password == _pass && a.FControlUnitID == orgCode).FirstOrDefault();
            var model = da.QueryMany(a => a.PL_UserName == fid).FirstOrDefault();

            if (_list != null)
            {             
                model.PL_IsLock = 0;
                da.Update(model);
                data = "ok";
            }
            else data = "no";
            return data;
        }

        public bool GetIsLock()
        {
            DAAtaw_PageLock da = new DAAtaw_PageLock(UnitOfData);
            string fid = GlobalVariable.UserFID;
            var model = da.QueryMany(a => a.PL_UserName == fid && (a.ISDELETE == false ||a.ISDELETE == null)).FirstOrDefault();
            bool IsLock = false;
            if (model != null)
            {
                if (model.PL_IsLock == 0)
                {
                    IsLock = false;
                }
                else {
                    IsLock = true;
                }
            }
            return IsLock;
        }

        public string PageLock()
        {
            DAAtaw_PageLock da = new DAAtaw_PageLock(UnitOfData);
            string fid = GlobalVariable.UserFID;
            var model = da.QueryMany(a => a.PL_UserName == fid && (a.ISDELETE == false || a.ISDELETE == null)).FirstOrDefault();
            if (model == null)
            {
                Ataw_PageLock data = new Ataw_PageLock();
                data.FID = UnitOfData.GetUniId();
                data.PL_UserName = fid;
                data.PL_IsLock = 1;
                return "true";
            }
            else {
                model.PL_IsLock = 1;
                da.Update(model);
            }
            return "true";
        }

        public string OpenCloseLock(string fid)
        {
            DAAtaw_PageLock da = new DAAtaw_PageLock(UnitOfData);
            var model = da.GetByKey(fid);
            string kind = "";
            if (model != null)
            {
                if (model.PL_IsLock == 0)
                {
                    model.PL_IsLock = 1;
                    da.Update(model);
                    kind = "0";
                }
                else {
                    model.PL_IsLock = 0;
                    da.Update(model);
                    kind = "1";
                }
            }
            return kind;
        }

        public string SaveFavorite(MarkSubmitData SubmitData)
        {
            DAXP_Website da = new DAXP_Website(UnitOfData);
            var data = da.QueryMany(a => a.Ws_Url == SubmitData.Url && (a.ISDELETE == false || a.ISDELETE == null)).FirstOrDefault();
            XP_WebSite model = new XP_WebSite();
            if (data == null)
            {
                model.FID = UnitOfData.GetUniId();
                model.Ws_Url = SubmitData.Url;
                model.Ws_Name = SubmitData.EName;
                model.Ws_FolderID = SubmitData.FolderName;
                model.Ws_id = GlobalVariable.UserFID;

                da.Add(model);
            }
            else
            {
                data.Ws_Url = SubmitData.Url;
                data.Ws_Name = SubmitData.EName;
                data.Ws_FolderID = SubmitData.FolderName;

                da.Update(data);
            }
            return model.FID;
        }

        public string UpdateSubmit(MarkSubmitData SubmitData)
        {
            DAXP_Website da = new DAXP_Website(UnitOfData);
            var data = da.QueryMany(a => a.Ws_Url == SubmitData.Url && (a.ISDELETE == false || a.ISDELETE == null)).FirstOrDefault();
            XP_WebSite model = new XP_WebSite();

            data.Ws_Name = SubmitData.EName;
            data.Ws_FolderID = SubmitData.FolderName;

            da.Update(data);
            return model.FID;
        }

        public ComboData.ColData GetCollData(string url)
        {
            DAXP_Website da = new DAXP_Website(UnitOfData);
            var model = da.QueryMany(a => a.Ws_Url == url && (a.ISDELETE == false || a.ISDELETE == null)).FirstOrDefault();
            ComboData.ColData data = new ComboData.ColData();
            if (model != null)
            {
                data.IsMark = true;
                data.FileVale = model.Ws_FolderID;
                data.ColName = model.Ws_Name;
            }
            else
            {
                data.IsMark = false;
            }
            return data;
        }

        public List<ComboData.CombData> GetFile()
        {
            List<ComboData.CombData> ItemList = new List<ComboData.CombData>();
            DAXP_Folder_Tree da = new DAXP_Folder_Tree(UnitOfData);

            var ListData = da.QueryMany(a => a.ISDELETE == null || a.ISDELETE == false).ToList();
            if (ListData != null)
            {
                foreach (var data in ListData)
                {
                    ComboData.CombData model = new ComboData.CombData();
                    model.Value = data.FID;
                    model.Text = data.F_Name;
                    ItemList.Add(model);
                }
            }

            return ItemList;
        }

        public void DeleteMark(string Url)
        {
            DAXP_Website da = new DAXP_Website(UnitOfData);
            var model = da.QueryMany(a => a.Ws_Url == Url && (a.ISDELETE == false || a.ISDELETE == null)).FirstOrDefault();
            model.ISDELETE = true;
            da.Update(model);
        }

        public TreeCodeTableModel GetTreeData()
        {
            var TreeData = "XPFolderTreeCodeTable".PlugGet<CodeTable<CodeDataModel>>() as DbTreeCodeTable;//GroupCodeTable
            TreeCodeTableModel model = TreeData.GetAllTree();

            return model;
        }

    }
}
