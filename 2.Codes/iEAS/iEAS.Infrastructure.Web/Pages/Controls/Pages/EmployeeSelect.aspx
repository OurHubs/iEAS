<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Blank.Master" AutoEventWireup="true" CodeBehind="EmployeeSelect.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Controls.Pages.EmployeeSelect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <script type="text/javascript">

        function returnValue(empId, empNumber, empName) {
            if (hfEmpId) {
                window.opener.document.getElementById(hfEmpId).value = empId;
            }
            if (hfEmpNumber) {
                window.opener.document.getElementById(hfEmpNumber).value = hfEmpNumber;
            }
            if (lblName) {
                window.opener.document.getElementById(lblName).innerHTML = empName;
            }
            if (hfEmpName) {
                window.opener.document.getElementById(hfEmpName).value = empName;
            }
            window.close();
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
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
            CssClass="table table-bordered table-hover" Width="100%" GridLines="None" Style="border-collapse: separate">
            <Columns>
                <asp:TemplateField HeaderText="名称">
                    <ItemTemplate>
                          <a href="#" onclick="returnValue('<%# Eval("ID") %>','<%# Eval("EmployeeNumber") %>','<%# Eval("ChineseName") %>')"><%# Eval("ChineseName") %></a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="员工编号">
                    <ItemTemplate>
                        <a href="#" onclick="returnValue('<%# Eval("ID") %>','<%# Eval("EmployeeNumber") %>','<%# Eval("ChineseName") %>')"><%# Eval("EmployeeNumber") %></a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="部门">
                    <ItemTemplate><%# GetDeptName(Container.DataItem) %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="描述">
                    <ItemTemplate><%# Eval("Desc") %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="editThead" HorizontalAlign="Center" />
            <RowStyle Wrap="true" />
        </iEAS:GridView>
    </div>
</asp:Content>
