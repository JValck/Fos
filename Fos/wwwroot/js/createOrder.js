(function e(t,n,r){function s(o,u){if(!n[o]){if(!t[o]){var a=typeof require=="function"&&require;if(!u&&a)return a(o,!0);if(i)return i(o,!0);var f=new Error("Cannot find module '"+o+"'");throw f.code="MODULE_NOT_FOUND",f}var l=n[o]={exports:{}};t[o][0].call(l.exports,function(e){var n=t[o][1][e];return s(n?n:e)},l,l.exports,e,t,n,r)}return n[o].exports}var i=typeof require=="function"&&require;for(var o=0;o<r.length;o++)s(r[o]);return s})({1:[function(require,module,exports){
'use strict';

$(document).ready(function () {
    initButtonListeners();
    initInputChangeListeners();
});

function initButtonListeners() {
    $('.add').click(function () {
        add($(this));
    });
    $('.reduce').click(function () {
        reduce($(this));
    });
}

function add(button) {
    var input = findInputFieldForDish(button);
    var newValue = parseInt(input.val()) + 1;
    input.val(newValue);
    input.trigger('change');
}

function reduce(button) {
    var input = findInputFieldForDish(button);
    var newValue = parseInt(input.val()) - 1;
    if (newValue >= 0) {
        input.val(newValue);
        input.trigger('change');
    }
}

function findInputFieldForDish(button) {
    var container = $(button).parents('.dish-order-container');
    return $(container.find('input[type="number"]'));
}

function initInputChangeListeners() {
    $('input[type="number"]').change(function () {
        updateBadge($(this));
    });
    $('input[type="number"]').trigger('change');
}

function updateBadge(inputField) {
    var badge = inputField.parent().find('span.badge-light');
    badge.text(inputField.val());
}

},{}]},{},[1])
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIm5vZGVfbW9kdWxlcy9icm93c2VyLXBhY2svX3ByZWx1ZGUuanMiLCJSZXNvdXJjZXNcXEFzc2V0c1xcanNcXGNyZWF0ZU9yZGVyLmpzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBOzs7QUNBQyxFQUFFLFFBQUYsRUFBWSxLQUFaLENBQWtCLFlBQVk7QUFDM0I7QUFDQTtBQUNILENBSEE7O0FBS0QsU0FBUyxtQkFBVCxHQUErQjtBQUMzQixNQUFFLE1BQUYsRUFBVSxLQUFWLENBQWdCLFlBQVk7QUFDeEIsWUFBSSxFQUFFLElBQUYsQ0FBSjtBQUNILEtBRkQ7QUFHQSxNQUFFLFNBQUYsRUFBYSxLQUFiLENBQW1CLFlBQVk7QUFDM0IsZUFBTyxFQUFFLElBQUYsQ0FBUDtBQUNILEtBRkQ7QUFHSDs7QUFFRCxTQUFTLEdBQVQsQ0FBYSxNQUFiLEVBQXFCO0FBQ2pCLFFBQUksUUFBUSxzQkFBc0IsTUFBdEIsQ0FBWjtBQUNBLFFBQUksV0FBVyxTQUFTLE1BQU0sR0FBTixFQUFULElBQXdCLENBQXZDO0FBQ0EsVUFBTSxHQUFOLENBQVUsUUFBVjtBQUNBLFVBQU0sT0FBTixDQUFjLFFBQWQ7QUFDSDs7QUFFRCxTQUFTLE1BQVQsQ0FBZ0IsTUFBaEIsRUFBd0I7QUFDcEIsUUFBSSxRQUFRLHNCQUFzQixNQUF0QixDQUFaO0FBQ0EsUUFBSSxXQUFXLFNBQVMsTUFBTSxHQUFOLEVBQVQsSUFBd0IsQ0FBdkM7QUFDQSxRQUFJLFlBQVksQ0FBaEIsRUFBbUI7QUFDZixjQUFNLEdBQU4sQ0FBVSxRQUFWO0FBQ0EsY0FBTSxPQUFOLENBQWMsUUFBZDtBQUNIO0FBQ0o7O0FBRUQsU0FBUyxxQkFBVCxDQUErQixNQUEvQixFQUF1QztBQUNuQyxRQUFJLFlBQVksRUFBRSxNQUFGLEVBQVUsT0FBVixDQUFrQix1QkFBbEIsQ0FBaEI7QUFDQSxXQUFPLEVBQUUsVUFBVSxJQUFWLENBQWUsc0JBQWYsQ0FBRixDQUFQO0FBQ0g7O0FBRUQsU0FBUyx3QkFBVCxHQUFvQztBQUNoQyxNQUFFLHNCQUFGLEVBQTBCLE1BQTFCLENBQWlDLFlBQVk7QUFDekMsb0JBQVksRUFBRSxJQUFGLENBQVo7QUFDSCxLQUZEO0FBR0EsTUFBRSxzQkFBRixFQUEwQixPQUExQixDQUFrQyxRQUFsQztBQUNIOztBQUVELFNBQVMsV0FBVCxDQUFxQixVQUFyQixFQUFpQztBQUM3QixRQUFJLFFBQVEsV0FBVyxNQUFYLEdBQW9CLElBQXBCLENBQXlCLGtCQUF6QixDQUFaO0FBQ0EsVUFBTSxJQUFOLENBQVcsV0FBVyxHQUFYLEVBQVg7QUFDSCIsImZpbGUiOiJnZW5lcmF0ZWQuanMiLCJzb3VyY2VSb290IjoiIiwic291cmNlc0NvbnRlbnQiOlsiKGZ1bmN0aW9uIGUodCxuLHIpe2Z1bmN0aW9uIHMobyx1KXtpZighbltvXSl7aWYoIXRbb10pe3ZhciBhPXR5cGVvZiByZXF1aXJlPT1cImZ1bmN0aW9uXCImJnJlcXVpcmU7aWYoIXUmJmEpcmV0dXJuIGEobywhMCk7aWYoaSlyZXR1cm4gaShvLCEwKTt2YXIgZj1uZXcgRXJyb3IoXCJDYW5ub3QgZmluZCBtb2R1bGUgJ1wiK28rXCInXCIpO3Rocm93IGYuY29kZT1cIk1PRFVMRV9OT1RfRk9VTkRcIixmfXZhciBsPW5bb109e2V4cG9ydHM6e319O3Rbb11bMF0uY2FsbChsLmV4cG9ydHMsZnVuY3Rpb24oZSl7dmFyIG49dFtvXVsxXVtlXTtyZXR1cm4gcyhuP246ZSl9LGwsbC5leHBvcnRzLGUsdCxuLHIpfXJldHVybiBuW29dLmV4cG9ydHN9dmFyIGk9dHlwZW9mIHJlcXVpcmU9PVwiZnVuY3Rpb25cIiYmcmVxdWlyZTtmb3IodmFyIG89MDtvPHIubGVuZ3RoO28rKylzKHJbb10pO3JldHVybiBzfSkiLCLvu78kKGRvY3VtZW50KS5yZWFkeShmdW5jdGlvbiAoKSB7XHJcbiAgICBpbml0QnV0dG9uTGlzdGVuZXJzKCk7XHJcbiAgICBpbml0SW5wdXRDaGFuZ2VMaXN0ZW5lcnMoKTtcclxufSk7XHJcblxyXG5mdW5jdGlvbiBpbml0QnV0dG9uTGlzdGVuZXJzKCkge1xyXG4gICAgJCgnLmFkZCcpLmNsaWNrKGZ1bmN0aW9uICgpIHtcclxuICAgICAgICBhZGQoJCh0aGlzKSk7XHJcbiAgICB9KVxyXG4gICAgJCgnLnJlZHVjZScpLmNsaWNrKGZ1bmN0aW9uICgpIHtcclxuICAgICAgICByZWR1Y2UoJCh0aGlzKSk7XHJcbiAgICB9KVxyXG59XHJcblxyXG5mdW5jdGlvbiBhZGQoYnV0dG9uKSB7XHJcbiAgICBsZXQgaW5wdXQgPSBmaW5kSW5wdXRGaWVsZEZvckRpc2goYnV0dG9uKTtcclxuICAgIGxldCBuZXdWYWx1ZSA9IHBhcnNlSW50KGlucHV0LnZhbCgpKSArIDE7XHJcbiAgICBpbnB1dC52YWwobmV3VmFsdWUpO1xyXG4gICAgaW5wdXQudHJpZ2dlcignY2hhbmdlJyk7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIHJlZHVjZShidXR0b24pIHtcclxuICAgIGxldCBpbnB1dCA9IGZpbmRJbnB1dEZpZWxkRm9yRGlzaChidXR0b24pO1xyXG4gICAgbGV0IG5ld1ZhbHVlID0gcGFyc2VJbnQoaW5wdXQudmFsKCkpIC0gMTtcclxuICAgIGlmIChuZXdWYWx1ZSA+PSAwKSB7XHJcbiAgICAgICAgaW5wdXQudmFsKG5ld1ZhbHVlKTtcclxuICAgICAgICBpbnB1dC50cmlnZ2VyKCdjaGFuZ2UnKTtcclxuICAgIH1cclxufVxyXG5cclxuZnVuY3Rpb24gZmluZElucHV0RmllbGRGb3JEaXNoKGJ1dHRvbikge1xyXG4gICAgbGV0IGNvbnRhaW5lciA9ICQoYnV0dG9uKS5wYXJlbnRzKCcuZGlzaC1vcmRlci1jb250YWluZXInKTtcclxuICAgIHJldHVybiAkKGNvbnRhaW5lci5maW5kKCdpbnB1dFt0eXBlPVwibnVtYmVyXCJdJykpOyAgICBcclxufVxyXG5cclxuZnVuY3Rpb24gaW5pdElucHV0Q2hhbmdlTGlzdGVuZXJzKCkge1xyXG4gICAgJCgnaW5wdXRbdHlwZT1cIm51bWJlclwiXScpLmNoYW5nZShmdW5jdGlvbiAoKSB7XHJcbiAgICAgICAgdXBkYXRlQmFkZ2UoJCh0aGlzKSk7XHJcbiAgICB9KTtcclxuICAgICQoJ2lucHV0W3R5cGU9XCJudW1iZXJcIl0nKS50cmlnZ2VyKCdjaGFuZ2UnKTtcclxufVxyXG5cclxuZnVuY3Rpb24gdXBkYXRlQmFkZ2UoaW5wdXRGaWVsZCkge1xyXG4gICAgbGV0IGJhZGdlID0gaW5wdXRGaWVsZC5wYXJlbnQoKS5maW5kKCdzcGFuLmJhZGdlLWxpZ2h0Jyk7XHJcbiAgICBiYWRnZS50ZXh0KGlucHV0RmllbGQudmFsKCkpO1xyXG59Il19
