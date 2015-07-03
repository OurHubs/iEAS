<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UxForm.ascx.cs" Inherits="iEAS.Infrastructure.Web.Model.Controls.Form.UxForm" %>
<form id="form1" runat="server">
    <asp:Panel ID="plForm" runat="server"></asp:Panel>
    <hr />
    <asp:Button ID="btnSave" runat="server" Text="保存信息" OnClick="btnSave_Click" CssClass="BigButton" />
</form>
<style type="text/css">
    .BigInput{
        width:50px;
    }
</style>
