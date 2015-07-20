<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaseDataItemList.aspx.cs"
     MasterPageFile="~/Masters/ListPage.Master"
     Inherits="iEAS.Infrastructure.Web.Pages.BaseData.BaseDataItemList" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
     <div class="tabbable work-nav">
        <ul id="myTab" class="nav nav-tabs">
            <li class="active"><a href="#" data-toggle="tab"> <asp:Literal ID="litDataTypeTitle" runat="server"></asp:Literal>  > 基础数据项</a></li>
        </ul>
    </div>
    <div class="search_area">
        <div class="form-search form-search-top" style="text-align: left; padding-left: 10px;">
            <div class="adv-select-label">数据项名称：
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
            <asp:Button ID="btnQuery" runat="server" Text="查 询" OnClick="btnQuery_Click" CssClass="btn btn-primary" />
        </div>
    </div>
    <div class="data-wrap">
        <div class="data-operation">
            <div class="button-operation">
                <asp:Button ID="btnAdd" runat="server" Text='增加' CssClass='btn btn-success' OnClick="btnAdd_Click" />
                <asp:Button ID="btnDeleteAll" runat="server" Text='删除' CssClass='btn btn-danger' OnClick="btnDeleteAll_Click" />
                <asp:Button ID="btnBack" runat="server" Text='返回' CssClass='btn btn-danger' OnClick="btnBack_Click" />
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
                <asp:TemplateField HeaderText="值">
                    <ItemTemplate><%# Eval("Value") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备注">
                    <ItemTemplate><%# Eval("Desc") %></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>

                         <a href="BaseDataItemEdit.aspx?typeid=<%=TypeID %>&parentID=<%# Eval("ID") %>">添加子项</a>|<a href="BaseDataItemEdit.aspx?typeid=<%=TypeID %>&rid=<%# Eval("ID") %>">编辑</a>|
                                <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="Del" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>

                     <%--  <a href="MenuEdit.aspx?portalid=<%=PortalID %>&parentID=<%# Eval("ID") %>">添加子项</a>|<a href="MenuEdit.aspx?portalid=<%=PortalID %>&rid=<%# Eval("ID") %>">编辑</a>|
                                <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="Del" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>--%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="editThead" HorizontalAlign="Center" />
            <RowStyle Wrap="true" />
        </iEAS:GridView>
    </div>



      

         <%--   <table class="tabList">
                <tr class="title">
                    <td style="width: 5%">
                        <input name="checkAll" class="checkAll" id="checkAll" type="checkbox" value='' />
                    </td>
                    <td style="width: 5%">ID
                    </td>
                    <td style="width: 20%">名称
                    </td>
                    <td style="width: 10%">值
                    </td>
                    <td>备注
                    </td>
                    <td style="width: 15%">操作
                    </td>
                </tr>
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
                                <%# Eval("ID") %>
                            </td>
                            <td>
                                <%# Eval("Name") %>
                            </td>
                            <td>
                                <%# Eval("Value") %>
                            </td>
                            <td>
                                <%# Eval("Desc") %>
                            </td>
                            <td>
                                <a href="BaseDataItemEdit.aspx?typeid=<%=TypeID %>&parentID=<%# Eval("ID") %>">添加子项</a>|<a href="BaseDataItemEdit.aspx?typeid=<%=TypeID %>&rid=<%# Eval("ID") %>">编辑</a>|
                                <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="Del" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </iEAS:ListView>
            </table>--%>

         <%--   <iEAS:ObjectDataSource ID="odsQuery" runat="server" OnQuery="odsQuery_Query" DeleteMethod="DeleteRecord">
            </iEAS:ObjectDataSource>
        </div>--%>

</asp:Content>