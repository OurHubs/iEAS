<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesptopNew.aspx.cs" Inherits="iEAS.Infrastructure.Web.DesptopNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link rel="stylesheet" href="//apps.bdimg.com/libs/jqueryui/1.10.4/css/jquery-ui.min.css" /> 
    <script src="//apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="//apps.bdimg.com/libs/jqueryui/1.10.4/jquery-ui.min.js"></script>
    
   

 <style>
  body {    min-width: 520px;  }
  .column {    width: 300px;    float: left;    padding-bottom: 100px;  }
  .columnbig{ width: 500px;    float: left;    padding-bottom: 100px; }
  .portlet {    margin: 0 1em 1em 0;    padding: 3px;  }
  .portlet-header {padding: 0.2em 0.3em; margin-bottom: 0.5em;position: relative; font-size:16px; }
  .portlet-toggle {    position: absolute;    top: 50%;    right: 0;    margin-top: -8px;  }
  .portlet-content {    padding: 0.4em;  }
  .portlet-placeholder {    border: 1px dotted black;    margin: 0 1em 1em 0;    height: 50px;  }
  .portlet ul{ list-style:none;margin:0px; padding:0px;}
  .portlet ul li{ list-style:none; font-weight:normal;}
  .portlet ul li a{ text-decoration:none; color:#3e7ab9;}
   .portlet ul li a:hover{ text-decoration:underline; color:#3e7ab9; }

  /*background:#ccc url(images/ui-bg_highlight-soft_75_cccccc_1x100.png) 50% 50% repeat-x*/

  </style>

    <script>
        $(function () {
            $(".column").sortable({
                connectWith: ".column",
                handle: ".portlet-header",
                cancel: ".portlet-toggle",
                placeholder: "portlet-placeholder ui-corner-all",
                //start: function (event, ui) { alert(ui.item.attr("id")) },
                stop: function (event, ui) { GetPortletIDS(); }
            });
            $(".column").sortable({
                connectWith: ".columnbig",
                handle: ".portlet-header",
                cancel: ".portlet-toggle",
                placeholder: "portlet-placeholder ui-corner-all",
                stop: function (event, ui) { GetPortletIDS(); }
            });
            $(".columnbig").sortable({
                connectWith: ".column",
                handle: ".portlet-header",
                cancel: ".portlet-toggle",
                placeholder: "portlet-placeholder ui-corner-all",
                stop: function (event, ui) { GetPortletIDS(); }
            });


            $(".portlet")
               .addClass("ui-widget ui-widget-content ui-helper-clearfix")
             // .addClass("ui-widget ui-widget-content ui-helper-clearfix  ui-corner-all")
              .find(".portlet-header")
                .addClass("ui-widget-header")
                //.addClass("ui-widget-header ui-corner-all")
                .prepend("<span class='ui-icon ui-icon-minusthick portlet-toggle'></span>");

            $(".portlet-toggle").click(function () {
                var icon = $(this);
                icon.toggleClass("ui-icon-minusthick ui-icon-plusthick");
                icon.closest(".portlet").find(".portlet-content").toggle();
            });
        });

        //获取列的所有ID，从上到下
        function GetPortletIDS() {
            //获取右边portlet
            var right_ids = $("div.column  div.portlet").map(function (p) {
                return $(this).attr("id");
            }).get().join(',');

            //获取左边portlet
            var left_ids = $("div.columnbig  div.portlet").map(function (p) {
                return $(this).attr("id");
            }).get().join(',');


            $.ajax({
                type: "POST",
                contentType: "application/json;charset=utf-8",
                url: "DesptopNew.aspx/UpdateUserDesptopUC",
                data: "{leftCodes:'" + left_ids + "',rightCodes:'" + right_ids + "'}",           
                dataType: "json",
                success: function (result) {                 
                    //alert(result.d);                 
                },
                error:function(msg){
                   // alert(msg);
                }
            });
        }
  </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="columnbig">
            <asp:PlaceHolder ID="phColumnbig" runat="server"></asp:PlaceHolder>
        </div>

        <div class="column">
            <asp:PlaceHolder ID="phColumn" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
