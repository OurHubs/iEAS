<%@ Control Language="C#" AutoEventWireup="true" Inherits="iEAS.Model.UI.UxModelControl" %>
<div class="wp banner-box">
    <div class="lf">
       <% ExecuteRecord(m =>{%><%=m.GetStr("DESC") %><%}, "Channel.SecondMenu"); %>
    </div>
    <ul class="sub-nav-2 cu-span">
        <% Iterator(m =>
           { %>
        <li><a href="/Channel/<%=m.GetStr("ID") %>" title="<%=m.GetStr("Name") %>"><span><%=m.GetStr("NAME") %></span></a></li>
        <%}); %>
    </ul>
</div>

<script type="text/C#" runat="server">
    public override string DataSourceCode
    {
        get { return "Channel.SecondMenu"; }
    }
</script>