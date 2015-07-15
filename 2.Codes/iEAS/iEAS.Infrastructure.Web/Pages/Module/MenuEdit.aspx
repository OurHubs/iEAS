<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuEdit.aspx.cs"
    MasterPageFile="~/Masters/EditPage.Master"
    Inherits="iEAS.Infrastructure.Web.Pages.Module.MenuEdit" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
    <div class="TableBlock_top">
        <div class="TableBlock_top_title">
            <img src="<%=Page.ResolveUrl("~/") %>assets/common/images/notify_new.gif" alt="" />
            菜单
        </div>
        <div class="TableBlock_top_back"><a href="MenuList.aspx" style="font-size: 12px;">&lt;&lt;返回列表页</a></div>
    </div>

    <table class="TableBlock">
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
                <asp:TextBox ID="txtName" CssClass="BigInput" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <span>*</span>编码：
            </th>
            <td>
                <asp:TextBox ID="txtValue" CssClass="BigInput" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Url：
            </th>
            <td>
                <asp:TextBox ID="txtUrl" CssClass="BigInput" Width="400" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                备注：
            </th>
            <td>
                <asp:TextBox ID="txtDesc" CssClass="BigInput" runat="server" TextMode="MultiLine" Rows="3" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr class="TableControl">
            <td colspan="4">
                <asp:Button ID="btnSave" runat="server" data-group="1" Text="保存信息" OnClick="btnSave_Click" CssClass="BigButton" />
                <input type="button" value="返 回" onclick="location.href = 'MenuList.aspx?portalid=<%=PortalID%>    '" class="BigButton" />

            </td>
        </tr>
    </table>

     <script type="text/javascript">
      
         $(function () {
             ConfigValidateGroup();
             $("#<%=txtName.ClientID%>").formValidator({ onShow: "请输入名称", onFocus: "至少1个长度", onCorrect: "名称正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "名称两边不能有空符号" }, onError: "名称不能为空,请确认" });
             $("#<%=txtValue.ClientID%>").formValidator({ onShow: "请输入编码", onFocus: "保证编码不可以重复", onCorrect: "编码正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "编码两边不能有空符号" }, onError: "编码不能为空,请确认" });
             $("#<%=txtUrl.ClientID%>").formValidator({empty: true,  onShow: "请输入URL", onFocus: "请输入URL", onCorrect: "URL正确" }).inputValidator({ empty: { leftEmpty: false, rightEmpty: false, emptyError: "URL两边不能有空符号" }, onError: "URL不能为空,请确认" });
             
             $("#<%=txtDesc.ClientID%>").formValidator({empty: true,  onShow: "请输入备注", onFocus: "最好填写备注", onCorrect: "备注正确" }).inputValidator({ empty: { leftEmpty: false, rightEmpty: false, emptyError: "编码两边不能有空符号" }, onError: "描述不能为空,请确认" });
          
         })
     </script>
 
</asp:Content>
