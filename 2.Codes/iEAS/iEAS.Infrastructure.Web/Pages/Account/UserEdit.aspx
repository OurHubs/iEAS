<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs"
    MasterPageFile="~/Masters/EditPage.Master"
    Inherits="iEAS.Infrastructure.Web.Pages.Account.UserEdit" %>

<%@ Register Src="UxControls/RoleSelect.ascx" TagName="RoleSelect" TagPrefix="ux" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">



    <div class="TableBlock_top">
        <div class="TableBlock_top_title">
            <img src="<%=Page.ResolveUrl("~/") %>assets/common/images/notify_new.gif" alt="" />
            新增用户</div>
        <div class="TableBlock_top_back"><a href="UserList.aspx" style="font-size: 12px;">&lt;&lt;返回列表页</a></div>
    </div>
    <table class="TableBlock2Column">
        <tr>
            <th>
                <span>*</span> 帐号：
            </th>
            <td>
                <asp:TextBox ID="txtLoginName" CssClass="BigInput" runat="server"></asp:TextBox>               
                
            </td>
             <th>
                <span>*</span>密码：
            </th>
            <td>
                <asp:TextBox ID="txtPassword" CssClass="BigInput" runat="server"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <th>
                <span>*</span>姓名：
            </th>
            <td>
                <asp:TextBox ID="txtName" CssClass="BigInput" runat="server"></asp:TextBox>
               
            </td>
             <th>
                <span>*</span>呢称：
            </th>
            <td>
                <asp:TextBox ID="txtNick" CssClass="BigInput" runat="server"></asp:TextBox>
              
            </td>
        </tr>
       
        <tr>
            <th>
                <span>*</span>性别：
            </th>
            <td>
                <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="男" Value="1"></asp:ListItem>
                    <asp:ListItem Text="女" Value="0"></asp:ListItem>
                    <asp:ListItem Text="未知" Value=""></asp:ListItem>
                </asp:RadioButtonList>
            </td>
             <th>
                <span>*</span>生日：
            </th>
            <td>
                <asp:TextBox ID="txtBirthday" CssClass="BigInput" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <th>
                <span>*</span>Email：
            </th>
            <td>
                <asp:TextBox ID="txtEmail" CssClass="BigInput" runat="server"></asp:TextBox>
            </td>
             <th>
                <span>*</span>电话：
            </th>
            <td>
                <asp:TextBox ID="txtTelephone" CssClass="BigInput" runat="server"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <th>
                <span>*</span>工作地址：
            </th>
            <td>
                <asp:TextBox ID="txtWorkAddress" CssClass="BigInput" runat="server"></asp:TextBox>
            </td>
             <th>
                <span>*</span>工作邮编：
            </th>
            <td>
                <asp:TextBox ID="txtWorkZip" CssClass="BigInput" runat="server"></asp:TextBox>
            </td>
        </tr>
      
        <tr>
            <th>
                <span>*</span>家庭地址：
            </th>
            <td>
                <asp:TextBox ID="txtHomeAddress" CssClass="BigInput" runat="server"></asp:TextBox>
            </td>
             <th>
                <span>*</span>家庭邮编：
            </th>
            <td>
                <asp:TextBox ID="txtHomeZip" CssClass="BigInput" runat="server"></asp:TextBox>
            </td>
        </tr>
      
        <tr>
            <th>
                <span>*</span>所属角色：
            </th>
            <td>
                <ux:RoleSelect ID="uxRoleSelect" runat="server" />
            </td>
            <th>
            </th>
            <td></td>
        </tr>
        <tr class="TableControl">
            <td colspan="4">
                <asp:Button ID="btnSave" runat="server" group='submit' Text="保存信息" OnClientClick="CheckForm();" OnClick="btnSave_Click" CssClass="BigButton" />
                <input type="button" value="返 回" onclick="location.href = 'RoleList.aspx'" class="BigButton" />
            </td>
        </tr>


    </table>

    <script type="text/javascript">
        $(function () {
            ConfigValidateGroup();
            $("#<%=txtLoginName.ClientID%>").formValidator({ onShow: "请输入账号", onFocus: "至少1个长度", onCorrect: "账号正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "账号两边不能有空符号" }, onError: "账号不能为空,请确认" });

            $("#<%=txtName.ClientID%>").formValidator({ onShow: "请输入名称", onFocus: "至少1个长度", onCorrect: "名称正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "名称两边不能有空符号" }, onError: "名称不能为空,请确认" });
            $("#<%=txtNick.ClientID%>").formValidator({ onShow: "请输入编码", onFocus: "保证编码不可以重复", onCorrect: "编码正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "编码两边不能有空符号" }, onError: "编码不能为空,请确认" });
           })
    </script>
</asp:Content>
