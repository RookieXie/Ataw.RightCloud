$(function () {
    $.AKjs.AfterFormFun.RCGroupAfterInitFun = function (formObj) {
        if (formObj.Action == "Update") {
            formObj.$JObj.find("[act_ds*='RCG_Code']").AtawControl().toReadStatus(true);
        }
    }
    $.AKjs.GrantGroupRightsFunc = function (page) {
        var _key = page.KeyValues[0];
        var _check = false;

        var url = "/RightCloud/NewRightConfig/GrantGroupRights?FID=" + _key + "&callback=" + Math.random();
        page.$AtawWindow.html("");
        var _$returnBt = $("<a class='btn btn-info'><i class='icon-reply' />返回</a>");
        page.$AtawWindow.append(_$returnBt);
        var $ztree = $("<ul class=\"ztree\" id=\"atawztree\"></ul>");
        page.$AtawWindow.append($ztree);
        page.$AtawWindow.slideDown("slow");
        page.$JObj.slideUp("slow");
        $ztree.AtawRightTree({
            //id: "atawztree",
            url: url,
            isCheckedAll: true,
            asyncSuccess: function () {
                SetValue(_key);
            }
        });

        var _$btnSure = $("<a href=\"javascript:void(0)\" class=\"functionBtn btn-primary btn-large ACT_PAGE_SUBMIT\" ><i class='icon-ok icon-white'></i> <span>确定</span></a>");
        page.$AtawWindow.append(_$btnSure);
        _$returnBt.unbind("click").bind("click", function () {
            page.$AtawWindow.slideUp("slow");
            page.$JObj.slideDown("slow");
            //_this.intoDom(_this.$JObj);


        });
        _$btnSure.unbind("click").bind("click", function () {
            var selRightsID = $("#atawztree").getSelectedNodesID();
            if (selRightsID.length < 1) {
                Ataw.msgbox.show("请至少选择一项！", 4, 500);
                return false;
            }
            var url = "/RightCloud/NewRightConfig/GroupMenuAdd"; //操作的action
            $.ajax({
                type: "POST",
                url: url,
                data: "{RightIds:'" + selRightsID + "',FID:'" + _key + "'}",
                contentType: "application/json; charset=utf-8",
                async: true,
                cache: false,
                error: function (msg) {
                    Ataw.msgbox.show("程序错误!", 5, 2000);
                },
                success: function (msg) {
                    if (msg == "1") {
                        Ataw.msgbox.show("权限分配成功!", 4, 2000);
                        //page.openNewXmlPage("module/Right/role/role.xml", "List", _key, "", "");
                        page.$AtawWindow.slideUp("slow");
                        page.$JObj.slideDown("slow");
                        // page.cancelFun();
                    } else {
                        Ataw.msgbox.show("权限分配失败!", 5, 2000);
                        // page.cancelFun();
                    }
                }
            })
        });
        //SetValue(_key);
    }
    //设置节点选中状态
    function SetValue(FID) {
        $.getJSON("/RightCloud/NewRightConfig/GetGroupRightsList?FID=" + FID + "&onlyId=true&callback=" + Math.random(), function (data) {
            $("#atawztree").setNodesChecked(data);
        })
    }
    $.AKjs.ViewGroupRightsfunc = function (page) {
        var _key = page.KeyValues[0];

        var url = "/RightCloud/NewRightConfig/GetGroupRightsList?FID=" + _key + "&onlyId=false&callback=" + Math.random();
        page.$AtawWindow.html("");
        var _$returnBt = $("<a class='btn btn-info'><i class='icon-reply' />返回</a>");
        page.$AtawWindow.append(_$returnBt);
        var $ztree = $("<ul class=\"ztree\" id=\"atawztree\"></ul>");
        page.$AtawWindow.append($ztree);
        page.$AtawWindow.slideDown("slow");
        page.$JObj.slideUp("slow");
        $ztree.AtawRightTree({
            url: url,
            chk: false,
            asyncSuccess: function () {
                Ataw.msgbox.hide(500); //隐藏加载提示
            },
            beforeAsync: function () {
                Ataw.msgbox.show(" 正在加载，请稍后...", 6);
                return true;
            }
        });
        _$returnBt.unbind("click").bind("click", function () {
            page.$AtawWindow.slideUp("slow");
            page.$JObj.slideDown("slow");

        });
    }
})