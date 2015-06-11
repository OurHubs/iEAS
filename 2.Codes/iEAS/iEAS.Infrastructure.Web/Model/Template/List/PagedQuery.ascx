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
            <iEAS:GridView ID="gvList" runat="server" AutoGenerateColumns="false" CssClass="tabList"  OnRowCommand="gvList_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate></HeaderTemplate>
                        <ItemTemplate></ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </iEAS:GridView>
            <div class="fenye">
                <asp:Button ID="btnQuery" runat="server" Text="Query" />
                <iEAS:AspNetPager ID="Pager" runat="server"></iEAS:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
