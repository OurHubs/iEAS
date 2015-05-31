<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pager.ascx.cs" Inherits="iEAS.Infrastructure.Web.Controls.Pager" %>

        <iEAS:DataPager ID="pager" runat="server" PageSize="10">
            <Fields>
                <asp:NumericPagerField />
            </Fields>
        </iEAS:DataPager>
