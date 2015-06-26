<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelTree.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Module.ChannelTree" %>

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

    var zNodes = <%=BuildChannel() %>

    $(function () {
        $.fn.zTree.init($("#treeModule"), setting, zNodes);
    });
    //-->
    </script>
    <style type="text/css">
        html,body{
            padding:0;
            margin:0;
            width:100%;
            background:#F6EDA4;
        }

    </style>
</head>
<body>
    <div style="background:#fefefe; margin:0 10px 0 0; height:600px;">
    <ul id="treeModule" class="ztree"></ul>
        </div>
</body>
</html>
