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
        $.ajax({
            type: "GET",
            url: '/Agenda/GetSchedule/',
            data: {
                id: info.event.id,
            },
            success: function (data) {
                switch (data.department.name) {
                case 0:
                    document.getElementById("detailsDepartment").innerHTML = "Kassa";
                    break;
                case 1:
                        document.getElementById("detailsDepartment").innerHTML = "Vers";
                    break;
                case 2:
                        document.getElementById("detailsDepartment").innerHTML = "Vakkenvullen";
                    break;
                default:
                }

                var startDate = new Date(data.startDate);
                document.getElementById("detailsStartDate").innerHTML = (
                    startDate.getDate() + "-"
                    + (startDate.getMonth() + 1) + "-"
                    + startDate.getFullYear() + " "
                    + ('0' + startDate.getHours()).slice(-2) + ":"
                    + ('0' + startDate.getMinutes()).slice(-2)
                );

                var endDate = new Date(data.endDate);
                document.getElementById("detailsEndDate").innerHTML = (
                    endDate.getDate() + "-"
                    + (endDate.getMonth() + 1) + "-"
                    + endDate.getFullYear() + " "
                    + ('0' + endDate.getHours()).slice(-2) + ":"
                    + ('0' + endDate.getMinutes()).slice(-2)
                    );
            },
            error: function () {
                alert('Error! Deze dienst kan niet gevonden worden.');
            }
        });
        $('#modalDetails').modal('show').find('.modal-title');
    },

    events: function (fetchInfo, successCallback, failureCallback) {
        $.ajax({
            type: "GET",
            url: '/Agenda/GetEmployeeEvents/',
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

function DeleteAvailability(employeeId, availabilityId) {
    document.getElementById("deleteEmployeeAvailabilityId").value = employeeId;
    document.getElementById("deleteAvailabilityId").value = availabilityId;
    $('#availabilityModalDelete').modal('show').find('.modal-title');
}