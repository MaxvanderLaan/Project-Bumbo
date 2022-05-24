$(document).ready(function () {
    $('#RemunerationTable').DataTable({
        "bFilter": false,
        "lengthMenu": [10],
        "bLengthChange": false,
        "columnDefs": [{ "orderable": false, "targets": 7 }],

        "language": {
            info: "Toont _START_ tot _END_ van de _TOTAL_ verloning(en)",
            emptyTable: "Geen verloningen beschikbaar",
            zeroRecords: "Geen verloningen gevonden met gegeven filter",
            infoEmpty: "Toont 0 tot 0 van de 0 verloning(en)",
            search: "Zoek:",
            infoFiltered: "{ Gefilterd op _MAX_ verloning(en) }",
            paginate: {
                previous: "Vorige",
                next: "Volgende",
            },
        }
    });
});

$(document).ready(function () {
    $('input:checkbox').click(function () {
        $('input:checkbox').not(this).prop('checked', false);
    });
});

