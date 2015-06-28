<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="iEAS.Infrastructure.Web.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnGenerateDB" runat="server" Text="生成数据库" OnClick="btnGenerateDB_Click" />
        <asp:Button ID="btnLogin" runat="server" Text="登陆" OnClick="btnLogin_Click" />
        <br />
        <asp:Button ID="btnSaveModelFile" runat="server" Text="生成模型文件" OnClick="btnSaveModelFile_Click" />    
        <asp:Button ID="btnModelEdit" runat="server" Text="模型编辑" OnClick="btnModelEdit_Click" />    
        <asp:Button ID="btnModelQuery" runat="server" Text="模型查询" OnClick="btnModelQuery_Click" />   
        <asp:Button ID="btnModelRegistry" runat="server" Text="模型注册" OnClick="btnModelRegistry_Click" />
    </div>
    </form>
</body>
</html>
