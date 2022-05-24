$(document).ready(function () {
    $('#EmployeeTable').DataTable({
        language: {
            lengthMenu: "Toont _MENU_ werknemers per pagina",
            zeroRecords: "Geen werknemers gevonden met gegeven filter",
            info: "Toont _START_ tot _END_ van de _TOTAL_ werknemers",
            emptyTable: "Geen werknemers beschikbaar",
            infoEmpty: "Toont 0 tot 0 van de 0 werknemers",
            search: "Zoek:",
            infoFiltered: "{Gefilterd op _MAX_ werknemers}",
            paginate: {
                previous: "Vorige",
                next: "Volgende",
            },
        },
        aoColumnDefs: [
            {
                bSortable: false,
                aTargets: [-1]
            }
        ]
    });
});