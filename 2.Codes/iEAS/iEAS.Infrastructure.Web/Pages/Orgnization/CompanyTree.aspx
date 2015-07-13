<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Masters/Blank.Master"
    CodeBehind="CompanyTree.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Orgnization.CompanyTree" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Header">
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
        callback: {
            beforeClick: function beforeClick(treeId, treeNode) {
            }
        }
    };

    var zNodes = <%=BuildTreeNodes() %>

    $(function () {
        $.fn.zTree.init($("#ctTree"), setting, zNodes);
    });
    //-->
    </script>
    <style type="text/css">
        html, body {
            padding: 0;
            margin: 0;
            width: 100%;
            background: #F6EDA4;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="Content">
    <div style="background: #fefefe; margin: 0 10px 0 0; height: 600px;">
        <ul id="ctTree" class="ztree"></ul>
    </div>
</asp:Content>