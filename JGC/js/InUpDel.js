function InUp(webmethod, funtios, DataID) {
        if (DataID == null) {
            DataID = "i";
        }
        if (Required(DataID) == 0) {
            if (Nopolis() == 0) {
                $.ajax({
                    type: "POST",
                    url: webmethod,
                    data: GetInput(DataID),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function (response) {
                        alert(response.d);
                    }
                });
                function OnSuccess(response) {
                    if (response[0].Exception == "1") {
                        $("[type=text]").val("");
                        $('[type=checkbox]').prop('checked', false);
                        $('[type=checkbox]').closest(".checked").removeClass("checked");
                        var funtio = new Function(funtios);
                        funtio.call(this);
                    }
                    else {
                        $(".modal-body #peringatan3").text(response[0].Exception.substring(4, response[0].Exception.length));
                        $("#Alert3").modal();

                    }
                }
            }
        }
}
function InUpTrans(webmethod, funtios, DataID) {
    if (DataID == null) {
        DataID = "i";
    }
    if (Required(DataID) == 0) {
        if (Nopolis() == 0) {
            $.ajax({
                type: "POST",
                url: webmethod,
                data: GetInput(DataID),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
            function OnSuccess(response) {
                if (response[0].Exception == "1") {
                    var funtio = new Function(funtios);
                    funtio.call(this);
                }
                else {
                    $(".modal-body #peringatan3").text(response[0].Exception.substring(4, response[0].Exception.length));
                    $("#Alert3").modal();

                }
            }
        }
    }
}
function InUpManual(webmethod, funtios, Datas) {
        if (Nopolis() == 0) {
            $.ajax({
                type: "POST",
                url: webmethod,
                data: Datas,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
            function OnSuccess(response) {
                if (response[0].Exception == "1") {
                    $("[type=text]").val("");
                    $('[type=checkbox]').prop('checked', false);
                    $('[type=checkbox]').closest(".checked").removeClass("checked");
                    $('.IUNP').css("display", "none");
                    var funtio = new Function(funtios);
                    funtio.call(this);
                }
                else {
                    $(".modal-body #peringatan3").text(response[0].Exception.substring(4, response[0].Exception.length));
                    $("#Alert3").modal();

                }
            }
    }
}
