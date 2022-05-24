let calendarElement = document.getElementById("calendarManager");
let calendar = new FullCalendar.Calendar(calendarElement, {
    timeZone: 'CET',
    firstDay: 1,
    initialView: 'timeGridWeek',
    height: 500,
    locale: 'nl',
    allDaySlot: false,
    headerToolbar: {
        left: 'prev,next',
        center: 'title',
        right: 'today'
    },
    buttonText: {
        today: 'Vandaag',
    },
    events: function (fetchInfo, successCallback, failureCallback) {
        $.ajax({
            type: "GET",
            url: '/Agenda/GetEvents/',
            success: function (data) {
                events = [];
                data.forEach(e => {
                    events.push(e);
                });
                successCallback(events);
            },
            error: function () {
                alert('Error! Diensten laden is niet gelukt.');
            }
        });
    },
});

calendar.render();