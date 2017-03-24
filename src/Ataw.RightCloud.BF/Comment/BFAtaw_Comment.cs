using Ataw.Framework.Web;
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
    public class BFAtaw_Comment : RightCloudBaseBF
    {
        public List<CommentData> getcommentlist(string ResouceID)
        {
            DAAtaw_Comment da = new DAAtaw_Comment(UnitOfData);
            List<CommentData> model = new List<CommentData>();
            DAAtaw_Comment_Resouce _da = new DAAtaw_Comment_Resouce(UnitOfData);
            //通过编号去资源取FID
            var fid = "";
            if (ResouceID != null)
            {
                var data = _da.QueryMany(a => a.SnsCR_ResouceID == ResouceID && (a.ISDELETE == null || a.ISDELETE == false)).FirstOrDefault();
                if (data != null)
                {
                    fid = data.FID;
                }

            }
            var FControlUnitID = GlobalVariable.FControlUnitID;
            List<Sns_Comment> models = new List<Sns_Comment>();
            if (FControlUnitID == "1")
            {
                models = da.QueryMany(a => a.SnsC_ResouceID == fid && (a.ISDELETE == null || a.ISDELETE == false)).ToList();
            }else
            //通过fid去所属评论
            models = da.QueryMany(a => a.SnsC_ResouceID == fid && (a.ISDELETE == null || a.ISDELETE == false) && a.FControlUnitID == FControlUnitID).ToList();
            foreach (var data in models)
            {
                CommentData Data = new CommentData();
                var user = GlobalVariable.UserFID;
                //var IsAudit = AddProof(data.SnsC_ResouceType);
                if (data.SnsC_User == user || data.IsAuditing == 1)
                {
                    if (data.IsAuditing == 1 ||data.IsAuditing == null)
                    {
                        Data.IsAuditing = 1;
                    }
                    else {
                        Data.IsAuditing = 0;
                    }
                    if (data.SnsC_User == user){
                        Data.IsOwer = true;
                    }
                    else{
                        Data.IsOwer = false;
                    }
                    if (data.CREATE_TIME == null)
                    {
                        Data.CtreteTime = "空";
                    }else{
                        Data.CtreteTime = data.CREATE_TIME.Value.ToString();
                    }
                    Data.SnsC_ResouceID = data.SnsC_ResouceID;
                    Data.SnsC_ResouceType = data.SnsC_ResouceType;
                    Data.SnsC_Content = data.SnsC_Content;
                    Data.SnsC_ToUser = GetName(data.SnsC_ToUser);
                    Data.SnsC_User = GetName(data.SnsC_User);
                    Data.SnsC_UserId = data.SnsC_User;
                    //Data.SnsC_UserName = data.SnsC_UserName;
                    Data.FID = data.FID;
                    model.Add(Data);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取用户名称
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public string GetName(string fid)
        {
            DAAtaw_Users da = new DAAtaw_Users(UnitOfData);
            var model = da.GetByKey(fid);
            string name = "";
            if (model != null)
            {
                name = model.NickName;
            }
            return name;
        }
        /// <summary>
        /// 还原删除数据
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public bool RemoveDelete(string fid)
        {
            bool res = false;
            DAAtaw_Comment da = new DAAtaw_Comment(UnitOfData);
            var model = da.QueryMany(a => a.FID == fid && (a.ISDELETE == true)).FirstOrDefault();
            if (model != null)
            {
                model.ISDELETE = false;
                res = true;
            }
            return res;
        }
        /// <summary>
        /// 物理删除数据
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public bool ReallyDelete(string fid)
        {
            bool res = false;
            DAAtaw_Comment da = new DAAtaw_Comment(UnitOfData);
            if (fid != null)
            {
                da.DeleteByKey(fid);
                res = true;
            }
            return res;
        }
        /// <summary>
        /// 审核，将修改字典数据
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public string AuditingComment(string fid)
        {
            DAAtaw_Comment_Resouce da = new DAAtaw_Comment_Resouce(UnitOfData);
            Sns_Comment_Resouce data = new Sns_Comment_Resouce();
            if (fid != null)
            {
                data = da.GetByKey(fid);
            }
            var model = da.QueryMany(a => a.SnsCR_Type == data.SnsCR_Type && a.IsProof == 1).FirstOrDefault();
            if (model != null)
            {
                if (model.IsAuditing == 1)
                {
                    model.IsAuditing = 0;
                    da.Update(model);
                }
                else
                {
                   model.IsAuditing = 1;
                   da.Update(model);
                }
            }
            return model.IsAuditing.Value.ToString();
        }

        public string OpenClose(string fid)
        {
            DAAtaw_Comment da = new DAAtaw_Comment(UnitOfData);
            var model = da.GetByKey(fid);
            if (model.IsAuditing == 0)
            {
                model.IsAuditing = 1;
                da.Update(model);
            }
            else
            {
                model.IsAuditing = 0;
                da.Update(model);
            }
            return model.IsAuditing.Value.ToString();
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public bool Delete(string fid)
        {
            bool res = false;
            DAAtaw_Comment da = new DAAtaw_Comment(UnitOfData);
            var model = da.QueryMany(a => a.FID == fid && (a.ISDELETE == null || a.ISDELETE == false)).FirstOrDefault();
            if (model != null)
            {
                model.ISDELETE = true;
                res = true;
            }
            return res;
        }
        /// <summary>
        /// 保存评论
        /// </summary>
        /// <param name="submitdata"></param>
        /// <returns></returns>
        public CommentData ReplyComment(submitData submitdata)
        {


            DAAtaw_Comment da = new DAAtaw_Comment(UnitOfData);
            Sns_Comment model = new Sns_Comment();
            var res = submitdata.resouceData;
            //首先判断资源是不是存在资源表中
            Sns_Comment_Resouce Resoucedata = new Sns_Comment_Resouce();
            if (res != null)
            {
                Resoucedata = this.GetResouce(res.SnsCR_ResouceID, res.SnsCR_Type, res.SnsCR_Title);
            }
            if (Resoucedata != null)
            {
                model.SnsC_ResouceID = Resoucedata.FID; //submitdata.commentData.SnsC_ResouceID;
                var IsAudit = AddProof(res.SnsCR_Type);
                if (IsAudit == 1)
                {
                    model.IsAuditing = 0;
                }
                else
                {
                    model.IsAuditing = 1;
                }
                
            }

            model.FID = UnitOfData.GetUniId();
            model.SnsC_ResouceType = submitdata.commentData.SnsC_ResouceType;
            model.SnsC_Content = submitdata.commentData.SnsC_Content;
            model.SnsC_ToUser = GetUserID(submitdata.commentData.SnsC_ToUser);
            model.SnsC_User = GlobalVariable.UserFID;
            //model.SnsC_UserName = GetName(GlobalVariable.UserFID);
            //model.SnsC_ToUserName = GetName(GetUserID(submitdata.commentData.SnsC_ToUser));
            model.CREATE_TIME = DateTime.Now;

            da.Add(model);

            CommentData data = new CommentData();
            data.FID = model.FID;
            data.SnsC_User = GetName(GlobalVariable.UserFID);
            data.SnsC_ToUser = GetName(GetUserID(submitdata.commentData.SnsC_ToUser));
            data.SnsC_ResouceID = model.SnsC_ResouceID;
            data.SnsC_Content = model.SnsC_Content;
            data.SnsC_ResouceType = model.SnsC_ResouceType;
            if (model.IsAuditing == 0)
            {
                data.IsAuditing = model.IsAuditing;
            }
            data.IsAuditing = model.IsAuditing;
            data.IsOwer = true;
            data.CtreteTime = model.CREATE_TIME.Value.ToString();
            return data;
        }

        //public Sns_Comment AddProof(string SnsCR_Type)
        //{
        //    DAAtaw_Comment da = new DAAtaw_Comment(UnitOfData);

        //    var model = da.QueryMany(a => a.SnsC_ResouceType == SnsCR_Type).FirstOrDefault();
        //    Sns_Comment data = new Sns_Comment();
        //    if (model == null)
        //    {
        //        data.FID = UnitOfData.GetUniId();
        //        data.SnsC_ResouceType = SnsCR_Type;
        //        data.IsAuditing = false;
        //        da.Add(data);
        //    }
        //    return data;
        //}

        /// <summary>
        /// 获取资源数据
        /// </summary>
        /// <param name="ResouceId"></param>
        /// <param name="type"></param>
        /// <param name="Title"></param>
        /// <returns></returns>
        public Sns_Comment_Resouce GetResouce(string ResouceId, string type, string Title)
        {
            DAAtaw_Comment_Resouce da = new DAAtaw_Comment_Resouce(UnitOfData);
            Sns_Comment_Resouce Resoucedata = new Sns_Comment_Resouce();
            var data = da.QueryMany(a => a.SnsCR_ResouceID == ResouceId).FirstOrDefault();
            if (data == null)
            {
                //添加
                Sns_Comment_Resouce model = new Sns_Comment_Resouce();
                model.FID = UnitOfData.GetUniId();
                model.SnsCR_Type = type;
                model.SnsCR_ResouceID = ResouceId;
                model.SnsCR_RepNum = 0;
                model.SnsCR_Title = Title;
                model.IsAuditing = 0;
                model.CREATE_TIME = DateTime.Now;

                da.Add(model);          

                Resoucedata = model;
                AddProof(type);
            }
            else
            {
                Resoucedata = data;
            }
            return Resoucedata;
        }

        public int AddProof(string type)
        {
            DAAtaw_Comment_Resouce da = new DAAtaw_Comment_Resouce(UnitOfData);
            var model = da.QueryMany(a => a.SnsCR_Type == type && a.SnsCR_ResouceID == "" && (a.IsProof == 1)).FirstOrDefault();
            Sns_Comment_Resouce data = new Sns_Comment_Resouce();
            if (model == null)
            {
                data.FID = UnitOfData.GetUniId();
                data.SnsCR_ResouceID = "";
                data.SnsCR_Type = type;
                data.IsProof = 1;
                data.IsAuditing = 1;

                da.Add(data);

                return data.IsAuditing.Value;
            } else
            return model.IsAuditing.Value;

        }

        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetUserID(string name)
        {
            DAAtaw_Users da = new DAAtaw_Users(UnitOfData);
            var model = da.QueryMany(a => a.NickName == name && a.ISDELETE == null).FirstOrDefault();
            string FID = "";
            if (model != null)
            {
                FID = model.UserID;
            }
            return FID;
        }
        /// <summary>
        /// 获取评论数量
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public string GetRepNum(string fid,string admin)
        {
            DAAtaw_Comment da = new DAAtaw_Comment(UnitOfData);

            string userid = GlobalVariable.UserFID;
            List<Sns_Comment> model = new List<Sns_Comment>();
            if (admin == "admin")
            {
                model = da.QueryMany(a => a.SnsC_ResouceID == fid &&((a.ISDELETE == null) || (a.ISDELETE == false))).ToList();
            }
            model = da.QueryMany(a => a.SnsC_ResouceID == fid &&a.SnsC_User== userid && ((a.ISDELETE == null) || (a.ISDELETE == false))).ToList();
            if (model != null)
            {
                var num = model.Count.ToString();
                return num;
            }
            return "0";
        }
        /// <summary>
        /// 获取资源表ID
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public string GetResouceID(string fid)
        {
            DAAtaw_Comment da = new DAAtaw_Comment(UnitOfData);
            var model = da.GetByKey(fid);
            var ResouceID = "";
            if (model != null)
            {
                DAAtaw_Comment_Resouce _da = new DAAtaw_Comment_Resouce(UnitOfData);
                var data = _da.QueryMany(a => a.FID == model.SnsC_ResouceID && (a.ISDELETE == null || a.ISDELETE == false)).FirstOrDefault();
                if(data != null)
                {
                    ResouceID = data.SnsCR_ResouceID;
                }

            }           
            return ResouceID;
        }
    }
}
