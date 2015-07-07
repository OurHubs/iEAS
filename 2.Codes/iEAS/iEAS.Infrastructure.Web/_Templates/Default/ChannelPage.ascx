<%@ Control Language="C#" AutoEventWireup="true" %>

<%@ Register src="Controls/Header/Header.ascx" tagname="Header" tagprefix="ux" %>
<%@ Register src="Controls/HtmlPart/HtmlPart.ascx" tagname="HtmlPart" tagprefix="ux" %>
<%@ Register src="Controls/Menu/TopMenu.SubMenu.ascx" tagname="TopMenu_SubMenu" tagprefix="ux" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title><%=SiteConfig.Instance.Title %></title>
    <meta name="keywords" content="<%=SiteConfig.Instance.Keywords %>" />
    <meta name="description" content="<%=SiteConfig.Instance.Description %>" />
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/_Templates/<%=SiteConfig.Instance.Template %>/assets/css/reset.css" rel="stylesheet" type="text/css" />
    <link href="/_Templates/<%=SiteConfig.Instance.Template %>/assets/css/public.css" rel="stylesheet" type="text/css" />
    <link href="/_Templates/<%=SiteConfig.Instance.Template %>/assets/css/style.css" rel="stylesheet" type="text/css" />
    <script src="/_Templates/<%=SiteConfig.Instance.Template %>/assets/js/jquery.min.js" type="text/javascript"></script>
    <script src="/_Templates/<%=SiteConfig.Instance.Template %>/assets/js/public.js" type="text/javascript"></script>
    <script src="/_Templates/<%=SiteConfig.Instance.Template %>/assets/js/MSClass.js" type="text/javascript"></script>
</head>
<body>
<ux:Header ID="Header" runat="server" />
<div class="other-banner">
	<ux:TopMenu_SubMenu ID="subMenu" runat="server"></ux:TopMenu_SubMenu>
</div>
<div class="wp clear">
	<div class="crumbs"><a href="/">首页</a><span> > </span><a href="product.html">产品</a><span> > </span><a href="product.html">产品介绍</a><span> > </span></div>
	<div class="box_line baojia-content lh22 min-height">       
        <div class="bk10">&nbsp;</div>
        <div class="products"> 
          <div class="products_a">
          <p style="font-size:36px; line-height:75px;color:#000000; font-weight:800; text-align:center;">天生创想OA协同管理软件</p>
                      <p>天生创想OA办公系统是适用于中小型企业的通用型协同OA管理软件，融合了天生创想OA长期从事管理软件开发的丰富经验与先进技术，该系统采用领先的B/S(浏览器/服务器)操作方式，使得网络办公不受地域限制。
        </p>
                      <p>天生创想OA使用敏捷的MVC开发框架，支持多种模块分布式开发，统一布局，界面简洁不失严肃。其功能包含有个人办公、工作流、公文、人力资源、行政办公、档案、项目管理、知识库、在线交流、CRM系统等，含盖60多个功能点，适合于企业领域内若干规范和要求，构成高性能、高可用、高质量、底成本的信息化管理平台。</p>
                      <p><img src="images/prod_1.png" /></p>
                      <p>天生创想OA首开先河，将众多企业视为保密、加密的软件源代码进行开放。在目前的OA、CRM软件市场上，大多数企业的源代码是加密的，有极小部份企业把源代码开放最多为30%，而天生创想OA一直以来以一种开放的思想，将基础源代码进行全开放，方便企业二次开发及维护。 </p>
			  
			  
			           <p style="font-size:36px; line-height:75px;color:#000000; font-weight:800; text-align:center;">办公效率的加速器</p> 
			  
			          <p>天生创想OA帮助企业的员工有效提升工作效率，通过无时无刻的文件同步以及基于文件的信息流，无论在办公室还是身处机场，地铁，都能够及时的查阅与操作文件，让员工不知不觉快起来。</p>
			  
			          <p><img src="images/speedup2_1.png" /></p>
			  
			  
			           <p style="font-size:36px; line-height:75px;color:#000000; font-weight:800; text-align:center;">使用天生创想OA，让企业员工在工作效率上、员工协作上的效率至少提升200%</p>
			          <p><img src="images/speedup2_4.png" /></p>
			          <p style="font-size:36px; line-height:75px;color:#000000; font-weight:800; text-align:center;">强大的移动手机端</p>
			          <p style="font-size:18px; line-height:45px;color:#666666; text-align:center;">功能强大的移动OA手机端。让移动OA成为随身携带的办公室，让企业的智慧与移动互联网有机结合</p>
			          <p><img src="images/beapart1_5.png" /></p>
                    </div>
        </div>
        <div class="bk15">&nbsp;</div>
    </div>
</div>
<div class="wp link">
    <ux:HtmlPart Id="keywords" runat="server" title="相关关键词" RecordID="3bc00f4e-f52a-4760-b315-eff22b39134c" DataSourceCode="HtmlPart.Record"></ux:HtmlPart>
</div>
<div class="footer">
    <ux:HtmlPart Id="footer" runat="server" title="尾部" RecordID="834354e3-6721-4ef9-a8c8-31d6affc2d75" DataSourceCode="HtmlPart.Record"></ux:HtmlPart>
</div>
<script type="text/javascript">

    $(".select").hover(
        function () {
            $(this).find(".msgNav").show();
        },
        function () {
            $(this).find(".msgNav").hide();
        }
    );
    $(".title-btn").toggle(
        function () {
            $(this).addClass("on");
            $(this).parent(".box-content").removeClass("off");
        },
        function () {
            $(this).removeClass("on");
            $(this).parent(".box-content").addClass("off");
        }
    );
</script>
</body>
</html>