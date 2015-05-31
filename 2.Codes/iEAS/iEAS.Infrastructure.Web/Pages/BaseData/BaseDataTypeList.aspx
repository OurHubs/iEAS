<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaseDataTypeList.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.BaseData.BaseDataTypeList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>框架管理系统</title>
    <link href="../../Assets/common/css/Admin.css" rel="stylesheet" />
    <script src="../../Assets/common/js/jquery.min.js" type="text/javascript"></script>
    <script src="../../Assets/common/js/table.js"></script>
    <script type="text/javascript">
        $(function () {
            //InitSort(); //初始化排序
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <ul class="tabList_toolbar">
                <li><a href="BaseDataTypeEdit.aspx" class="add">增 加</a> </li>
                <li><a href="#" class="del">删 除</a></li>
            </ul>
            <iEAS:DataPager ID="DataPager1" runat="server" PageSize="10" PagedControlID="lvQuery">
                <Fields>
                    <asp:NumericPagerField />
                </Fields>
            </iEAS:DataPager>
            <iEAS:ListView ID="lvQuery" runat="server" DataSourceID="odsQuery">
                <LayoutTemplate>
                    <table class="tabList">
                        <tr class="title">
                            <td style="width: 5%">
                                <input name="checkAll" class="checkAll" id="checkAll" type="checkbox" value='' />
                            </td>
                            <td style="width: 20%">
                                <a id="Sort_TypeID" href="javascript:Sort(this,'TypeID');" class="down">类型名称</a>
                            </td>

                            <td style="width: 8%">
                                <a id="A1" href="javascript:Sort(this,'TypeID');" class="up">类型编码</a>
                            </td>
                            <td style="width: 10%">操作
                            </td>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <input type="checkbox" name="IDS" />
                        </td>
                        <td>
                            <%# Container.DataItem %>
                        </td>
                        <td>张三
                        </td>
                        <td>
                            <a href="BaseDataItemList.aspx">查看数据项</a>|编辑|删除
                        </td>
                    </tr>
                </ItemTemplate>
            </iEAS:ListView>
            <iEAS:ObjectDataSource ID="odsQuery" runat="server" OnQuery="odsQuery_Query"></iEAS:ObjectDataSource>
        </div>
        <asp:HiddenField ID="hfSort" runat="server" />
    </form>
</body>
</html>
