function GetInput(DataID) {
    var ijson = [];
    var iattr = [];
    $.each($("[data-id='"+DataID+"']"), function () {
        if ($(this).attr("type") == "text" || $(this).attr("type") == "number" || $(this).attr("type") == "password" || $(this).attr("type") == "hidden" || $(this).prop("tagName") == "SELECT" || $(this).prop("tagName") == "TEXTAREA") {
            iattr.push($(this).attr("Name") + ':"' + $(this).val() + '"');
        }
        else if ($(this).attr("type") == "radio")
        {
            if (this.checked)
            {
                iattr.push($(this).attr("Names") + ':"' + $(this).val() + '"');
            }
        }
        else {
            if (this.checked) {
                iattr.push($(this).attr("Name") + ':' + '1');
            }
            else {
                iattr.push($(this).attr("Name") + ':' + '0');
            }
        }
    });
    ijson.push('{' + iattr.toString() + '}')
    return ijson.toString();
}