var date = new Date(), y = date.getFullYear(), m = date.getMonth();
var firstDay = new Date(y, m, 1);
var lastDay = new Date(y, m + 1, 0);
$(".datepicker").datepicker({ format: 'dd/mm/yyyy'}).on('changeDate', function(ev){                 
    $(this).datepicker('hide');
});
$(".datepicker").mask("99/99/9999");
$("#fromdate").val(firstDay.format("dd/MM/yyyy"));
$("#todate").val(lastDay.format("dd/MM/yyyy")); 

$('.chkSelectAll').click(function () {
    if ($(this).parent().hasClass("checked")) {
        $(this).closest('.chkbx').find('input:checkbox').prop('checked', false);
        $(this).closest('.chkbx').find('span').removeClass("checked");
    }
    else {
        $(this).closest('.chkbx').find('input:checkbox').prop('checked', true);
        $(this).closest('.chkbx').find('span').addClass("checked");
    }

});

   function GetDataFilter() {
       var ijson = [];
       var iattr = [];
       var inparam = [];
       $('[data-filter]').each(function () {
           var name = ''
           name = $(this).data('filter');
           inparam = [];
           $(this).find('[name="' + name + '"]').each(function () {
               if ($(this).prop("type").toLowerCase() == "checkbox") {
                   if (this.checked) {
                       inparam.push( $(this).val());
                   }
               }
               else if ($(this).prop("type").toLowerCase() == "text" || $(this).prop("type").toLowerCase() == "hidden") {
                    inparam.push( $(this).val());
               }
           });
           iattr.push(name + ':"' + inparam.toString() + '"');
       });
       ijson.push('{' + iattr.toString() + '}')
       return ijson.toString();

   }