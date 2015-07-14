<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/EditPage.Master" AutoEventWireup="true" CodeBehind="DepartmentEdit.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Orgnization.DepartmentEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="Content">
    <table width="90%" border="0" align="center" cellpadding="3" cellspacing="0" class="small">
        <tr>
            <td class="Big">
                <img src="<%=Page.ResolveUrl("~/") %>assets/common/images/notify_new.gif" align="middle" alt=""><span class="big3"> 部门管理</span>&nbsp;&nbsp;&nbsp;&nbsp;
	           
                <span style="font-size: 12px; float: right; margin-right: 20px;">
                    <a href="DepartmentList.aspx?companyID=<%=CompanyID %>" style="font-size: 12px;">&lt;&lt;返回列表页</a>
                </span>
            </td>
        </tr>
    </table>
    <table class="TableBlock" border="0" width="90%" align="center" style="border-bottom: #4686c6 solid 0px;">
         <tr>
            <td nowrap class="TableContent" width="15%">公司：
            </td>
            <td class="TableData">
                <asp:Label ID="lblCompany" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%">上级部门：
            </td>
            <td class="TableData">
                <asp:Label ID="lblParent" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%"><font title='打*号表示为必填' color='#ff0000'>*</font>部门名称：
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtName" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%"><font title='打*号表示为必填' color='#ff0000'>*</font>部门编码：
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtCode" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%"><font title='打*号表示为必填' color='#ff0000'>*</font>主负责人：
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtPrincipalNumber" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%">副负责人：
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtDeputyNumber" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%">描述：
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="3" Width="500px" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr align="center" class="TableControl">
            <td colspan="2" nowrap height="35">
                <asp:Button ID="btnSave" runat="server" Text="保 存" OnClick="btnSave_Click" CssClass="BigButton" />
                <input type="button" value="返 回" class="BigButton" onclick="location.href='DepartmentList.aspx?companyID=<%=CompanyID %>'" />
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        $(function () {
            ConfigValidateGroup();
            $("#<%=txtName.ClientID%>").formValidator({ onShow: "请输入名称", onFocus: "至少1个长度", onCorrect: "名称正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "名称两边不能有空符号" }, onError: "名称不能为空,请确认" });
            $("#<%=txtCode.ClientID%>").formValidator({ onShow: "请输入编码", onFocus: "保证编码不可以重复", onCorrect: "编码正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "编码两边不能有空符号" }, onError: "编码不能为空,请确认" });
            $("#<%=txtPrincipalNumber.ClientID%>").formValidator({ onShow: "请输入主负责人", onFocus: "至少1个长度", onCorrect: "主负责人正确" }).inputValidator({ min: 1, onError: "主负责人不能为空,请确认" });
            
        })
    </script>
</asp:Content>
