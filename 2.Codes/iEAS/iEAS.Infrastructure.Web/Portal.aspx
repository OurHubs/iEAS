<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Portal.aspx.cs" Inherits="iEAS.Infrastructure.Web._Portal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" class="off">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<title>iEAS企业应用平台 </title>

<link href="assets/common/css/reset.css" rel="stylesheet" type="text/css" />
<link href="assets/common/css/zh-cn-system.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="assets/common/js/jquery.min.js"></script>
<script language="javascript" type="text/javascript" src="assets/common/js/styleswitch.js"></script>
</head>
<body scroll="no" class="objbody">
<div class="header">
	<div class="logo lf"><a href="" target="_blank"><span class="invisible">iEAS企业应用办公平台</span></a></div>
    <div class="rt-col">
    	<div class="tab_style white cut_line text-r"><a href="javascript:;" onClick="show_userback()" class="top_ico" title="在线人员"><img src="assets/common/images/2014_1.png" width="22" height="22" /></a>
		<a href="javascript:_MP(214,'');" hidefocus='true' title="短消息"><b id="sms_count"></b><img src="assets/common/images/2014_5.png" width="22" height="22" /></a>&nbsp;
		<a href="javascript:_M(0,'')" hidefocus="true" style="outline:none;" title="桌面设置"><img src="assets/common/images/2014_4.png" width="22" height="22" /></a>&nbsp;
		<a href="" title="风格切换"><img src="assets/common/images/2014_3.png" width="22" height="22" /></a>&nbsp;
		<a href="" title="保存到桌面"><img src="assets/common/images/2014_2.png" width="22" height="22" /></a>&nbsp;
		<a href="" target="_blank" title="在线帮助"><img src="assets/common/images/2014_6.png" width="22" height="22" /></a>
        </div>
    </div>
    <div class="col-auto">
    	<div class="log white cut_line">您好！测试1  [系统管理组]<span style="color:#A30100;">|</span><a href="Login.aspx">[退出]</a>
    	</div>
        <ul class="nav white" id="top_menu">
            <%
                int i = 0;
                foreach (var menu in TopMenus)
               { %>
		    <li id="_M<%=menu.ID %>" class="top_menu"><a href="javascript:_M('<%=menu.ID %>','<%=menu.Url %>')" hidefocus="true" style="outline:none;"><%=menu.Name %></a></li>
		    <%} %>
        </ul>
    </div>
</div>
<div id="content">
	<div class="col-left left_menu">
    	<div id="Scroll"><div id="leftMain" style="padding-bottom:20px;"></div></div>
        <a href="javascript:;" id="openClose" style="outline-style: none; outline-color: invert; outline-width: medium;" hideFocus="hidefocus" class="open" title="展开与关闭左侧菜单"><span class="hidden">展开</span></a>
    </div>
	<!--<div class="col-1 lf cat-menu" id="display_center_id" style="display:none" height="100%">
	<div class="content">
        	<iframe name="center_frame" id="center_frame" src="" frameborder="false" scrolling="auto" style="border:none" width="100%" height="auto" allowtransparency="true"></iframe>
            </div>
			
        </div> -->
    <div class="col-auto mr8">
    <div class="crumbs">
    </div>
    	<div class="col-1">
        	<div class="content" style="position:relative; overflow:hidden; width:100%;">
                <iframe name="right" id="rightMain" frameborder="false" src="desktop.aspx" scrolling="auto" style="border:none;" width="100%" height="auto" allowtransparency="true"></iframe>
        	</div>
        </div>
    </div>
