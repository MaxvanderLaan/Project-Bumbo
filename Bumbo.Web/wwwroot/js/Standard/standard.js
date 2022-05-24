$(document).ready(function () {
    var table = $('#StandardTable').DataTable({
        "lengthMenu": [10],
        "bLengthChange": false,
        "columnDefs": [{ "orderable": false, "targets": 4 }],
        "language": {
            info: "Toont _START_ tot _END_ van de _TOTAL_ normeringen",
            emptyTable: "Geen normeringen beschikbaar",
            zeroRecords: "Geen normeringen gevonden met gegeven filter",
            infoEmpty: "Toont 0 tot 0 van de 0 normeringen",
            search: "Zoek:",
            infoFiltered: "{Gefilterd op _MAX_ normeringen}",
            paginate: {
                previous: "Vorige",
                next: "Volgende",
            },
        }
    });

});
