$(".isnumeric").keypress(function (evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false

    return true
});

//tambahan buat angka ribuan
//Buat angka
$('input.angka').keyup(function (event) {

    // skip for arrow keys
    if (event.which >= 37 && event.which <= 40) {
        event.preventDefault();
    }

    $(this).val(function (index, value) {
        value = value.replace(/,/g, '');
        return numberWithCommas(value);
    });
});

function numberWithCommas(x) {
    var parts = x.toString().split(".");
    parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    return parts.join(".");
}

//tambahan buat angka ribuan

$(".isnumericwithcomma").keypress(function (evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
        return false

    return true
});

$(".isnospace").keypress(function (evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode == 32 || charCode == 38)
        return false

    return true
});

$("input").keypress(function (evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode == 38)
        return false

    return true
});

$(".readonly").keypress(function (evt) {
    evt.preventDefault();
});