<%@ Control Language="C#" AutoEventWireup="true" %>

<%@ Register src="Controls/ProductShow/ProductShow.ascx" tagname="ProductShow" tagprefix="ux" %>
<%@ Register src="Controls/Header/Header.ascx" tagname="Header" tagprefix="ux" %>
<%@ Register src="Controls/Special/Special.ascx" tagname="Special" tagprefix="ux" %>
<%@ Register src="Controls/News/News.ascx" tagname="News" tagprefix="ux" %>
<%@ Register src="Controls/UserCase/UserCase.ascx" tagname="UserCase" tagprefix="ux" %>
<%@ Register src="Controls/HtmlPart/HtmlPart.ascx" tagname="HtmlPart" tagprefix="ux" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title><%=SiteConfig.Instance.Title %></title>
    <meta name="keywords" content="<%=SiteConfig.Instance.Keywords %>" />
    <meta name="description" content="<%=SiteConfig.Instance.Description %>" />
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="_Templates/<%=SiteConfig.Instance.Template %>/assets/css/reset.css" rel="stylesheet" type="text/css" />
    <link href="_Templates/<%=SiteConfig.Instance.Template %>/assets/css/public.css" rel="stylesheet" type="text/css" />
    <link href="_Templates/<%=SiteConfig.Instance.Template %>/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="_Templates/<%=SiteConfig.Instance.Template %>/assets/css/style1.css" rel="stylesheet" type="text/css" />
    <script src="_Templates/<%=SiteConfig.Instance.Template %>/assets/js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="_Templates/<%=SiteConfig.Instance.Template %>/assets/js/jquery.mousewheel.min.js"></script>
</head>
<body>
    <ux:Header ID="Header" runat="server" />
    <ux:ProductShow ID="ProductShow1" runat="server" />
    <div class="wp clear">
        <ux:Special ID="Special" runat="server" Title="产品特色" DataSourceCode="Special.List" />
        <div class="col-left w720">
            <ux:UserCase Id="UserCase1" runat="server" title="客户案例" DataSourceCode="UserCase.List"></ux:UserCase>
        </div>   
        <div class="col-right m-news">
            <ux:News Id="News" runat="server" title="新闻动态" DataSourceCode="News.List"></ux:News>
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

