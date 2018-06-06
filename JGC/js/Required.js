function Required(DataID) {
    var i = 0;
    var elements = null;
    var Data = "";
    if (DataID != null)
    {
        Data="[data-id='" + DataID + "']"
    }
    $(".ErrorText").remove(".ErrorText");
    $("div").removeClass("InputGroupError");
    $.each($("[required]"+Data), function () {
        $(this).removeClass("Error");
        if ($(this).val().trim() == "") {
            i = i + 1;
            $(this).addClass("Error");
            if ($(this).parent().hasClass('input-group') && $(this).attr("type") != "hidden") {
                $(this).parent().addClass("InputGroupError");
                $(this).parent().after("<label class='ErrorText'>Please fill out this field.</label>")
                if (elements == null) {
                    elements = $(this).attr("id")
                }
            }
            else if($(this).attr("type") != "hidden") {
                $(this).after("<label class='ErrorText'>Please fill out this field.</label>");
                if (elements == null) {
                    elements = $(this).attr("id")
                }
            }
        }

    });
    if (i > 0 && elements != null) {
        $('html, body').animate({
            scrollTop: $("#" + elements).offset().top
        }, 100);
    }
    return i;
}