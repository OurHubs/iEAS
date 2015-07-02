<%@ Control Language="C#" AutoEventWireup="true" Inherits="iEAS.Model.UI.ModelUxListControl" %>

<ul>
    <%Iterator(m =>
  {
    %>
    <li><%=m.GetStr("Name","{0:f2}") %></li>
    <li><%=m.GetStr("Name","{0:f2}") %></li>
    <li><%=m.GetStr("Name","{0:f2}") %></li>
    <%
  });
    %>
</ul>
