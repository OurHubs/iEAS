<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ListPage.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Orgnization.EmployeeList" %>

<asp:Content ID="ctHeader" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="ctContent" ContentPlaceHolderID="Content" runat="server">
    <div class="tabbable work-nav">
        <ul id="myTab" class="nav nav-tabs">
            <li class="active"><a href='EmployeeList.aspx?departmentId=<%=DepartmentID %>' data-toggle="tab">员工管理</a></li>
        </ul>
    </div>
    <div class="search_area">
        <div class="form-search form-search-top" style="text-align: left; padding-left: 10px;">
          <div class="adv-select-label">名称：</div>
            <asp:TextBox ID="txtName" runat="server" CssClass="BigInput"></asp:TextBox>
            <div class="adv-select-label">编码：</div>
            <asp:TextBox ID="txtEmployeeNumber" runat="server" CssClass="BigInput"></asp:TextBox>
            <asp:Button ID="btnQuery" runat="server" Text="查 询" OnClick="btnQuery_Click" CssClass="btn btn-primary" />
        </div>
    </div>
    <div class="data-wrap">
        <div class="data-operation">
            <div class="button-operation">
                <input type="button" value="添加员工" class='btn btn-success' onclick="location.href = 'EmployeeEdit.aspx?departmentId=<%=DepartmentID %>'" />
                <asp:Button ID="btnDeleteAll" runat="server" Text='删除员工' CssClass='btn btn-danger' OnClick="btnDeleteAll_Click" />
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
                <asp:TemplateField HeaderText="名称">
                    <ItemTemplate><%# Eval("ChineseName") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="65px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="员工编号">
                    <ItemTemplate><%# Eval("EmployeeNumber") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="65px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="手机">
                    <ItemTemplate><%# Eval("MobilePhone") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Email">
                    <ItemTemplate><%# Eval("Email") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="部门">
                    <ItemTemplate><%# GetDeptName(Container.DataItem) %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="汇报对象">
                    <ItemTemplate><%# Eval("ReportLineUser.ChineseName") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="65px" />
                </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="状态">
                    <ItemTemplate><%# Eval("WorkStatsDisplayName") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                         <a href="EmployeeEdit.aspx?departmentId=<%# DepartmentID %>&rid=<%# Eval("ID") %>">编辑</a>|
                        <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="Del" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="90px" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="editThead" HorizontalAlign="Center" />
            <RowStyle Wrap="true" />
        </iEAS:GridView>
    </div>
</asp:Content>