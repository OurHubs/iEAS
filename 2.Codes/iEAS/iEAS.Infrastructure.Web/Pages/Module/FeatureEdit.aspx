<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeatureEdit.aspx.cs"
    MasterPageFile="~/Masters/EditPage.Master"
    Inherits="iEAS.Infrastructure.Web.Pages.Module.FeatureEdit" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
    <div class="TableBlock_top">
        <div class="TableBlock_top_title">
            <img src="<%=Page.ResolveUrl("~/") %>assets/common/images/notify_new.gif" alt="" />
            增加项
        </div>
        <div class="TableBlock_top_back"><a href="FeatureList.aspx" style="font-size: 12px;">&lt;&lt;返回列表页</a></div>
    </div>

    <table class="TableBlock">
        <tr>
            <th>
                <span>*</span> 上级功能项：
            </th>
            <td>
                <asp:Label ID="lblParent" CssClass="BigInput" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                <span>*</span> 名称：
            </th>
            <td>
                <asp:TextBox ID="txtName" CssClass="BigInput" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <span>*</span>编码：
            </th>
            <td>
                <asp:TextBox ID="txtCode" CssClass="BigInput" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <span>*</span>备注：
            </th>
            <td>
                <asp:TextBox ID="txtDesc" CssClass="BigInput" runat="server" TextMode="MultiLine" Rows="3" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr class="TableControl">
            <td colspan="4">
                <asp:Button ID="btnSave" runat="server" data-group="1"  Text="保存信息"   OnClick="btnSave_Click" CssClass="BigButton" />
               <input type="button" value="返 回" onclick="location.href = 'FeatureList.aspx?moduleID=<%=ModuleID%>'" class="BigButton" />
          
            </td>
        </tr>
    </table>

    <script type="text/javascript">
      
        $(function () {
            ConfigValidateGroup();
            $("#<%=txtName.ClientID%>").formValidator({ btnSubmit: "<%=btnSave.ClientID%>", onShow: "请输入名称", onFocus: "至少1个长度", onCorrect: "名称正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "名称两边不能有空符号" }, onError: "名称不能为空,请确认" });
            $("#<%=txtCode.ClientID%>").formValidator({ btnSubmit: "<%=btnSave.ClientID%>", onShow: "请输入编码", onFocus: "保证编码不可以重复", onCorrect: "编码正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "编码两边不能有空符号" }, onError: "编码不能为空,请确认" });
            $("#<%=txtDesc.ClientID%>").formValidator({ btnSubmit: "<%=btnSave.ClientID%>", empty: true, onEmpty: "真的不输入备注了吗？", onShow: "请输入备注", onFocus: "最好填写备注", onCorrect: "备注正确" }).inputValidator({ empty: { leftEmpty: false, rightEmpty: false, emptyError: "编码两边不能有空符号" }, onError: "描述不能为空,请确认" });
          
        })
    </script>
</asp:Content>
