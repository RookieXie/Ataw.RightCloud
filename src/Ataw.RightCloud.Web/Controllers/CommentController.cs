using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ataw.RightCloud.Service;
using Ataw.Framework.Web;
using Ataw.Framework.Core;

namespace Ataw.RightCloud.Web
{
    public class CommentController : AtawBaseController
    {
        CommentService service = new CommentService();
        //获取评论列表
        public string GetCommentList(string ResouceID)
        {
            var data = service.GetCommentList(ResouceID);
            return ReturnJson(data);
        }
        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public string Delete(string fid)
        {
           if (fid == null) { fid = ""; }
           var data = service.Delete(fid);
           return ReturnJson(data);
        }
        //发布评论
        public string ReplyComment(string submit)
        {
            var submitdata = submit.SafeJsonObject<submitData>();
            var data = service.ReplyComment(submitdata);
            return ReturnJson(data);
        }
        //获取资源ID
        public string GetResouceID(string fid)
        {
            string ResouceID = "";
            ResouceID = service.GetResouceID(fid);
            return ReturnJson(ResouceID);
        }

        //还原也删除的评论
        public string RemoveDelete(string fid)
        {
            var data = service.RemoveDelete(fid);
            return ReturnJson(data);
        }

        //物理删除评论
        public string ReallyDelete(string fid)
        {
            var data = service.ReallyDelete(fid);
            return ReturnJson(data);
        }
        /// <summary>
        /// 启用/禁用按钮
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public string EnableOrDisable(string fid)
        {
            var data = service.AuditingComment(fid);
            return ReturnJson(data);
        }
        /// <summary>
        /// 审核未审核按钮
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public string OpenClose(string fid)
        {
            var data = service.OpenClose(fid);
            return ReturnJson(data);
        }

        public string GetRepNum(string fid, string admin)
        {
            string num = service.GetRepNum(fid, admin);
            string repnum = "0";
            if (num != null)
            {
                repnum = num;
            }
            return ReturnJson(repnum);
        }

    }
}