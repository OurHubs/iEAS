<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/EditPage.Master" AutoEventWireup="true" CodeBehind="CompanyEdit.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Orgnization.CompanyEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <table width="90%" border="0" align="center" cellpadding="3" cellspacing="0" class="small">
        <tr>
            <td class="Big">
                <img src="<%=Page.ResolveUrl("~/") %>assets/common/images/notify_new.gif" align="middle" alt=""><span class="big3"> 新增公司</span>&nbsp;&nbsp;&nbsp;&nbsp;
	           
                <span style="font-size: 12px; float: right; margin-right: 20px;">
                    <a href="CompanyList.aspx" style="font-size: 12px;">&lt;&lt;返回列表页</a>
                </span>
            </td>
        </tr>
    </table>
    <table class="TableBlock" border="0" width="90%" align="center" style="border-bottom: #4686c6 solid 0px;">
        <tr>
            <td nowrap class="TableContent" width="15%"><font title='打*号表示为必填' color='#ff0000'>*</font>名称：
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtName" runat="server" CssClass="BigInput"></asp:TextBox>
                <div id="<%=txtName.ClientID %>Tip"  ></div>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%"><font title='打*号表示为必填' color='#ff0000'>*</font>编码：
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtCode" runat="server" CssClass="BigInput"></asp:TextBox>
                <div id="<%=txtCode.ClientID %>Tip"></div>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%">地址：
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%">网站：
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtWebUrl" runat="server" CssClass="BigInput"></asp:TextBox>
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
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" CssClass="BigButton" />
                <input type="button" value="返 回" onclick="location.href='CompanyList.aspx'" class="BigButton" />
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        $(function () {
            ConfigValidateGroup();
            $("#<%=txtName.ClientID%>").formValidator({ onShow: "请输入名称", onFocus: "至少1个长度", onCorrect: "名称正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "名称两边不能有空符号" }, onError: "名称不能为空,请确认" });
            $("#<%=txtCode.ClientID%>").formValidator({ onShow: "请输入编码", onFocus: "保证编码不可以重复", onCorrect: "编码正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "编码两边不能有空符号" }, onError: "编码不能为空,请确认" });
        })
    </script>
</asp:Content>
