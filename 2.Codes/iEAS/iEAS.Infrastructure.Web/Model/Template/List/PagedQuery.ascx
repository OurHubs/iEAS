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
                <li><a href="ModelEdit.aspx?model=<%=ModelContext.Current.Config.Code %>" class="add">增 加</a> </li>
            </ul>
            <table>
                <asp:Repeater ID="rptConditions" runat="server" OnItemDataBound="rptConditions_ItemDataBound">
                    <ItemTemplate>
                        <%# Container.ItemIndex%3==0?"<tr>":"" %>
                        <th><%# Eval("Title") %></th>
                        <td>
                            <iEAS:ModelFieldContainer ID="ctField" runat="server"></iEAS:ModelFieldContainer>
                        </td>
                        <%# Container.ItemIndex%3==2?"</tr>":"" %>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="6">
                        <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" />
                    </td>
                </tr>
            </table>
            <iEAS:GridView ID="gvList" runat="server" AutoGenerateColumns="false" CssClass="tabList" GridLines="None" OnRowCommand="gvList_RowCommand">
            </iEAS:GridView>
            <div class="fenye">
                <iEAS:AspNetPager ID="Pager" runat="server" AlwaysShow="true" ShowCustomInfoSection="Right" PrevPageText="上一页" NextPageText="下一页" FirstPageText="首页" LastPageText="尾页"
                    PagingButtonLayoutType="Span" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，第页显示%PageSize%条"
                    OnPageChanging="Pager_PageChanging">
                </iEAS:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
