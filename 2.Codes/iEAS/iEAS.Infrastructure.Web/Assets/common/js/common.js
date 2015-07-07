function checkAll(checkBox,ids) {
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