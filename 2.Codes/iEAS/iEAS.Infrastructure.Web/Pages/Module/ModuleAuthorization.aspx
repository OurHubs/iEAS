<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModuleAuthorization.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Module.ModuleAuthorization" %>

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
        },
        callback: {
            beforeClick: function beforeClick(treeId, treeNode) {
                var zTree = $.fn.zTree.getZTreeObj("treeModule");
                zTree.checkNode(treeNode, !treeNode.checked, null, true);
                return false;
            }
        }
    };

    var zNodes = <%=BuildFeatureData() %>

    $(function () {
        $.fn.zTree.init($("#treeModule"), setting, zNodes);
    });

        function BindCheckedFeatures() {
            var treeObj = $.fn.zTree.getZTreeObj("treeModule");
            var nodes = treeObj.getCheckedNodes(true);
            var guids = "";
            for (var i in nodes) {
                guids += nodes[i].guid + ",";
            }
            $("#<%=hfSelectedFeatures.ClientID %>").val(guids);
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
                <h1>模块</h1>
                <ul>
                <asp:Repeater ID="rptModule" runat="server" OnItemCommand="rptModule_ItemCommand">
                    <ItemTemplate>
                        <li>
                            <asp:LinkButton ID="btnModule" CssClass="add" runat="server" CommandName="SelectModule" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Name") %>'></asp:LinkButton>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                </ul>
            </div>
            <div style="float:left">
                <h1>功能清单</h1>
                <ul id="treeModule" class="ztree"></ul>
            </div>
            <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" OnClientClick="BindCheckedFeatures()" style="height: 32px" />
            <asp:HiddenField ID="hfSelectedFeatures" runat="server" />
        </div>
    </form>
</body>
</html>