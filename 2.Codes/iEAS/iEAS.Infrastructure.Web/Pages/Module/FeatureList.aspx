﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeatureList.aspx.cs"
    MasterPageFile="~/Masters/ListPage.Master"
    Inherits="iEAS.Infrastructure.Web.Pages.Module.FeatureList" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
    <div class="tabbable work-nav">
        <ul id="myTab" class="nav nav-tabs">
            <li class="active"><a href="ModuleList.aspx" data-toggle="tab">功能管理</a></li>
        </ul>
    </div>
    <div class="search_area">
        <div class="form-search form-search-top" style="text-align: left; padding-left: 10px;">
            <div class="adv-select-label">功能名称：
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
            <asp:Button ID="btnQuery" runat="server" Text="查 询" OnClick="btnQuery_Click" CssClass="btn btn-primary" />
        </div>
    </div>
    <div class="data-wrap">
        <div class="data-operation">
            <div class="button-operation">
                <asp:Button ID="btnAdd" runat="server" Text='增加功能' CssClass='btn btn-success' OnClick="btnAdd_Click" />

                <asp:Button ID="btnDeleteAll" runat="server" Text='删除功能' CssClass='btn btn-danger' OnClick="btnDeleteAll_Click" />
            </div>

        </div>
    </div>
    <div class="data-list">
        <iEAS:GridView ID="gvList" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
            CssClass="table table-bordered table-hover" Width="100%" GridLines="None" OnRowCommand="gvList_RowCommand" Style="border-collapse: separate">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <input type="checkbox" onclick="checkAll(this, 'ids')" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <input name="ids" data="ids" type="checkbox" value="<%# Eval("ID") %>" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="功能名称" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate><%# Eval("Name") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="400px" />

                </asp:TemplateField>
                <asp:TemplateField HeaderText="功能编码">
                    <ItemTemplate><%# Eval("Code") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="功能描述">
                    <ItemTemplate><%# Eval("Desc") %></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <a href="FeatureEdit.aspx?moduleID=<%=ModuleID %>&parentID=<%# Eval("ID") %>">添加子功能</a>
                        |<a href="FeatureEdit.aspx?moduleID=<%=ModuleID %>&rid=<%# Eval("ID") %>">编辑</a>
                        |<asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="Del" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="editThead" HorizontalAlign="Center" />
            <RowStyle Wrap="true" />
        </iEAS:GridView>
    </div>
</asp:Content>
