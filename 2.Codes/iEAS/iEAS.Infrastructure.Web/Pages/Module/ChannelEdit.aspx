<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelEdit.aspx.cs"
    ValidateRequest="false"
    MasterPageFile="~/Masters/EditPage.Master"
    Inherits="iEAS.Infrastructure.Web.Pages.Module.ChannelEdit" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content"> 
     <div class="TableBlock_top">
        <div class="TableBlock_top_title">
            <img src="<%=Page.ResolveUrl("~/") %>assets/common/images/notify_new.gif" alt="" />
            新增Channel
        </div>
        <div class="TableBlock_top_back"><a href="ChannelList.aspx" style="font-size: 12px;">&lt;&lt;返回列表页</a></div>
    </div>
    <table class="TableBlock">
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
                <asp:TextBox ID="txtName" CssClass="BigInput"  runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <span>*</span>编码：
            </th>
            <td>
                <asp:TextBox ID="txtCode" CssClass="BigInput"  runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <th>
                <span>*</span>栏目类别：
            </th>
            <td>
                <asp:DropDownList ID="ddlChannelType" CssClass="BigSelect"  runat="server">
                    <asp:ListItem Text="URL" Value="URL"></asp:ListItem>
                    <asp:ListItem Text="模型" Value="MODEL"></asp:ListItem>
                    <asp:ListItem Text="单页模型" Value="PModel"></asp:ListItem>
                    <asp:ListItem Text="节点" Value="NODE"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>
               URL：
            </th>
            <td>
                <asp:TextBox ID="txtURL" CssClass="BigInput"  runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                模型：
            </th>
            <td>
                <asp:TextBox ID="txtModel" CssClass="BigInput"  runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
               模板：
            </th>
            <td>
                <asp:TextBox ID="txtTemplate" CssClass="BigInput"  runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <th>
                备注：
            </th>
            <td>
                <asp:TextBox ID="txtDesc" runat="server" CssClass="BigInput"  TextMode="MultiLine" Rows="3" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr class="TableControl">
            <td colspan="4">
                <asp:Button ID="btnSave" runat="server" group='submit' Text="保存信息" OnClick="btnSave_Click" CssClass="BigButton" />
                <input type="button" value="返 回" onclick="location.href = 'ChannelList.aspx'" class="BigButton" />
            </td>
        </tr>
    </table>
     <script type="text/javascript">

         $(function () {
             ConfigValidateGroup();
             $("#<%=txtName.ClientID%>").formValidator({ onShow: "请输入名称", onFocus: "至少1个长度", onCorrect: "名称正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "名称两边不能有空符号" }, onError: "名称不能为空,请确认" });
             $("#<%=txtCode.ClientID%>").formValidator({ onShow: "请输入编码", onFocus: "保证编码不可以重复", onCorrect: "编码正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "编码两边不能有空符号" }, onError: "编码不能为空,请确认" });

             var selValue = $("#<%=ddlChannelType.ClientID%>").val();
             if (selValue == "URL") {
                 $("#<%=txtURL.ClientID%>").formValidator({ onShow: "请输入URL", onFocus: "保证URL不可以重复", onCorrect: "URL正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "URL两边不能有空符号" }, onError: "URL不能为空,请确认" });
                 $("#<%=txtURL.ClientID%>").closest("tr").find("th").prepend("<span>*</span>");
             } else if (selValue == "MODEL" || selValue == "PModel") {
                 $("#<%=txtModel.ClientID%>").formValidator({ onShow: "请输入模型", onFocus: "请输入模型", onCorrect: "模型正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "模型两边不能有空符号" }, onError: "模型不能为空,请确认" });
                 $("#<%=txtModel.ClientID%>").closest("tr").find("th").prepend("<span>*</span>");
             }
        })

    </script>
</asp:Content>
