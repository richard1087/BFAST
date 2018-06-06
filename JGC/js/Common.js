function SpecialChar() {
    var i = 0;
    var patternSpecialChar = /^[a-zA-Z0-9!@#$^*()_+\-=\[\]{} ;':"\\|,.<>\/?]*$/;
    var patternSpecialCharNoSpace = /^[a-zA-Z0-9!@#$^*()_+\-=\[\]{};':"\\|,.<>\/?]*$/;
    $.each($("input"), function () {
        if ($(this).is(".isnospace")) {
            if (!patternSpecialCharNoSpace.test($(this).val())) {
                i = 1
                $(this).css("background-color", "#ababab");
            }
            else {
                $(this).css("background-color", "");
            }
        }
        else {
            if (!patternSpecialChar.test($(this).val())) {
                i = 1
                $(this).css("background-color", "#ababab");
            }
            else {
                $(this).css("background-color", "");
            }
        }
    });
    return i;
}
function Nopolis()
{
    var i = 0;
    var elements = null;
    var patternNopolis = /^[A-Za-z]{1,3} [0-9]{1,4} [A-Za-z]{1,3}$/;
    $(".ErrorText").remove(".ErrorText");
    $("div").removeClass("InputGroupError");
$.each($("input"), function () {
    $(this).removeClass("Error");
    if ($(this).is(".NoPolisi")) {
        if (!patternNopolis.test($(this).val())) {
            i = 1
            $(this).addClass("Error");
            if ($(this).parent().hasClass('input-group') && $(this).attr("type") != "hidden") {
                $(this).parent().addClass("InputGroupError");
                $(this).parent().after("<label class='ErrorText'>Wrong Format. Example (B 1234 ABC).</label>");
                if (elements == null) {
                    elements = $(this).attr("id")
                }
            }
            else if ($(this).attr("type") != "hidden") {
                $(this).after("<label class='ErrorText'>Wrong Format. Example (B 1234 ABC).</label>");
                if (elements == null) {
                    elements = $(this).attr("id")
                }
            }
        }
    }
});
if (i > 0 && elements != null) {
    $('html, body').animate({
        scrollTop: $("#"+elements).offset().top
    }, 100);
}
    return i;
}
function SDown() {
    $('.IUNP').css('display', '');

    $('html , body').animate({
        scrollTop: $("#jqxgrid").offset().top + 400
    }, 100);
}