$(document).ready(function () {
    $(".btnSeriesVarSearch").button();
    $(".btnBackToSearchResults").button();

    $("#tabs").tabs();

    $("#accSeries").accordion({
        collapsible: true,
        heightStyle: "content"
    });

    // Adjust accordion styling for IE 7
    if ($.browser.msie && ($.browser.version < 8.0 || document.documentMode < 8.0)) {
        $(".ui-accordion .ui-accordion-header .ui-accordion-header-icon").css({ "display": "none" });
    }
    else {
        $(".ui-accordion .ui-accordion-header, .ui-button").css({ "position": "relative" });
    }

    $("#tblSeriesFile").tablesorter(
        {
            sortList: [[0, 0], [1, 0], [2, 0], [3, 0], [4, 0], [5, 0]]
        }
    );

    $("input[name='submit']").hover(function () {
        $(this).css("color", "#e17009");
    }, function () {
        $(this).css("color", "#2e6e9e");
    });

    $("input[name='txtSeriesVarSearchTerm']").keypress(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });
});