<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="iEAS.BPM.Web.Test" %>

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
         <asp:Button ID="btnCreateProc" runat="server" Text="创建流程实例" OnClick="btnCreateProc_Click" />
    </div>
    </form>
</body>
</html>
