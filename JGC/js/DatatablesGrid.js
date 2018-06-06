var table;
function DTable(id,url, column,filter,popup)
{
    if (table) {
        if (popup == null) {
            table.destroy();
        }
        $("#" + id).empty();
    }
    table = $("#" + id).DataTable({
        "processing": true,
        "destroy": true,
        "ajax": {
            "url": url,
            "type": "POST",
            "datatype": "json",
            "data": filter
        },
        "columnDefs": [
       {
           "targets": [0],
           "visible": false,
           "searchable": false
       }
        ],
        "columns": column 
    });
}