<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/EditPage.Master" AutoEventWireup="true" CodeBehind="EmployeeEdit.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Orgnization.EmployeeEdit" %>

<asp:Content ID="ctHeader" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="ctContent" ContentPlaceHolderID="Content" runat="server">
    <table width="90%" border="0" align="center" cellpadding="3" cellspacing="0" class="small">
        <tr>
            <td class="Big">
                <img src="<%=Page.ResolveUrl("~/") %>assets/common/images/notify_new.gif" align="middle" alt=""><span class="big3"> 员工管理</span>&nbsp;&nbsp;&nbsp;&nbsp;
	           
                <span style="font-size: 12px; float: right; margin-right: 20px;">
                    <a href="EmployeeList.aspx" style="font-size: 12px;">&lt;&lt;返回列表页</a>
                </span>
            </td>
        </tr>
    </table>
    <table class="TableBlock" border="0" width="90%" align="center" style="border-bottom: #4686c6 solid 0px;">
        <tr>
            <td nowrap class="TableContent" width="15%"><font title='打*号表示为必填' color='#ff0000'>*</font>中文名称
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtChinesename" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td nowrap class="TableContent" width="15%"><font title='打*号表示为必填' color='#ff0000'>*</font>英文名称
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtEnglishName" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%"><font title='打*号表示为必填' color='#ff0000'>*</font>编码
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtEmployeeNumber" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%">描述
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="3" Width="500px" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr align="center" class="TableControl">
            <td colspan="2" nowrap height="35">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" CssClass="BigButton" />
                <input type="button" value="返 回" onclick="location.href = 'EmployeeList.aspx'" class="BigButton" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $(function () {
            ConfigValidateGroup();
            $("#<%=txtChinesename.ClientID%>").formValidator({ onShow: "请输入中文名称", onFocus: "至少1个长度", onCorrect: "中文名称正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "中文名称两边不能有空符号" }, onError: "中文名称不能为空,请确认" });
            $("#<%=txtEnglishName.ClientID%>").formValidator({ onShow: "请输入英文名称", onFocus: "至少1个长度", onCorrect: "英文名称正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "英文名称两边不能有空符号" }, onError: "英文名称不能为空,请确认" });
            $("#<%=txtEmployeeNumber.ClientID%>").formValidator({ onShow: "请输入员工编码", onFocus: "保证编码不可以重复", onCorrect: "员工编码正确" }).inputValidator({ min: 1, onError: "员工编码不能为空,请确认" });

        })
    </script>
</asp:Content>