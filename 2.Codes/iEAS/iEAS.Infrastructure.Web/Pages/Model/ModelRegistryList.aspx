<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModelRegistryList.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Model.ModelRegistryList" %>


<!DOCTYPE html>
<!--[if IE 6 ]> <html class="ie6 lte_ie6 lte_ie7 lte_ie8 lte_ie9"> <![endif]-->
<!--[if lte IE 6 ]> <html class="lte_ie6 lte_ie7 lte_ie8 lte_ie9"> <![endif]-->
<!--[if lte IE 7 ]> <html class="lte_ie7 lte_ie8 lte_ie9"> <![endif]-->
<!--[if lte IE 8 ]> <html class="lte_ie8 lte_ie9"> <![endif]-->
<!--[if lte IE 9 ]> <html class="lte_ie9"> <![endif]-->
<!--[if (gte IE 10)|!(IE)]><!-->
<html>
<!--<![endif]-->
<head>
    <title>iEAS</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=10,chrome=1" />
    <link rel="stylesheet" type="text/css" href="../../assets/common/css/style2015.css">
    <script type="text/javascript" src="../../assets/common/js/jquery.min.js"></script>
    <script type="text/javascript" src="../../assets/common/js/lockTableTitle.js"></script>
    <script type="text/javascript" src="../../assets/common/js/common.js"></script>
</head>
<body class="body-wrap">
    <form runat="server">
        <div class="tabbable work-nav">
            <ul id="myTab" class="nav nav-tabs">
                <li class="active"><a href="ChannelEdit.aspx" data-toggle="tab">内容模型</a></li>
            </ul>
        </div>
        <div class="data-wrap">
            <div class="data-operation">
                <div class="button-operation">
                    <button type="button" class="btn btn-success">新建模型</button>
                </div>
                <div class="pager_operation">
                </div>
            </div>
        </div>
        <div class="data-list">
            <iEAS:GridView ID="gvList" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                CssClass="table table-bordered table-hover" Width="100%" GridLines="None" OnRowCommand="gvList_RowCommand" Style="border-collapse: separate">
                <Columns>
                    <asp:TemplateField HeaderText="序号" HeaderStyle-Width="30px">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="模型名称" HeaderStyle-Width="200px">
                        <ItemTemplate>
                            <%# Eval("Name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="模型编码" HeaderStyle-Width="200px">
                        <ItemTemplate>
                            <%# Eval("Name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="模块" HeaderStyle-Width="200px">
                        <ItemTemplate>
                            <%# Eval("Module") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注" >
                        <ItemTemplate>
                            <%# Eval("Desc") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" HeaderStyle-Width="300px">
                        <ItemTemplate>
                             <asp:LinkButton ID="btnGenerateTable" runat="server" Text="生成表结构" CommandName="GenerateTable" CommandArgument='<%# Eval("Code") %>'></asp:LinkButton>
                            |<asp:LinkButton ID="btnBuildTableFields" runat="server" Text="生成表结构配置" CommandName="TableFields" CommandArgument='<%# Eval("Code") %>'></asp:LinkButton>
                            |<asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="Del" CommandArgument='<%# Eval("Code") %>'></asp:LinkButton>
                            |<a href="ModelTempEditIframe.aspx?code=<%# Eval("Code") %>">模板编辑</a>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="editThead" HorizontalAlign="Center" />
                <RowStyle Wrap="true" />
            </iEAS:GridView>
        </div>
    </form>
</body>
</html>