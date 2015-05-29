<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaseDataTypeList.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.BaseData.BaseDataTypeList" %>

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
        <div class="form_panel">
               <div class="from_panel_header">
                <span class="title">查询条件</span>
            </div>
               <table class="table_detail">
          
            <tr>
                <th >  机构名称：</th>
                <td class="td_value"  >
                   
                    <asp:TextBox ID="TextBox2" runat="server" Text="一缕晨光"></asp:TextBox>         
                </td>  
                <th>
                    机构名称：
                </th>
                <td >
                   <asp:TextBox ID="TextBox3" runat="server" Text="一缕晨光"></asp:TextBox>         
                </td>     
                 <th>
                    机构名称：
                </th>
                <td >
                   <asp:TextBox ID="TextBox4" runat="server" Text="一缕晨光"></asp:TextBox>         
                </td>   
                     
            </tr>
            <tr>
                 <th >
                    是否中智分支：
                </th>
                <td >
                    <input type="checkbox" name="checkbox3" id="checkbox1" />北京
                    <input type="checkbox" name="checkbox3" id="checkbox2" />上海
                    <input type="checkbox" name="checkbox3" id="checkbox3" />杭州
                    <input type="checkbox" name="checkbox3" id="checkbox4" />贵州
                    <input type="checkbox" name="checkbox3" id="checkbox5" />云南
                </td>
                <th >
                    机构性质：
                </th>
                <td class="td_value" >
                    <select>
                        <option selected="selected">国有业</option>
                        <option>民（私）营</option>
                        <option>外资</option>
                        <option>股份制</option>
                        <option>事业单位</option>
                        <option>其他</option>
                    </select>
                </td>
                 <th >
                    机构名称：
                </th>
                <td class="td_value"  >
                   <asp:TextBox ID="TextBox5" runat="server" Text="一缕晨光"></asp:TextBox>         
                </td>   
            </tr>
                  </table>
               <div class="form_panel_foot form_panel_foot_right">
                   <asp:Button ID="Button1" class="btn_search_submit" runat="server" Text="" />
                   <asp:Button ID="Button2" class="btn_search_clear" runat="server" Text="" />
               </div>
        </div>  
           <ul class="tabList_toolbar">
             <li><a href="#" class="add" >增 加</a> </li>
             <li><a href="#" class="edit">编 辑</a></li>
              <li><a href="#" class="del">删 除</a></li>
             <li><a href="#" class="show">查 看</a></li>
             <li><a href="#" class="set">设 置</a></li>            
             <li><a href="#" class="export">导 出</a></li>
        </ul>
        <table class="tabList"  >
             <tr class="title">
                <td style="width: 5%">
                    <input name="checkAll" class="checkAll" id="checkAll" type="checkbox" value='' />
                </td>
                <td style="width: 20%">
                   <a  id="Sort_TypeID" href="javascript:Sort(this,'TypeID');" class="down" >机构名称</a>  
                </td>
                
                <td style="width: 8%">
                    
                     <a  id="A1" href="javascript:Sort(this,'TypeID');" class="up" >机构负责联系人</a>  
                </td>
                <td style="width: 10%">
                    机构地址
                </td>
                <td style="width: 10%">
                    开户银行名称
                </td>
                <td style="width: 7%">
                    是否中智分支
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
                    上海汉威大厦西区25层
                </td>
                <td>
                    中国银行
                </td>
                <td >
                    是
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
                    上海汉威大厦西区25层
                </td>
                <td>
                    中国银行
                </td>
                <td >
                    是
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
                    上海汉威大厦西区25层
                </td>
                <td>
                    中国银行
                </td>
                <td >
                    是
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