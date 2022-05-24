$(document).ready(function () {
    
    var table = $('#ForecastTable').DataTable({
        pageLength: 5,
        lengthChange: false,
        language: {
            info: "Toont _START_ tot _END_ van de _TOTAL_ prognoses",
            emptyTable: "Geen prognoses beschikbaar",
            zeroRecords: "Geen prognoses gevonden met gegeven filter",
            infoEmpty: "Toont 0 tot 0 van de 0 prognoses",
            search: "Zoek:",
            infoFiltered: "{Gefilterd op _MAX_ prognoses}",
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

    $('#ForecastTable tbody').on( 'click', 'button', function () {
        const id = table.row($(this).parents('tr')).data()[0];
        $.ajax({
            type: "GET",
            url: '/Prognosis/GetOneForecast/',
            data: {
                id: id,
            },
            success: function (data) {
                const modal = $('#forecast-modal-edit').modal('show');

                modal.find('#branch-edit').val(data.branch.name);
                modal.find('#customer-edit').val(data.amountOfCustomers);
                modal.find('#forecast-id').val(data.forecastId);
                modal.find('#branch-id').val(data.branch.branchId);
                modal.find('#colli-edit').val(data.rollContainers);
                modal.find('#cashiers-edit').val(data?.amountOfCashiers);
                modal.find('#fresh-edit').val(data?.amountOfFresh);
                modal.find('#stock-clerks-edit').val(data?.amountOfStockClerks);
                var date = new Date(data.date);
                date.setDate(date.getDate() + 1);
                modal.find('#date-edit').val(date.toISOString().substring(0, 10).split('/').reverse().join('/'));
                modal.find('#description-edit').val(data.description);
            },
            error: function () {
                alert('Error! Prognose niet gevonden!');
            }
        });
    });

    const minDate = new Date();
    document.getElementById('date-create').min = minDate.toISOString().substring(0, 10).split('/').reverse().join('/');
});

let changed = false;
function onChangeEvent() {
    if (!changed) {
        document.getElementById('dangerId').innerText = 'Herbereken vernieuwd de benodigde uren gebaseerd op klanten en colli.';
        document.getElementById('recalculateId').disabled = false;
    }
    changed = true;
}


