<%@ Control Language="C#" AutoEventWireup="true" Inherits="iEAS.Model.UI.UxModelPagedControl" %>
<% Iterator(m=>{ %>
<dl class="clear">
    <dt>
        <div class="titleH1"><span><a href="<%=m.GetDetailUrl() %>" target="_blank"><%=m.GetStr("Title") %></a></span><span class="bg"><%=m.GetStr("Title") %></span></div>
        <p class="des lh22">
           <%=m.GetStr("Content",50) %>
        </p>
        <div class="btnContent">
            更新时间:<%=m.GetStr("UpdateTime","yyyy年MM月dd日") %>
        </div>
    </dt>
</dl>
<%}); %>
<script type="text/C#" runat="server">
    public override string DataSourceCode
    {
        get
        {
            return "News.PagedList";
        }
    }

</script>
