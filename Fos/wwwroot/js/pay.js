$(document).ready(function () {
    $('#receivedFromClient').keyup(function () {
        calculateNewRefund($(this).val());
    });
});

function calculateNewRefund(receivedMoney) {
    if (receivedMoney.length > 0 && receivedMoney > 0) {
        var received = parseFloat($('#receivedFromClient').val().replace(',', '.'));
        var toPay = parseFloat($('#price').text().replace(',', '.'));
        var refund = parseFloat(received - toPay).toFixed(2) + "";
        if (refund >= 0) {
            $('#refund').text('€' + refund.replace('.', ','));
            $('#payButton').prop('disabled', false);
        } else {
            $('#payButton').prop('disabled', true);
        }
    } else {
        $('#refund').text('€0,0');
    }
}

function requestPayement() {

}