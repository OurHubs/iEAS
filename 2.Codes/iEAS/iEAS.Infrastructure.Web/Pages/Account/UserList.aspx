<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" 
      MasterPageFile="~/Masters/ListPage.Master"
    Inherits="iEAS.Infrastructure.Web.Pages.Account.UserList" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
   <div class="tabbable work-nav">
        <ul id="myTab" class="nav nav-tabs">
            <li class="active"><a href="UserList.aspx" data-toggle="tab">用户管理</a></li>
        </ul>
    </div>
    <div class="search_area">
        <div class="form-search form-search-top" style="text-align: left; padding-left: 10px;">
             <div class="adv-select-label">名称： <asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
        
            <asp:Button ID="btnQuery" runat="server" Text="查 询" OnClick="btnQuery_Click" CssClass="btn btn-primary" />
        </div>
    </div>
    <div class="data-wrap">
        <div class="data-operation">
            <div class="button-operation">
                <asp:Button ID="btnAdd" runat="server" Text='添加用户' CssClass='btn btn-success' OnClick="btnAdd_Click" />
                <asp:Button ID="btnDeleteAll" runat="server" Text='删除用户' CssClass='btn btn-danger' OnClick="btnDeleteAll_Click" />
            </div>
            <div class="pager_operation">
                <iEAS:AspNetPager ID="aspnetpage" runat="server" AlwaysShow="true" ShowCustomInfoSection="Left" PrevPageText="上一页" NextPageText="下一页" FirstPageText="首页" LastPageText="尾页"
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
                <asp:TemplateField HeaderText="登录名">
                    <ItemTemplate><%# Eval("LoginName") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="姓名">
                    <ItemTemplate><%# Eval("Name") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate><%#Eval("Gender").ToStr(m=>m=="1"?"男":"女","未知")  %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="生日">
                    <ItemTemplate><%# Eval("Birthday","{0:yyyy-MM-dd}")  %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="电话">
                    <ItemTemplate><%#Eval("Telephone") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate><%#Eval("Email") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                </asp:TemplateField>
                
             
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <a href="UserEdit.aspx?rid=<%# Eval("ID") %>">编辑</a>|
                        <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="Del" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="300px" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="editThead" HorizontalAlign="Center" />
            <RowStyle Wrap="true" />
        </iEAS:GridView>
    </div>
</asp:Content>
