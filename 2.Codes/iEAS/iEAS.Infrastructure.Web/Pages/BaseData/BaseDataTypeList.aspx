<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaseDataTypeList.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.BaseData.BaseDataTypeList" %>

<%@ Register src="../../Controls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>框架管理系统</title>
     <link href="../../Assets/common/css/Admin.css" rel="stylesheet" />
     <script src="../../Assets/common/js/jquery.min.js" type="text/javascript"></script>
     <script src="../../Assets/common/js/table.js"></script>
     <script type="text/javascript">
         $(function () {
             InitSort(); //初始化排序
         });
    </script>
</head>
<body>
    <form id="form1" runat="server">
      <div class="container">         
           <ul class="tabList_toolbar">
             <li><a href="BaseDataTypeEdit.aspx" class="add" >增 加</a> </li>
             <li><a href="#" class="del">删 除</a></li>
        </ul>
          <asp:ListView ID="lvQuery" runat="server" DataSourceID="odsQuery">
              <LayoutTemplate>
                  <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
              </LayoutTemplate>
              <ItemTemplate>
                  <li><%# Container.DataItem %></li>
              </ItemTemplate>
          </asp:ListView>
                            <asp:DataPager ID="dpList" runat="server" PageSize="10" PagedControlID="lvQuery">
                      <Fields>
                          <asp:NumericPagerField />
                      </Fields>
                  </asp:DataPager>
          <iEAS:ObjectDataSource ID="odsQuery" runat="server"></iEAS:ObjectDataSource>
           <uc1:Pager ID="Pager1" runat="server"  PagedControlID="lvQuery" />
        <table class="tabList"  >
             <tr class="title">
                <td style="width: 5%">
                    <input name="checkAll" class="checkAll" id="checkAll" type="checkbox" value='' />
                </td>
                <td style="width: 20%">
                   <a  id="Sort_TypeID" href="javascript:Sort(this,'TypeID');" class="down" >类型名称</a>  
                </td>
                
                <td style="width: 8%">
                     <a  id="A1" href="javascript:Sort(this,'TypeID');" class="up" >类型编码</a>  
                </td>
                <td style="width: 10%">
                    操作
                </td>
            </tr>
             <tr>
                <td >
                    <input type="checkbox" name="IDS" />
                </td>
                <td >
                    <a href="agencyDetailInfo.htm">中智上海经济技术合作公司外企服务分公司</a>
                </td>
                <td >
                    张三
                </td>
                <td >
                    <a href="BaseDataItemList.aspx">查看数据项</a>|编辑|删除
                </td>
            </tr>
           <tr>
                <td >
                    <input type="checkbox" name="IDS" />
                </td>
                <td >
                    <a href="agencyDetailInfo.htm">中智上海经济技术合作公司外企服务分公司</a>
                </td>
                <td >
                    张三
                </td>
                <td >
                    <a href="BaseDataItemList.aspx">查看数据项</a>|编辑|删除
                </td>
            </tr>
            <tr>
                <td >
                    <input type="checkbox" name="IDS" />
                </td>
                <td >
                    <a href="agencyDetailInfo.htm">中智上海经济技术合作公司外企服务分公司</a>
                </td>
                <td >
                    张三
                </td>
                <td >
                   <a href="BaseDataItemList.aspx">查看数据项</a>|编辑|删除
                </td>
            </tr>
            <tr>
                <td >
                    <input type="checkbox" name="IDS" />
                </td>
                <td >
                    <a href="agencyDetailInfo.htm">中智上海经济技术合作公司外企服务分公司</a>
                </td>
                <td >
                    张三
                </td>
                <td >
                    <a href="BaseDataItemList.aspx">查看数据项</a>|编辑|删除
                </td>
            </tr>
        </table>

        <div class="fenye">
            <div id="aspnetpageDiv">     
<%--                <webthink:aspnetpager ID="pager"  CssClass="anpager" runat="server"  UrlPaging="false"
                 ShowPageIndexBox="Never" PageIndexBoxType="DropDownList"    
                 TextBeforePageIndexBox="转到: " HorizontalAlign="right" PageSize="15" 
                 OnPageChanged="pager_PageChanged" EnableTheming="true" 
                 FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页">
                </webthink:aspnetpager>--%>
           </div>
        </div>
      </div>
    <!--用于辅助列表排序的 -->
    <asp:HiddenField ID="hfSort" runat="server" />
    </form>
</body>
</html>