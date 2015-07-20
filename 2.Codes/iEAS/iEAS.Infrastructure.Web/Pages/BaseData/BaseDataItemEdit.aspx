<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaseDataItemEdit.aspx.cs" 
     MasterPageFile="~/Masters/EditPage.Master"
    Inherits="iEAS.Infrastructure.Web.Pages.BaseData.BaseDataItemEdit" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
      <%--  <div class="container">
            <div class="form_panel">
                <div class="from_panel_header">
                    <span class="title icon_search">基础数据项</span>
                </div>
                <div class="form_panel_body">--%>

    <div class="TableBlock_top">
        <div class="TableBlock_top_title">
            <img src="<%=Page.ResolveUrl("~/") %>assets/common/images/notify_new.gif" alt="" />
            基础数据项
        </div>
        <div class="TableBlock_top_back"><a href="BaseDataItemList.aspx?typeId=<%=TypeID%>" style="font-size: 12px;">&lt;&lt;返回列表页</a></div>
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
                                <span>*</span>值：
                            </th>
                            <td>
                                <asp:TextBox ID="txtValue" CssClass="BigInput" runat="server"></asp:TextBox>
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
                                <asp:Button ID="btnSave" runat="server" data-group="1" Text="保存信息" OnClick="btnSave_Click" CssClass="BigButton" />
                                <input type="button" value="返 回" onclick="location.href = 'BaseDataItemList.aspx?typeId=<%=TypeID%>'" class="BigButton" />
                            </td>
                        </tr>
                    </table>
              
</asp:Content>

