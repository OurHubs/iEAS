<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Desktop.aspx.cs" Inherits="iEAS.Infrastructure.Web.Desktop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml10-transitional.dtd">
<html lang="zh-cn" xml:lang="zh-cn" xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>文字版桌面</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="assets/common/css/desktop.css" />
<style type="text/css">
body{ background-color:#F6EDA4;color:#2E2E30; margin:auto 10px; padding: 0px;}
</style>
</head>
<script type="text/javascript">
    var $ = function (id) { return document.getElementById(id); };
    var userAgent = navigator.userAgent.toLowerCase();
    var isSafari = userAgent.indexOf("Safari") >= 0;
    var is_opera = userAgent.indexOf('opera') != -1 && opera.version();
    var is_moz = (navigator.product == 'Gecko') && userAgent.substr(userAgent.indexOf('firefox') + 8, 3);
    var is_ie = (userAgent.indexOf('msie') != -1 && !is_opera) && userAgent.substr(userAgent.indexOf('msie') + 5, 3);


    function getCookie(name) {
        var arr = document.cookie.split("; ");
        for (i = 0; i < arr.length; i++)
            if (arr[i].split("=")[0] == name)
                return unescape(arr[i].split("=")[1]);
        return null;
    }
    function setCookie(name, value, paras) {
        var today = new Date();
        var expires = new Date();
        expires.setTime(today.getTime() + 1000 * 60 * 60 * 24 * 2000);

        var path = null;
        if (typeof (paras) == "object") {
            if (typeof (paras.expires) != "undefined")
                expires = paras.expires;
            if (typeof (paras.path) != "undefined")
                path = paras.path;
        }

        document.cookie = name + "=" + escape(value) + "; expires=" + expires.toGMTString() + (path ? '; path=' + path : '');
    }

    function _resize(module_id) {
        var module_i = $("module_" + module_id);
        var head_i = $("module_" + module_id + "_head");
        var body_i = $("module_" + module_id + "_body");
        var img_i = $("img_resize_" + module_id);
        var my_cookie = getCookie("my_expand_3");
        my_cookie = (my_cookie == null || my_cookie == "undefined") ? "" : my_cookie;//alert(my_cookie)
        if (body_i.style.display == "none") {
            module_i.className = module_i.className.substr(0, module_i.className.lastIndexOf(" "));
            head_i.className = head_i.className.substr(0, head_i.className.lastIndexOf(" "));
            body_i.style.display = "block";
            if (img_i.className.match("collapse_arrow"))
                img_i.className = img_i.className.replace("collapse_arrow", "expand_arrow");
            img_i.title = "折叠";

            if (my_cookie.indexOf(module_id + ",") == 0)
                my_cookie = my_cookie.replace(module_id + ",", "");
            else if (my_cookie.indexOf("," + module_id + ",") > 0)
                my_cookie = my_cookie.replace("," + module_id + ",", ",");

            //my_expand=true;
            setCookie("my_expand_all_3", "");
        }
        else {
            module_i.className = module_i.className + " listColorCollapsed";
            head_i.className = head_i.className + " moduleHeaderCollapsed";
            body_i.style.display = "none";
            if (img_i.className.match("expand_arrow"))
                img_i.className = img_i.className.replace("expand_arrow", "collapse_arrow");
            img_i.title = "展开";

            if (my_cookie.indexOf(module_id + ",") != 0 && my_cookie.indexOf("," + module_id + ",") <= 0)
                my_cookie += module_id + ",";
        }
        setCookie("my_expand_3", my_cookie);
    }
</script>
<body style="padding-top:20px;">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
 <tr>
 	<td width="255" valign="top">
		<div id='content-left'>
 		<ul id='arraw' class="clearfix">
			<li id='arraw1' class="blue active">短消息</li></ul>
					<div id='content-left1'>
				<div class="module listColor module_nav">
					<div class='inner14'>
<style type="text/css">
#pl_weibo_show{margin:0px;padding:0px;font-size:12px;overflow-y:auto;height:500px;}
.weiboShow .content{margin: 0 10px 0 10px;padding: 12px 0 10px;border-bottom: 1px dotted #D2D2D2;text-align:left;color:#000000}
.weiboShow .content img{vertical-align: -3px;}
.weiboShow .content_txt, .weiboShow .content_action{margin: 0 5px 0 5px;line-height: 20px;}
.weiboShow .content_txt{word-break:break-all;word-wrap:break-word;}
.weiboShow .WB_linkB a, .weiboShow .WB_linkB {color: #9ABBC8;}
.weiboShow .content .content_actionTime {float: left;}
.weiboShow .content .content_actionMore {float: right;cursor: pointer;}
.weiboShow .content .content_actionMore .weiboShow_vline {margin: 0 7px 0 8px;}
.weiboShow .weiboShow_vline {color: #D2D2D2;}
</style>
<div class="WB_widgets weiboShow" id="pl_weibo_show" style="height:
444px;" >

<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150612110024)测试1“于“2015-06-12 11:07:13“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=221&urls=list-do=view-fileurl=apps-appid=1135"ac=list&do=view&fileurl=apps&appid=1135">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-06-12 11:07:13</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150612110024)测试1“于“2015-06-12 11:07:13“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=222&urls=list-do=view-fileurl=apps-appid=1135"ac=list&do=view&fileurl=apps&appid=1135">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-06-12 11:07:13</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-06-12 11:06:47</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150612110024)测试1“于“2015-06-12 11:06:47“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=218&urls=list-do=view-fileurl=apps-appid=1135"ac=list&do=view&fileurl=apps&appid=1135">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-06-12 11:06:47</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150612110024)测试1“于“2015-06-12 11:06:08“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=216&urls=list-do=view-fileurl=apps-appid=1135"ac=list&do=view&fileurl=apps&appid=1135">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-06-12 11:06:08</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-06-12 11:00:49</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-06-08 16:23:13</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150608162113)测试1“于“2015-06-08 16:23:13“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=208&urls=list-do=view-fileurl=apps-appid=1118"ac=list&do=view&fileurl=apps&appid=1118">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-06-08 16:23:13</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150608162113)测试1“于“2015-06-08 16:22:33“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=204&urls=list-do=view-fileurl=apps-appid=1118"ac=list&do=view&fileurl=apps&appid=1118">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-06-08 16:22:33</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150608162113)测试1“于“2015-06-08 16:22:33“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=205&urls=list-do=view-fileurl=apps-appid=1118"ac=list&do=view&fileurl=apps&appid=1118">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-06-08 16:22:33</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-06-08 16:21:55</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-06-08 16:21:29</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-06-05 17:55:31</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 16:50:58</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150528165019)测试1“于“2015-05-28 16:50:58“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=199&urls=list-do=view-fileurl=apps-appid=1106"ac=list&do=view&fileurl=apps&appid=1106">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 16:50:58</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 16:50:36</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“abcdefg(No:20150528164851)测试1“于“2015-05-28 16:49:42“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=195&urls=list-do=view-fileurl=apps-appid=1105"ac=list&do=view&fileurl=apps&appid=1105">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 16:49:42</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 16:49:27</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“abcdefg(No:20150528164851)测试1“于“2015-05-28 16:49:27“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=194&urls=list-do=view-fileurl=apps-appid=1105"ac=list&do=view&fileurl=apps&appid=1105">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 16:49:27</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 16:48:59</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“abcdefg(No:20150528162028)测试1“于“2015-05-28 16:25:18“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=190&urls=list-do=view-fileurl=apps-appid=1104"ac=list&do=view&fileurl=apps&appid=1104">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 16:25:18</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 16:24:36</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要阅读,请点击进入公文阅读里进行查看!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 16:22:37</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 16:20:45</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“公文收文(No:20150528161301)测试1“于“2015-05-28 16:14:05“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=175&urls=list-do=view-fileurl=apps-appid=1099"ac=list&do=view&fileurl=apps&appid=1099">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 16:14:05</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“公文收文(No:20150528161301)测试1“于“2015-05-28 16:14:05“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=176&urls=list-do=view-fileurl=apps-appid=1099"ac=list&do=view&fileurl=apps&appid=1099">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 16:14:05</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 16:13:48</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“公文收文(No:20150528161301)测试1“于“2015-05-28 16:13:48“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=174&urls=list-do=view-fileurl=apps-appid=1099"ac=list&do=view&fileurl=apps&appid=1099">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 16:13:48</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 16:13:28</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个计划需要执行,计划主题为：12222;请进行处理!&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=157&urls=plan-fileurl=workbench-do=views-id=2"ac=plan&fileurl=workbench&do=views&id=2">点击查看>></a></p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:33:09</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个计划需要参与,计划主题为：12222;请进行处理!&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=167&urls=plan-fileurl=workbench-do=views-id=2"ac=plan&fileurl=workbench&do=views&id=2">点击查看>></a></p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:33:09</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个任务需要执行,编号为：20150528152442;请进行处理!&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=147&urls=duty-fileurl=duty-do=view-id=7"ac=duty&fileurl=duty&do=view&id=7">点击处理>></a></p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:25:07</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个任务需要执行,编号为：20150528151954;请进行处理!&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=137&urls=duty-fileurl=duty-do=view-id=6"ac=duty&fileurl=duty&do=view&id=6">点击处理>></a></p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:20:37</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个工作流程需要审批,请点击进入工作流进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:17:22</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个工作流程需要审批,请点击进入工作流进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:13:51</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
审批流程“用车申请(No:20150528151235)测试1“于“2015-05-28 15:13:51“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=130&urls=list-do=view-fileurl=workclass-workid=1083"ac=list&do=view&fileurl=workclass&workid=1083">查看</a>”工作流!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:13:51</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个工作流程需要审批,请点击进入工作流进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:13:16</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
审批流程“用车申请(No:20150528150702)测试1“于“2015-05-28 15:12:10“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=123&urls=list-do=view-fileurl=workclass-workid=1082"ac=list&do=view&fileurl=workclass&workid=1082">查看</a>”工作流!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:12:10</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
审批流程“用车申请(No:20150528150702)测试1“于“2015-05-28 15:12:10“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=124&urls=list-do=view-fileurl=workclass-workid=1082"ac=list&do=view&fileurl=workclass&workid=1082">查看</a>”工作流!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:12:10</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
审批流程“用车申请(No:20150528150702)测试1“于“2015-05-28 15:12:10“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=125&urls=list-do=view-fileurl=workclass-workid=1082"ac=list&do=view&fileurl=workclass&workid=1082">查看</a>”工作流!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:12:10</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
审批流程“用车申请(No:20150528150702)测试1“于“2015-05-28 15:12:10“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=126&urls=list-do=view-fileurl=workclass-workid=1082"ac=list&do=view&fileurl=workclass&workid=1082">查看</a>”工作流!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:12:10</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
审批流程“用车申请(No:20150528150702)测试1“于“2015-05-28 15:12:10“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=127&urls=list-do=view-fileurl=workclass-workid=1082"ac=list&do=view&fileurl=workclass&workid=1082">查看</a>”工作流!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:12:10</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个工作流程需要审批,请点击进入工作流进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:11:45</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
审批流程“用车申请(No:20150528150702)测试1“于“2015-05-28 15:11:45“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=119&urls=list-do=view-fileurl=workclass-workid=1082"ac=list&do=view&fileurl=workclass&workid=1082">查看</a>”工作流!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:11:45</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
审批流程“用车申请(No:20150528150702)测试1“于“2015-05-28 15:11:45“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=120&urls=list-do=view-fileurl=workclass-workid=1082"ac=list&do=view&fileurl=workclass&workid=1082">查看</a>”工作流!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:11:45</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
审批流程“用车申请(No:20150528150702)测试1“于“2015-05-28 15:11:45“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=121&urls=list-do=view-fileurl=workclass-workid=1082"ac=list&do=view&fileurl=workclass&workid=1082">查看</a>”工作流!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:11:45</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
审批流程“用车申请(No:20150528150702)测试1“于“2015-05-28 15:11:45“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=122&urls=list-do=view-fileurl=workclass-workid=1082"ac=list&do=view&fileurl=workclass&workid=1082">查看</a>”工作流!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:11:45</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个工作流程需要审批,请点击进入工作流进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:10:26</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
审批流程“用车申请(No:20150528150702)测试1“于“2015-05-28 15:10:26“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=115&urls=list-do=view-fileurl=workclass-workid=1082"ac=list&do=view&fileurl=workclass&workid=1082">查看</a>”工作流!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:10:26</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
审批流程“用车申请(No:20150528150702)测试1“于“2015-05-28 15:10:26“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=116&urls=list-do=view-fileurl=workclass-workid=1082"ac=list&do=view&fileurl=workclass&workid=1082">查看</a>”工作流!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:10:26</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
审批流程“用车申请(No:20150528150702)测试1“于“2015-05-28 15:10:26“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=117&urls=list-do=view-fileurl=workclass-workid=1082"ac=list&do=view&fileurl=workclass&workid=1082">查看</a>”工作流!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:10:26</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个工作流程需要审批,请点击进入工作流进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:09:33</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
审批流程“用车申请(No:20150528150702)测试1“于“2015-05-28 15:09:33“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=112&urls=list-do=view-fileurl=workclass-workid=1082"ac=list&do=view&fileurl=workclass&workid=1082">查看</a>”工作流!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:09:33</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
审批流程“用车申请(No:20150528150702)测试1“于“2015-05-28 15:09:33“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=113&urls=list-do=view-fileurl=workclass-workid=1082"ac=list&do=view&fileurl=workclass&workid=1082">查看</a>”工作流!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:09:33</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个工作流程需要审批,请点击进入工作流进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:08:44</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
审批流程“用车申请(No:20150528150702)测试1“于“2015-05-28 15:08:44“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=110&urls=list-do=view-fileurl=workclass-workid=1082"ac=list&do=view&fileurl=workclass&workid=1082">查看</a>”工作流!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:08:44</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个工作流程需要审批,请点击进入工作流进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 15:07:53</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:46:58</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144458)测试1“于“2015-05-28 14:46:58“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=106&urls=list-do=view-fileurl=apps-appid=1098"ac=list&do=view&fileurl=apps&appid=1098">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:46:58</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144458)测试1“于“2015-05-28 14:46:58“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=107&urls=list-do=view-fileurl=apps-appid=1098"ac=list&do=view&fileurl=apps&appid=1098">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:46:58</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:46:21</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144458)测试1“于“2015-05-28 14:46:21“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=104&urls=list-do=view-fileurl=apps-appid=1098"ac=list&do=view&fileurl=apps&appid=1098">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:46:21</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:45:36</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:43:47“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=96&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:47</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:43:47“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=97&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:47</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:43:47“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=98&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:47</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:43:47“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=99&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:47</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:43:47“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=100&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:47</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:43:47“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=101&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:47</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:28</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:43:28“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=91&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:28</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:43:28“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=92&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:28</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:43:28“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=93&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:28</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:43:28“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=94&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:28</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:43:28“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=95&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:28</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:11</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:43:11“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=86&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:11</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:43:11“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=87&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:11</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:43:11“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=88&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:11</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:43:11“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=89&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:43:11</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:42:54</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:42:54“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=82&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:42:54</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:42:54“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=83&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:42:54</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:42:54“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=84&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:42:54</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:42:29</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:42:29“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=79&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:42:29</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:42:29“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=80&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:42:29</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:42:11</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“市委办公室发文呈批单(No:20150528144117)测试1“于“2015-05-28 14:42:11“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=77&urls=list-do=view-fileurl=apps-appid=1097"ac=list&do=view&fileurl=apps&appid=1097">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:42:11</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:41:52</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150528143534)测试1“于“2015-05-28 14:39:19“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=70&urls=list-do=view-fileurl=apps-appid=1095"ac=list&do=view&fileurl=apps&appid=1095">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:39:19</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150528143534)测试1“于“2015-05-28 14:39:19“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=71&urls=list-do=view-fileurl=apps-appid=1095"ac=list&do=view&fileurl=apps&appid=1095">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:39:19</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150528143534)测试1“于“2015-05-28 14:39:19“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=72&urls=list-do=view-fileurl=apps-appid=1095"ac=list&do=view&fileurl=apps&appid=1095">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:39:19</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150528143534)测试1“于“2015-05-28 14:39:19“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=73&urls=list-do=view-fileurl=apps-appid=1095"ac=list&do=view&fileurl=apps&appid=1095">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:39:19</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150528143534)测试1“于“2015-05-28 14:39:19“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=74&urls=list-do=view-fileurl=apps-appid=1095"ac=list&do=view&fileurl=apps&appid=1095">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:39:19</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:39:00</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150528143534)测试1“于“2015-05-28 14:39:00“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=66&urls=list-do=view-fileurl=apps-appid=1095"ac=list&do=view&fileurl=apps&appid=1095">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:39:00</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150528143534)测试1“于“2015-05-28 14:39:00“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=67&urls=list-do=view-fileurl=apps-appid=1095"ac=list&do=view&fileurl=apps&appid=1095">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:39:00</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150528143534)测试1“于“2015-05-28 14:39:00“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=68&urls=list-do=view-fileurl=apps-appid=1095"ac=list&do=view&fileurl=apps&appid=1095">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:39:00</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150528143534)测试1“于“2015-05-28 14:39:00“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=69&urls=list-do=view-fileurl=apps-appid=1095"ac=list&do=view&fileurl=apps&appid=1095">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:39:00</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:38:40</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150528143534)测试1“于“2015-05-28 14:38:40“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=62&urls=list-do=view-fileurl=apps-appid=1095"ac=list&do=view&fileurl=apps&appid=1095">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:38:40</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150528143534)测试1“于“2015-05-28 14:38:40“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=63&urls=list-do=view-fileurl=apps-appid=1095"ac=list&do=view&fileurl=apps&appid=1095">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:38:40</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150528143534)测试1“于“2015-05-28 14:38:40“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=64&urls=list-do=view-fileurl=apps-appid=1095"ac=list&do=view&fileurl=apps&appid=1095">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:38:40</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:37:40</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150528143534)测试1“于“2015-05-28 14:37:40“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=59&urls=list-do=view-fileurl=apps-appid=1095"ac=list&do=view&fileurl=apps&appid=1095">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:37:40</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150528143534)测试1“于“2015-05-28 14:37:40“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=60&urls=list-do=view-fileurl=apps-appid=1095"ac=list&do=view&fileurl=apps&appid=1095">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:37:40</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:36:41</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
公文流程“住房和城乡建设局文件处理笺(No:20150528143534)测试1“于“2015-05-28 14:36:41“被测试1审批完成,请点击“&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=57&urls=list-do=view-fileurl=apps-appid=1095"ac=list&do=view&fileurl=apps&appid=1095">查看</a>”公文!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:36:41</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-28 14:36:08</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试8</em>：
您有一个任务需要执行,编号为：20150516162923;请进行处理!&nbsp;&nbsp;<a href="admin.php?ac=receive&fileurl=sms&do=smskeymana&id=52&urls=duty-fileurl=duty-do=view-id=5"ac=duty&fileurl=duty&do=view&id=5">点击处理>></a></p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-27 17:50:08</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-27 16:54:37</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个工作流程需要审批,请点击进入工作流进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-22 10:33:27</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个公文流程需要审批,请点击进入公文管理进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-20 23:07:08</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
<div class="content clearfix">
<p class="content_txt">
<em>测试1</em>：
您有一个工作流程需要审批,请点击进入工作流进行审批!</p>
<p class="content_action WB_linkB">
<span class="content_actionTime">
2015-05-19 17:56:51</span>
<!--<span class="content_actionMore">
标志己读
</span>
 --></p>
