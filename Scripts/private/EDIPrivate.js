// Private JS file -- TBD

$(document).ready(function () {

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