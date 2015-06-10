<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GridEditor.ascx.cs" Inherits="iEAS.Infrastructure.Web.Model.Template.Form.GridEditor" %>
<table>
    <asp:Repeater ID="rptGrid" runat="server">
        <ItemTemplate>
            <tr>
                <td>
                    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
