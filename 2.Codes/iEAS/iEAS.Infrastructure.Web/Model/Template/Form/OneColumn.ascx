<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OneColumn.ascx.cs" Inherits="iEAS.Infrastructure.Web.Model.Template.Form.OneColumn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <asp:Repeater ID="rptForm" runat="server" OnItemDataBound="rptForm_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <th>
                            <%# Eval("Title") %>
                        </th>
                        <td>
                            <iEAS:ModelFieldContainer ID="ctField" runat="server" FieldCode='<%# Eval("Code") %>'></iEAS:ModelFieldContainer>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
    </form>
</body>
</html>

