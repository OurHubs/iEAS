﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuEdit.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Module.MenuEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>菜单编辑</title>
    <link href="../../Assets/common/css/Admin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form_panel">
                <div class="from_panel_header">
                    <span class="title icon_search">基础数据项</span>
                </div>
                <div class="form_panel_body">
                    <table class="table_detail">
                         <tr>
                            <th>
                                <span>*</span> 上级数据项：
                            </th>
                            <td>
                                <asp:Label ID="lblParent" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <span>*</span> 名称：
                            </th>
                            <td>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <span>*</span>值：
                            </th>
                            <td>
                                <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <span>*</span>备注：
                            </th>
                            <td>
                                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="3" Width="500px"></asp:TextBox>
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
