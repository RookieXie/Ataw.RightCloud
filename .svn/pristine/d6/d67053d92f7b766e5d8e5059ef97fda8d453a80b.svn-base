using Ataw.Framework.Web;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.BF;
using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Service
{
    public class CommentService : BaseService
    {
        BFAtaw_Comment bf_comment = new BFAtaw_Comment();
        public ResponseData<List<CommentData>> GetCommentList(string ResouceID)
        {
            List<CommentData> commentlistdata = new List<CommentData>();
            commentlistdata = bf_comment.getcommentlist(ResouceID);
            ResponseData<List<CommentData>> Data = new ResponseData<List<CommentData>>();
            Data.Data = commentlistdata;
            Data = setData<List<CommentData>>(Data);
            return Data;
        }

        public ResponseData<string> Delete(string fid)
        {
            ResponseData<string> data = new ResponseData<string>();
            bf_comment.Delete(fid);
            bf_comment.Submit();
            data.Data = "ok";
            data = setData<string>(data);

            return data;
        }

        public ResponseData<CommentData> ReplyComment(submitData submitdata)
        {
            ResponseData<CommentData> data = new ResponseData<CommentData>();
            var fid = bf_comment.ReplyComment(submitdata);

            bf_comment.Submit();           
            data.Data = fid;
            data.Content = "OK";
            data = setData<CommentData>(data);

            return data;
        }

        public string GetRepNum(string fid,string admin)
        {
            string num = bf_comment.GetRepNum(fid,admin);
            string repnum = "0";
            if (num != null)
            {
                repnum = num;
            }
            return repnum;
        }


        public string GetResouceID(string fid)
        {
            string ResouceID = "";
            ResouceID = bf_comment.GetResouceID(fid);
            return ResouceID;
        }
        
        public ResponseData<string> RemoveDelete(string fid)
        {
            ResponseData<string> data = new ResponseData<string>();
            bf_comment.RemoveDelete(fid);
            bf_comment.Submit();
            data.Data = "ok";
            data = setData<string>(data);

            return data;
        }
        public ResponseData<string> ReallyDelete(string fid)
        {
            ResponseData<string> data = new ResponseData<string>();
            bf_comment.ReallyDelete(fid);
            bf_comment.Submit();
            data.Data = "ok";
            data = setData<string>(data);

            return data;
        }
        
        public ResponseData<string> AuditingComment(string fid)
        {
            ResponseData<string> data = new ResponseData<string>();
            var key = bf_comment.AuditingComment(fid);
            bf_comment.Submit();
            data.Data = key;
            data = setData<string>(data);

            return data;
        }


        public ResponseData<string> OpenClose(string fid)
        {
            ResponseData<string> data = new ResponseData<string>();
            var key = bf_comment.OpenClose(fid);
            bf_comment.Submit();
            data.Data = key;
            data = setData<string>(data);

            return data;
        }

    }
}
