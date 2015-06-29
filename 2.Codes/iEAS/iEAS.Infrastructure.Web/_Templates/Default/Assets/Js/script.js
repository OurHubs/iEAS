/* 
(c) 2011 Lubomir Krupa, CC BY-ND 3.0
*/

$(document).ready(function(){
	var num = numberOfScreens;

	for(var i=1;i<=num;i++){
		$('#name'+i).html(blockName[i]);
	}

	
	if(hoverEffect){
		for(i=1;i<=num;i++){
			$('<style>#wrapper'+i+' div:hover{border: 2px #fff solid;box-shadow: 0px 0px 10px #fff;margin-left:4px;margin-top:4px;}</style>').appendTo('head');
		};
	};
	
	var j=0;
	for (j=0; j <= (num-1); j++) {		
	    for (i = 0; i <= 15; i++) {

			var title = bookmark[j][i]['title'];
			var url = bookmark[j][i]['url'];
			var thumb = bookmark[j][i]['thumb'];
			if(url==''){
				if(thumb==''){
					$('#thumb'+(j+1)+'-'+(i+1)).html('<span class="title">'+title+'</span>');
				}
				else{
					$('#thumb'+(j+1)+'-'+(i+1)).html('<img src="thumbs/'+thumb+'" />');
				}
			}else{
				if(thumb==''){
					$('#thumb'+(j+1)+'-'+(i+1)).html('<a href="'+url+'" target="_blank"><span class="title">'+title+'</span></a>');
				}
				else{
					$('#thumb'+(j+1)+'-'+(i+1)).html('<a href="'+url+'" target="_blank"><img src="thumbs/'+thumb+'" /></a>');
				}
			}
		};
	};
});

