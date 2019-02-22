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
                    minDate: '',
                    maxDate: ''
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
});