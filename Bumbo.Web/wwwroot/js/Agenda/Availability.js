$(document).ready(function () {
    $('#AvailabilityTable').DataTable({
        language: {
            lengthMenu: "Toont _MENU_ onbeschikbaarheden per pagina",
            zeroRecords: "Geen onbeschikbaarheden gevonden met gegeven filter",
            info: "Toont _START_ tot _END_ van de _TOTAL_ onbeschikbaarheden",
            emptyTable: "Er zijn geen aangegeven onbeschikbaarheden",
            infoEmpty: "Toont 0 tot 0 van de 0 onbeschikbaarheden",
            search: "Zoek",
            infoFiltered: "{Gefilterd op _MAX_ onbeschikbaarheden}",
            paginate: {
                previous: "Vorige",
                next: "Volgende",
            },
        }
    });
});

function DeleteAvailability(employeeId, availabilityId) {
    document.getElementById("deleteEmployeeAvailabilityId").value = employeeId;
    document.getElementById("deleteAvailabilityId").value = availabilityId;
    $('#availabilityModalDelete').modal('show').find('.modal-title');
}