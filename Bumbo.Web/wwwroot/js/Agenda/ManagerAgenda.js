let calendarElement = document.getElementById("calendar");
let events = [];

let calendar = new FullCalendar.Calendar(calendarElement, {
    timeZone: 'CET',
    initialView: 'dayGridMonth',
    firstDay: 1,
    locale: 'nl',
    height: 650,
    allDaySlot: false,

    headerToolbar: {
        left: 'prev,next today',
        center: 'title',
        right: 'dayGridMonth timeGridWeek'
    },
    buttonText: {
        today: 'Vandaag',
        week: 'Week',
        month: 'Maand',
    },
    eventClick: function(info) {
        window.location.href = '/Agenda/EditSchedule/' + info.event.id;
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

let changed = false;
function onChangeEvent() {
    if (!changed) {
        document.getElementById('refreshId').disabled = false;
    }
    changed = true;
}

function getForecast() {
    var select = document.getElementById('prognoseSelect');
    var option = select.options[select.selectedIndex];
    
    $.ajax({
            type: "GET",
            url: '/Agenda/GetRequiredHoursRemaining/',
            data:{
                id: option.value,
            },
            success: function (data) {
                document.getElementById('stockId').value = data[0];
                document.getElementById('cashierId').value = data[1];
                document.getElementById('freshId').value = data[2];
            },
            error: function () {
                alert('Error! Prognose niet gevonden!');
            }
        }
    )
}
