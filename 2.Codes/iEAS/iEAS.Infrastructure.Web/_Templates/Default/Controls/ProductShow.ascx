<%@ Control Language="C#" AutoEventWireup="true"%>
<script type="text/javascript">

    var hoverEffect = true;
    var numberOfScreens = 3;
    var blockName = new Array();
    blockName[1] = 'Most used';

    var bookmark = new Array();
    bookmark[0] = new Array();

    <% for (int i = 0; i <= 12; i++)
       {%>
    bookmark[0][<%=i%>] = {
        'title': '<%=SiteConfig.Instance.Title %>',
        'url': '<%=SiteConfig.Instance.Url %>',
        'thumb': '<%=i+1 %>.png'
    };
    <%}%>
    bookmark[0][8] = {
        'title':'国内发展最快的OA软件,4年拥有5万家用户,现以每天500安装量增长中...',
        'url':'',
        'thumb':''
    };
    $(function () {
        var num = numberOfScreens;

        for (var i = 1; i <= num; i++) {
            $('#name' + i).html(blockName[i]);
        }
        if (hoverEffect) {
            for (i = 1; i <= num; i++) {
                $('<style>#wrapper' + i + ' div:hover{border: 2px #fff solid;box-shadow: 0px 0px 10px #fff;margin-left:4px;margin-top:4px;}</style>').appendTo('head');
            };
        };

        var j = 0;
        for (j = 0; j <=0 ; j++) {
            for (i =0; i <= 12; i++) {
                var title = bookmark[j][i]['title'];
                var url = bookmark[j][i]['url'];
                var thumb = bookmark[j][i]['thumb'];
                if (url == '') {
                    if (thumb == '') {
                        $('#thumb' + (j + 1) + '-' + (i + 1)).html('<span class="title">' + title + '</span>');
                    }
                    else {
                        $('#thumb' + (j + 1) + '-' + (i + 1)).html('<img src="/_Templates/Default/Assets/Images/' + thumb + '" />');
                    }
                } else {
                    if (thumb == '') {
                        $('#thumb' + (j + 1) + '-' + (i + 1)).html('<a href="' + url + '" target="_blank"><span class="title">' + title + '</span></a>');
                    }
                    else {
                        $('#thumb' + (j + 1) + '-' + (i + 1)).html('<a href="' + url + '" target="_blank"><img src="/_Templates/Default/Assets/Images/' + thumb + '" /></a>');
                    }
                }
            };
        };
    });
</script>
<div class="m-banner">
    <div id="wrapper2">
    </div>
    <div id="wrapper1">
        <div id="thumb1-1"></div>
        <div id="thumb1-2"></div>
        <div id="thumb1-3"></div>
        <div id="thumb1-4"></div>
        <div id="thumb1-5"></div>
        <div id="thumb1-6"></div>
        <div id="thumb1-7"></div>
        <div id="thumb1-8"></div>
        <span id="thumb1-9" title="国内发展最快的OA软件,4年拥有5万家用户,现以每天500安装量增长中..."></span>
        <div id="thumb1-10"></div>
        <div id="thumb1-11"></div>
        <div id="thumb1-12"></div>
        <div id="thumb1-13"></div>
    </div>
</div>
