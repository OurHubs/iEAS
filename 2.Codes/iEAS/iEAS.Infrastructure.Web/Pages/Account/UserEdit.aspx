<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs"
    MasterPageFile="~/Masters/EditPage.Master"
    Inherits="iEAS.Infrastructure.Web.Pages.Account.UserEdit" %>
<%@ Register Src="UxControls/RoleSelect.ascx" TagName="RoleSelect" TagPrefix="ux" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
   <%--<style type="text/css">
    .TableBlock2Column td table{ float:left;}
    .tabContainer{}
    .tabContainer table{float:left; display:inline; width:400px;}
   </style>--%>


    <div class="TableBlock_top">
        <div class="TableBlock_top_title">
            <img src="<%=Page.ResolveUrl("~/") %>assets/common/images/notify_new.gif" alt="" />
            新增用户</div>
        <div class="TableBlock_top_back"><a href="UserList.aspx" style="font-size: 12px;">&lt;&lt;返回列表页</a></div>
    </div>
    <table class="TableBlock2Column" >
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
                <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="BigInput" runat="server"></asp:TextBox>
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
                <asp:RadioButtonList ID="rblGender" style=" float:left;" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="女" Value="0"></asp:ListItem>                
                </asp:RadioButtonList>
                <div id="genderTip" style="float:left; bottom:0px; margin-left:400px;"></div>
            </td>
             <th>
                生日：
            </th>
            <td>
                <asp:TextBox ID="txtBirthday" ReadOnly="true"   onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"  CssClass="BigInput" runat="server"></asp:TextBox>
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
                <span></span>电话：
            </th>
            <td>
                <asp:TextBox ID="txtTelephone" CssClass="BigInput" runat="server"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <th>
                <span></span>工作地址：
            </th>
            <td>
                <asp:TextBox ID="txtWorkAddress" CssClass="BigInput"  Width="60%" runat="server"></asp:TextBox>
            </td>
             <th>
                工作邮编：
            </th>
            <td>
                <asp:TextBox ID="txtWorkZip" CssClass="BigInput" runat="server"></asp:TextBox>
            </td>
        </tr>
      
        <tr>
            <th>
                <span></span>家庭地址：
            </th>
            <td>
                <asp:TextBox ID="txtHomeAddress" CssClass="BigInput" Width="60%" runat="server"></asp:TextBox>
            </td>
             <th>
                <span></span>家庭邮编：
            </th>
            <td>
                <asp:TextBox ID="txtHomeZip" CssClass="BigInput" runat="server"></asp:TextBox>
            </td>
        </tr>
      
        <tr>
            <th>
                <span>*</span>所属角色：
            </th>
            <td colspan="3" class="tabContainer">
                <ux:RoleSelect ID="uxRoleSelect"  runat="server" />
                <div id="RoleTip" style="display:inline-table"></div>
            </td>
  
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
            $("#<%=txtPassword.ClientID%>").formValidator({ onShow: "请输入密码", onFocus: "密码6-20位", onCorrect: "密码合法" }).inputValidator({ min: 6, max: 20, onError: "密码非法,请确认" });
            $("#<%=txtEmail.ClientID%>").formValidator({ onShow: "请输入邮箱", onFocus: "邮箱至少6个字符,最多100个字符", onCorrect: "恭喜你,你输对了" }).inputValidator({ min: 6, max: 100, onError: "你输入的邮箱长度非法,请确认" }).regexValidator({ regExp: "^([\\w-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([\\w-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$", onError: "你输入的邮箱格式不正确" });
            $("#<%=txtTelephone.ClientID%>").formValidator({ empty: true, onShow: "手机或电话,可以为空", onFocus: "例如：0577-88888888或手机号", onCorrect: "谢谢你的合作", onEmpty: "你真的不想留电话了吗？" }).regexValidator({ regExp: ["tel", "mobile"], dataType: "enum", onError: "你输入的手机或电话格式不正确" });

            $("#<%=txtNick.ClientID%>").formValidator({ onShow: "请输入编码", onFocus: "保证编码不可以重复", onCorrect: "编码正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "编码两边不能有空符号" }, onError: "编码不能为空,请确认" });

            $("#<%=txtWorkAddress.ClientID%>").formValidator({ empty: true, onShow: "请输入工作地址", onFocus: "至少1个长度", onCorrect: "正确", onEmpty: "工作地址为空？" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "地址两边不能有空符号" }, onError: "地址不能为空,请确认" });
            $("#<%=txtHomeAddress.ClientID%>").formValidator({ empty: true, onShow: "请输入家庭住址", onFocus: "至少1个长度", onCorrect: "正确", onEmpty: "家庭住址不填写？" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "住址两边不能有空符号" }, onError: "住址不能为空,请确认" });
            $("#<%=txtWorkZip.ClientID%>").formValidator({ empty: true, onShow: "请输入工作邮编", onFocus: "至少1个长度", onCorrect: "正确", onEmpty: "工作邮编不填写？" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "工作邮编不能有空符号" }, onError: "工作邮编为空,请确认" });
            $("#<%=txtHomeZip.ClientID%>").formValidator({ empty: true, onShow: "请输入家庭邮编", onFocus: "至少1个长度", onCorrect: "正确", onEmpty: "家庭邮编不填写？" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "家庭邮编不能有空符号" }, onError: "家庭邮编为空,请确认" });

            //$(":radio[name='ctl00$Content$rblGender']").formValidator({  tipID: "genderTip", tipCss: { "left": "60px" }, onShow: "请选择你的性别", onFocus: "没有第三种性别了，你选一个吧", onCorrect: "输入正确", defaultValue: ["1"] }).inputValidator({ min: 1, max: 1, onError: "性别忘记选了,请确认" }).defaultPassed();
            $(":checkbox[id^='Content_uxRoleSelect_chkRoles']").formValidator({ tipID: "RoleTip", tipCss: { "left": "60px" }, onShow: "请选择角色", onFocus: "至少选择一个角色", onCorrect: "恭喜你,你选对了" }).inputValidator({ min: 0, onError: "你选的个数不对(至少选择1角色)" });
            //$("#tabContainer > input[type=checkbox]").formValidator({ tipID: "RoleTip", tipCss: { "left": "60px" }, onShow: "请选择角色", onFocus: "至少选择一个角色", onCorrect: "恭喜你,你选对了" }).inputValidator({ min: 1, onError: "你选的个数不对(至少选择1角色)" });

            //$("#tabContainer > input[type=checkbox] ").formValidator({ relativeID: "pp6", tipID: "xq2Tip", tipCss: { "left": "60px" }, onShow: "请选择用户角色(至少选择1个)", onFocus: "你至少选择2个,最多选择3个", onCorrect: "恭喜你,你选对了", defaultValue: ["7", "8"] }).inputValidator({ min: 2, max: 3, onError: "至少选择1个" });

           })
    </script>
</asp:Content>
