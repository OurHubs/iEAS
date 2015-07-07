<%@ Control Language="C#" AutoEventWireup="true" Inherits="iEAS.Model.UI.UxModelControl" %>
<div class="box">
    <div class="title" title="<%=SiteConfig.Instance.Title %>"><span><%=Title %></span><span class="bg"><%=Title %></span><a href="product.html" class="more" target="_blank">了解<%=Title %></a></div>
    <div class="box-content tese">
        <ul class="clear" id="Browser">
            <% Iterator(m =>
               { %>
            <li>
                <div class="icon">
                    <a href="/Detail/<%=m.GetStr("RecordID") %>">
                        <img src="<%=m.GetStr("Thumbnail") %>" alt="<%=m.GetStr("Title") %>"></a>
                </div>
                <div class="des">
                    <h3><%=m.GetStr("Title") %></h3>
                    <p><%=m.GetStr("Desc") %></p>
                </div>
            </li>
            <%}); %>
        </ul>
    </div>
</div>
