/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here.
	// For complete reference see:
	// http://docs.ckeditor.com/#!/api/CKEDITOR.config

	// The toolbar groups arrangement, optimized for two toolbar rows.

config.filebrowserBrowseUrl = 'ckfinder/ckfinder.html'; //不要写成"~/ckfinder/..."或者"/ckfinder/..." 
config.filebrowserImageBrowseUrl = 'ckfinder/ckfinder.html?Type=Images'; 
config.filebrowserFlashBrowseUrl = 'ckfinder/ckfinder.html?Type=Flash'; 
config.filebrowserUploadUrl = 'ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files'; 
config.filebrowserImageUploadUrl ='ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images'; 
config.filebrowserFlashUploadUrl ='ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'; 
config.filebrowserWindowWidth = '800'; //“浏览服务器”弹出框的size设置 
config.filebrowserWindowHeight = '500'; 
	
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

	// Remove some buttons provided by the standard plugins, which are
	// not needed in the Standard(s) toolbar.
	config.removeButtons = 'Underline,Subscript,Superscript';

	// Set the most common block elements.
	config.format_tags = 'p;h1;h2;h3;pre';

	// Simplify the dialog windows.
	config.removeDialogTabs = 'image:advanced;link:advanced';
};