</div>
  
</div>
</div>
</div>
</div>

		</div>
	</td>
  <td valign="top">
 <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table-layout-fixed">
 <tr>
  <td id="col_l" width="65%" valign="top">
<div id="module_0" class="module listColor"><div class="head"><h4 id="module_0_head" class="moduleHeader"><a href="javascript:_resize(0);" class="expand expand_arrow" id="img_resize_0" title="折叠"></a><span id="module_0_text" class="text" onclick="_resize(0);">公共文件柜</span></h4></div><div id="module_0_body" class="module_body"><div id="module_0_ul" class="module_div" style="height:150px;overflow:auto;"><ul><li><a href="admin.php?ac=document&fileurl=knowledge&do=list&type=2">img002.jpg</a></li></ul></div></div></div><div id="module_1" class="module listColor"><div class="head"><h4 id="module_1_head" class="moduleHeader"><a href="javascript:_resize(1);" class="expand expand_arrow" id="img_resize_1" title="折叠"></a><span id="module_1_text" class="text" onclick="_resize(1);">下载管理</span></h4></div><div id="module_1_body" class="module_body"><div id="module_1_ul" class="module_div" style="height:150px;overflow:auto;"><ul><li><a href="admin.php?ac=document&fileurl=knowledge&do=list&type=4">天生创想OA产品介绍与报价V2014.doc</a></li></ul><ul><li><a href="admin.php?ac=document&fileurl=knowledge&do=list&type=4">天生创想协同OA软件简介.ppt</a></li></ul><ul><li><a href="admin.php?ac=document&fileurl=knowledge&do=list&type=4">天生创想OA政务版产品介绍与报价.doc</a></li></ul><ul><li><a href="admin.php?ac=document&fileurl=knowledge&do=list&type=4">天生创想OA(V2014)产品说明书.doc</a></li></ul><ul><li><a href="admin.php?ac=document&fileurl=knowledge&do=list&type=4">天生创想OA手机(企业微信)版产品说明书.doc</a></li></ul><ul><li><a href="admin.php?ac=document&fileurl=knowledge&do=list&type=4">天生创想OA手机(WAP)版产品说明书v3.0.doc</a></li></ul></div></div></div>
<div class="shadow"></div>  </td>
  <td id="col_r" valign="top">
