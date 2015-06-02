<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Account.UserEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Assets/common/css/Admin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form_panel">
                <div class="from_panel_header">
                    <span class="title icon_search">用户管理</span>
                </div>
                <div class="form_panel_body">
                    <table class="table_detail">
                        <tr>
                            <th>
                                <span>*</span> 帐号：
                            </th>
                            <td>
                                <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <span>*</span>密码：
                            </th>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <span>*</span>姓名：
                            </th>
                            <td>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <span>*</span>呢称：
                            </th>
                            <td>
                                <asp:TextBox ID="txtNick" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <span>*</span>性别：
                            </th>
                            <td>
                                <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="男" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="女" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="未知" Value=""></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <span>*</span>生日：
                            </th>
                            <td>
                                <asp:TextBox ID="txtBirthday" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <span>*</span>Email：
                            </th>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <th>
                                <span>*</span>电话：
                            </th>
                            <td>
                                <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <th>
                                <span>*</span>工作地址：
                            </th>
                            <td>
                                <asp:TextBox ID="txtWorkAddress" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <span>*</span>工作邮编：
                            </th>
                            <td>
                                <asp:TextBox ID="txtWorkZip" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <span>*</span>家庭地址：
                            </th>
                            <td>
                                <asp:TextBox ID="txtHomeAddress" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <span>*</span>家庭邮编：
                            </th>
                            <td>
                                <asp:TextBox ID="txtHomeZip" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="form_panel_foot">
                    <asp:Button ID="btnSave" runat="server" Text="提 交" class="btn" OnClick="btnSave_Click" />
                    <asp:Button ID="btnBack" runat="server" Text="返 回" class="btn_back" OnClick="btnBack_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>