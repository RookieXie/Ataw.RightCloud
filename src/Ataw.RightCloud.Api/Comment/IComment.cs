using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api
{
    public interface IComment
    {
        ResponseData<List<CommentData>> GetCommentList(string ResouceID);
    }
}
