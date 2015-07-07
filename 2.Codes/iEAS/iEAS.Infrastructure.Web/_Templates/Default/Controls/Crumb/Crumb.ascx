<%@ Control Language="C#" AutoEventWireup="true" Inherits="iEAS.Model.UI.UxModelControl" %>
<div class="crumbs">所在位置：<a href="/">首页</a><span> ></span><% Record(m =>{
           string[] names = m.GetStr("FULL_NAME").Trim('/').Split('/');
           string[] ids = m.GetStr("FULL_PATH").Trim('/').Split('/');
           for (int i = 0; i < ids.Length; i++) { 
           %><a href="/Channel/<%=ids[i] %>"><%=names[i] %></a><span> > </span><%}
       }); %></div>
<script type="text/C#" runat="server">
    public override string DataSourceCode
    {
        get
        {
            return "Channel.CurrentMenu";
        }
    }
</script>