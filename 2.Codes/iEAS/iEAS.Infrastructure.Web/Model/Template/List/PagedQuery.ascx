<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PagedQuery.ascx.cs" Inherits="iEAS.Infrastructure.Web.Model.Template.List.PagedQuery" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>框架管理系统</title>
    <link href="~/Assets/common/css/Admin.css" rel="stylesheet" />
    <script src="../Assets/common/js/jquery.min.js" type="text/javascript"></script>
    <script src="../Assets/common/js/table.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <ul class="tabList_toolbar">
                <li><a href="RoleEdit.aspx" class="add">增 加</a> </li>
                <li><a href="#" class="del">删 除</a></li>
            </ul>
            <table class="tabList">
                <tr class="title">
                    <asp:Repeater ID="rptHeader" runat="server">
                        <ItemTemplate>
                            <td><%# Eval("Title") %></td>
                        </ItemTemplate>
                    </asp:Repeater>
                </tr>
                <iEAS:ListView ID="lvQuery" runat="server" DataSourceID="odsQuery" DataKeyNames="RecordID" OnItemCommand="lvQuery_ItemCommand" OnItemDataBound="lvQuery_ItemDataBound">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <asp:Repeater ID="rptCells" runat="server" OnItemDataBound="rptCells_ItemDataBound">
                                <ItemTemplate>
                                    <td><asp:PlaceHolder ID="phContainer" runat="server"></asp:PlaceHolder></td>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tr>
                    </ItemTemplate>
                </iEAS:ListView>
            </table>
            <div class="fenye">
                <iEAS:Pager ID="Pager" runat="server" PagedControlID="lvQuery" />
            </div>
            <iEAS:ObjectDataSource ID="odsQuery" runat="server" OnQuery="odsQuery_Query">
            </iEAS:ObjectDataSource>
        </div>
    </form>
</body>
</html>
