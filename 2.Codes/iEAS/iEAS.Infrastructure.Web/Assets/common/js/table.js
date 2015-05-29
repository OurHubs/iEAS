

//各行换色初始化
$(function () {

    //各行换色
    $(".tabList tr:nth-child(2n+1)").addClass("gray"); //各行换色

    //光棒效果
    $(".tabList tr").mouseover(function () {
        if ($(this).hasClass("gray")) { $(this).removeClass("gray"); }//移除灰色
        $(this).addClass("hover");
    }).mouseout(function () {
        $(this).removeClass("hover");
        $(".tabList tr:nth-child(2n+1)").addClass("gray"); //各行换色
    });

    //内列表中checkbox选择
    $('.tabList  input:checkbox').click(function () {
        $(this).parent().parent().toggleClass('select');
    });

    //全选
    $("#checkAll").click(function () {
        $(".tabList input[name=IDS]").attr('checked', this.checked);
        if (this.checked) {
            $(".tabList  tr").addClass("select");
        } else {
            $(".tabList  tr").removeClass("select");
        }
    });
});

//全选前的验证是否选择
function checkSelect() {
    $(function () {
        var hasChecked = false; //默认情况是都没有选择
        $("input[name='IDS']").each(function () {
            if ($(this)[0].checked) {
                hasChecked = true; //有一个就复制为true
            }
        })
        if (!hasChecked) {
            alert("您还没有选择");
            return false;
        } else {
            if (confirm("确定要删除吗")) {
                return true;
            } else {
                return false;
            }
        }
    });
}
//列表排序
function Sort(obj, sortStr) {
    var $a = $(obj);
    var lastSortStr = $("#hfSort").val(); //上一次的排序字符串
    var currSortStr = ""; //当前排序的字符串

    //第一次排序
    if (lastSortStr == "") {
        currSortStr = sortStr;
        $a.addClass("up");
    } else {
        //上次是升序
        if (lastSortStr == sortStr) {
            currSortStr = sortStr + " desc"; //这次按降序排
            $a.removeClass("up");
            $a.addClass("down");
        } else {
            currSortStr = sortStr;
            $a.removeClass("up");
            $a.addClass("up");
        }
    }
    $("#hfSort").val(currSortStr); //保存排序字段
    __doPostBack('btnSearch', '');
}

///初始化排序
function InitSort() {
    var sortStr = $("#hfSort").val(); //排序字段
    var hdSortVal = $("#hfSort").val();
    if (sortStr != "") {
        //倒序          
        if (sortStr.indexOf("desc") > 0) {
            var sortName = $.trim(sortStr.replace("desc", ""));
            var $a = $("#" + sortName); //获取a标签
            $(".title a").removeClass("up");
            $(".title a").removeClass("down");
            $a.addClass("down");
        } else {
            var sortName = $.trim(sortStr);
            $(".title a").removeClass("up");
            $(".title a").removeClass("down");
            $("#" + sortName).addClass("up");
        }
    }
}

///排序基础定义
///obj 对象
///tabName 表名
///colName 列名
/// id 编号ID
function SetOrderNumDef(obj, tabName, colName, id) {
    var $input = $(obj);
    var ordernum = $input.val();
    $.post("../AjaxHandler.ashx", { ID: id, tabName: tabName, colName: colName, numValue: ordernum, ajaxType: "setValue" }, function (result) {
        if (result == "0") {
            alert("修改失败");
        }
    }, "json");
}

///设置bool值ajax
///obj 对象本身
///tabName 表名字
///colName 列名称
///id ID
function SetBoolDef(obj, tabName, colName, id) {
    var $input = $(obj);
    var boolValue = $input.html()=="是"?0:1;
    $.post("../AjaxHandler.ashx", { ID: id, tabName: tabName, colName: colName, numValue: boolValue, ajaxType: "setValue" }, function (result) {
        if (result == "0") {
            alert("修改失败");
        } else {
            var value = $input.html();
            $input.html(value == "是" ? "否" : "是");
        }
    }, "json");
}

function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

