<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAuthorization.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Module.MenuAuthorization" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>框架管理系统</title>
    <link href="../../Assets/common/css/Admin.css" rel="stylesheet" />
    <link href="../../Assets/ztree/css/zTreeStyle/zTreeStyle.css" rel="stylesheet" />
    <script src="../../Assets/common/js/jquery.min.js" type="text/javascript"></script>
    <script src="../../Assets/ztree/js/jquery.ztree.all-3.5.min.js" type="text/javascript"></script>
    <script type="text/javascript">
	<!--
    var setting = {
        check: {
            enable: true,
            chkboxType: { Y: 'ps', N: 'ps' }
        },
        data: {
            simpleData: {
                enable: true
            }
        }
    };

    var zNodes = <%=BuildMenuData() %>

    $(function () {
        $.fn.zTree.init($("#treeMenu"), setting, zNodes);
    });

        function BindCheckedMenus() {
            var treeObj = $.fn.zTree.getZTreeObj("treeMenu");
            var nodes = treeObj.getCheckedNodes(true);
            var guids = "";
            for (var i in nodes) {
                guids += nodes[i].guid + ",";
            }
            $("#<%=hfSelectedMenus.ClientID %>").val(guids);
        }
    //-->
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <ul class="tabList_toolbar">
            </ul>
            <div style="float: left; width: 200px;">
                <h1>Portal列表</h1>
                <ul>
                <asp:Repeater ID="rptPortal" runat="server" OnItemCommand="rptPortal_ItemCommand">
                    <ItemTemplate>
                        <li>
                            <asp:LinkButton ID="btnProtal" CssClass="add" runat="server" CommandName="SelectProtal" CommandArgument='<%# Eval("Guid") %>' Text='<%# Eval("Name") %>'></asp:LinkButton>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                </ul>
            </div>
            <div style="float:left">
                <h1>菜单</h1>
                <ul id="treeMenu" class="ztree"></ul>
            </div>
            <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" OnClientClick="BindCheckedMenus()" />
            <asp:HiddenField ID="hfSelectedMenus" runat="server" />
        </div>
    </form>
</body>
</html>
