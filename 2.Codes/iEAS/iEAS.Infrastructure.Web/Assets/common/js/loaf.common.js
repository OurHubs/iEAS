
jQuery.extend(
    {
        
        /// 打开一个ifame弹出层
        openPage: function (sTitle, sWidth, sHeight, sUrl) {          
            $.openPageX("frame1", sTitle, sWidth, sHeight, sUrl);
        },
        //打开一个iframe子层
        openPageChild: function (sTitle, sWidth, sHeight, sUrl) {

            if (sWidth == "") sWidth = 'auto';
            if (sHeight == "") sHeight = 'auto';
            var api = frameElement.api, W = api.opener;
            if (api != null && W != null) {
                W.$.dialog(
              {
                  id: 'frame2',
                  title: sTitle,
                  lock: true,
                  parent: api,
                  width: sWidth,
                  height: sHeight,
                  content: "url:" + sUrl,
              });
            }
        },
        //打开一个iframe孙子层
        openPageGrandson: function (sTitle, sWidth, sHeight, sUrl) {

            if (sWidth == "") sWidth = 'auto';
            if (sHeight == "") sHeight = 'auto';
            var api = frameElement.api, W = api.opener;
            W.$.dialog(
                {
                    id: 'frame3',
                    title: sTitle,
                    lock: true,
                    parent: api,
                    width: sWidth,
                    height: sHeight,
                    content: "url:" + sUrl,
                });
        },

        openPageX: function (x, sTitle, sWidth, sHeight, sUrl) {

            if (sWidth == "") sWidth = 'auto';
            if (sHeight == "") sHeight = 'auto';
            $.dialog({
                id: x,
                lock: true,
                title: sTitle,
                width: sWidth,
                height: sHeight,
                content: "url:" + sUrl
            });
        } ,
        ///打开的页面
        openPager:
            {
            ///被打开页面的api
            api: frameElement.api!=null?frameElement.api:null,
            win: frameElement.api != null && frameElement.api.opener != null ? frameElement.api.opener : null
           }

       
});

