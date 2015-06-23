<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OneColumn.ascx.cs" Inherits="iEAS.Infrastructure.Web.Model.Template.Form.OneColumn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <link rel="stylesheet" type="text/css" href="../assets/common/css/style.css" />
    <link rel="stylesheet" type="text/css" href="../assets/formvalidator/themes/default/" />
    <script src="../assets/common/js/jQuery.min.js" type="text/javascript" charset="UTF-8"></script>
    <script src="../assets/formvalidator/formValidator.min.js" type="text/javascript" charset="UTF-8"></script>
    <script src="../assets/formvalidator/formValidatorRegex.js" type="text/javascript" charset="UTF-8"></script>
    <title>企业应用服务平台</title>
</head>
<body class="bodycolor">
    <table width="90%" border="0" align="center" cellpadding="3" cellspacing="0" class="small">
        <tr>
            <td class="Big">
                <img src="../assets/common/images/notify_new.gif" align="middle" alt=""><span class="big3"> 新增<%=ModelContext.Current.Form.Title %></span>&nbsp;&nbsp;&nbsp;&nbsp;
	            <span style="font-size: 12px; float: right; margin-right: 20px;">
                    <a href="ModelQuery.aspx?model=<%=ModelContext.Current.Form.Code %>" style="font-size: 12px;">&lt;&lt;返回列表页</a>
                </span>
            </td>
        </tr>
    </table>
    <form id="form1" runat="server">
        <table class="TableBlock" border="0" width="90%" align="center" style="border-bottom: #4686c6 solid 0px;">
            <asp:Repeater ID="rptForm" runat="server" OnItemDataBound="rptForm_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td nowrap class="TableContent" width="15%">
                            <%# Eval("Title") %>
                            <%# Eval("IsRequired").Equals(true)?"<font title='打*号表示为必填' color='#ff0000'>(*)</font>":""  %>
                        </td>
                        <td class="TableData">
                            <iEAS:ModelFieldContainer ID="ctField" runat="server" FieldCode='<%# Eval("Code") %>'></iEAS:ModelFieldContainer>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr align="center" class="TableControl">
                <td colspan="2" nowrap height="35">
                    <asp:Button ID="btnSave" runat="server" Text="保存信息" OnClick="btnSave_Click" CssClass="BigButton" />
                </td>
            </tr>
        </table>
    </form>
    <script type="text/javascript">
        $(function () {
            $.formValidator.initConfig({
                theme: "default", submitOnce: true, formID: "<%=form1.ClientID%>",
                onError: function (msg) { alert(msg); },
                submitAfterAjaxPrompt: '有数据正在异步验证，请稍等...'
            });

            <%=ModelFieldControl.ValidateScripts %>
        });
    </script>
</body>
</html>

