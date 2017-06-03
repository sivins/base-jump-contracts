var events = [];

$(document).ready(function () {

    $('body').on('click', function (e) {
        var d = new Date();
        var time = d.getTime();
        var htmlClass = e.target.className;
        var tagName = e.target.tagName;
        var text = e.target.textContent;
        //console.log(e);
        var event = { "Time": time, "TagName" : tagName, "HtmlClass": htmlClass, "Text" : text };
        events.push(event);
        //console.log(events);
    });

});

$(window).on('unload', function () {
    $.ajax({
        url: "/api/EventLog",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(events)
    });

    // Need to give the server a quick moment to process the Ajax POST.
    function wait(ms) {
        var start = new Date().getTime();
        var end = start;
        while (end < start + ms) {
            end = new Date().getTime();
        }
    }

    wait(200);
});