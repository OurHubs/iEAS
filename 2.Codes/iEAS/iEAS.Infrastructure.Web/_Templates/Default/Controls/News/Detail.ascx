<%@ Control Language="C#" AutoEventWireup="true" Inherits="iEAS.Model.UI.UxModelControl" %>
<% Record(m =>
   { %><div class="titleH1 title"><%=m.GetStr("Title") %></div>
<div class="down-content">
    <div class="lh22" id="contentImg">
        <%=m.GetStr("Content") %>
    </div>
</div>
<%}); %>
<script type="text/C#" runat="server">

    public override string DataSourceCode
    {
        get
        {
            return "News.Record";
        }
    }

</script>