$(document).ready(function () {
$.datepicker.setDefaults({
    changeMonth: true,
    changeYear: true
});
$("input[type=datetime]").each(function () {
    $(this).datepicker();
});
});
$.fn.initializeDataTable=function() {
	$(this).dataTable({
		"scrollY": 200,
		"scrollCollapse": true,
		"jQueryUI": true,
		"bDestroy": true
	});
}