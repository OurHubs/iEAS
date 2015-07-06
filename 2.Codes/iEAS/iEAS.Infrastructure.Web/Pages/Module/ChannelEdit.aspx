<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelEdit.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Module.ChannelEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title></title>
     <link href="../../Assets/common/css/Admin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="container">
            <div class="form_panel">
                <div class="from_panel_header">
                    <span class="title icon_search">入口数据</span>
                </div>
                <div class="form_panel_body">
                    <table class="table_detail">
                        <tr>
                            <th>
                                <span>*</span> 上一级：
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
                                <span>*</span>编码：
                            </th>
                            <td>
                                <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                       
                        <tr>
                            <th>
                                <span>*</span>栏目类别：
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlChannelType"  runat="server" Width="200">
                                     <asp:ListItem Text="URL" Value="URL"></asp:ListItem>
                                     <asp:ListItem Text="模型" Value="MODEL"></asp:ListItem>
                                     <asp:ListItem Text="单页模型" Value="PModel"></asp:ListItem>
                                     <asp:ListItem Text="节点" Value="NODE"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <span>*</span>URL：
                            </th>
                            <td>
                                <asp:TextBox ID="txtURL" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <span>*</span>模型：
                            </th>
                            <td>
                                <asp:TextBox ID="txtModel" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <th>
                                <span>*</span>模板：
                            </th>
                            <td>
                                <asp:TextBox ID="txtTemplate" runat="server"></asp:TextBox>
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
