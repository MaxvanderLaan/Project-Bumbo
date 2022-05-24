$(document).ready(function () {
    $('#branchTable').DataTable({
        "lengthMenu": [10],
        "bLengthChange": false,
        "columnDefs": [{ "orderable": false, "targets": 7 }],

        "language": {
            info: "Toont _START_ tot _END_ van de _TOTAL_ branch(es)",
            emptyTable: "Geen branches beschikbaar",
            zeroRecords: "Geen branches gevonden met gegeven filter",
            infoEmpty: "Toont 0 tot 0 van de 0 branch(es)",
            search: "Zoek:",
            infoFiltered: "{ Gefilterd op _MAX_ branch(es) }",
            paginate: {
                previous: "Vorige",
                next: "Volgende",
            },
        }
    })
});

