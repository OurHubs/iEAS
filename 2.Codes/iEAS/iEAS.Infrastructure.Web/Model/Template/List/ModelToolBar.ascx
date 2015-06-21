<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModelToolBar.ascx.cs" Inherits="iEAS.Infrastructure.Web.Model.Template.List.ModelToolBar" %>
<asp:Repeater ID="rptToolBar" runat="server" OnItemCommand="rptToolBar_ItemCommand">
    <ItemTemplate>
        <asp:Button ID="btnCmd" runat="server" Text='<%# Eval("Title") %>' CommandName='<%# Eval("Command") %>' CssClass="btn btn-success" />
    </ItemTemplate>
</asp:Repeater>