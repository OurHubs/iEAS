//缩略图
jQuery.fn.LoadImage=function(scaling,width,height,loadpic){
    if(loadpic==null)loadpic="../images/msg_img/loading.gif";
return this.each(function(){
   var t=$(this);
   var src=$(this).attr("src")
   var img=new Image();
   img.src=src;
   //自动缩放图片
   var autoScaling=function(){
    if(scaling){
     if(img.width>0 && img.height>0){ 
           if(img.width/img.height>=width/height){ 
               if(img.width>width){ 
                   t.width(width); 
                   t.height((img.height*width)/img.width); 
               }else{ 
                   t.width(img.width); 
                   t.height(img.height); 
               } 
           } 
           else{ 
               if(img.height>height){ 
                   t.height(height); 
                   t.width((img.width*height)/img.height); 
               }else{ 
                   t.width(img.width); 
                   t.height(img.height); 
               } 
           } 
       } 
    } 
   }
   //处理ff下会自动读取缓存图片
   if(img.complete){
    autoScaling();
      return;
   }
   $(this).attr("src","");
   var loading=$("<img alt=\"加载中...\" title=\"图片加载中...\" src=\""+loadpic+"\" />");
  
   t.hide();
   t.after(loading);
   $(img).load(function(){
    autoScaling();
    loading.remove();
    t.attr("src",this.src);
    t.show();
	//$('.photo_prev a,.photo_next a').height($('#big-pic img').height());
   });
  });
}
$(function(){
	$(".downSelect").each(function(i){
		var navSub = $("#msgNav"),msgNavContent = $("#msgNavContent");
		$(this).bind("mouseenter",function(){
			msgNavContent.html($(this).find(".textContent").html());
			//alert();
			var offset =$(this).offset();
				if(navSub.css("display") == "none"){
					navSub.css({"position":"absolute","z-index":"100",left:offset.left,top:offset.top+$(this).height()+2}).show();
				}
		}).bind("mouseleave",function(){
			navSub.hide();
		});
		navSub.bind("mouseenter",function(){
			navSub.show();
		}).bind("mouseleave",function(){
			navSub.hide();
		});
		
	})
})