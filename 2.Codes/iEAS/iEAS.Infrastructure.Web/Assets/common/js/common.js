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