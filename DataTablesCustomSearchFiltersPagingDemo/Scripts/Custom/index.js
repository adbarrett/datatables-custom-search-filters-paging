$(document).ready(function() {
    $('#employees-list').DataTable({
        processing: true,
        serverSide: true,
        ajax: {
            url: '/Home/GetEmployees',
            type: 'POST',
            datatype: 'json',
            'data': function (dtParams) {
                dtParams.columns[3].dateSearch = {
                    minDate: $('#from-date-filter').val(),
                    maxDate: $('#to-date-filter').val()
                }

                console.log(dtParams);

                return dtParams;
            }
        },
        columns: [
            { title: 'Id', data: 'Id', visible: false },
            { title: 'First Name', data: 'FirstName' },
            { title: 'Last Name', data: 'LastName' },
            { title: 'Date of Birth', data: 'DateOfBirth', type: 'date', render: function(data) {
                var date = new Date(data);
                return date.toLocaleDateString();
            } },
            { title: 'Department', data: 'Department.Name' }
        ]
    });

    $('#first-name-filter').on('keyup', function () {
        $('#employees-list').DataTable().column(1).search($(this).val(), false, true).draw();
    });

    $('#last-name-filter').on('keyup', function () {
        $('#employees-list').DataTable().column(2).search($(this).val(), false, true).draw();
    });

    $('#department-filter').on('change', function () {
        $('#employees-list').DataTable().column(4).search($(this).val(), false, true).draw();
    });

    $('.date-filter').on('change', function () {
        $('#employees-list').DataTable().draw();
    });
});