<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Blank.Master" AutoEventWireup="true" CodeBehind="DepartmentSelect.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Controls.Pages.DepartmentSelect" %>

<asp:Content ID="ctHeader" ContentPlaceHolderID="Header" runat="server">
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="ctContent" ContentPlaceHolderID="Content" runat="server">
    <div class="data-list">
        <iEAS:GridView ID="gvList" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
            CssClass="table table-bordered table-hover" Width="100%" GridLines="None" Style="border-collapse: separate">
            <Columns>
                 <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <a href="#">选择</a>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                     <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="部门名称">
                    <ItemTemplate>
                        <%# Eval("Name") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="部门编码" HeaderStyle-Width="200px">
                    <ItemTemplate>
                        <%# Eval("Code") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="editThead" HorizontalAlign="Center" />
            <RowStyle Wrap="true" />
        </iEAS:GridView>
    </div>
</asp:Content>
