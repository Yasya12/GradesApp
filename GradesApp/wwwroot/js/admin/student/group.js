var dataTable;

$(document).ready(function () {
    loadDataTable();
});



function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/faculty/group/getall' },
        "columns": [
            { data: 'groupName', "width": "20%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/admin/student/getallstudent?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Показати список студентів</a>
                        </div>`;
                },

                "width": "40%"
            }
        ]
    });
}



