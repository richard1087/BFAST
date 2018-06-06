$(".jqxgridPopup").bind('rowselect', function (event) {
    var row = event.args.rowindex;
    var datarow = $(this).jqxGrid('getrowdata', row);
    for (i = 0; i < getdata.length; i++) {
        $('#' + input[i]).val($.trim(datarow[getdata[i]]));
    }
    $('.Lookup').modal('hide');
    input = '';
});