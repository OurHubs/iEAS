﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextEditor.ascx.cs" Inherits="iEAS.Infrastructure.Web.Model.Controls.Field.TextEditor" %>
<asp:TextBox ID="txtValue" runat="server" onblur="setEditorValue(this)" TextMode="MultiLine" CssClass="ckeditor"></asp:TextBox>