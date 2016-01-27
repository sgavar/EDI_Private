$(document).ready(function () {
    
    //initialize all the url params
    var urlVars = getURLParams();

    //General
    $(".btnSearch, .btnMenuSearch").button();

    $(document).ajaxStart(function () {
        $("#ajaxMenuSearchWait").show();
    });

    $(document).ajaxStop(function () {
        $("#ajaxMenuSearchWait").hide();
    });

    $(".btnMenuSearch, .aStudy, .aSeries").live("click", function () {
        $("#ajaxMenuSearchWait").show();
    });

    $("#aAdvancedSearch").live("click", function () {
        $("#divSearchResults").hide();
    });

    // Home
    $(".slideSeries").live("click", function () {
        var url = {
            "searchTerm": $(this).children("div").find(".seriesName").text(),
            "rdSearchType": "Exact",
            "seriesID": $(this).attr("id")
        };
        window.location.href = buildURL(url);
    });

    // Inventory List
    $("#aSortSeriesList").live("click", function () {
        $(this).text($(this).text() == "Sort Descending" ? "Sort Ascending" : "Sort Descending");

        $("#tblInventoryList").tablesorter(
        {
            sortList: [[0, 0]]
        });

        $("#tblInventoryList thead").find("th:eq(0)").trigger("sort");
        return false;
    });

    $(".aStudyListCount").live("click", function () {
        var divStudyList = $(this).parents("td:eq(0)").find(".studyList");
        divStudyList.toggle();

        var spanIcon = $(this).find("span");
        spanIcon.toggleClass("ui-icon-circle-plus ui-icon-circle-minus");
    });

    $("#aInventoryStudyAll").live("click", function () {
        $(this).text($(this).text() == "Expand All" ? "Collapse All" : "Expand All");

        if ($(this).text() == "Collapse All") {
            $(".studyList").show();
            $(".aStudyListCount span").addClass("ui-icon-circle-minus");
            $(".aStudyListCount span").removeClass("ui-icon-circle-plus");
        }
        else {
            $(".studyList").hide();
            $(".aStudyListCount span").addClass("ui-icon-circle-plus").removeClass("ui-icon-circle-minus");
        }
    });

    $(".aSeriesList").live("click", function () {
        var url = {
            "searchTerm": $(this).text(),
            "rdSearchType": "Exact",
            "seriesID": $(this).attr("id")
        };
        window.location.href = buildURL(url);
    });

    $(".aSeriesStudyList, .aSeriesFollowupList").live("click", function () {
        var studyType = $(this).attr("class") == "aSeriesFollowupList" ? "followup" : "study";
        var url = {
            "txtMenuSearchTerm": urlVars["txtMenuSearchTerm"],
            "txtSearchTerm": urlVars["txtSearchTerm"],
            "seriesID": $(this).parents("td:eq(0)").children("div:eq(0)").find("a:eq(0)").attr("id"),
            "studyID": $(this).attr("id"),
            "searchTerm": $(this).text(),
            "rdSearchType": "Exact",
            "studyType": studyType
        };
        window.location.href = buildURL(url);
    });

    // Search
    if (urlVars["seriesID"] != "") {
        if (urlVars["studyVar"] == "true") {
            GetDetail("studyVar", urlVars["seriesID"], urlVars["studyID"], urlVars["searchTerm"], urlVars["rdSearchType"], urlVars["studyType"]);
        } else if (urlVars["studyID"] > 0) {
            GetDetail("study", urlVars["seriesID"], urlVars["studyID"], urlVars["searchTerm"], urlVars["rdSearchType"], urlVars["studyType"]);
        } else if (urlVars["seriesVar"] == "true") {
            GetDetail("seriesVar", urlVars["seriesID"], urlVars["studyID"], urlVars["searchTerm"], urlVars["rdSearchType"], urlVars["studyType"]);
        } else {
            GetDetail("series", urlVars["seriesID"], 0, urlVars["searchTerm"], urlVars["rdSearchType"], urlVars["studyType"]);
        }
        $("#ajaxMenuSearchWait").show();
    }

    $("#aSortSeries").live("click", function () {
        $(this).text($(this).text() == "Sort Descending" ? "Sort Ascending" : "Sort Descending");

        $("#tblSearchResults").tablesorter(
        {
            sortList: [[0, 0]]
        });

        $("#tblSearchResults thead").find("th:eq(0)").trigger("sort");
        return false;
    });

    // Search data
    $("input[name='txtSearchTerm']").keypress(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });

    var lastStudyVarLine = $(".studyVar").parents("tr").find(".studyVarLine:last");
    lastStudyVarLine.css({ "display": "none" });

    var lastStudyVar = $(".studyVar").parents("tr").find(".studyVar:last");
    lastStudyVar.css({ "padding-bottom": "5px" });

    if ($("input[name='txtSearchTerm']").val() == "") {
        $("#divSearchResults").css({ "display": "none" });
    }

    $(".aStudyVar").live("click", function () {
        var divStudyVar = $(this).parents("td:eq(0)").find(".studyVar");
        divStudyVar.toggle();

        var spanIcon = $(this).find("span");
        spanIcon.toggleClass("ui-icon-circle-plus ui-icon-circle-minus");
    });

    $("#aStudyVarAll").live("click", function () {
        $(this).text($(this).text() == "Expand All" ? "Collapse All" : "Expand All");

        if ($(this).text() == "Collapse All") {
            $(".studyVar").show();
            $(".aStudyVar span").addClass("ui-icon-circle-minus").removeClass("ui-icon-circle-plus");
        }
        else {
            $(".studyVar").hide();
            $(".aStudyVar span").addClass("ui-icon-circle-plus").removeClass("ui-icon-circle-minus");
        }
    });

    // Get detail
    function GetDetail(source, seriesID, studyID, searchTerm, searchType, studyType) {
        $.get("Detail/" + seriesID + "/" + studyID + "/" + studyType, function (data) {
            $("#ajaxMenuSearchWait").show();
            $("input[value='" + searchType + "']").attr("checked", true);
            $("#divSearchTips").hide();
            $("#divSearch").hide();
            $("#divDetail").empty().append(data);
            $("#ajaxMenuSearchWait").hide();
            if (urlVars["currentSearch"] != "") {
                $("#back_div").show();
            }
            $("#divDetail").show();

            if (studyID > 0) {
                $("#tabs").tabs({ active: 1 });
            }
            if(urlVars["studyVar"] == "true") {
                $("#ajaxMenuSearchWait").show();
                SearchStudyVarData("search", studyID, urlVars["studyVarTerm"], urlVars["studyVarType"], urlVars["studyType"], 1, $("#hdStudyVarLastPage").val(), "variableName", "ASC", true);
                $("#accStudy").accordion({ active: 2 });
                return false;
            }
            if (urlVars["seriesVar"] == "true") {
                $("#ajaxMenuSearchWait").show();
                SearchSeriesVarData(seriesID, urlVars["seriesVarTerm"], urlVars["seriesVarType"], 1, $("#hdStudyVarLastPage").val(), "variableName", "ASC", true);
                $("#accStudy").accordion({ active: 2 });
            }
            return false;
        });
    }

    $(".aStudyVariable").live("click", function () {
        $("#ajaxMenuSearchWait").show();
        var url = urlVars;
        url["seriesID"] = $(this).parents("td").find(".aSeries").attr("id");
        url["studyID"] = $(this).parents("div").find(".aStudy").attr("id");
        url["studyVar"] = "true";
        url["studyVarTerm"] = url["currentSearch"];
        url["seriesVar"] = "false";
        url["seriesVarTerm"] = "";
        url["seriesVarType"] = "";
        window.location.href = buildURL(url);
    });

    //Series

    $("#aBack").live("click", function () {
        $("#divSearchTips, #divDetail, #divSearch").hide();
        $("#ajaxMenuSearchWait").show();
        var url = {
            txtMenuSearchTerm: urlVars["txtMenuSearchTerm"],
            txtSearchTerm: urlVars["txtSearchTerm"],
            rdSearchType: urlVars["rdSearchType"]
        }
        window.location.href = buildURL(url);
    });

    $("#cbSeriesVarAll").live("click", function () {
        if ($(this).is(":checked")) {
            $(".cbSeriesVar").prop("checked", true);
            $("#aSeriesVarCSV").prop("disabled", false).css({ "opacity": "1.0", "pointer-events": "auto", "cursor": "pointer" });

            $("input[name='submit']").hover(function () {
                $(this).css("color", "#e17009");
            }, function () {
                $(this).css("color", "#2e6e9e");
            });
        }
        else {
            $(".cbSeriesVar").prop("checked", false);
            $("#aSeriesVarCSV").prop("disabled", true).css({ "opacity": "0.5", "pointer-events": "none", "cursor": "default" });
        }
    });

    $(".cbSeriesVar").live("click", function () {
        if ($(".cbSeriesVar:checked").length > 0) {
            $("#aSeriesVarCSV").prop("disabled", false).css({ "opacity": "1.0", "pointer-events": "auto", "cursor": "pointer" });

            $("input[name='submit']").hover(function () {
                $(this).css("color", "#e17009");
            }, function () {
                $(this).css("color", "#2e6e9e");
            });
        }
        else {
            $("#aSeriesVarCSV").prop("disabled", true).css({ "opacity": "0.5", "pointer-events": "none", "cursor": "default" });
        }
    });


    $(".aSeriesVarValue").live("click", function () {
        var divSeriesVarValue = $(this).parents("td:eq(0)").find(".divSeriesVarValue");
        divSeriesVarValue.toggle();

        var spanIcon = $(this).find("span");
        spanIcon.toggleClass("ui-icon-circle-plus ui-icon-circle-minus");
    });

    $("#aSeriesVarValueAll").live("click", function () {
        $(this).text($(this).text() == "Expand All Value Labels" ? "Collapse All Value Labels" : "Expand All Value Labels");

        if ($(this).text() == "Collapse All Value Labels") {
            $(".divSeriesVarValue").show();
            $(".aSeriesVarValue span").addClass("ui-icon-circle-minus").removeClass("ui-icon-circle-plus");
        }
        else {
            $(".divSeriesVarValue").hide();
            $(".aSeriesVarValue span").addClass("ui-icon-circle-plus").removeClass("ui-icon-circle-minus");
        }
    });

    var page = 1;
    var lastPage = 1;
    var sortColumn = "variableName";
    var sortDirection = "ASC";

    $("#aSearchData").on('click', function(){
        $("#ajaxMenuSearchWait").show();
    });

    $("#aSearchSeriesVar").live("click", function () {
        var url = urlVars;
        url["seriesVar"] = "true";
        url["seriesVarTerm"] = $("input[name='txtSeriesVarSearchTerm']").val();
        url["seriesVarType"] = $("input[name='rdSeriesVarSearchType']:checked").val();
        url["studyVar"] = "";
        url["studyID"] = "";
        url["studyVarTerm"] = "";
        url["studyVarType"] = "";
        window.location.href = buildURL(url);
    });

    // Search series variable data
    $("#aSeriesVarFirst, #aSeriesVarPrev, #aSeriesVarNext, #aSeriesVarLast, #aSeriesVarName, #aSeriesVarLabel, #aSeriesVarExtDef, #aSeriesVarDetail, #aSeriesVarStudy, #aSeriesVarFile").live("click", function () {
        var seriesID = $("#hdSeriesID").val();
        var searchTerm = $("input[name='txtSeriesVarSearchTerm']").val();
        var searchType = $("input[name='rdSeriesVarSearchType']:checked").val();
        var newSearch = false;

        lastPage = $("#hdSeriesVarLastPage").val();

        switch ($(this).attr("id")) {
            case "aSearchSeriesVar": case "aSeriesVarFirst":
                page = 1;
                sortColumn = "variableName";
                sortDirection = "ASC";
                newSearch = true;
                break;
            case "aSeriesVarPrev":
                page = page - 1;
                break;
            case "aSeriesVarNext":
                page = page + 1;
                break;
            case "aSeriesVarLast":
                page = lastPage;
                break;
            case "aSeriesVarName": case "aSeriesVarLabel": case "aSeriesVarExtDef": case "aSeriesVarDetail": case "aSeriesVarStudy": case "aSeriesVarFile":
                page = 1;

                if ($(this).parent("th:eq(0)").hasClass("headerSortDown")) {
                    sortDirection = "DESC";
                    $(this).parent("th:eq(0)").removeClass("header headerSortDown").addClass("headerSortUp");
                    $(this).children("span:eq(0)").removeClass("ui-icon-triangle-2-n-s ui-icon-triangle-1-n").addClass("ui-icon-triangle-1-s");
                }
                else if ($(this).parent("th:eq(0)").hasClass("headerSortUp")) {
                    sortDirection = "ASC";
                    $(this).parent("th:eq(0)").removeClass("header headerSortUp").addClass("headerSortDown");
                    $(this).children("span:eq(0)").removeClass("ui-icon-triangle-2-n-s ui-icon-triangle-1-s").addClass("ui-icon-triangle-1-n");
                }
                else if ($(this).parent("th:eq(0)").hasClass("header")) {
                    sortDirection = "ASC";
                    $(this).parent("th:eq(0)").removeClass("header headerSortUp").addClass("headerSortDown");
                    $(this).children("span:eq(0)").removeClass("ui-icon-triangle-2-n-s ui-icon-triangle-1-s").addClass("ui-icon-triangle-1-n");
                }
                break;
        }

        switch ($(this).attr("id")) {
            case "aSeriesVarName":
                sortColumn = "variableName";
                break;
            case "aSeriesVarLabel":
                sortColumn = "variableLabel";
                break;
            case "aSeriesVarExtDef":
                sortColumn = "variableExtendedDefn";
                break;
            case "aSeriesVarDetail":
                sortColumn = "variableDetail";
                break;
            case "aSeriesVarStudy":
                sortColumn = "studyName";
                break;
            case "aSeriesVarFile":
                sortColumn = "fileList";
                break;
        }

        if (searchTerm == "") {
            $("#divSearchSeriesVarMsg").show();
            $("#divSeriesVarSearchResults").hide();
            $("input[name='txtSeriesVarSearchTerm']").focus();
        }
        else {
            $("#divSearchSeriesVarMsg").hide();
            SearchSeriesVarData(seriesID, searchTerm, searchType, page, lastPage, sortColumn, sortDirection, newSearch);
        }
    });

    function SearchSeriesVarData(seriesID, searchTerm, searchType, page, lastPage, sortColumn, sortDirection, newSearch) {
        var cbSeriesVarAll = $("#cbSeriesVarAll").is(":checked");
        var seriesVarValAll = $("#aSeriesVarValueAll").text();

        $.get("SeriesVariable/GetSeriesVariable/" + seriesID + "/" + searchTerm + "/" + searchType + "/" + page + "/" + sortColumn + "/" + sortDirection, function (data) {
            $("#divSeriesVarSearchResults").show();
            $("#divSeriesVarSearchResults").empty().append(data);
            $("#aSeriesVarCSV").prop("disabled", true).css({ "opacity": "0.5", "pointer-events": "none", "cursor": "default" });
            lastPage = $("#hdSeriesVarLastPage").val();

            if (page == 1 && lastPage != 1) {
                $("#iconSeriesVarNext, #iconSeriesVarLast").prop("disabled", false).removeClass("ui-state-disabled");
                $("#iconSeriesVarFirst, #iconSeriesVarPrev").prop("disabled", true).addClass("ui-state-disabled");
            }
            else {
                if (page == 1 && lastPage == 1) {
                    $("#iconSeriesVarFirst, #iconSeriesVarPrev, #iconSeriesVarNext, #iconSeriesVarLast").prop("disabled", true).addClass("ui-state-disabled");
                }
                else if (page == lastPage) {
                    $("#iconSeriesVarNext, #iconSeriesVarLast").prop("disabled", true).addClass("ui-state-disabled");
                    $("#iconSeriesVarFirst, #iconSeriesVarPrev").prop("disabled", false).removeClass("ui-state-disabled");
                }
                else {
                    $("#iconSeriesVarFirst, #iconSeriesVarPrev, #iconSeriesVarNext, #iconSeriesVarLast").prop("disabled", false).removeClass("ui-state-disabled");
                }
            }

            if (newSearch == true) {
                $("#tblSeriesVarSearchResults thead th").addClass("header");
                $("#tblSeriesVarSearchResults thead th:eq(1)").removeClass("header").addClass("headerSortDown");
                $("input[name='txtSeriesVarSearchTerm']").val(urlVars["seriesVarTerm"]);
                $("input[name='rdSeriesVarSearchType'][value='" + urlVars["seriesVarType"] + "']").prop("checked", true);
            }
            else {
                if (cbSeriesVarAll == true) {
                    $("#cbSeriesVarAll, .cbSeriesVar").prop("checked", true);
                }
                else {
                    $("#cbSeriesVarAll, .cbSeriesVar").prop("checked", false);
                }

                if (seriesVarValAll == "Collapse All Value Labels") {
                    $("#aSeriesVarValueAll").text(seriesVarValAll);
                    $(".divSeriesVarValue").show();
                    $(".aSeriesVarValue span").addClass("ui-icon-circle-minus").removeClass("ui-icon-circle-plus");
                }
                else {
                    $(".divSeriesVarValue").hide();
                    $(".aSeriesVarValue span").addClass("ui-icon-circle-plus").removeClass("ui-icon-circle-minus");
                }

                $("#tblSeriesVarSearchResults thead th").removeClass("headerSortUp headerSortDown").addClass("header");
                $("#tblSeriesVarSearchResults thead span").removeClass("ui-icon-triangle-1-n ui-icon-triangle-1-s").addClass("ui-icon-triangle-2-n-s");

                var headerID;

                switch (sortColumn) {
                    case "variableName":
                        headerID = "#aSeriesVarName";
                        break;
                    case "variableLabel":
                        headerID = "#aSeriesVarLabel";
                        break;
                    case "variableExtendedDefn":
                        headerID = "#aSeriesVarExtDef";
                        break;
                    case "variableDetail":
                        headerID = "#aSeriesVarDetail";
                        break;
                    case "studyName":
                        headerID = "#aSeriesVarStudy";
                        break;
                    case "fileList":
                        headerID = "#aSeriesVarFile";
                        break;
                }

                if (sortDirection == "ASC") {
                    $(headerID).parent("th:eq(0)").removeClass("header").addClass("headerSortDown");
                    $(headerID).children("span:eq(0)").removeClass("ui-icon-triangle-2-n-s").addClass("ui-icon-triangle-1-n");
                }
                else {
                    $(headerID).parent("th:eq(0)").removeClass("header").addClass("headerSortUp");
                    $(headerID).children("span:eq(0)").removeClass("ui-icon-triangle-2-n-s").addClass("ui-icon-triangle-1-s");
                }
            }
        });
    }

    $(".seriesVarFile").live("click", function () {
        $("#accSeries").accordion({ active: 3 });
    });

    $(".aSeriesStudy").live("click", function () {
        $("#ajaxMenuSearchWait").show();
        var url = urlVars;
        url["studyID"] = $(this).attr("id");
        url["studyType"] = "study";
        url["studyVar"] = "";
        url["seriesVar"] = "";
        window.location.href = buildURL(url);
    });

    $(".aSeriesFollowup").live("click", function () {
        $("#ajaxMenuSearchWait").show();
        var url = urlVars;
        url["studyID"] = $(this).attr("id");
        url["studyType"] = "followup";
        url["studyVar"] = "";
        url["seriesVar"] = "";
        window.location.href = buildURL(url);
    });

    $(".aSeriesVarStudy").live("click", function () {
        var url = urlVars;
        url["studyID"] = $(this).attr("id");
        url["studyVar"] = "true";
        url["studyVarTerm"] = url["seriesVarTerm"];
        url["studyVarType"] = url["seriesVarType"];
        url["seriesVar"] = "false";
        url["seriesVarTerm"] = "";
        url["seriesVarType"] = "";
        window.location.href = buildURL(url);
        //GetStudyDetail("seriesVar", studyID, "study");
    });

    $(".aSeriesFileStudy").live("click", function () {
        var studyID = $(this).attr("id");
        GetStudyDetail("seriesFile", studyID, "study");
    });

    function GetStudyDetail(source, studyID, studyType) {
        var seriesID = $("#hdSeriesID").val();

        $.get("StudyDetail/" + seriesID + "/" + studyID + "/" + studyType, function (data) {
            $("#tabs").tabs({ active: 1 });
            $("#divStudyDetail").show();
            $("#divStudyDetail").empty().append(data);
            //if (source == "seriesVar") {
            if (urlVars["studyVar"] == 'true') {
                $("#accStudy").accordion({ active: 2 });
            } else if (source == "seriesFile") {
                $("#accStudy").accordion({ active: 3 });
            }
        });
    }

    // Study
    $("#cbStudyVarAll").live("click", function () {
        if ($(this).is(":checked")) {
            $(".cbStudyVar").prop("checked", true);
            $("#aStudyVarCSV").prop("disabled", false).css({ "opacity": "1.0", "pointer-events": "auto", "cursor": "pointer" });

            $("input[name='submit']").hover(function () {
                $(this).css("color", "#e17009");
            }, function () {
                $(this).css("color", "#2e6e9e");
            });
        }
        else {
            $(".cbStudyVar").prop("checked", false);
            $("#aStudyVarCSV").prop("disabled", true).css({ "opacity": "0.5", "pointer-events": "none", "cursor": "default" });
        }
    });

    $(".cbStudyVar").live("click", function () {
        if ($(".cbStudyVar:checked").length > 0) {
            $("#aStudyVarCSV").prop("disabled", false).css({ "opacity": "1.0", "pointer-events": "auto", "cursor": "pointer" });

            $("input[name='submit']").hover(function () {
                $(this).css("color", "#e17009");
            }, function () {
                $(this).css("color", "#2e6e9e");
            });
        }
        else {
            $("#aStudyVarCSV").prop("disabled", true).css({ "opacity": "0.5", "pointer-events": "none", "cursor": "default" });
        }
    });

    $(".aStudyVarValue").live("click", function () {
        var divStudyVarValue = $(this).parents("td:eq(0)").find(".divStudyVarValue");
        divStudyVarValue.toggle();

        var spanIcon = $(this).find("span");
        spanIcon.toggleClass("ui-icon-circle-plus ui-icon-circle-minus");
    });

    $("#aStudyVarValueAll").live("click", function () {
        $(this).text($(this).text() == "Expand All Value Labels" ? "Collapse All Value Labels" : "Expand All Value Labels");

        if ($(this).text() == "Collapse All Value Labels") {
            $(".divStudyVarValue").show();
            $(".aStudyVarValue span").addClass("ui-icon-circle-minus").removeClass("ui-icon-circle-plus");
        }
        else {
            $(".divStudyVarValue").hide();
            $(".aStudyVarValue span").addClass("ui-icon-circle-plus").removeClass("ui-icon-circle-minus");
        }
    });

    $(".aStudyQuestionnaire").live("click", function () {
        var divStudyQuestionnaire = $(this).parents("td:eq(0)").find(".divStudyQuestionnaire");
        divStudyQuestionnaire.toggle();

        var spanIcon = $(this).find("span");
        spanIcon.toggleClass("ui-icon-circle-plus ui-icon-circle-minus");
    });

    $("#aStudyQuestionnaireAll").live("click", function () {
        $(this).text($(this).text() == "Expand All" ? "Collapse All" : "Expand All");

        if ($(this).text() == "Collapse All") {
            $(".divStudyQuestionnaire").show();
            $(".aStudyQuestionnaire span").addClass("ui-icon-circle-minus").removeClass("ui-icon-circle-plus");
        }
        else {
            $(".divStudyQuestionnaire").hide();
            $(".aStudyQuestionnaire span").addClass("ui-icon-circle-plus").removeClass("ui-icon-circle-minus");
        }
    });

    $("#aSearchStudyVar").live("click", function () {
        var url = urlVars;
        url["studyVar"] = true;
        url["studyVarTerm"] = $("input[name='txtStudyVarSearchTerm']").val();
        url["studyVarType"] = $("input[name='rdStudyVarSearchType']:checked").val();
        window.location.href = buildURL(url);
    });

    // Search study variable data
    $("#aStudyVarFirst, #aStudyVarPrev, #aStudyVarNext, #aStudyVarLast, #aStudyVarName, #aStudyVarLabel, #aStudyVarExtDef, #aStudyVarDetail, #aStudyVarFile").live("click", function () {
        var studyID = $("#hdStudyID").val();
        var searchTerm = $("input[name='txtStudyVarSearchTerm']").val();
        var searchType = $("input[name='rdStudyVarSearchType']:checked").val();
        var studyType = $("#hdStudyType").val();
        var newSearch = false;

        lastPage = $("#hdStudyVarLastPage").val();

        switch ($(this).attr("id")) {
            case "aStudyVarFirst":
                page = 1;
                sortColumn = "variableName";
                sortDirection = "ASC";
                newSearch = true;
                break;
            case "aStudyVarPrev":
                page = page - 1;
                break;
            case "aStudyVarNext":
                page = page + 1;
                break;
            case "aStudyVarLast":
                page = lastPage;
                break;
            case "aStudyVarName": case "aStudyVarLabel": case "aStudyVarExtDef": case "aStudyVarDetail": case "aStudyVarFile":
                page = 1;

                if ($(this).parent("th:eq(0)").hasClass("headerSortDown")) {
                    sortDirection = "DESC";
                    $(this).parent("th:eq(0)").removeClass("header headerSortDown").addClass("headerSortUp");
                    $(this).children("span:eq(0)").removeClass("ui-icon-triangle-2-n-s ui-icon-triangle-1-n").addClass("ui-icon-triangle-1-s");
                }
                else if ($(this).parent("th:eq(0)").hasClass("headerSortUp")) {
                    sortDirection = "ASC";
                    $(this).parent("th:eq(0)").removeClass("header headerSortUp").addClass("headerSortDown");
                    $(this).children("span:eq(0)").removeClass("ui-icon-triangle-2-n-s ui-icon-triangle-1-s").addClass("ui-icon-triangle-1-n");
                }
                else if ($(this).parent("th:eq(0)").hasClass("header")) {
                    sortDirection = "ASC";
                    $(this).parent("th:eq(0)").removeClass("header headerSortUp").addClass("headerSortDown");
                    $(this).children("span:eq(0)").removeClass("ui-icon-triangle-2-n-s ui-icon-triangle-1-s").addClass("ui-icon-triangle-1-n");
                }
                break;
        }

        switch ($(this).attr("id")) {
            case "aStudyVarName":
                sortColumn = "variableName";
                break;
            case "aStudyVarLabel":
                sortColumn = "variableLabel";
                break;
            case "aStudyVarExtDef":
                sortColumn = "variableExtendedDefn";
                break;
            case "aStudyVarDetail":
                sortColumn = "variableDetail";
                break;
            case "aStudyVarFile":
                sortColumn = "fileList";
                break;
        }

        if (searchTerm == "") {
            $("#divSearchStudyVarMsg").show();
            $("#divStudyVarSearchResults").hide();
            $("input[name='txtStudyVarSearchTerm']").focus();
        }
        else {
            $("#divSearchStudyVarMsg").hide();
            SearchStudyVarData("detail", studyID, searchTerm, searchType, studyType, page, lastPage, sortColumn, sortDirection, newSearch);
        }
    });

    function SearchStudyVarData(source, studyID, searchTerm, searchType, studyType, page, lastPage, sortColumn, sortDirection, newSearch) {
        var cbStudyVarAll = $("#cbStudyVarAll").is(":checked");
        var StudyVarValAll = $("#aStudyVarValueAll").text();

        if (searchTerm.length == 0) {
            searchTerm = "null";
        }

        $.get("StudyVariable/GetStudyVariable/" + studyID + "/" + searchTerm + "/" + searchType + "/" + studyType + "/" + page + "/" + sortColumn + "/" + sortDirection, function (data) {
            $("input[name='txtStudyVarSearchTerm']").blur();
            $("#divStudyVarSearchResults").show();
            $("#divStudyVarSearchResults").empty().append(data);

            lastPage = $("#hdStudyVarLastPage").val();

            $("#aStudyVarCSV").prop("disabled", true).css({ "opacity": "0.5", "pointer-events": "none", "cursor": "default" });

            if (page == 1 && lastPage != 1) {
                $("#iconStudyVarNext, #iconStudyVarLast").prop("disabled", false).removeClass("ui-state-disabled");
                $("#iconStudyVarFirst, #iconStudyVarPrev").prop("disabled", true).addClass("ui-state-disabled");
            }
            else {
                if (page == 1 && lastPage == 1) {
                    $("#iconStudyVarFirst, #iconStudyVarPrev, #iconStudyVarNext, #iconStudyVarLast").prop("disabled", true).addClass("ui-state-disabled");
                }
                else if (page == lastPage) {
                    $("#iconStudyVarNext, #iconStudyVarLast").prop("disabled", true).addClass("ui-state-disabled");
                    $("#iconStudyVarFirst, #iconStudyVarPrev").prop("disabled", false).removeClass("ui-state-disabled");
                }
                else {
                    $("#iconStudyVarFirst, #iconStudyVarPrev, #iconStudyVarNext, #iconStudyVarLast").prop("disabled", false).removeClass("ui-state-disabled");
                }
            }

            if (newSearch == true) {
                $("#tblStudyVarSearchResults thead th").addClass("header");
                $("#tblStudyVarSearchResults thead th:eq(1)").removeClass("header").addClass("headerSortDown");
            }
            else {
                if (cbStudyVarAll == true) {
                    $("#cbStudyVarAll, .cbStudyVar").prop("checked", true);
                }
                else {
                    $("#cbStudyVarAll, .cbStudyVar").prop("checked", false);
                }

                if (StudyVarValAll == "Collapse All Value Labels") {
                    $("#aStudyVarValueAll").text(StudyVarValAll);
                    $(".divStudyVarValue").show();
                    $(".aStudyVarValue span").addClass("ui-icon-circle-minus").removeClass("ui-icon-circle-plus");
                }
                else {
                    $(".divStudyVarValue").hide();
                    $(".aStudyVarValue span").addClass("ui-icon-circle-plus").removeClass("ui-icon-circle-minus");
                }

                $("#tblStudyVarSearchResults thead th").removeClass("headerSortUp headerSortDown").addClass("header");
                $("#tblStudyVarSearchResults thead span").removeClass("ui-icon-triangle-1-n ui-icon-triangle-1-s").addClass("ui-icon-triangle-2-n-s");

                var headerID;

                switch (sortColumn) {
                    case "variableName":
                        headerID = "#aStudyVarName";
                        break;
                    case "variableLabel":
                        headerID = "#aStudyVarLabel";
                        break;
                    case "variableExtendedDefn":
                        headerID = "#aStudyVarExtDef";
                        break;
                    case "variableDetail":
                        headerID = "#aStudyVarDetail";
                        break;
                    case "fileList":
                        headerID = "#aStudyVarFile";
                        break;
                }

                if (sortDirection == "ASC") {
                    $(headerID).parent("th:eq(0)").removeClass("header").addClass("headerSortDown");
                    $(headerID).children("span:eq(0)").removeClass("ui-icon-triangle-2-n-s").addClass("ui-icon-triangle-1-n");
                }
                else {
                    $(headerID).parent("th:eq(0)").removeClass("header").addClass("headerSortUp");
                    $(headerID).children("span:eq(0)").removeClass("ui-icon-triangle-2-n-s").addClass("ui-icon-triangle-1-s");
                }
            }

            if (searchTerm != "null") {
                $("input[name='txtStudyVarSearchTerm']").val(searchTerm);
            }

            $("input[name='rdStudyVarSearchType'][value='" + searchType + "']").attr("checked", "checked");
            
            if (urlVars["studyVar"] == true) {
                $("#accStudy").accordion({ active: 2 });
            }
        });
    }

    $(".studyVarFile").live("click", function () {
        $("#accStudy").accordion({ active: 3 });
    });

    $("#aSortQuestionnaire").live("click", function () {
        $(this).text($(this).text() == "Sort Descending" ? "Sort Ascending" : "Sort Descending");

        $("#tblStudyQuestionnaire")
            .tablesorter(
            {
                sortList: [[0, 0]]
            })
            .tablesorterPager({
                container: $("#pagerStudyQuestionnaire")
            });

        $("#tblStudyQuestionnaire thead").find("th:eq(0)").trigger("sort");
        return false;
    });

    $(".aStudySeries").live("click", function () {
        var seriesID = $(this).attr("id");
        $("#tabs").tabs({ active: 0 });
    });
});

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function getURLParams() {
    var param_names = ["txtMenuSearchTerm", "txtSearchTerm", "searchTerm", "rdSearchType", "seriesID", "studyID", "studyType", "seriesVar", "seriesVarTerm", "seriesVarType", "studyVar", "studyVarTerm", "studyVarType"];
    var params = {};
    $.each(param_names, function (i, v) {
        params[v] = getParameterByName(v);
    });
    if (params["studyID"] == "") params["studyID"] = 0;
    if (params["studyType"] == "") params["studyType"] = "study";
    if (params['rdSearchType'] == "") params["rdSearchType"] = "And";
    if (params["seriesVarType"] == "") params["seriesVarType"] = params["rdSearchType"];
    if (params["studyVarType"] == "") params["studyVarType"] = params["rdSearchType"];
    params["currentSearch"] = params["txtSearchTerm"] == "" ? params["txtMenuSearchTerm"] : params["txtSearchTerm"];
    return params;
}

function buildURL(params) {
    params_for_url = [];
    $.each(params, function (i, v) {
        params_for_url.push(encodeURIComponent(i) + "=" + encodeURIComponent(v));
    });
    return "Search?" + params_for_url.join("&");
}