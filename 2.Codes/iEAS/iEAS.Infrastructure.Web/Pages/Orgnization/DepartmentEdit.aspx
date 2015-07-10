<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/EditPage.Master" AutoEventWireup="true" CodeBehind="DepartmentEdit.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Orgnization.DepartmentEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="Content">
    <table width="90%" border="0" align="center" cellpadding="3" cellspacing="0" class="small">
        <tr>
            <td class="Big">
                <img src="<%=Page.ResolveUrl("~/") %>assets/common/images/notify_new.gif" align="middle" alt=""><span class="big3"> 新增角色</span>&nbsp;&nbsp;&nbsp;&nbsp;
	           
                <span style="font-size: 12px; float: right; margin-right: 20px;">
                    <a href="RoleList.aspx" style="font-size: 12px;">&lt;&lt;返回列表页</a>
                </span>
            </td>
        </tr>
    </table>
    <table class="TableBlock" border="0" width="90%" align="center" style="border-bottom: #4686c6 solid 0px;">
        <tr>
            <td nowrap class="TableContent" width="15%">上级部门
            </td>
            <td class="TableData">
                <asp:Label ID="lblParent" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%">部门名称<font title='打*号表示为必填' color='#ff0000'>(*)</font>
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtName" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%">部门编码<font title='打*号表示为必填' color='#ff0000'>(*)</font>
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtCode" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%">主负责人<font title='打*号表示为必填' color='#ff0000'>(*)</font>
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtPrincipalNumber" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%">副负责人<font title='打*号表示为必填' color='#ff0000'>(*)</font>
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtDeputyNumber" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%">描述<font title='打*号表示为必填' color='#ff0000'>(*)</font>
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="3" Width="500px" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr align="center" class="TableControl">
            <td colspan="2" nowrap height="35">
                <asp:Button ID="btnSave" runat="server" Text="保 存" OnClick="btnSave_Click" CssClass="BigButton" />
                <input type="button" value="返 回" class="BigButton" onclick="location.href='DepartmentList.aspx'" />
            </td>
        </tr>
    </table>
</asp:Content>
