<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UxPositionSelect.ascx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Controls.UxPositionSelect" %>
<input id="<%=ClientID %>" type="button" value="选择" />
<asp:Label ID="lblName" runat="server"></asp:Label>
<asp:HiddenField ID="hfId" runat="server" />
<asp:HiddenField ID="hfName" runat="server" />
<script type="text/javascript">
    $(function () {
        $("#<%=lblName.ClientID %>").text($("#<%=hfName.ClientID %>"));

        $("#<%=ClientID %>").click(function () {
            return openWindow('<%=Page.ResolveUrl("~/")%>Pages/Controls/Pages/PositionSelect.aspx', null, null, function (win) {
                win.hfId = "<%=hfId.ClientID %>";
                win.hfName = "<%=hfName.ClientID %>";
                win.lblName = "<%=lblName.ClientID %>";
                win.focus();
        });
    });
</script>
