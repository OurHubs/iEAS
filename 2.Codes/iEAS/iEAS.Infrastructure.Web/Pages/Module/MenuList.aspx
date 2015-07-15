<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" 
     MasterPageFile="~/Masters/ListPage.Master"
    Inherits="iEAS.Infrastructure.Web.Pages.Module.MenuList" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
     <div class="tabbable work-nav">
        <ul id="myTab" class="nav nav-tabs">
            <li class="active"><a href="ModuleList.aspx" data-toggle="tab">菜单管理</a></li>
        </ul>
    </div>
    <div class="search_area">
        <div class="form-search form-search-top" style="text-align: left; padding-left: 10px;">
            <div class="adv-select-label">菜单名称：
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
            <asp:Button ID="btnQuery" runat="server" Text="查 询" OnClick="btnQuery_Click" CssClass="btn btn-primary" />
        </div>
    </div>
    <div class="data-wrap">
        <div class="data-operation">
            <div class="button-operation">
                <asp:Button ID="btnAdd" runat="server" Text='增加菜单' CssClass='btn btn-success' OnClick="btnAdd_Click" />
                <asp:Button ID="btnDeleteAll" runat="server" Text='删除菜单' CssClass='btn btn-danger' OnClick="btnDeleteAll_Click" />
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
                <asp:TemplateField HeaderText="名称" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate><%# Eval("Name") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="400px" />

                </asp:TemplateField>
                <asp:TemplateField HeaderText="编码">
                    <ItemTemplate><%# Eval("Code") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="描述">
                    <ItemTemplate><%# Eval("Desc") %></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                       <a href="MenuEdit.aspx?portalid=<%=PortalID %>&parentID=<%# Eval("ID") %>">添加子项</a>|<a href="MenuEdit.aspx?portalid=<%=PortalID %>&rid=<%# Eval("ID") %>">编辑</a>|
                                <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="Del" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="editThead" HorizontalAlign="Center" />
            <RowStyle Wrap="true" />
        </iEAS:GridView>
    </div>

         <%--   <ul class="tabList_toolbar">
                <li><a href="MenuEdit.aspx?portalid=<%=PortalID %>" class="add">增 加</a> </li>
                <li><a href="#" class="del">删 除</a></li>
            </ul>
          
                <iEAS:ListView ID="lvQuery" runat="server" DataSourceID="odsQuery" DataKeyNames="ID" OnItemCommand="lvQuery_ItemCommand">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input type="checkbox" name="IDS" />
                            </td>
                         
                            <td>
                                <%# Eval("Name") %>
                            </td>
                            <td>
                                <%# Eval("Code") %>
                            </td>
                            <td>
                                <%# Eval("Desc") %>
                            </td>
                            <td>
                                <a href="MenuEdit.aspx?portalid=<%=PortalID %>&parentID=<%# Eval("ID") %>">添加子项</a>|<a href="MenuEdit.aspx?portalid=<%=PortalID %>&rid=<%# Eval("ID") %>">编辑</a>|
                                <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="Del" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </iEAS:ListView>
           --%>
     
</asp:Content>
