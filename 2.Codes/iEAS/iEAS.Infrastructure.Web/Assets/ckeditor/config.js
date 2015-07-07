/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here.
	// For complete reference see:
	// http://docs.ckeditor.com/#!/api/CKEDITOR.config

	// The toolbar groups arrangement, optimized for two toolbar rows.
	config.toolbarGroups = [
		{ name: 'clipboard',   groups: [ 'clipboard', 'undo' ] },
		{ name: 'editing',     groups: [ 'find', 'selection', 'spellchecker' ] },
		{ name: 'links' },
		{ name: 'insert' },
		{ name: 'forms' },
		{ name: 'tools' },
		{ name: 'document',	   groups: [ 'mode', 'document', 'doctools' ] },
		{ name: 'others' },
		'/',
		{ name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ] },
		{ name: 'paragraph',   groups: [ 'list', 'indent', 'blocks', 'align', 'bidi' ] },
		{ name: 'styles' },
		{ name: 'colors' },
		{ name: 'about' }
	];

	config.language = 'zh-cn'; //中文
	config.uiColor = '#54ADD8'; //编辑器颜色
	config.font_names = '宋体;楷体_GB2312;新宋体;黑体;隶书;幼圆;微软雅黑;Arial;Comic Sans MS;Courier New;Tahoma;Times New Roman;Verdana';
	config.toolbar_Full =
    [
        ['Source', '-', 'Preview', '-', 'Templates'],
        ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Print', 'SpellChecker', 'Scayt'],
        ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
        ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'],
        '/',
        ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
        ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote', 'CreateDiv'],
        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
        ['Link', 'Unlink', 'Anchor'],
          ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'],
        '/',
        ['Styles', 'Format', 'Font', 'FontSize'],
        ['TextColor', 'BGColor'],
        ['Maximize', 'ShowBlocks', '-', 'About']
    ];

	config.toolbar_Basic =
    [
        ['Bold', 'Italic', '-', 'NumberedList', 'BulletedList', '-', 'Link', 'Unlink', '-', 'About']
    ];

	//config.width = 771; //宽度

	//config.height = 260; //高度

    //如果需要使用ckfinder上传功能必须添下列代码
	config.filebrowserBrowseUrl = location.hash + '/assets/ckfinder/ckfinder.html';
	config.filebrowserImageBrowseUrl = location.hash + '/assets/ckfinder/ckfinder.html?Type=Images';
	config.filebrowserFlashBrowseUrl = location.hash + '/assets/ckfinder/ckfinder.html?Type=Flash';
	config.filebrowserUploadUrl = location.hash + '/assets/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&amp;type=Files';
	config.filebrowserImageUploadUrl = location.hash + '/assets/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&amp;type=Images';
	config.filebrowserFlashUploadUrl = location.hash + '/assets/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&amp;type=Flash';


	// Remove some buttons provided by the standard plugins, which are
	// not needed in the Standard(s) toolbar.
	config.removeButtons = 'Underline,Subscript,Superscript';

	// Set the most common block elements.
	config.format_tags = 'p;h1;h2;h3;pre';

    //禁止过滤服务器标签
	//config.allowedContent = 'True';
	config.allowedContent = true;
	// Simplify the dialog windows.
	config.removeDialogTabs = 'image:advanced;link:advanced';
};
