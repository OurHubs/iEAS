<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextEditor.ascx.cs" Inherits="iEAS.Infrastructure.Web.Model.Controls.Field.TextEditor" %>
<asp:TextBox ID="txtValue" runat="server" TextMode="MultiLine"></asp:TextBox>
<script type="text/javascript">

    var editor = CKEDITOR.replace("<%=txtValue.ClientID %>");
    CKFinder.setupCKEditor(editor, "/assets/ckfinder/");

</script>