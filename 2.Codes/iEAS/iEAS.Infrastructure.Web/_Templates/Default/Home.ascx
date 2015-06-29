<%@ Control Language="C#" AutoEventWireup="true" %>

<%@ Register src="Controls/ProductShow.ascx" tagname="ProductShow" tagprefix="ux" %>
<%@ Register src="Controls/Header.ascx" tagname="Header" tagprefix="ux" %>
<%@ Register src="Controls/Special.ascx" tagname="Special" tagprefix="ux" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title><%=SiteConfig.Instance.Title %></title>
    <meta name="keywords" content="<%=SiteConfig.Instance.Keywords %>" />
    <meta name="description" content="<%=SiteConfig.Instance.Description %>" />
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
        <ux:Special ID="Special" runat="server" />
        <div class="col-left w720">
            <div class="box">
                <div class="title"><span>客户案例</span><span class="bg">客户案例</span></div>
                <div class="box-content anli picbig">
                    <div id="anliWp">
                        <ul id="anliContent">
                            <li style="width: 710px; height: 208px;">
                                <ul class="clear picList">
                                    <li>
                                        <div class="img-wrap"><a href="product.html">
                                            <img src="upload/01.gif" alt="OA系统"></a></div>
                                    </li>
                                    <li>
                                        <div class="img-wrap"><a href="product.html">
                                            <img src="upload/02.gif" alt="OA系统"></a></div>
                                    </li>
                                    <li>
                                        <div class="img-wrap"><a href="product.html">
                                            <img src="upload/03.gif" alt="OA系统"></a></div>
                                    </li>
                                    <li>
                                        <div class="img-wrap"><a href="product.html">
                                            <img src="upload/04.gif" alt="OA系统"></a></div>
                                    </li>
                                    <li>
                                        <div class="img-wrap"><a href="product.html">
                                            <img src="upload/05.gif" alt="OA系统"></a></div>
                                    </li>
                                    <li>
                                        <div class="img-wrap"><a href="product.html">
                                            <img src="upload/06.gif" alt="OA系统"></a></div>
                                    </li>
                                    <li>
                                        <div class="img-wrap"><a href="product.html">
                                            <img src="upload/07.gif" alt="OA系统"></a></div>
                                    </li>
                                    <li>
                                        <div class="img-wrap"><a href="product.html">
                                            <img src="upload/08.gif" alt="OA系统"></a></div>
                                    </li>
                                    <li>
                                        <div class="img-wrap"><a href="product.html">
                                            <img src="upload/09.gif" alt="OA系统"></a></div>
                                    </li>
                                    <li>
                                        <div class="img-wrap"><a href="product.html">
                                            <img src="upload/10.gif" alt="OA系统"></a></div>
                                    </li>
                                    <li>
                                        <div class="img-wrap"><a href="product.html">
                                            <img src="upload/11.gif" alt="OA系统"></a></div>
                                    </li>
                                    <li>
                                        <div class="img-wrap"><a href="product.html">
                                            <img src="upload/12.gif" alt="OA系统"></a></div>
                                    </li>
                                </ul>
                            </li>




                        </ul>
                    </div>
                </div>

            </div>
        </div>
        <div class="col-right m-news">
            <div class="box">
                <div class="title"><span>新闻动态</span><span class="bg">新闻动态</span></div>
                <div class="box-content">
                    <ul class="m-list" style="margin-bottom: 0">
                        <li>·<a href="article/2327.html" title="天生创想CRM 产品安装/运行环境" target="_blank">天生创想CRM 产品安装/运行环境</a></li>
                        <li>·<a href="article/2326.html" title="天生创想CRM 版本升级与定制开发" target="_blank">天生创想CRM 版本升级与定制开发</a></li>
                        <li>·<a href="article/2325.html" title="CRM客户管理系统 产品验证与授权" target="_blank">CRM客户管理系统 产品验证与授权</a></li>
                        <li>·<a href="article/2324.html" title="天生创想CRM 运行环境安装Apache+Mysql+PHP集成环境" target="_blank">天生创想CRM...</a></li>
                        <li>·<a href="article/2323.html" title="天生创想CRM 软件安装详解" target="_blank">天生创想CRM 软件安装详解</a></li>
                        <li>·<a href="article/2322.html" title="[天生创想CRM]系统基础信息配置" target="_blank">[天生创想CRM]系统基础信息配置</a></li>
                        <li>·<a href="article/2321.html" title="天生创想CRM 系统权限设置" target="_blank">天生创想CRM 系统权限设置</a></li>
                        <li>·<a href="article/2320.html" title="天生创想CRM 部门设置" target="_blank">天生创想CRM 部门设置</a></li>


                    </ul>
                    <p align="right"><a href="news.php" class="more" style="position: static">查看更多</a></p>
                </div>
            </div>
        </div>
    </div>
    <div class="wp link">
        <strong>相关关键词：</strong><a href="http://www.515158.com/" target="_blank">OA</a> | <a href="http://www.515158.com/" target="_blank">OA办公系统</a> | <a href="http://www.515158.com/" target="_blank">OA软件</a> | <a href="http://www.515158.com/" target="_blank">OA系统</a> | <a href="http://www.515158.com/" target="_blank">协同OA软件</a> | <a href="http://www.515158.com/" target="_blank">手机OA系统</a> | <a href="http://www.515158.com/" target="_blank">天生创想OA</a>
    </div>

    <div class="footer">
        <p>
            <a href="about.html">关于天生创想</a><span> | </span><a href="about_aptitude.html">联系我们</a><span> | </span><a href="news.php?type=3">公司动态</a><span> | </span><a href="about_job.html">人才招聘</a><span> | </span><a href="about_law.html">版权声明</a><span> | </span><a href="about_secret.html" target="_blank">隐私保护</a><span> | </span><a href="http://www.515158.com/2013.html" target="_blank">加盟代理</a><div style="display: none;">
                <script src="http://s94.cnzz.com/stat.php?id=2032594&web_id=2032594&show=pic1" language="JavaScript"></script>
            </div>
        </p>
        <p>
            CopyRight &copy; 2014 北京天生创想信息技术有限公司 京ICP备12044350号-5
        </p>
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

