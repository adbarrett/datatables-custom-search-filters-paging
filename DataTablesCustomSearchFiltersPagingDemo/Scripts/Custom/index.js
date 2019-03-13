$(document).ready(function() {
    $('#employees-list').DataTable({
        processing: true,
        serverSide: true,
        ajax: {
            url: '/Home/GetEmployees',
            type: 'POST',
            datatype: 'json',
            data: function (dtParams) {
                dtParams.columns[3].dateSearch = {
                    minDate: $('#from-date-filter').val(),
                    maxDate: $('#to-date-filter').val()
                }

                return dtParams;
            }
        },
        drawCallback: function (settings) {
            var pageLength = settings.oAjaxData.length;
            $('#page-length').val(pageLength);

            var totalRecords = settings.json.recordsFiltered;
            var currentPage = (settings.oAjaxData.start / pageLength);
            addPageControls(totalRecords, pageLength, currentPage);
            bindPageControls();
        },
        dom: '',
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

    $('#page-length').on('change', function () {
        $('#employees-list').DataTable().page.len($(this).val()).draw();
    });
});

function addPageControls(totalRecords, pageLength, currentPage) {
    var totalPages = Math.ceil(totalRecords / pageLength);
    if (totalPages < 0) {
        totalPages = 1;
    }

    var lastPage = totalPages - 1;

    var disabledNoPreviousPages = (currentPage === 0 ? ' disabled' : '');
    var firstPageLink = '<li class="page-item' + disabledNoPreviousPages + '" data-page="0"><span class="page-link">First</span></li>';
    var previousPageLink = '<li class="page-item' + disabledNoPreviousPages + '" data-page="' + (currentPage === 0 ? 0 : currentPage - 1) + '"><span class="page-link">Previous</span></li>';

    var previousRangeLink = '';
    if (currentPage > 2) {
        previousRangeLink = '<li class="page-item" data-page="' + (currentPage - 3) + '"><span class="page-link">...</span></li>';
    }
    var nextRangeLink = '';
    if (totalPages > 5 && currentPage < (lastPage - 2)) {
        nextRangeLink = '<li class="page-item" data-page="' + (currentPage + 3) + '"><span class="page-link">...</span></li>';
    }

    var disabledNoNextPages = (currentPage === lastPage ? ' disabled' : '');
    var nextPageLink = '<li class="page-item' + disabledNoNextPages + '" data-page="' + (currentPage === lastPage ? lastPage : currentPage + 1) + '"><span class="page-link">Next</span></li>';
    var lastPageLink = '<li class="page-item' + disabledNoNextPages + '" data-page="' + lastPage + '"><span class="page-link">Last</span></li>';

    var pageLinks = '';
    var rangeFirstPage;
    var rangeLastPage;
    if (currentPage < 3) {
        rangeFirstPage = 0;
        rangeLastPage = totalPages < 5 ? totalPages : 5;
    } else if (currentPage > (lastPage - 3)) {
        rangeFirstPage = lastPage - 4;
        rangeLastPage = totalPages;
    } else {
        rangeFirstPage = currentPage - 2;
        rangeLastPage = currentPage + 3;
    }

    for (var i = rangeFirstPage; i < rangeLastPage; i++) {
        var page = i + 1;
        var activeClass = '';
        if (currentPage === i) {
            activeClass = ' active';
        }
        pageLinks = pageLinks + '<li class="page-item' + activeClass + '" data-page="' + i + '"><span class="page-link">' + page + '</span></li>';
    }

    $('#page-options').html(firstPageLink + previousPageLink + previousRangeLink + pageLinks + nextRangeLink + nextPageLink + lastPageLink);
}

function bindPageControls() {
    $('.page-item').on('click', function () {
        $('#employees-list').DataTable().page($(this).data('page')).draw('page');
    });
}