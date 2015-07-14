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
              <th>描述 </th>         
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

            //$("#").formValidator({ onShow: "请输入编码", onFocus: "保证编码不可以重复", onCorrect: "编码正确" }).inputValidator({ min: 5, max: 10, onError: "你输入的编码非法,请确认" })
            //.ajaxValidator({
            //    dataType : "json",
            //    async: true,               
            //    url: "Handler1.ashx?action=CheckRoleCode&code=" +  $(this).val(),
            //    success: function (data) {
                   
            //        alert(data.ReturnDesc);
            //        if (data.ReturnCode == "1") return true;
            //        return data.ReturnDesc;
            //    },            
            //    error: function(jqXHR, textStatus, errorThrown){alert("服务器没有返回数据，可能服务器忙，请重试"+errorThrown);},
            //    onError : "该编码不可用，请更换",
            //    onWait : "正在对角色编码进行合法性校验，请稍候..."
            //}).defaultPassed();
        })



    </script>
</asp:Content>
