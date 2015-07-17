<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UxEmployeeSelect.ascx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Controls.UxEmployeeSelect" %>
<input id="<%=ClientID %>" type="button" value="选择" />
<asp:Label ID="lblName" runat="server"></asp:Label>
<asp:HiddenField ID="hfEmpId" runat="server" />
<asp:HiddenField ID="hfEmpNumber" runat="server" />
<asp:HiddenField ID="hfEmpName" runat="server" />
<script type="text/javascript">
    $(function () {
        $("#<%=lblName.ClientID %>").text($("#<%=hfEmpName.ClientID %>").val());

        $("#<%=ClientID %>").click(function () {
            return openWindow('<%=Page.ResolveUrl("~/")%>Pages/Controls/Pages/EmployeeSelect.aspx',700, 400, function (win) {
                win.hfEmpId = "<%=hfEmpId.ClientID %>";
                win.hfEmpNumber = "<%=hfEmpNumber.ClientID %>";
                win.lblName = "<%=lblName.ClientID %>";
                win.hfEmpName = "<%=hfEmpName.ClientID %>";
                win.focus();
            });
        });
    });
</script>