</div>
<div class="scroll"><a href="javascript:;" class="per" title="使用鼠标滚轴滚动侧栏" onclick="menuScroll(1);"></a><a href="javascript:;" class="next" title="使用鼠标滚轴滚动侧栏" onclick="menuScroll(2);"></a></div>
<script type="text/javascript">
    if (!Array.prototype.map)
        Array.prototype.map = function (fn, scope) {
            var result = [], ri = 0;
            for (var i = 0, n = this.length; i < n; i++) {
                if (i in this) {
                    result[ri++] = fn.call(scope, this[i], i, this);
                }
            }
            return result;
        };

    var getWindowSize = function () {
        return ["Height", "Width"].map(function (name) {
            return window["inner" + name] ||
              document.compatMode === "CSS1Compat" && document.documentElement["client" + name] || document.body["client" + name]
        });
    }
    window.onload = function () {
        if (!+"\v1" && !document.querySelector) { // for IE6 IE7
            document.body.onresize = resize;
        } else {
            window.onresize = resize;
        }
        function resize() {
            wSize();
            return false;
        }
    }
    function wSize() {
        //这是一字符串
        var str = getWindowSize();
        var strs = new Array(); //定义一数组
        strs = str.toString().split(","); //字符分割
        var heights = strs[0] - 120, Body = $('body'); $('#rightMain').height(heights);
        //iframe.height = strs[0]-46;
        if (strs[1] < 980) {
            $('.header').css('width', 980 + 'px');
            $('#content').css('width', 980 + 'px');
            Body.attr('scroll', '');
            Body.removeClass('objbody');
        } else {
            $('.header').css('width', 'auto');
            $('#content').css('width', 'auto');
            Body.attr('scroll', 'no');
            Body.addClass('objbody');
        }

        var openClose = $("#rightMain").height() + 39;
        $('#center_frame').height(openClose + 9);
        $("#openClose").height(openClose);
        $("#Scroll").height(openClose - 20);
        windowW();
    }
    wSize();
    function windowW() {
        if ($('#Scroll').height() < $("#leftMain").height()) {
            $(".scroll").show();
        } else {
            $(".scroll").hide();
        }
    }
    windowW();
    //站点下拉菜单
    $(function () {
        var offset = $(".tab_web").offset();
        $(".tab_web").mouseover(function () {
            $(".tab-web-panel").css({ "left": +offset.left + 4, "top": +offset.top + $('.tab_web').height() + 2 });
            $(".tab-web-panel").show();
        });
        $(".tab_web span").mouseout(function () { hidden_site_list_1() });
        $(".tab-web-panel").mouseover(function () { clearh(); $('.tab_web a').addClass('on') }).mouseout(function () { hidden_site_list_1(); $('.tab_web a').removeClass('on') });
        //默认载入左侧菜单
        //$("#leftMain").load("inc/lmenu.php");
        //面板切换
        $("#btnx").removeClass("btns2");
        $("#Site_model,#btnx h6").css("display", "none");
        $("#btnx").hover(function () { $("#Site_model,#btnx h6").css("display", "block"); $(this).addClass("btns2"); $(".bg_btn").hide(); }, function () { $("#Site_model,#btnx h6").css("display", "none"); $(this).removeClass("btns2"); $(".bg_btn").show(); });
        $("#Site_model li").hover(function () { $(this).toggleClass("hvs"); }, function () { $(this).toggleClass("hvs"); });
        $("#Site_model li").click(function () { $("#Site_model li").removeClass("ac"); $(this).addClass("ac"); });

    })

    //隐藏站点下拉。
    var s = 0;
    var h;
    function hidden_site_list() {
        s++;
        if (s >= 3) {
            $('.tab-web-panel').hide();
            clearInterval(h);
            s = 0;
        }
    }
    function clearh() {
        if (h) clearInterval(h);
    }
    function hidden_site_list_1() {
        h = setInterval("hidden_site_list()", 1);
    }

    //左侧开关
    $("#openClose").click(function () {
        if ($(this).data('clicknum') == 1) {
            $("html").removeClass("on");
            $(".left_menu").removeClass("left_menu_on");
            $(this).removeClass("close");
            $(this).data('clicknum', 0);
            $(".scroll").show();
        } else {
            $(".left_menu").addClass("left_menu_on");
            $(this).addClass("close");
            $("html").addClass("on");
            $(this).data('clicknum', 1);
            $(".scroll").hide();
        }
        return false;
    });

    function _M(menuid, targetUrl) {
        $("#menuid").val(menuid);
        $("#bigid").val(menuid);
        $("#paneladd").html('<a class="panel-add" href="javascript:add_panel();"><em>添加</em></a>');

        $("#leftMain").load("Ajax/LMenu.aspx?portal=<%=PortalCode %>&menuid=" + menuid, { limit: 25 }, function () {
            windowW();
        });
        $("#rightMain").attr('src', targetUrl);
        $('.top_menu').removeClass("on");
        $('#_M' + menuid).addClass("on");
        $.get("Ajax/TMenu.aspx?menuid=" + menuid, function (data) {
            $("#current_pos").html(data);
        });
        //当点击顶部菜单后，隐藏中间的框架
        $('#display_center_id').css('display', 'none');
        //显示左侧菜单，当点击顶部时，展开左侧
        $(".left_menu").removeClass("left_menu_on");
        $("#openClose").removeClass("close");
        $("html").removeClass("on");
        $("#openClose").data('clicknum', 0);
        $("#current_pos").data('clicknum', 1);
        if (menuid == 1) {
            $(".left_menu").addClass("left_menu_on");
            $(this).addClass("close");
            $("html").addClass("on");
            $(this).data('clicknum', 1);
            $(".scroll").hide();
            $("#openClose").hide();
            $('#btnx').css('display', 'block');
        } else {
            $('#btnx').css('display', 'none');
        }
    }
    _M(1, 'Desktop.aspx');
    function _MP(menuid, targetUrl) {
        targetUrl = targetUrl || "";

        $("#menuid").val(menuid);
        $("#paneladd").html('<a class="panel-add" href="javascript:add_panel();"><em>添加</em></a>');


        if (targetUrl.indexOf("?")< 0) {
            targetUrl += "?menuid=" + menuid;
        }
        else {
            targetUrl += "&menuid=" + menuid;
        }

        $("#rightMain").attr('src', targetUrl);
        $('.sub_menu').removeClass("on fb blue");
        $('#_MP' + menuid).addClass("on fb blue");
        $.get("Ajax/LMenu.aspx?portal=<%=PortalCode %>&menuid=" + menuid, function (data) {
            $("#current_pos").html(data + '<span id="current_pos_attr"></span>');
        });
        $("#current_pos").data('clicknum', 1);
    }
    function menuScroll(num) {
        var Scroll = document.getElementById('Scroll');
        if (num == 1) {
            Scroll.scrollTop = Scroll.scrollTop - 60;
        } else {
            Scroll.scrollTop = Scroll.scrollTop + 60;
        }
    }
</script>
</body>
</html>