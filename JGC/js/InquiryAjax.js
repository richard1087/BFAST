var timer;
$(document).ajaxStart(function () {
    timer && clearTimeout(timer);
    timer = setTimeout(function () {
        $('#Loading').show();
    }, 1000);
});

$(document).ajaxStop(function () {
    clearTimeout(timer);
    $('#Loading').hide();
});

function GetInquiryStock(id, folder, webmethod, column, filter, search) {
    $.ajax({
        type: "POST",
        url: folder + "/" + webmethod,
        data: filter,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        }

    });
    function OnSuccess(data) {
        var source =
            {
                datatype: "json",
                datafields: [
                    { name: 'PoolId', type: 'string' },
                    { name: 'KodeBin', type: 'string' },
                    { name: 'KodePool', type: 'string' },
                    { name: 'KodeProduct', type: 'string' },
                    { name: 'NamaProduct', type: 'string' },
                    { name: 'NamaBrand', type: 'string' },
                    { name: 'NamaSubBrand', type: 'string' },
                    { name: 'NamaProductClass', type: 'string' },
                    { name: 'KodeGudang', type: 'string' },
                    { name: 'TotalQty', type: 'string' },
                    { name: 'QtyIntransit', type: 'string' },
                    { name: 'QtyAlokasi', type: 'string' },
                    { name: 'QtyOnHand', type: 'string' },
                    { name: 'QtyAllocated', type: 'string' },
                    { name: 'QtyReserved', type: 'string' },
                    { name: 'QtyAvailable', type: 'string' },
                    { name: 'KodeDefUoM', type: 'string' },
                    { name: 'AllTotalQty', type: 'string' },
                    { name: 'AllQtyIntransit', type: 'string' },
                    { name: 'AllQtyAlokasi', type: 'string' },
                    { name: 'AllQtyOnHand', type: 'string' },
                    { name: 'AllQtyAllocated', type: 'string' },
                    { name: 'AllQtyReserved', type: 'string' },
                    { name: 'AllQtyAvailable', type: 'string' }
                ],
                localdata: data.d
            };

        JqGrid("#" + id, source, column, search)
    }
}
function GetCompanyInquiry(id, folder, webmethod, column, filter, search) {
    $.ajax({
        type: "POST",
        url: folder + "/" + webmethod,
        data: filter,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        }

    });
    function OnSuccess(data) {
        var source =
            {
                datatype: "json",
                datafields: [
                    { name: 'KodePerusahaan', type: 'string' },
                    { name: 'KodePT', type: 'string' },
                    { name: 'KodeProduct', type: 'string' },
                    { name: 'NamaProduct', type: 'string' },
                    { name: 'Qty', type: 'string' },
                    { name: 'AverageCost', type: 'string' },
                    { name: 'TotalCost', type: 'string' }
                ],
                localdata: data.d
            };

        JqGrid("#" + id, source, column, search)
    }
}
