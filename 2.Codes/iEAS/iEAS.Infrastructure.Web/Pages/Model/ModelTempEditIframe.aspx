<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModelTempEditIframe.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Model.ModelTempEditIframe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
       <script src="/Assets/ckeditor/ckeditor.js" type="text/javascript"></script>
</head>
<body>
   <form id="form1" runat="server">
       <asp:TextBox ID="txtTempalte" runat="server" onblur="setEditorValue(this)" TextMode="MultiLine" CssClass="ckeditor"></asp:TextBox>

       
         <script type="text/javascript">

             CKEDITOR.plugins.add('serverctl_insert', {

                 init: function (editor) {
                     //这里是对话框的主体. 定义一个名为'mydialog'的对话框
                     CKEDITOR.dialog.add('serverctl_insert_dialog', function (editor) {
                         var timestamp = Math.round(new Date().getTime() / 1000);
                         var ckeditorPage = 'TempIframe.aspx?timestamp=' + timestamp;
                         return {
                             title: '选择一个服务器控件',
                             minWidth: 700,
                             minHeight: 400,
                             contents: [
                                {
                                    id: 'tab1',
                                    label: 'Label',
                                    title: 'Title',
                                    expand: true,
                                    padding: 0,
                                    elements: [
                                        {
                                            type: "html",
                                            html: "<iframe id='swfuploadPage' width='100%' height='100%' frameborder='no' src='" + ckeditorPage + "'></iframe>",
                                            style: "width:100%;height:380px;padding:0;"
                                        }
                                    ]
                                }
                             ],
                             buttons: [CKEDITOR.dialog.okButton, CKEDITOR.dialog.cancelButton],
                             onOk: function () {
                                 var ctl = document.getElementById('swfuploadPage').contentWindow.document.getElementById('txtName');
                                 editor.insertHtml(ctl.value);
                             },
                             onHide: function () { document.getElementById('swfuploadPage').contentDocument.location.reload(); }
                         };
                     });

                     //插件的逻辑主体再次被封装, new CKEDITOR.dialogCommand('mydialog')就是用来弹出名为'mydialog'的对话框.
                     editor.addCommand('serverctl_insert_cmd', new CKEDITOR.dialogCommand('serverctl_insert_dialog'));

                     //editor.ui.addButton('mybutton', {
                     //    lable: 'FButton',
                     //    title: 'My Button',
                     //    command: 'mycommand'  //通过命令的方式连接
                     //    // toolbar: 'insert'
                     //});

                     //添加上下文菜单项, 
                     if (editor.contextMenu) {
                         editor.addMenuGroup('serverctl_group', 10);
                         editor.addMenuItem('serverctl_insert_menu', {
                             label: '插入服务器控件',
                             command: 'serverctl_insert_cmd',   //通过命令的方式绑定
                             group: 'serverctl_group'
                         });


                     }
                     //为上下文菜单添加监听器, 如果不添加这句, 我们的创建的上下文菜单将无法显示在右键菜单里面. 原理不详,望指点
                     //editor.contextMenu.addListener(function (element) {
                     //    return { 'mymenuitem': CKEDITOR.TRISTATE_OFF };
                     //});

                     editor.contextMenu.addListener(function (startElement, selection, path) {
                         //alert(startElement.getHtml());
                         //alert(startElement.getOuterHtml());
                         //alert(startElement.data("ctlname"));

                         //如果包含data-ctlname 代表是咱们的服务器空间
                         if (startElement.data("ctlname") != "field") {
                             return { 'serverctl_insert_menu': CKEDITOR.TRISTATE_OFF };
                         }
                     });

                 }

             });
            
            

    </script>

       <script type="text/javascript">

           //编辑服务器控件
           CKEDITOR.plugins.add('serverctl_edit', {

               init: function (editor) {
                   //这里是对话框的主体. 定义一个名为'mydialog'的对话框
                   CKEDITOR.dialog.add('serverctl_edit_dialog', function (editor) {
                      // var elment = editor.element;
                      // alert(elment.getOuterHtml());
                       //alert(elment.data("ctlname"));

                       //获取光标所在元素
                       var element = editor.getSelection().getStartElement();
                       //alert(element.getName());
                       var editParam = element.data("code");


                       var timestamp = Math.round(new Date().getTime() / 1000);
                       var ckeditorPage = 'TempIframe.aspx?code='+editParam+'&timestamp=' + timestamp;
                       return {
                           title: '选择一个服务器控件',
                           minWidth: 700,
                           minHeight: 400,
                           contents: [
                              {
                                  id: 'tab1',
                                  label: 'Label',
                                  title: 'Title',
                                  expand: true,
                                  padding: 0,
                                  elements: [
                                      {
                                          type: "html",
                                          html: "<iframe id='swfuploadPage' width='100%' height='100%' frameborder='no' src='" + ckeditorPage + "'></iframe>",
                                          style: "width:100%;height:380px;padding:0;"
                                      }
                                  ]
                              }
                           ],
                           buttons: [CKEDITOR.dialog.okButton, CKEDITOR.dialog.cancelButton],
                           onOk: function () {
                               var ctl = document.getElementById('swfuploadPage').contentWindow.document.getElementById('txtName');
                               editor.insertHtml(ctl.value);
                           },
                           onHide: function () { document.getElementById('swfuploadPage').contentDocument.location.reload(); }
                       };
                   });

                   //插件的逻辑主体再次被封装, new CKEDITOR.dialogCommand('mydialog')就是用来弹出名为'mydialog'的对话框.
                   editor.addCommand('serverctl_edit_cmd', new CKEDITOR.dialogCommand('serverctl_edit_dialog'));

                   //editor.ui.addButton('mybutton', {
                   //    lable: 'FButton',
                   //    title: 'My Button',
                   //    command: 'mycommand'  //通过命令的方式连接
                   //    // toolbar: 'insert'
                   //});

                   //添加上下文菜单项, 
                   if (editor.contextMenu) {
                       editor.addMenuGroup('serverctl_group', 11);
                       editor.addMenuItem('serverctl_edit_menu', {
                           label: '编辑服务器控件',
                           command: 'serverctl_edit_cmd',   //通过命令的方式绑定
                           group: 'serverctl_group'
                       });


                   }
                   //为上下文菜单添加监听器, 如果不添加这句, 我们的创建的上下文菜单将无法显示在右键菜单里面. 原理不详,望指点
                   //editor.contextMenu.addListener(function (element) {
                   //    return { 'mymenuitem': CKEDITOR.TRISTATE_OFF };
                   //});

                   editor.contextMenu.addListener(function (startElement, selection, path) {
                       //alert(startElement.getHtml());
                       //alert(startElement.getOuterHtml());
                       //alert(startElement.data("ctlname"));
                       //如果包含data-ctlname 代表是自定义的服务器空间
                       if (startElement.data("ctlname") == "field") {
                           return { 'serverctl_edit_menu': CKEDITOR.TRISTATE_OFF };
                       }
                   });

               }

           });
           //告诉CKEDITOR我们有定义了一个插件.
           CKEDITOR.replace('txtTempalte', {
               extraPlugins: 'serverctl_edit,serverctl_insert'
           });
        
    </script>
       <asp:HiddenField ID="hfEditCtl" runat="server" />
    </form>
</body>
</html>
