<%@ Control Language="C#" AutoEventWireup="true" Inherits="iEAS.Model.UI.UxModelPager" %>
<div id="pages" class="text-c mg20">
    <a class="a1"><%=RecordCount %>条</a>
    <% if (HasPrevPageIndex)
       { %>
    <a href="<%=Page.GetChannelUrl(PrevPageIndex) %>" class="a1">上一页</a>
    <%}
       else
       { %>
    <span>上一页</span>
    <%} %>
    <% for (int i = StartPageIndex; i <= EndPageIndex; i++)
       { %>
    <% if (i == CurrentPageIndex)
       { %>
    <span><%=i %></span>
    <%}
       else
       { %>
    <a href="<%=Page.GetChannelUrl(i) %>"><%=i %></a>
    <%} %>
    <%} %>
     <% if (HasNextPageIndex)
       { %>
    <a href="<%=Page.GetChannelUrl(NextPageIndex) %>" class="a1">下一页</a>
    <%}
       else
       { %>
    <span>下一页</span>
    <%} %>
</div>
