<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pager.ascx.cs" Inherits="iEAS.Infrastructure.Web.Controls.Pager" %>

<iEAS:DataPager ID="pager" runat="server" PageSize="2">
    <Fields>
        <asp:TemplatePagerField>
            <PagerTemplate>
                <span class="total">共 <b><%=Math.Ceiling ((double)pager.TotalRowCount / pager.PageSize)%></b> 页,共 <b><%=pager.TotalRowCount%></b> 条记录</span> &nbsp;&nbsp
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
