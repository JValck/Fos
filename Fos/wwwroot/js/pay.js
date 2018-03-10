(function(){function e(t,n,r){function s(o,u){if(!n[o]){if(!t[o]){var a=typeof require=="function"&&require;if(!u&&a)return a(o,!0);if(i)return i(o,!0);var f=new Error("Cannot find module '"+o+"'");throw f.code="MODULE_NOT_FOUND",f}var l=n[o]={exports:{}};t[o][0].call(l.exports,function(e){var n=t[o][1][e];return s(n?n:e)},l,l.exports,e,t,n,r)}return n[o].exports}var i=typeof require=="function"&&require;for(var o=0;o<r.length;o++)s(r[o]);return s}return e})()({1:[function(require,module,exports){
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
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIm5vZGVfbW9kdWxlcy9icm93c2VyLXBhY2svX3ByZWx1ZGUuanMiLCJSZXNvdXJjZXMvQXNzZXRzL2pzL3BheS5qcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTs7O0FDQUMsRUFBRSxRQUFGLEVBQVksS0FBWixDQUFrQixZQUFZO0FBQzNCLE1BQUUscUJBQUYsRUFBeUIsS0FBekIsQ0FBK0IsWUFBWTtBQUN2QywyQkFBbUIsRUFBRSxJQUFGLEVBQVEsR0FBUixFQUFuQjtBQUNILEtBRkQ7QUFHSCxDQUpBOztBQU1ELFNBQVMsa0JBQVQsQ0FBNEIsYUFBNUIsRUFBMkM7QUFDdkMsUUFBSSxjQUFjLE1BQWQsR0FBdUIsQ0FBdkIsSUFBNEIsZ0JBQWdCLENBQWhELEVBQW1EO0FBQy9DLFlBQUksV0FBVyxXQUFXLEVBQUUscUJBQUYsRUFBeUIsR0FBekIsR0FBK0IsT0FBL0IsQ0FBdUMsR0FBdkMsRUFBMkMsR0FBM0MsQ0FBWCxDQUFmO0FBQ0EsWUFBSSxRQUFRLFdBQVcsRUFBRSxRQUFGLEVBQVksSUFBWixHQUFtQixPQUFuQixDQUEyQixHQUEzQixFQUFnQyxHQUFoQyxDQUFYLENBQVo7QUFDQSxZQUFJLFNBQVUsV0FBVyxLQUFaLEdBQW1CLEVBQWhDO0FBQ0EsWUFBSSxTQUFTLENBQWIsRUFBZ0I7QUFDWixjQUFFLFNBQUYsRUFBYSxJQUFiLENBQWtCLE1BQU0sT0FBTyxPQUFQLENBQWUsR0FBZixFQUFtQixHQUFuQixDQUF4QjtBQUNIO0FBQ0osS0FQRCxNQU9PO0FBQ0gsVUFBRSxTQUFGLEVBQWEsSUFBYixDQUFrQixNQUFsQjtBQUNIO0FBQ0oiLCJmaWxlIjoiZ2VuZXJhdGVkLmpzIiwic291cmNlUm9vdCI6IiIsInNvdXJjZXNDb250ZW50IjpbIihmdW5jdGlvbigpe2Z1bmN0aW9uIGUodCxuLHIpe2Z1bmN0aW9uIHMobyx1KXtpZighbltvXSl7aWYoIXRbb10pe3ZhciBhPXR5cGVvZiByZXF1aXJlPT1cImZ1bmN0aW9uXCImJnJlcXVpcmU7aWYoIXUmJmEpcmV0dXJuIGEobywhMCk7aWYoaSlyZXR1cm4gaShvLCEwKTt2YXIgZj1uZXcgRXJyb3IoXCJDYW5ub3QgZmluZCBtb2R1bGUgJ1wiK28rXCInXCIpO3Rocm93IGYuY29kZT1cIk1PRFVMRV9OT1RfRk9VTkRcIixmfXZhciBsPW5bb109e2V4cG9ydHM6e319O3Rbb11bMF0uY2FsbChsLmV4cG9ydHMsZnVuY3Rpb24oZSl7dmFyIG49dFtvXVsxXVtlXTtyZXR1cm4gcyhuP246ZSl9LGwsbC5leHBvcnRzLGUsdCxuLHIpfXJldHVybiBuW29dLmV4cG9ydHN9dmFyIGk9dHlwZW9mIHJlcXVpcmU9PVwiZnVuY3Rpb25cIiYmcmVxdWlyZTtmb3IodmFyIG89MDtvPHIubGVuZ3RoO28rKylzKHJbb10pO3JldHVybiBzfXJldHVybiBlfSkoKSIsIu+7vyQoZG9jdW1lbnQpLnJlYWR5KGZ1bmN0aW9uICgpIHtcclxuICAgICQoJyNyZWNlaXZlZEZyb21DbGllbnQnKS5rZXl1cChmdW5jdGlvbiAoKSB7XHJcbiAgICAgICAgY2FsY3VsYXRlTmV3UmVmdW5kKCQodGhpcykudmFsKCkpO1xyXG4gICAgfSk7XHJcbn0pO1xyXG5cclxuZnVuY3Rpb24gY2FsY3VsYXRlTmV3UmVmdW5kKHJlY2VpdmVkTW9uZXkpIHtcclxuICAgIGlmIChyZWNlaXZlZE1vbmV5Lmxlbmd0aCA+IDAgJiYgcmVjZWl2ZWRNb25leSA+IDApIHtcclxuICAgICAgICB2YXIgcmVjZWl2ZWQgPSBwYXJzZUZsb2F0KCQoJyNyZWNlaXZlZEZyb21DbGllbnQnKS52YWwoKS5yZXBsYWNlKCcsJywnLicpKTtcclxuICAgICAgICB2YXIgdG9QYXkgPSBwYXJzZUZsb2F0KCQoJyNwcmljZScpLnRleHQoKS5yZXBsYWNlKCcsJywgJy4nKSk7XHJcbiAgICAgICAgdmFyIHJlZnVuZCA9IChyZWNlaXZlZCAtIHRvUGF5KStcIlwiO1xyXG4gICAgICAgIGlmIChyZWZ1bmQgPiAwKSB7XHJcbiAgICAgICAgICAgICQoJyNyZWZ1bmQnKS50ZXh0KCfigqwnICsgcmVmdW5kLnJlcGxhY2UoJy4nLCcsJykpO1xyXG4gICAgICAgIH1cclxuICAgIH0gZWxzZSB7XHJcbiAgICAgICAgJCgnI3JlZnVuZCcpLnRleHQoJ+KCrDAsMCcpO1xyXG4gICAgfVxyXG59Il19
