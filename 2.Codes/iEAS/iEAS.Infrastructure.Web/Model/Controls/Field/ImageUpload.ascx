<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageUpload.ascx.cs" Inherits="iEAS.Infrastructure.Web.Model.Controls.Field.ImageUpload" %>
<asp:TextBox ID="txtValue" runat="server" CssClass="BigInput"></asp:TextBox>

<%
      if(Field.IsRequired)
      {
          ValidateScripts.AppendFormat(@"$(""#{0}"").formValidator({{onShow: ""请输入{1}"",onFocus:""请输入{1}"",onCorrect: ""输入正确""}}).inputValidator({{min:1,onError:""请输入{1}""}});", txtValue.ClientID, Field.Title);
      }
  %>
