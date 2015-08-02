<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowPending.aspx.cs" Inherits="iEAS.BPM.Web.FlowPending" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnCreateTest" runat="server" Text="创建流程" OnClick="btnCreateTest_Click" />
        <br />
        用户:<asp:TextBox ID="txtUser" runat="server"></asp:TextBox><asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" />
        <div>
            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" OnRowCommand="gvList_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="SN" ItemStyle-Width="50px">
                        <ItemTemplate><%# Eval("SN") %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Folio" ItemStyle-Width="100px">
                        <ItemTemplate><%# Eval("Folio") %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="流程名称" ItemStyle-Width="200px">
                        <ItemTemplate><%# Eval("ProcessInstance.Process.Code") %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="节点名称" ItemStyle-Width="200px">
                        <ItemTemplate><%# Eval("ActivityInstance.Name") %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ItemStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Button ID="btnApprove" runat="server" Text="审批" CommandName="Approve" CommandArgument='<%# Eval("SN") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
