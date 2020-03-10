
$(document).ready(function () {
    $("#submit").click(function (e) {
        var data = $("#venue").val() == null ? "" : $("#venue").val();
        populateData(data);
    });
    function populateData(search) {
        $.ajax({
            type: "get",
            url: "/Event/_eventPartial",
            data: { 'venue': search },
            success: function (result, status, xhr) {
                $("#eventSearchDiv").html(result);
            },
            error: function (xhr, status, error) {
                // do something
            }
        });
    }
    populateData("");
});