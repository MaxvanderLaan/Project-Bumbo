$(document).ready(function () {
    var functionTable = $('#FunctionTable').DataTable({
        "lengthMenu": [10],
        "bLengthChange": false,
        "columnDefs": [{ "orderable": false, "targets": 2 }],

        "language": {
            info: "Toont _START_ tot _END_ van de _TOTAL_ functie(s)",
            emptyTable: "Geen functies beschikbaar",
            zeroRecords: "Geen functies gevonden met gegeven filter",
            infoEmpty: "Toont 0 tot 0 van de 0 functie(s)",
            search: "Zoek:",
            infoFiltered: "{ Gefilterd op _MAX_ functie(s) }",
            paginate: {
                previous: "Vorige",
                next: "Volgende",
            },
        }
    });

    var departmentTable = $('#DepartmentTable').DataTable({
        "lengthMenu": [10],
        "bLengthChange": false,

        "language": {
            info: "Toont _START_ tot _END_ van de _TOTAL_ afdeling(en)",
            emptyTable: "Geen afdelingen beschikbaar",
            zeroRecords: "Geen afdelingen gevonden met gegeven filter",
            infoEmpty: "Toont 0 tot 0 van de 0 afdeling(en)",
            search: "Zoek:",
            infoFiltered: "{ Gefilterd op _MAX_ afdeling(en) }",
            paginate: {
                previous: "Vorige",
                next: "Volgende",
            },
        }
    });

});

