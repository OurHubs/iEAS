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
    <table class="TableBlock2Column">
        <tr>
            <th>公司：</th>
            <td class="TableData">
                <asp:Label ID="lblCompany" runat="server"></asp:Label>
            </td>
            <th>上级部门：</th>
            <td class="TableData">
                <asp:Label ID="lblParent" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>部门名称：</th>
            <td class="TableData">
                <asp:TextBox ID="txtName" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
            <th>部门编码：</th>
            <td class="TableData">
                <asp:TextBox ID="txtCode" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>主负责人：</th>
            <td class="TableData">
                <asp:TextBox ID="txtPrincipalNumber" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
            <th>副负责人：</th>
            <td class="TableData">
                <asp:TextBox ID="txtDeputyNumber" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>所设岗位：</th>
            <td class="TableData" colspan="3">
                <asp:ListBox ID="lstPosition" runat="server" SelectionMode="Multiple" Height="150px" Width="350px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <th>个人描述：</th>
            <td class="TableData" colspan="3">
                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="3" Width="500px" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr align="center" class="TableControl">
            <td colspan="2" height="35">
                <asp:Button ID="btnSave" runat="server" Text="保 存" OnClick="btnSave_Click" CssClass="BigButton" />
                <input type="button" value="返 回" class="BigButton" onclick="location.href='DepartmentList.aspx?companyID=<%=CompanyID %>    '" />
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
