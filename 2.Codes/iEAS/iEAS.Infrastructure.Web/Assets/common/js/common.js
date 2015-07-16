if (!Array.prototype.map) {
    Array.prototype.map = function (fn, scope) {
        var result = [], ri = 0;
        for (var i = 0, n = this.length; i < n; i++) {
            if (i in this) {
                result[ri++] = fn.call(scope, this[i], i, this);
            }
        }
        return result;
    };
}

/*
*获取当前窗体的大小
*/
var getWindowSize = function () {
    return ["Height", "Width"].map(function (name) {
        return window["inner" + name] ||
          document.compatMode === "CSS1Compat" && document.documentElement["client" + name] || document.body["client" + name]
    });
}

/*
*打开Windows窗口
*/
function openWindow(url, width, height,callback) {

    var iWidth = 500,
        iHeight = 350,
        iTop = 0,
        iLeft = 0,
        name = new Date().getTime(),
        opener;

    if(width){
        iWidth=parseInt(width.replace("px",""));
    }
    if(height){
        iHeight=parseInt(height.replace("px",""));
    }

    iTop=(window.screen.availHeight - 30 - iHeight) / 2;
    iLeft = (window.screen.availWidth - 10 - iWidth) / 2;

    var features = "width="+iWidth+"px";
    features += ",height="+iHeight+"px";
    features += ",top="+iTop+"px";
    features += ",left="+iLeft+"px";
    features += ",toolbar=no,menubar=no,scrollbars=yes, resizable=no,location=no, status=no";
    opener = window.open(url, name, features, false);
    if (callback && typeof callback =="function") {
        callback(opener);
    }
    return false;
}

function parseInt(){
    parseFloat
}






function checkAll(checkBox, ids) {
    if ($(checkBox).attr('checked')) {
		$("[data="+ids+"]").each(function() {
			$(this).attr('checked','checked');
			$(this).parent().parent().addClass('highlight');
		});
	} else {
        $("[data=" + ids + "]").each(function () {
			$(this).removeAttr('checked');
			$(this).parent().parent().removeClass('highlight');
		});
	}
}