<div id="module_2" class="module listColor"><div class="head"><h4 id="module_2_head" class=" moduleHeader"><a href="javascript:_resize(2);" class="expand expand_arrow" id="img_resize_2" title="折叠"></a><span id="module_2_text" class="text" onclick="_resize(2);">新闻</span></h4></div><div id="module_2_body" class="module_body"><div id="module_2_ul" class="module_div" style="height:150px;overflow:auto;"></div></div></div></div><div id="module_3" class="module listColor"><div class="head"><h4 id="module_3_head" class="moduleHeader"><a href="javascript:_resize(3);" class="expand expand_arrow" id="img_resize_3" title="折叠"></a><span id="module_3_text" class="text" onclick="_resize(3);">大事记</span></h4></div><div id="module_3_body" class="module_body"><div id="module_3_ul" class="module_div" style="height:150px;overflow:auto;"></div></div></div></div><div id="module_4" class="module listColor"><div class="head"><h4 id="module_4_head" class="moduleHeader"><a href="javascript:_resize(4);" class="expand expand_arrow" id="img_resize_4" title="折叠"></a><span id="module_4_text" class="text" onclick="_resize(4);">投票</span></h4></div><div id="module_4_body" class="module_body"><div id="module_4_ul" class="module_div" style="height:150px;overflow:auto;"><ul><li><a href="admin.php?ac=app&fileurl=knowledge&do=views&id=1" target="_blank">9+5+98</a></li></ul></div></div></div>


<div class="shadow"></div>
  </td>
 </tr>
</table>
  </td>
 </tr>
</table>




</body>
</html>
