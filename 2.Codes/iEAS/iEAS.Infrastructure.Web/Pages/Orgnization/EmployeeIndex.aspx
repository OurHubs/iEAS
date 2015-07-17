<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="EmployeeIndex.aspx.cs" Inherits="iEAS.Infrastructure.Web.Pages.Orgnization.EmployeeIndex" %>

<html>
<head>
    <title></title>
</head>
<frameset cols="200px,*" noresize="1" border="0">
    <frame name="left" src="DepartmentTree.aspx" scrolling="no"  frameborder="0" marginwidth="0" marginHeight="0" noresize="1"/>
    <frame name="main" src="EmployeeList.aspx"  scrolling="yes"  frameborder="0" marginwidth="0" marginHeight="0" noresize="1"/>
    <noframes>
        <body>
        <p>对不起，您的浏览器不支持“框架”！</p>
        </body>
    </noframes>
</frameset>
</html>
