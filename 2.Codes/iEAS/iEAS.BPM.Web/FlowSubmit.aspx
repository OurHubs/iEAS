<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowSubmit.aspx.cs" Inherits="iEAS.BPM.Web.FlowSubmit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        流程：
        <asp:DropDownList ID="ddlProcess" runat="server">
            <asp:ListItem Text="iEAS.BPM.Test" Value="iEAS.BPM.Test"></asp:ListItem>
        </asp:DropDownList>
        <br />
        Folio：<asp:TextBox ID="txtFolio" runat="server"></asp:TextBox>
        CurrentUser:<asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
