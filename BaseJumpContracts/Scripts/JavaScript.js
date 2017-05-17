$(document).ready(function () {
    // document.cookie = "CookieName=CookieValue;";
    var events = [];
    var counter = 0;

    $('body').on('click', function (e) {
        // Time event happened in milliseconds since 1/1/70
        var d = new Date();
        var time = d.getTime();
        var timeStamp = "BJC" + counter + "timeStamp=" + time  + ";";
        document.cookie = timeStamp;

        //Event type (what event occurred)
        //Class

        counter++
    });
})