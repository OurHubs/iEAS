<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UxDepartmentSelect.ascx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Controls.UxDepartmentSelect" %>

<input type="button" value="选择" onclick="openPostionSelect()" />
<asp:Label ID="lblName" runat="server"></asp:Label>
<asp:HiddenField ID="hfId" runat="server" />
<asp:HiddenField ID="hfName" runat="server" />
<script type="text/javascript">
    function openPostionSelect() {
        return openWindow('<%=Page.ResolveUrl("~/")%>Pages/Controls/Pages/PositionSelect.aspx',null,null,function(win){
            win.hfId="<%=hfId.ClientID %>";
            win.hfName="<%=hfName.ClientID %>";
            win.lblName="<%=lblName.ClientID %>";
            win.focus();
        });
    }
    $(function () {
        $("#<%=lblName.ClientID %>").text($("#<%=hfName.ClientID %>"));
    });
</script>