var dataTable;

$(document).ready(function () {
    loadDataTable();
});



function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/student/getall' },
        "columns": [
            { data: 'name', "width": "10%" },
            { data: 'lastName', "width": "10%" },
            { data: 'averageGrade', "width": "20%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/admin/faculty/upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Edit</a>
                        <a onClick=Delete('/admin/faculty/delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash3"></i> Delete</a>
                        </div>`;
                },
                "width": "40%"
            }
        ],
        "initComplete": function () {
            var api = this.api();
            var subjects = [];

            // Збираємо всі унікальні предмети
            api.rows().every(function () {
                var rowData = this.data();
                if (rowData.subjectStudents) {
                    rowData.subjectStudents.forEach(function (subject) {
                        if (subjects.indexOf(subject.subjectId) === -1) {
                            subjects.push(subject.subjectId);
                        }
                    });
                }
            });

            // Додаємо стовбці для кожного предмету
            subjects.forEach(function (subjectId) {
                api.column().every(function () {
                    this.append($('<th>' + subjectId + '</th>'));
                });
            });

            // Оновлюємо дані таблиці
            api.draw();
        }
    });
}



function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toolbar.success(data.message);
                }

            })
        }
    })
}

 

