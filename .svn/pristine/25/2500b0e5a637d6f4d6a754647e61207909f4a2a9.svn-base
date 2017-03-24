$(function () {
    $.AKjs = $.AKjs ? $.AKjs : {};

    $.AKjs.GoToUrl = function (page) {
        var _key = page.KeyValues[0];
        $.AKjs.getJSON("/RightCloud/SortCut/GetUrl", { fid: _key }, function (a) {
            if (a) {
                if (a.Data) {
                    var url = a.Data.split("module/");
                    if (url.length > 1) {
                        $.AKjs.AppGet().openUrl("$$" + a.Data);
                    } else {
                        $.AKjs.AppGet().openUrl("$" + a.Data + "$")
                    }
                }
                
            } else {
                alert("跳转失败！");
            }
        })
    }

    $.AKjs.GoToMarkUrl = function (page) {
        var _key = page.KeyValues[0];
        $.AKjs.getJSON("/RightCloud/SortCut/GetMarkUrl", { fid: _key }, function (a) {
            if (a) {
                if (a.Data) {
                    var url = a.Data.split("module/");
                    if (url.length > 1) {
                        $.AKjs.AppGet().openUrl("$$" + a.Data);
                    } else {
                        $.AKjs.AppGet().openUrl("$" + a.Data + "$")
                    }
                }

            } else {
                alert("跳转失败！");
            }
        })
    }

});(jQuery);