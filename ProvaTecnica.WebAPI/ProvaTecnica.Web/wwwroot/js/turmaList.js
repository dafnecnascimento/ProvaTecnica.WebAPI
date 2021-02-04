var dataTable;


$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('DT_load').DataTable({
        "ajax": {
            "url": "/api/turma",
            "type": "GET",
            "datatype" : "json"
        },
        "colums": [
            { "data": "nometurma", "width": "30%" },
            { "data": "idescola", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Turma/Edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            Edit
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Delete('/api/turma?id='+${data})>
                            Excluir
                        </a>
                        </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}