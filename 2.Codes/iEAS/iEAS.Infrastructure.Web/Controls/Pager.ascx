<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pager.ascx.cs" Inherits="iEAS.Infrastructure.Web.Controls.Pager" %>
<iEAS:DataPager ID="pager" runat="server" PageSize="10">
    <Fields>
        <asp:NumericPagerField />
<%--        <asp:TemplatePagerField>
            <PagerTemplate>
                   你好呀
            </PagerTemplate>
        </asp:TemplatePagerField>--%>
    </Fields>
</iEAS:DataPager>