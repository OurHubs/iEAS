<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pager.ascx.cs" Inherits="iEAS.Infrastructure.Web.Controls.Pager" %>

<iEAS:DataPager ID="pager" runat="server" PageSize="10">
    <Fields>
        <asp:TemplatePagerField>
            <PagerTemplate>
                <span class="total">共<strong><%=Math.Ceiling ((double)pager.TotalRowCount / pager.PageSize)%></strong>页<strong><%=pager.TotalRowCount%></strong>条记录</span>
            </PagerTemplate>
        </asp:TemplatePagerField>
        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="True"
            ShowNextPageButton="False" ShowPreviousPageButton="False"
            FirstPageText="首页" LastPageText="尾页" />
        <asp:NumericPagerField ButtonCount="5" CurrentPageLabelCssClass="current" />
        <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="True"
            ShowNextPageButton="False" ShowPreviousPageButton="False"
            FirstPageText="首页" LastPageText="尾页" />
    </Fields>
</iEAS:DataPager>
