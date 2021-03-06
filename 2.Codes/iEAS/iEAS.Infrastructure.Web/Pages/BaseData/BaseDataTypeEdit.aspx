﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaseDataTypeEdit.aspx.cs"
    MasterPageFile="~/Masters/EditPage.Master"
    Inherits="iEAS.Infrastructure.Web.Pages.BaseData.BaseDataTypeEdit" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">

    <div class="TableBlock_top">
        <div class="TableBlock_top_title">
            <img src="<%=Page.ResolveUrl("~/") %>assets/common/images/notify_new.gif" alt="" />
            新增数据类型
        </div>
        <div class="TableBlock_top_back"><a href="BaseDataTypeList.aspx" style="font-size: 12px;">&lt;&lt;返回列表页</a></div>
    </div>

    <table class="TableBlock">
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
                <span>*</span>是否支持树型结构：
            </th>
            <td>
                <asp:RadioButtonList ID="rblTreeMode" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="是" Value="1"></asp:ListItem>
                    <asp:ListItem Text="否" Value="0" Selected="True"></asp:ListItem>
                </asp:RadioButtonList>
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
                <asp:Button ID="btnSave" runat="server" group='submit' Text="保存信息" OnClick="btnSave_Click" CssClass="BigButton" />
                <input type="button" value="返 回" onclick="location.href = 'BaseDataTypeList.aspx'" class="BigButton" />
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
