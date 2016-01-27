$(document).ready(function () {
    $(".tooltip").tooltip();

    // Adjust accordion styling for IE 7
    if ($.browser.msie && ($.browser.version < 8.0 || document.documentMode < 8.0)) {
        $(".ui-accordion .ui-accordion-header .ui-accordion-header-icon").css({ "display": "none" });
    }
    else {
        $(".ui-accordion .ui-accordion-header, .ui-button").css({ "position": "relative" });
    }


    $("input[name='submit']").hover(function () {
        $(this).css("color", "#e17009");
    }, function () {
        $(this).css("color", "#2e6e9e");
    });

    $("input[name='txtStudyVarSearchTerm']").keypress(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });
});