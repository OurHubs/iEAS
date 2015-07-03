<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModelTempEdit.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Model.ModelTempEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="/Assets/ckeditor/ckeditor.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
       <asp:TextBox ID="txtValue" runat="server" onblur="setEditorValue(this)" TextMode="MultiLine" CssClass="ckeditor"></asp:TextBox>

       <%-- <textarea name="editor1" id="editor1">&lt;p&gt;Initial editor content.&lt;/p&gt;</textarea>--%>

        <script type="text/javascript">

            CKEDITOR.plugins.add('myplugin', {
                init: function (editor) {
                    //这里是对话框的主体. 定义一个名为'mydialog'的对话框
                    CKEDITOR.dialog.add('mydialog', function (editor) {
                        return {
                            title: '第一个对话框',
                            minWidth: 390,
                            minHeight: 130,
                            contents: [
                               {
                                   id: 'tab1',
                                   label: 'Label',
                                   title: 'Title',
                                   expand: true,
                                   padding: 0,
                                   elements: [
                                       {
                                           type: 'html',
                                           html: '<p>This is some sample HTML content.</p>'
                                       },
                                       {
                                           type: 'textarea',
                                           id: 'textareaId',
                                           rows: 4,
                                           cols: 40
                                       }
                                   ]
                               }

                            ],
                            buttons: [ CKEDITOR.dialog.okButton, CKEDITOR.dialog.cancelButton ],
                            onOk: function() {
                                // "this" is now a CKEDITOR.dialog object.
                                // Accessing dialog elements:
                                var textareaObj = this.getContentElement('tab1', 'textareaId');
                                //alert( "You have entered: " + textareaObj.getValue() );
                                //var now = new Date();
                                //editor.insertHtml('现在时间： <em>' + now.toString() + '</em>');

                                editor.insertHtml('你输入内容： <em>' + textareaObj.getValue() + '</em>');
                                

                            }

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
            CKEDITOR.replace('txtValue', {
                extraPlugins: 'myplugin'
            });

    </script>
    </form>
</body>
</html>
