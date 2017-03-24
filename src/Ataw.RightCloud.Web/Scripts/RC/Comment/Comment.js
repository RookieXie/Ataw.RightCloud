$(function () {
    $.AKjs = $.AKjs ? $.AKjs : {};
    //评论列表内容转换
    $.AKjs.DetailFormat.ContentReplay = function (val) {
        if (val != null) {
            val = val.replace(/\</g, '&lt;');
            val = val.replace(/\>/g, '&gt;');
            val = val.replace(/\n/g, '<br/>');
            val = val.replace(/\[em_([0-9]*)\]/g, '<img src="/Content/images/face/$1.gif" border="0" />');
            return val;
        }
    }
    //资源列表跳转评论组件
    $.AKjs.CommentList = function (page) {
        var _key = page.KeyValues[0];

        page.Data.Sns_Comment_Resouce.forEach(function(a){
            if (a.FID == _key)
            {
                //$.AKjs.getJSON("/RightCloud/Comment/GetResouceID", { fid: a.SnsCR_ResouceID }, function (data) {
                //    if (data) {
                var str = "$WinCOMMENTListPAGE$" + a.SnsCR_ResouceID + "$" + a.SnsCR_Type+"$";
                        $.AKjs.AppGet().openUrl(str, { noUrl: false })
                    //} else {
                    //    alert("跳转失败！");
                    //}
               // })
            }
            
        })

      
    }
    //评论列表跳转评论组件
    $.AKjs.ShowAllComment = function (page) {
        var key = page.KeyValues[0];
        $.AKjs.getJSON("/RightCloud/Comment/GetResouceID", { fid:key}, function (data) {
            if (data) {
                var str = "$WinCOMMENTListPAGE$" + data +  "$";
                $.AKjs.AppGet().openUrl(str, { noUrl: false })
            } else {
                alert("跳转失败！");
            }
        })

    }

    //回复也删除评论
    $.AKjs.RemoveDelete = function (page) {
        var key = page.KeyValues[0];
        $.AKjs.getJSON("/RightCloud/Comment/RemoveDelete", { fid: key }, function (data) {
            if (data) {
                alert("还原成功！")
                return page.afterPostData();
            } else {
                alert("还原失败！");
            }
        })
    }

    $.AKjs.ReallyDelete = function (page) {
        var key = page.KeyValues[0];
        $.AKjs.getJSON("/RightCloud/Comment/ReallyDelete", { fid: key }, function (data) {
            if (data) {
                alert("删除成功！")
                return page.afterPostData();
            } else {
                alert("删除失败！");
            }
        })
    }

    $.AKjs.EnableOrDisable = function (page) {
        var key = page.KeyValues[0];
        $.AKjs.getJSON("/RightCloud/Comment/EnableOrDisable", { fid: key }, function (data) {
            if (data.Data == "1") {
                alert("已启用！")
                return page.afterPostData();
            } else {
                alert("已禁用！");
                return page.afterPostData();
            }
        })
    }

    $.AKjs.OpenClose = function (page) {
        var key = page.KeyValues[0];
        $.AKjs.getJSON("/RightCloud/Comment/OpenClose", { fid: key }, function (data) {
            if (data.Data == "1") {
                alert("禁用审核！")
                return page.afterPostData();
            } else {
                alert("启用审核！");
                return page.afterPostData();
            }
        })
    }

    $.AKjs.OpenCloseLock = function (page) {
        var key = page.KeyValues[0];
        $.AKjs.getJSON("/RightCloud/PageLock/OpenCloseLock", { fid: key }, function (data) {
            if (data.Data == "0") {
                alert("已锁定！");
                return page.afterPostData();
            } else {
                alert("已解锁！");
                return page.afterPostData();
            }
        })
    }

}); (jQuery);