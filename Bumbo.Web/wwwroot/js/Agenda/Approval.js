$(document).ready(function () {
    $('#ApprovalTable').DataTable({
        language: {
            lengthMenu: "Toont _MENU_ onbeschikbaarheden per pagina",
            info: "Toont _START_ tot _END_ van de _TOTAL_ onbeschikbaarheden",
            emptyTable: "Er zijn onbeschikbaarheden om te beoordelen",
            infoEmpty: "Toont 0 tot 0 van de 0 onbeschikbaarheden",
            search: "Zoek",
            infoFiltered: "{Gefilterd van _MAX_ onbeschikbaarheden}",
            paginate: {
                previous: "Vorige",
                next: "Volgende",
            },
        }
    });
});