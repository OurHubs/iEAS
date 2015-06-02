<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Theme="Default" Inherits="iEAS.Infrastructure.Web.Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>框架管理系统</title>
     <link href="Assets/easyui/theme/icon.css" rel="stylesheet" />  
     <link href="Assets/common/css/Admin.css" rel="stylesheet" />
     <script src="Assets/common/js/jquery.min.js" type="text/javascript"></script>
     <script src="Assets/easyui/jquery.easyui.min.js" type="text/javascript"></script>
</head>
<body class="easyui-layout">
    <form id="form1" runat="server">
    <div data-options="region:'north',split:false" style="height:81px;" id="region_head"> 
        <img src="assets/common/images/logo.png" />
         <div class="div_sys_user">
            <div >欢迎您，<span class="span_name">Lance</span></div>
            <div class="div_min_split"> </div>
           
            <div ><a href="#">退出</a></div>                
            <div class="div_min_split"></div>            
            <div ><a href="#" target="_blank">网站首页</a></div>    
             <div class="div_min_split"></div>          
            <div ><a href="#" id="div_wel" >首页</a></div>
        </div>
    </div>
    <div data-options="region:'south'" style="height:30px; background:#eee;">
         <div class="div_sys_bottom_company"> 版权所有：一缕晨光设计</div>
         <div class="div_sys_bottom_navigation"><a href="#">首页</a>&nbsp;|&nbsp;<a href="#">常见问题</a>&nbsp;|&nbsp;<a href="#">隐私政策</a></div>
         <div class="div_sys_bottom_txt">建议使用IE7.0版本以上的浏览器</div>
    </div>
    <div data-options="region:'west',title:'&nbsp;系统菜单',split:true" style="width:170px;" id="">
        <div class="easyui-accordion"   fit='true' border='false' id='div_main_left_menu'>
             <div title="框架页面Demo" data-title="框架页面Demo" style="padding: 10px; overflow: auto;">
                 <ul class="ul_menu">
                      <li data-url="Pages/BaseData/BaseDataTypeList.aspx" >基础数据</li>
                    <li data-url="Pages/Module/PortalList.aspx" >入口</li>
                      <li data-url="List.aspx" >列表页面-带搜索</li>
                      <li data-url="ListSimple.aspx" >列表页面-简单</li>
                      <li data-sec_menu_url="TreeDemo.aspx"   data-url="List.aspx" >带有二级页面树</li>
                 </ul>
             </div>
             <div title="lhgdialog弹出层试例" data-title="lhgdialog弹出层试例"  style="padding: 10px; overflow: auto;">
                 <ul class="ul_menu">
                     <li data-url="lhgDemo/lhgBase.aspx">基本应用</li>
                     <li data-url="lhgDemo/MoreFloor.html" >多层弹出Demo</li>
                     <li data-url="loafjs/parent.aspx" >封装后的lhgdialog</li>
                 </ul>
             </div>
             <div title="菜单三"  data-title="菜单三" style="padding: 10px; overflow: auto;">
                  <ul class="ul_menu">
                     <li data-url="/Public/BaseDictionary/agencyList.htm">合作机构</li>
                     <li data-url="/Public/BaseDictionary/cityList.htm">区域城市</li>
                     <li data-url="/Public/BaseDictionary/insuranceCityCaseList.htm">社保政策</li>
                 </ul>
             </div>
        </div>
    </div>
    <div data-options="region:'center',iconCls:'icon-home'" title="<div class='div_main_title'></div>" style="background:#fff;">
        <div class="easyui-layout" data-options="fit:true" id="center_main_sec"  >
			<div data-options="region:'west',split:true,border:false" style="width:150px">
                    <div class="easyui-tabs" data-options="fit:true" border="false" >           
                    <iframe  src="Welcome.aspx" id="iframe_two_menu" name="iframe_two_menu" frameborder="0" framespacing="0" width="100%" height="100%"> </iframe>
                    </div>
            </div>
			<div data-options="region:'center',border:false">
                <div class="easyui-tabs"  data-options="fit:true" >           
                    <iframe  src="Welcome.aspx" id="iframe_two_main" name="iframe_two_main"  frameborder="0" framespacing="0" width="100%" height="100%"> </iframe>
                    </div>
			</div>
		</div>
        <div class="easyui-tabs" data-options="fit:true" id="center_main"  >           
            <iframe  src="Welcome.aspx" id="iframe_one_main" name="iframe_one_main" frameborder="0" framespacing="0" width="100%" height="100%"> </iframe>
        </div>
	</div>
    </form>
</body>
</html>
<script type="text/javascript">
    $(function () {
        $("#center_main_sec").hide();
        $(".div_main_title").html("<div class='div_main_title_txt'>当前位置：管理系统&nbsp;>&nbsp;系统首页&nbsp;>&nbsp;首页</div>");
        //初始化左侧带单
        $("#div_main_left_menu li").click(function () {
            var parentTitle = $(this).closest("div").data("title");
            var url = $(this).data("url");//
            var securl = $(this).data("sec_menu_url");//二级菜单目录
            if (securl == null) {//没有二级菜单url
                $("#center_main").show();
                $("#center_main_sec").hide();
                $("#iframe_one_main").attr("src", url);

            } else {
                $("#center_main").hide();
                $("#center_main_sec").show();
                $("#iframe_two_main").attr("src", url);
                $("#iframe_two_menu").attr("src", securl);
            }

            $(".div_main_title_txt").html("当前位置：管理系统 > " + parentTitle + " > " + $(this).html());

            //菜单样式更改
            $(this).removeClass("currentli");//移除所有
            $(this).addClass("currentli").siblings().removeClass("currentli");
        });
    });
    </script>