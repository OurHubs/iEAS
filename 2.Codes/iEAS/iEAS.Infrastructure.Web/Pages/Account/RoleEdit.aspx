<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleEdit.aspx.cs" 
    MasterPageFile="~/Masters/EditPage.Master"
    Inherits="iEAS.Infrastructure.Web.Pages.Account.RoleEdit" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
     <table width="90%" border="0" align="center" cellpadding="3" cellspacing="0" class="small">
        <tr>
            <td class="Big">
                <img src="<%=Page.ResolveUrl("~/") %>assets/common/images/notify_new.gif" align="middle" alt=""><span class="big3"> 新增角色</span>&nbsp;&nbsp;&nbsp;&nbsp;
	            <span style="font-size: 12px; float: right; margin-right: 20px;">
                    <a href="RoleList.aspx" style="font-size: 12px;">&lt;&lt;返回列表页</a>
                </span>
            </td>
        </tr>
    </table>
     <table class="TableBlock" border="0" width="90%" align="center" style="border-bottom: #4686c6 solid 0px;">
        <tr>
            <td nowrap class="TableContent" width="15%">
                名称<font title='打*号表示为必填' color='#ff0000'>(*)</font>
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtName" runat="server" CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap class="TableContent" width="15%">
                编码<font title='打*号表示为必填' color='#ff0000'>(*)</font>
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtCode" runat="server" CssClass="BigInput"></asp:TextBox>

            </td>
        </tr>
        

        <tr>
            <td nowrap class="TableContent" width="15%">
                描述<font title='打*号表示为必填' color='#ff0000'>(*)</font>
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="3" Width="500px"  CssClass="BigInput"></asp:TextBox>
            </td>
        </tr>
        <tr align="center" class="TableControl">
            <td colspan="2" nowrap height="35">
                <asp:Button ID="btnSave" runat="server" Text="保存信息" OnClick="btnSave_Click" CssClass="BigButton" />
                <asp:Button ID="btnBack" runat="server" Text="返 回" class="btn" OnClick="btnBack_Click" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">

        $(function () {
            //$.formValidator.initConfig({
            //    formid: "formTable",
            //    errorfocus: false,
            //    submitonce: true,
            //    tipstyle: "both",
            //    onerror: function () { // 验证不通过时的回调函数
            //        alert("红色提示处输入非法，请根据提示修改！");
            //    }
            //});

           // $.formValidator.initConfig({ autotip: true, onerror: function (msg) { alert(msg) } });

            
            $("#<%=txtName.ClientID%>").formValidator({ onshow: "请输入密码", onfocus: "密码不能为 空", oncorrect: "密码合法" })
                         .inputValidator({ min: 1, empty: { leftempty: false, rightempty: false, emptyerror: "密码两边不能有空符号" }, onerror: "名字不能 为空,请确认" });
        })
      
    </script>
   

</asp:Content>