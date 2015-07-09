<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAuthorization.aspx.cs"
    MasterPageFile="~/Masters/ListPage.Master"
    Inherits="iEAS.Infrastructure.Web.Pages.Module.MenuAuthorization" %>

<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
    <link href="<%=Page.ResolveUrl("~/") %>assets/ztree/css/zTreeStyle/zTreeStyle.css" rel="stylesheet" />
    <script src="<%=Page.ResolveUrl("~/") %>assets/common/js/jquery.min.js" type="text/javascript"></script>
    <script src="<%=Page.ResolveUrl("~/") %>assets/ztree/js/jquery.ztree.all-3.5.min.js" type="text/javascript"></script>
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
                var zTree = $.fn.zTree.getZTreeObj("treeMenu");
                zTree.checkNode(treeNode, !treeNode.checked, null, true);
                return false;
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
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
    <div class="tabbable work-nav">
        <ul id="myTab" class="nav nav-tabs">
            <li class="active"><a href="RoleList.aspx" data-toggle="tab">菜单权限</a></li>
        </ul>
    </div>
    <div class="data-wrap">
        <div class="data-operation">
            <div class="button-operation">
                <asp:Button ID="btnSave" runat="server" Text='保存' CssClass='btn btn-success' OnClick="btnSave_Click" OnClientClick="BindCheckedMenus()" />
                <asp:Button ID="btnBack" runat="server" Text="返回" CssClass='btn btn-danger' OnClick="btnBack_Click" />
            </div>
        </div>
    </div>
    <div class="data-list">
        <div style="float: left; width: 200px;">
            <h1>Portal列表</h1>
            <ul>
                <asp:Repeater ID="rptPortal" runat="server" OnItemCommand="rptPortal_ItemCommand">
                    <ItemTemplate>
                        <li>
                            <asp:LinkButton ID="btnProtal" CssClass="add" runat="server" CommandName="SelectProtal" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Name") %>'></asp:LinkButton>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="float: left">
            <h1>菜单</h1>
            <ul id="treeMenu" class="ztree"></ul>
        </div>
        <asp:HiddenField ID="hfSelectedMenus" runat="server" />
    </div>
</asp:Content>
