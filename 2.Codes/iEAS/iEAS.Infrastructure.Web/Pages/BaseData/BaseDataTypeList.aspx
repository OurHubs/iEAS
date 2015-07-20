<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaseDataTypeList.aspx.cs"
      MasterPageFile="~/Masters/ListPage.Master"
     Inherits="iEAS.Infrastructure.Web.Pages.BaseData.BaseDataTypeList" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
    <div class="tabbable work-nav">
        <ul id="myTab" class="nav nav-tabs">
            <li class="active"><a href="ModuleList.aspx" data-toggle="tab">基础数据类型管理</a></li>
        </ul>
    </div>
     <div class="search_area">
        <div class="form-search form-search-top" style="text-align: left; padding-left: 10px;">
            <div class="adv-select-label">类型名称： <asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
            <asp:Button ID="btnQuery" runat="server" Text="查 询" OnClick="btnQuery_Click" CssClass="btn btn-primary" />
        </div>
    </div>
     <div class="data-wrap">
        <div class="data-operation">
            <div class="button-operation">
                <asp:Button ID="btnAdd" runat="server" Text='添加' CssClass='btn btn-success' OnClick="btnAdd_Click" />
                <asp:Button ID="btnDeleteAll" runat="server" Text='删除' CssClass='btn btn-danger' OnClick="btnDeleteAll_Click" />
            </div>
            <div class="pager_operation">
                <iEAS:AspNetPager ID="Pager" runat="server" AlwaysShow="true" ShowCustomInfoSection="Left" PrevPageText="上一页" NextPageText="下一页" FirstPageText="首页" LastPageText="尾页"
                    PagingButtonLayoutType="UnorderedList" CustomInfoHTML="<div class='page-info-block'>共<span id='total_records'>%RecordCount%</span>条  <span id='total_page'>%PageSize%</span>条/页 共<span id='current_page'>%PageCount%</span>页</div> "
                    OnPageChanging="Pager_PageChanging" PageSize="10" CurrentPageButtonTextFormatString="{0}" NumericButtonTextFormatString="{0}" PagingButtonSpacing="0">
                </iEAS:AspNetPager>
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
                <asp:TemplateField HeaderText="类型名称">
                    <ItemTemplate><%# Eval("Name") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="类型编码">
                    <ItemTemplate><%# Eval("Code") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="描述">
                    <ItemTemplate><%# Eval("Desc") %></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"/>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate >          
                            <a href="BaseDataItemList.aspx?typeid=<%# Eval("ID") %>">查看数据项</a>                                |
                            <a href="BaseDataTypeEdit.aspx?rid=<%# Eval("ID") %>">编辑</a>|
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="删除" CommandName="Del" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="editThead" HorizontalAlign="Center" />
            <RowStyle Wrap="true" />
        </iEAS:GridView>
    </div>





      <%--  <div class="container">
            <ul class="tabList_toolbar">
                <li><a href="BaseDataTypeEdit.aspx" class="add">增 加</a> </li>
                <li><a href="#" class="del">删 除</a></li>
            </ul>--%>

            <%--<table class="tabList">
                <tr class="title">
                    <td style="width: 5%">
                        <input name="checkAll" class="checkAll" id="checkAll" type="checkbox" value='' />
                    </td>
                    <td style="width: 20%">类型名称
                    </td>

                    <td style="width: 10%">类型编码
                    </td>
                    <td>描述
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
                                <%# Eval("Name") %>
                            </td>
                            <td>
                                <%# Eval("Code") %>
                            </td>
                            <td>
                                <%# Eval("Desc") %>
                            </td>
                            <td>
                                <a href="BaseDataItemList.aspx?typeid=<%# Eval("ID") %>">查看数据项</a>
                                |
                            <a href="BaseDataTypeEdit.aspx?rid=<%# Eval("ID") %>">编辑</a>|
                            <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="Del" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </iEAS:ListView>
            </table>--%>


          <%--  <div class="fenye">
              <iEAS:Pager ID="Pager"  runat="server" PagedControlID="lvQuery" />
            </div>
           
            <iEAS:ObjectDataSource ID="odsQuery" runat="server" OnQuery="odsQuery_Query" DeleteMethod="DeleteRecord">
            </iEAS:ObjectDataSource>
        </div>--%>
  
</asp:Content>