(function e(t,n,r){function s(o,u){if(!n[o]){if(!t[o]){var a=typeof require=="function"&&require;if(!u&&a)return a(o,!0);if(i)return i(o,!0);var f=new Error("Cannot find module '"+o+"'");throw f.code="MODULE_NOT_FOUND",f}var l=n[o]={exports:{}};t[o][0].call(l.exports,function(e){var n=t[o][1][e];return s(n?n:e)},l,l.exports,e,t,n,r)}return n[o].exports}var i=typeof require=="function"&&require;for(var o=0;o<r.length;o++)s(r[o]);return s})({1:[function(require,module,exports){
'use strict';

$(document).ready(function () {
    $('#receivedFromClient').keyup(function () {
        calculateNewRefund($(this).val());
    });
});

function calculateNewRefund(receivedMoney) {
    if (receivedMoney.length > 0 && receivedMoney > 0) {
        var received = parseFloat($('#receivedFromClient').val().replace(',', '.'));
        var toPay = parseFloat($('#price').text().replace(',', '.'));
        var refund = received - toPay + "";
        if (refund > 0) {
            $('#refund').text('€' + refund.replace('.', ','));
        }
    } else {
        $('#refund').text('€0,0');
    }
}

},{}]},{},[1])
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIm5vZGVfbW9kdWxlcy9icm93c2VyLXBhY2svX3ByZWx1ZGUuanMiLCJSZXNvdXJjZXNcXEFzc2V0c1xcanNcXHBheS5qcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTs7O0FDQUMsRUFBRSxRQUFGLEVBQVksS0FBWixDQUFrQixZQUFZO0FBQzNCLE1BQUUscUJBQUYsRUFBeUIsS0FBekIsQ0FBK0IsWUFBWTtBQUN2QywyQkFBbUIsRUFBRSxJQUFGLEVBQVEsR0FBUixFQUFuQjtBQUNILEtBRkQ7QUFHSCxDQUpBOztBQU1ELFNBQVMsa0JBQVQsQ0FBNEIsYUFBNUIsRUFBMkM7QUFDdkMsUUFBSSxjQUFjLE1BQWQsR0FBdUIsQ0FBdkIsSUFBNEIsZ0JBQWdCLENBQWhELEVBQW1EO0FBQy9DLFlBQUksV0FBVyxXQUFXLEVBQUUscUJBQUYsRUFBeUIsR0FBekIsR0FBK0IsT0FBL0IsQ0FBdUMsR0FBdkMsRUFBMkMsR0FBM0MsQ0FBWCxDQUFmO0FBQ0EsWUFBSSxRQUFRLFdBQVcsRUFBRSxRQUFGLEVBQVksSUFBWixHQUFtQixPQUFuQixDQUEyQixHQUEzQixFQUFnQyxHQUFoQyxDQUFYLENBQVo7QUFDQSxZQUFJLFNBQVUsV0FBVyxLQUFaLEdBQW1CLEVBQWhDO0FBQ0EsWUFBSSxTQUFTLENBQWIsRUFBZ0I7QUFDWixjQUFFLFNBQUYsRUFBYSxJQUFiLENBQWtCLE1BQU0sT0FBTyxPQUFQLENBQWUsR0FBZixFQUFtQixHQUFuQixDQUF4QjtBQUNIO0FBQ0osS0FQRCxNQU9PO0FBQ0gsVUFBRSxTQUFGLEVBQWEsSUFBYixDQUFrQixNQUFsQjtBQUNIO0FBQ0oiLCJmaWxlIjoiZ2VuZXJhdGVkLmpzIiwic291cmNlUm9vdCI6IiIsInNvdXJjZXNDb250ZW50IjpbIihmdW5jdGlvbiBlKHQsbixyKXtmdW5jdGlvbiBzKG8sdSl7aWYoIW5bb10pe2lmKCF0W29dKXt2YXIgYT10eXBlb2YgcmVxdWlyZT09XCJmdW5jdGlvblwiJiZyZXF1aXJlO2lmKCF1JiZhKXJldHVybiBhKG8sITApO2lmKGkpcmV0dXJuIGkobywhMCk7dmFyIGY9bmV3IEVycm9yKFwiQ2Fubm90IGZpbmQgbW9kdWxlICdcIitvK1wiJ1wiKTt0aHJvdyBmLmNvZGU9XCJNT0RVTEVfTk9UX0ZPVU5EXCIsZn12YXIgbD1uW29dPXtleHBvcnRzOnt9fTt0W29dWzBdLmNhbGwobC5leHBvcnRzLGZ1bmN0aW9uKGUpe3ZhciBuPXRbb11bMV1bZV07cmV0dXJuIHMobj9uOmUpfSxsLGwuZXhwb3J0cyxlLHQsbixyKX1yZXR1cm4gbltvXS5leHBvcnRzfXZhciBpPXR5cGVvZiByZXF1aXJlPT1cImZ1bmN0aW9uXCImJnJlcXVpcmU7Zm9yKHZhciBvPTA7bzxyLmxlbmd0aDtvKyspcyhyW29dKTtyZXR1cm4gc30pIiwi77u/JChkb2N1bWVudCkucmVhZHkoZnVuY3Rpb24gKCkge1xyXG4gICAgJCgnI3JlY2VpdmVkRnJvbUNsaWVudCcpLmtleXVwKGZ1bmN0aW9uICgpIHtcclxuICAgICAgICBjYWxjdWxhdGVOZXdSZWZ1bmQoJCh0aGlzKS52YWwoKSk7XHJcbiAgICB9KTtcclxufSk7XHJcblxyXG5mdW5jdGlvbiBjYWxjdWxhdGVOZXdSZWZ1bmQocmVjZWl2ZWRNb25leSkge1xyXG4gICAgaWYgKHJlY2VpdmVkTW9uZXkubGVuZ3RoID4gMCAmJiByZWNlaXZlZE1vbmV5ID4gMCkge1xyXG4gICAgICAgIHZhciByZWNlaXZlZCA9IHBhcnNlRmxvYXQoJCgnI3JlY2VpdmVkRnJvbUNsaWVudCcpLnZhbCgpLnJlcGxhY2UoJywnLCcuJykpO1xyXG4gICAgICAgIHZhciB0b1BheSA9IHBhcnNlRmxvYXQoJCgnI3ByaWNlJykudGV4dCgpLnJlcGxhY2UoJywnLCAnLicpKTtcclxuICAgICAgICB2YXIgcmVmdW5kID0gKHJlY2VpdmVkIC0gdG9QYXkpK1wiXCI7XHJcbiAgICAgICAgaWYgKHJlZnVuZCA+IDApIHtcclxuICAgICAgICAgICAgJCgnI3JlZnVuZCcpLnRleHQoJ+KCrCcgKyByZWZ1bmQucmVwbGFjZSgnLicsJywnKSk7XHJcbiAgICAgICAgfVxyXG4gICAgfSBlbHNlIHtcclxuICAgICAgICAkKCcjcmVmdW5kJykudGV4dCgn4oKsMCwwJyk7XHJcbiAgICB9XHJcbn0iXX0=
