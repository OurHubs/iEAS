﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masters/ListPage.Master" CodeBehind="ChannelList.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Module.ChannelList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="tabbable work-nav">
        <ul id="myTab" class="nav nav-tabs">
            <li class="active"><a href="ChannelEdit.aspx" data-toggle="tab">栏目管理</a></li>
        </ul>
    </div>
    <div class="data-wrap">
        <div class="data-operation">
            <div class="button-operation">
                <input type="button" value="新建" class='btn btn-success' onclick="location.href='ChannelEdit.aspx'" />
            </div>
            <div class="pager_operation">
            </div>
        </div>
    </div>
    <div class="data-list">
        <iEAS:GridView ID="gvList" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
            CssClass="table table-bordered table-hover" Width="100%" GridLines="None" OnRowCommand="gvList_RowCommand" Style="border-collapse: separate">
            <Columns>
                <asp:TemplateField HeaderText="栏目名称">
                    <ItemTemplate>
                        <%# Eval("Name") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="栏目编码" HeaderStyle-Width="200px">
                    <ItemTemplate>
                        <%# Eval("Code") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备注" HeaderStyle-Width="200px">
                    <ItemTemplate>
                        <%# Eval("Desc") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作" HeaderStyle-Width="300px">
                    <ItemTemplate>
                        <a href="ChannelEdit.aspx?parentID=<%# Eval("ID") %>">添加子项</a>|<a href="ChannelEdit.aspx?rid=<%# Eval("ID") %>">编辑</a>|
                                <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="Del" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="editThead" HorizontalAlign="Center" />
            <RowStyle Wrap="true" />
        </iEAS:GridView>
    </div>
</asp:Content>
