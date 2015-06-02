<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Account.UserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>框架管理系统</title>
    <link href="../../Assets/common/css/Admin.css" rel="stylesheet" />
    <script src="../../Assets/common/js/jquery.min.js" type="text/javascript"></script>
    <script src="../../Assets/common/js/table.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <ul class="tabList_toolbar">
                <li><a href="UserEdit.aspx" class="add">增 加</a> </li>
                <li><a href="#" class="del">删 除</a></li>
            </ul>
            <table class="tabList">
                <tr class="title">
                    <td style="width: 5%">
                        <input name="checkAll" class="checkAll" id="checkAll" type="checkbox" value='' />
                    </td>
                    <td>登陆名</td>
                    <td>姓名</td>
                    <td>性别</td>
                    <td>生日</td>
                    <td>电话</td>
                    <td>Email</td>
                    <td style="width: 15%">操作</td>
                </tr>
                <iEAS:ListView ID="lvQuery" runat="server" DataSourceID="odsQuery" DataKeyNames="ID" OnItemCommand="lvQuery_ItemCommand">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input type="checkbox" name="IDS" />
                            </td>
                            <td><%# Eval("LoginName") %></td>
                            <td><%# Eval("Name") %></td>
                            <td><%# Eval("Gender").ToStr(m=>m=="1"?"男":"女","未知") %></td>
                            <td><%# Eval("Birthday","{0:yyyy-MM-dd}") %></td>
                            <td><%# Eval("Telephone") %></td>
                            <td><%# Eval("Email") %></td>
                            <td>
                                <a href="UserEdit.aspx?rid=<%# Eval("ID") %>">编辑</a>|
                                <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="Del" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </iEAS:ListView>
            </table>
            <div class="fenye">
              <iEAS:Pager ID="Pager"  runat="server" PagedControlID="lvQuery" />
            </div>
            <iEAS:ObjectDataSource ID="odsQuery" runat="server" OnQuery="odsQuery_Query" DeleteMethod="DeleteRecord">
            </iEAS:ObjectDataSource>
        </div>
    </form>
</body>
</html>