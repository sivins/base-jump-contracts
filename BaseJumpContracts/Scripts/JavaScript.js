var events = [];

$(document).ready(function () {

    $('body').on('click', function (e) {
        var d = new Date();
        var time = d.getTime();
        var eventType = "click";
        var htmlClass = this.className;
        var event = { "TimeStamp": time, "EventType": eventType, "HtmlClass": htmlClass };
        events.push(event);
        console.log(events);
    });

});

$(window).on('unload', function () {
    for (var i=0, len = events.length; i < len; i++) {
        //.map() to make faster
        //var event = JSON.stringify(events[i]);
        //events[i] = event;
    }
    console.log(events);
    $.ajax({
        url: "/api/EventLog",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(events)
    });

    function wait(ms) {
        var start = new Date().getTime();
        var end = start;
        while (end < start + ms) {
            end = new Date().getTime();
        }
    }

    wait(100);
});