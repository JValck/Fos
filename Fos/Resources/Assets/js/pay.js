$(document).ready(function () {
    $('#receivedFromClient').keyup(function () {
        calculateNewRefund($(this).val());
    });
});

function calculateNewRefund(receivedMoney) {
    if (receivedMoney.length > 0 && receivedMoney > 0) {
        var received = parseFloat($('#receivedFromClient').val().replace(',','.'));
        var toPay = parseFloat($('#price').text().replace(',', '.'));
        var refund = (received - toPay)+"";
        if (refund > 0) {
            $('#refund').text('€' + refund.replace('.',','));
        }
    } else {
        $('#refund').text('€0,0');
    }
}