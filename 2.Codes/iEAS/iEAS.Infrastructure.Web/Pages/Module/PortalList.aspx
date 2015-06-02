<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PortalList.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Module.PortalList" %>
<!DOCTYPE html>


<head id="Head1" runat="server">
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
                <li><a href="PortalEdit.aspx" class="add">增 加</a> </li>
                <li><a href="#" class="del">删 除</a></li>
            </ul>
            <table class="tabList">
                <tr class="title">
                    <td style="width: 5%">
                        <input name="checkAll" class="checkAll" id="checkAll" type="checkbox" value='' />
                    </td>
                    <td style="width: 20%">类型名称
                    </td>

                    <td style="width: 10%">类型编码
                    </td>
                    <td>描述
                    </td>
                    <td style="width: 15%">操作
                    </td>
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
                            <td>
                                <%# Eval("Name") %>
                            </td>
                            <td>
                                <%# Eval("Code") %>
                            </td>
                            <td>
                                <%# Eval("Desc") %>
                            </td>
                            <td>
                                <a href="BaseDataItemList.aspx?typeid=<%# Eval("ID") %>">查看菜单项</a>
                                |
                            <a href="BaseDataTypeEdit.aspx?rid=<%# Eval("ID") %>">编辑</a>|
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
