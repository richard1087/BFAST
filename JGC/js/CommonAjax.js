function deletes(folder,data,href) {
    if (confirm("Are you sure you want to delete this?")) {
        $.ajax({
            type: "POST",
            url: folder+"/Deletes",
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function (response) {
                alert(response.d);
            }

        });
        function OnSuccess(response) {
            var Update = $.parseJSON(response.d);
            if (Update[0].Exception == "1") {
                location.href = href;
            }
            else {
                alert(Update[0].Exception);
            }
        }
    }
    else {
        return false;
    }
}

function Select2Get(folder, method, data) {
    var option = [];
    var string;
        $.ajax({
            type: "POST",
            url: folder + "/" + method,
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: OnSuccess,
            failure: function (response) {
                alert(response.d);
            }

        });
        function OnSuccess(response) {
            $.each(response, function (k, v) {
                $.each(v, function (k, v) {
                    option.push("<option value='" + v.Value + "'>" + v.Text + "</option>");
                });
            });
        }
        return option.toString().replace(',', '');
}

function Get1Data(folder, method, data) {
    var string;
    $.ajax({
        type: "POST",
        url: folder + "/" + method,
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        }

    });
    function OnSuccess(response) {
        $.each(response, function (k, v) {
            $.each($.parseJSON(v), function (k, v) {
            string = v.KodeBin
            });
        });
    }
    return string;
}