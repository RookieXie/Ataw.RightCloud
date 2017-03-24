$(function () {


    $.AKjs.AfterFormFun.RCRoleAfterInitFun = function (formObj) {
        if (formObj.Action == "Update") {
            formObj.$JObj.find("[act_ds*='FControlUnitID']").AtawControl().toReadStatus(true);
        }
    }

    $.AKjs.RoleRightFunc = function (page) {
        var _key = page.KeyValues[0];
        var _check = false;

        var url = "/RightCloud/NewRightConfig/InitRoleRightsTree?roleId=" + _key + "&callback=" + Math.random();
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
            var url = "/RightCloud/NewRightConfig/RoleMenuAdd"; //操作的action
            $.ajax({
                type: "POST",
                url: url,
                data: "{RightIds:'" + selRightsID + "',RoleID:'" + _key + "'}",
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
    function SetValue(Roleid) {
        $.getJSON("/RightCloud/NewRightConfig/GetRoleRightsList?roleId=" + Roleid + "&callback=" + Math.random(), function (data) {
            $("#atawztree").setNodesChecked(data);
        })
    }
})