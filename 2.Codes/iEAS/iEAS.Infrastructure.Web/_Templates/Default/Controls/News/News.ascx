<%@ Control Language="C#" AutoEventWireup="true" Inherits="iEAS.Model.UI.UxModelControl" %>

<div class="box">
    <div class="title"><span><%=Title %></span><span class="bg"><%=Title %></span></div>
    <div class="box-content">
        <ul class="m-list" style="margin-bottom: 0">
            <%Iterator(m =>
            {%>
            <li>·<a href="/Detail/<%=m.GetStr("RecordID") %>" title="<%=m.GetStr("Title") %>" target="_blank"><%=m.GetStr("Title") %></a></li>
            <%});%>
        </ul>
        <p align="right"><a href="/Channel/News" class="more" style="position: static">查看更多</a></p>
    </div>
</div>