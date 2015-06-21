<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TabPagedQuery.ascx.cs" Inherits="iEAS.Infrastructure.Web.Model.Template.List.TabPagedQuery" %>
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
    <title>天生创想OA政务版</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=10,chrome=1" />
    <link rel="stylesheet" type="text/css" href="../assets/common/css/style.css">
    <script type="text/javascript" src="../assets/common/js/jquery.min.js"></script>
    <script type="text/javascript" src="../assets/common/js/lockTableTitle.js"></script>
    <script type="text/javascript" src="../assets/common/js/common.js"></script>
    <script type="text/javascript" src="../assets/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">

        var locktb;
        $(function () {
            <%--locktb = new Kkctf.table.lockTableSingle({
                tMain: $('#<%=gvList.ClientID %>').closest("div"),            //table的层
                padWidth: 15,                        //单元格左右的padding的值总和数值
                borWidth: 2,                        //表格左右边框宽度总和值
                subtHeig: 50,                    //表格高度减去多少
                dinamicDiv: $('#dynamicDiv'),      //动态层的高度.表格会根据动态层的显示或隐藏进行表格大小的动态调整(可选)
                autoHeight: true                 //表格窗口是否随着窗口的高度改变自动调整高度(可选)
            });--%>
        });

        function formview() {

            if ($('#dynamicDiv').is(':visible')) {
                $('#dynamicDiv').hide();
            } else {
                $('#dynamicDiv').show();
            }

            locktb.autoHeightFn();
        }
        function sendForm() {
            document.save.submit();
        }
    </script>
</head>
<body class="body-wrap">
    <form runat="server">
        <div class="tabbable work-nav">
            <ul id="myTab" class="nav nav-tabs">
                <li class="active"><a href="admin.php?ac=duty&fileurl=duty" data-toggle="tab">所有任务</a></li>
                <li><a href="admin.php?ac=duty&fileurl=duty&dkey=1" data-toggle="tab">进行中任务</a></li>
                <li><a href="admin.php?ac=duty&fileurl=duty&dkey=2" data-toggle="tab">未完成任务</a></li>
                <li><a href="admin.php?ac=duty&fileurl=duty&dkey=3" data-toggle="tab">己完成任务</a></li>
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
<%--                    <button type="button" class="btn btn-success">新建任务</button>
                    <button type="button" class="btn btn-danger">清理数据</button>
                    <button type="button" id="query_export" class="btn btn-info">导出查询列表</button>--%>
                    <iEAS:ModelToolBar ID="uxToolBar" runat="server" />
                </div>
                <div class="pager_operation">
                    <iEAS:AspNetPager ID="Pager" runat="server" AlwaysShow="true" ShowCustomInfoSection="Left" PrevPageText="上一页" NextPageText="下一页" FirstPageText="首页" LastPageText="尾页"
                        PagingButtonLayoutType="UnorderedList" CustomInfoHTML="<div class='page-info-block'>共<span id='total_records'>176</span>条  <span id='total_page'>%PageSize%</span>条/页 共<span id='current_page'>%PageCount%</span>页</div> "
                        OnPageChanging="Pager_PageChanging" PageSize="2"
                     CurrentPageButtonTextFormatString="{0}"
                     NumericButtonTextFormatString="{0}"
                        PagingButtonSpacing="0">
                             
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
