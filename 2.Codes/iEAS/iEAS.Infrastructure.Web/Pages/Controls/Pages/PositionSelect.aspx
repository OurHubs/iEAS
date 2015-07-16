<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Blank.Master" AutoEventWireup="true" CodeBehind="PositionSelect.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Controls.Pages.PositionSelect" %>

<asp:Content ID="ctHeader" runat="server" ContentPlaceHolderID="Header">
    <link href="<%=Page.ResolveUrl("~/") %>assets/ztree/css/zTreeStyle/zTreeStyle.css" rel="stylesheet" />
    <script src="<%=Page.ResolveUrl("~/") %>assets/ztree/js/jquery.ztree.all-3.5.min.js" type="text/javascript"></script>
    <script type="text/javascript">
	<!--
    var setting = {
        data: {
            simpleData: {
                enable: true
            }
        },
        check:{
            enable:true
        },
        callback: {
            beforeClick: function beforeClick(treeId, treeNode) {
            }
        }
    };

    var zNodes = <%=BuildTreeNodes() %>

    $(function () {
        $.fn.zTree.init($("#ctTree"), setting, zNodes);
    });

        function getAllCheckedNodes() {
            var treeObj = $.fn.zTree.getZTreeObj("ctTree");
            var nodes = treeObj.getCheckedNodes(true);
            alert(nodes.length);
        }

        function returnValue() {
            var treeObj = $.fn.zTree.getZTreeObj("ctTree");
            var nodes = treeObj.getCheckedNodes(true);
            var ids = "", names = "";
            for (var i = 0; i < nodes.length; i++) {
                var node = nodes[i];
                ids += "," + nodes.id + "_" + node.pId;
                names += "," + node.name + "(" + node.deptName + ")";
            }

            ids = ids ? ids.substr(1, ids.length - 1) : "";
            names = names ? names.substr(1, names.length - 1) : "";
            window.opener.document.getElementById(hfId).value = ids;
            window.opener.document.getElementById(hfName).value = names;
            window.opener.document.getElementById(lblName).innerHTML = names;
            window.close();
        }
    //-->
    </script>
    <style type="text/css">
        html, body {
            padding: 0;
            margin: 0;
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="ctContent" runat="server" ContentPlaceHolderID="Content">
    <div style="position:fixed;top:0;right:5px;">
        <input type="button" value="选择" onclick="returnValue()" />
    </div>
    <ul id="ctTree" class="ztree"></ul>
</asp:Content>
