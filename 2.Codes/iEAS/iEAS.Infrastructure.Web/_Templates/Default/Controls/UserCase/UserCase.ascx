<%@ Control Language="C#" AutoEventWireup="true" Inherits="iEAS.Model.UI.UxModelControl" %>

<div class="box">
    <div class="title"><span><%=Title %></span><span class="bg"><%=Title %></span></div>
    <div class="box-content anli picbig">
        <div id="anliWp">
            <ul id="anliContent">
                <li style="width: 710px; height: 208px;">
                    <ul class="clear picList">
                        <% Iterator(m =>
                           { %>
                        <li>
                            <div class="img-wrap">
                                <a href="Detail/<%=m.GetStr("RecordID")%>">
                                    <img src="<%=m.GetStr("Thumbnail")%>" alt="<%=m.GetStr("Name")%>"></a>
                            </div>
                        </li>
                        <%}); %>
                    </ul>
                </li>
            </ul>
        </div>
    </div>
</div>
