﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TabPagedQuery.ascx.cs" Inherits="iEAS.Infrastructure.Web.Model.Template.List.TabPagedQuery" %>
<%@ Register src="ModelToolBar.ascx" tagname="ModelToolBar" tagprefix="iEAS" %>
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
    <link rel="stylesheet" type="text/css" href="../assets/common/css/style2015.css">
    <script type="text/javascript" src="../assets/common/js/jquery.min.js"></script>
    <script type="text/javascript" src="../assets/common/js/lockTableTitle.js"></script>
    <script type="text/javascript" src="../assets/common/js/common.js"></script>
</head>
<body class="body-wrap">
    <form runat="server">
        <div class="tabbable work-nav">
            <ul id="myTab" class="nav nav-tabs">
                <% foreach(var item in ModelContext.Current.List.Navigations){ %>
                <% if(item.IsCurrent){ %>
                    <li class="active">
                <%} else { %>
                    <li>
                <%} %>
                <% if(item.Type=="ModelList"){ %>
                    <a href="/ModelQuery/<%=item.Url %>" data-toggle="tab">
                <%} %>                    
                    <%=item.Title %></a></li>
                <%} %>
            </ul>
        </div>
        <div class="search_area">
            <div class="form-search form-search-top" style="text-align: left; padding-left: 10px;">
                <asp:Repeater ID="rptConditions" runat="server" OnItemDataBound="rptConditions_ItemDataBound">
                    <ItemTemplate>
                        <div class="adv-select-label"><%# Eval("Title") %>：</div>
                        <iEAS:ModelFieldContainer ID="ctField" runat="server"></iEAS:ModelFieldContainer>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Button ID="btnQuery" runat="server" Text="查 询" OnClick="btnQuery_Click" CssClass="btn btn-primary" />
            </div>
        </div>
        <div class="data-wrap">
            <div class="data-operation">
                <div class="button-operation">
                    <iEAS:ModelToolBar ID="uxToolBar" runat="server" />
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
                <HeaderStyle CssClass="editThead" HorizontalAlign="Center" />
                <RowStyle Wrap="true" />
            </iEAS:GridView>
        </div>
    </form>
</body>
</html>
