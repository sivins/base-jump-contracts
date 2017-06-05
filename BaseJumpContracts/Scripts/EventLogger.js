var events = [];

$(document).ready(function () {

    $('body').on('click', function (e) {
        var d = new Date();
        var time = d.getTime();
        var htmlClass = e.target.className;
        var tagName = e.target.tagName;
        var text = e.target.textContent;
        var event = { "Time": time, "TagName" : tagName, "HtmlClass": htmlClass, "Text" : text };
        events.push(event);
    });

});

$(window).on('unload', function () {
    $.ajax({
        url: "/api/EventLog",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(events)
    });
/*
    function wait(ms) {
        var start = new Date().getTime();
        var end = start;
        while (end < start + ms) {
            end = new Date().getTime();
        }
    }

    //wait(700);
    */
});