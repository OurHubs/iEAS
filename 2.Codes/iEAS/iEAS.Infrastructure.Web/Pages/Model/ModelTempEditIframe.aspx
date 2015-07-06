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

            CKEDITOR.plugins.add('myplugin', {

                init: function (editor) {
                    //这里是对话框的主体. 定义一个名为'mydialog'的对话框
                    CKEDITOR.dialog.add('mydialog', function (editor) {
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
                    editor.addCommand('mycommand', new CKEDITOR.dialogCommand('mydialog'));

                    editor.ui.addButton('mybutton', {
                        lable: 'FButton',
                        title: 'My Button',
                        command: 'mycommand'  //通过命令的方式连接
                        // toolbar: 'insert'
                    });

                    //添加上下文菜单项, 
                    if (editor.contextMenu) {
                        editor.addMenuGroup('mymenugroup', 10);
                        editor.addMenuItem('mymenuitem', {
                            label: '插入服务器标签',
                            command: 'mycommand',   //通过命令的方式绑定
                            group: 'mymenugroup'
                        });
                    }
                    //为上下文菜单添加监听器, 如果不添加这句, 我们的创建的上下文菜单将无法显示在右键菜单里面. 原理不详,望指点
                    editor.contextMenu.addListener(function (element) {
                        return { 'mymenuitem': CKEDITOR.TRISTATE_OFF };
                    });
                }

            });
            //告诉CKEDITOR我们有定义了一个插件.
            CKEDITOR.replace('txtTempalte', {
                extraPlugins: 'myplugin'
            });
            //CKEDITOR.replace('textarea_id', { allowedContent: true });
    </script>
    </form>
</body>
</html>
