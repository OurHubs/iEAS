<%@ Control Language="C#" AutoEventWireup="true" Inherits="iEAS.Model.UI.UxModelControl" %>
<% Record(m =>
{ %>
<%=m.GetStr("Content") %>
<%}); %>
<script type="text/C#" runat="server">
    public override string DataSourceCode
    {
        get
        {
            return "Page.ChannelRecord";
        }
    }
</script>