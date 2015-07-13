<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleEdit.aspx.cs"
    MasterPageFile="~/Masters/EditPage.Master"
    Inherits="iEAS.Infrastructure.Web.Pages.Account.RoleEdit" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
  
    <div class="TableBlock_top">     
         <div class="TableBlock_top_title"> <img src="<%=Page.ResolveUrl("~/") %>assets/common/images/notify_new.gif"  alt="" /> 新增角色</div>
         <div class="TableBlock_top_back"> <a href="RoleList.aspx" style="font-size: 12px;">&lt;&lt;返回列表页</a></div>
    </div>
    <table class="TableBlock" >
        <tr>          
            <th>名称 <span>*</span></th>
            <td >
                <asp:TextBox ID="txtName" runat="server" CssClass="BigInput"></asp:TextBox>
               
            </td>
            
        </tr>
        <tr>
            <th>编码 <span>*</span></th>
            <td>
                <asp:TextBox ID="txtCode" runat="server" CssClass="BigInput"></asp:TextBox>
               
            </td>
            
        </tr>
        <tr>
              <th>描述 <span>*</span></th>         
            <td>
                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="3" Width="500px" CssClass="BigInput"></asp:TextBox>
            </td>
            
        </tr>
        <tr class="TableControl">
            <td colspan="2"  >
                <asp:Button ID="btnSave" runat="server" group='submit' Text="保存信息" OnClientClick="CheckForm();"  OnClick="btnSave_Click" CssClass="BigButton" />
                <input type="button" value="返 回" onclick="location.href = 'RoleList.aspx'" class="BigButton" />
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        $(function () {  
            ConfigValidateGroup();
            $("#<%=txtName.ClientID%>").formValidator({  onShow: "请输入名称", onFocus: "至少1个长度", onCorrect: "名称正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "名称两边不能有空符号" }, onError: "名称不能为空,请确认" });
            $("#<%=txtCode.ClientID%>").formValidator({  onShow: "请输入编码", onFocus: "保证编码不可以重复", onCorrect: "编码正确" }).inputValidator({ min: 1, empty: { leftEmpty: false, rightEmpty: false, emptyError: "编码两边不能有空符号" }, onError: "编码不能为空,请确认" });
            //$("#S").formValidator({onShow: "请输入用户名", onFocus: "用户名至少5个字符,最多10个字符", onCorrect: "该用户名可以注册" }).inputValidator({ min: 5, max: 10, onError: "你输入的用户名非法,请确认" })//.regexValidator({regExp:"username",dataType:"enum",onError:"用户名格式不正确"})
	        //.ajaxValidator({
	        //    type: "GET",
	        //    dataType: "json",
	        //    async: true,
	        //    //url: "RoleEdit.aspx/CheckRoleCode",
	        //    url: "test.aspx",
	        //    data: "{leftCodes:'1',rightCodes:'2'}",
	        //   // contentType: "application/json;charset=utf-8",
	        //    //data: "{roleCode:'" + 2 + "'}",
	        //    success: function (data) {
	        //        alert(data.d);
	        //        if (data == "0") return true;
	        //        return "该用户名不可用，请更换用户名";
	        //    },
	        //    //buttons: $("#button"),
	        //    error: function (jqXHR, textStatus, errorThrown) {
	        //        debugger;
	        //        alert("服务器没有返回数据，可能服务器忙，请重试" + errorThrown);
	        //    },
	        //    onError: "该用户名不可用，请更换用户名",
	        //    onWait: "正在对用户名进行合法性校验，请稍候..."
	        //}).defaultPassed();

        })
    </script>
</asp:Content>
