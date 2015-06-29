<%@ Control Language="C#" AutoEventWireup="true" %>
<%@ Register Src="TopMenu.ascx" TagName="TopMenu" TagPrefix="ux" %>
<div class="header">
    <div class="logo"><a href="<%=SiteConfig.Instance.Url %>" title="<%=SiteConfig.Instance.Title %>"></a></div>
    <div class="right-box">
        <div class="top-nav" id="topLogin">
            <span style="font-size: 14px; font-weight: bold; color: #006600"><a href="<%=SiteConfig.Instance.WeiBoUrl %>" target="_blank" style="background-image: none;">
                <img src="/_templates/default/assets/images/sina_weibo.png" border="0">新浪微博</a>&nbsp;&nbsp;&nbsp;&nbsp;咨询热线：400-618-6615</span>&nbsp;&nbsp;&nbsp;&nbsp;<a href="http">商业授权查询</a> <a href="">帮助中心</a>
        </div>
    </div>
    <ux:TopMenu ID="TopMenu" runat="server" />
</div>
