<%@ Control Language="C#" AutoEventWireup="true" %>

<%@ Register src="Controls/Header/Header.ascx" tagname="Header" tagprefix="ux" %>
<%@ Register src="Controls/HtmlPart/HtmlPart.ascx" tagname="HtmlPart" tagprefix="ux" %>
<%@ Register src="Controls/Menu/TopMenu.SubMenu.ascx" tagname="TopMenu_SubMenu" tagprefix="ux" %>
<%@ Register src="Controls/Page/Page.ascx" tagname="Page" tagprefix="ux" %>
<%@ Register src="Controls/Crumb/Crumb.ascx" tagname="Crumb" tagprefix="ux" %>

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
    <ux:Crumb ID="crumb" runat="server" />
    <ux:Page ID="channelPage" runat="server" />
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