<%@ Control Language="C#" AutoEventWireup="true" Inherits="iEAS.Model.UI.UxModelControl" %>
<div class="nav">
    <ul class="cu-span" id="nav">
        <li style="margin: 0" class="on"><a href="/" title="<%=SiteConfig.Instance.Title %>"><span>首 页</span></a></li>
        <% Iterator(m =>
           { %>
        <li><a href="<%=GetChannelUrl(m) %>" title="<%=m.GetStr("NAME") %>"><span><%=m.GetStr("NAME") %></span></a></li>
        <%}); %>
    </ul>
</div>
<script type="text/C#" runat="server">
    public override string DataSourceCode
    {
        get { return "Channel.TopMenu"; }
    }


    public string GetChannelUrl(IReadOnlyDictionary<string,object> channel)
    {
        string channelType = channel.GetStr("CHANNEL_TYPE").ToLower();
        string url = String.Empty;
        switch (channelType)
        {
            case "model":
            case "pmodel":
                url = "/channel/" + channel.GetStr("SN");
                break;
            case "node":
                url = "/channel/" + channel.GetStr("URL");
                break;
            case "url":
                url = channel.GetStr("URL");
                break;
        }
        return url; 
    }
    
</script>