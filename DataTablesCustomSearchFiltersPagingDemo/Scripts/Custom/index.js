$(document).ready(function() {
    $('#employees-list').DataTable({
        processing: true,
        serverSide: true,
        ajax: {
            url: '/Home/GetEmployees',
            type: 'POST',
            datatype: 'json'
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