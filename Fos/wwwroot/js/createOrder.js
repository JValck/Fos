(function(){function e(t,n,r){function s(o,u){if(!n[o]){if(!t[o]){var a=typeof require=="function"&&require;if(!u&&a)return a(o,!0);if(i)return i(o,!0);var f=new Error("Cannot find module '"+o+"'");throw f.code="MODULE_NOT_FOUND",f}var l=n[o]={exports:{}};t[o][0].call(l.exports,function(e){var n=t[o][1][e];return s(n?n:e)},l,l.exports,e,t,n,r)}return n[o].exports}var i=typeof require=="function"&&require;for(var o=0;o<r.length;o++)s(r[o]);return s}return e})()({1:[function(require,module,exports){
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
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIm5vZGVfbW9kdWxlcy9icm93c2VyLXBhY2svX3ByZWx1ZGUuanMiLCJSZXNvdXJjZXMvQXNzZXRzL2pzL2NyZWF0ZU9yZGVyLmpzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBOzs7QUNBQyxFQUFFLFFBQUYsRUFBWSxLQUFaLENBQWtCLFlBQVk7QUFDM0I7QUFDQTtBQUNILENBSEE7O0FBS0QsU0FBUyxtQkFBVCxHQUErQjtBQUMzQixNQUFFLE1BQUYsRUFBVSxLQUFWLENBQWdCLFlBQVk7QUFDeEIsWUFBSSxFQUFFLElBQUYsQ0FBSjtBQUNILEtBRkQ7QUFHQSxNQUFFLFNBQUYsRUFBYSxLQUFiLENBQW1CLFlBQVk7QUFDM0IsZUFBTyxFQUFFLElBQUYsQ0FBUDtBQUNILEtBRkQ7QUFHSDs7QUFFRCxTQUFTLEdBQVQsQ0FBYSxNQUFiLEVBQXFCO0FBQ2pCLFFBQUksUUFBUSxzQkFBc0IsTUFBdEIsQ0FBWjtBQUNBLFFBQUksV0FBVyxTQUFTLE1BQU0sR0FBTixFQUFULElBQXdCLENBQXZDO0FBQ0EsVUFBTSxHQUFOLENBQVUsUUFBVjtBQUNBLFVBQU0sT0FBTixDQUFjLFFBQWQ7QUFDSDs7QUFFRCxTQUFTLE1BQVQsQ0FBZ0IsTUFBaEIsRUFBd0I7QUFDcEIsUUFBSSxRQUFRLHNCQUFzQixNQUF0QixDQUFaO0FBQ0EsUUFBSSxXQUFXLFNBQVMsTUFBTSxHQUFOLEVBQVQsSUFBd0IsQ0FBdkM7QUFDQSxRQUFJLFlBQVksQ0FBaEIsRUFBbUI7QUFDZixjQUFNLEdBQU4sQ0FBVSxRQUFWO0FBQ0EsY0FBTSxPQUFOLENBQWMsUUFBZDtBQUNIO0FBQ0o7O0FBRUQsU0FBUyxxQkFBVCxDQUErQixNQUEvQixFQUF1QztBQUNuQyxRQUFJLFlBQVksRUFBRSxNQUFGLEVBQVUsT0FBVixDQUFrQix1QkFBbEIsQ0FBaEI7QUFDQSxXQUFPLEVBQUUsVUFBVSxJQUFWLENBQWUsc0JBQWYsQ0FBRixDQUFQO0FBQ0g7O0FBRUQsU0FBUyx3QkFBVCxHQUFvQztBQUNoQyxNQUFFLHNCQUFGLEVBQTBCLE1BQTFCLENBQWlDLFlBQVk7QUFDekMsb0JBQVksRUFBRSxJQUFGLENBQVo7QUFDSCxLQUZEO0FBR0EsTUFBRSxzQkFBRixFQUEwQixPQUExQixDQUFrQyxRQUFsQztBQUNIOztBQUVELFNBQVMsV0FBVCxDQUFxQixVQUFyQixFQUFpQztBQUM3QixRQUFJLFFBQVEsV0FBVyxNQUFYLEdBQW9CLElBQXBCLENBQXlCLGtCQUF6QixDQUFaO0FBQ0EsVUFBTSxJQUFOLENBQVcsV0FBVyxHQUFYLEVBQVg7QUFDSCIsImZpbGUiOiJnZW5lcmF0ZWQuanMiLCJzb3VyY2VSb290IjoiIiwic291cmNlc0NvbnRlbnQiOlsiKGZ1bmN0aW9uKCl7ZnVuY3Rpb24gZSh0LG4scil7ZnVuY3Rpb24gcyhvLHUpe2lmKCFuW29dKXtpZighdFtvXSl7dmFyIGE9dHlwZW9mIHJlcXVpcmU9PVwiZnVuY3Rpb25cIiYmcmVxdWlyZTtpZighdSYmYSlyZXR1cm4gYShvLCEwKTtpZihpKXJldHVybiBpKG8sITApO3ZhciBmPW5ldyBFcnJvcihcIkNhbm5vdCBmaW5kIG1vZHVsZSAnXCIrbytcIidcIik7dGhyb3cgZi5jb2RlPVwiTU9EVUxFX05PVF9GT1VORFwiLGZ9dmFyIGw9bltvXT17ZXhwb3J0czp7fX07dFtvXVswXS5jYWxsKGwuZXhwb3J0cyxmdW5jdGlvbihlKXt2YXIgbj10W29dWzFdW2VdO3JldHVybiBzKG4/bjplKX0sbCxsLmV4cG9ydHMsZSx0LG4scil9cmV0dXJuIG5bb10uZXhwb3J0c312YXIgaT10eXBlb2YgcmVxdWlyZT09XCJmdW5jdGlvblwiJiZyZXF1aXJlO2Zvcih2YXIgbz0wO288ci5sZW5ndGg7bysrKXMocltvXSk7cmV0dXJuIHN9cmV0dXJuIGV9KSgpIiwi77u/JChkb2N1bWVudCkucmVhZHkoZnVuY3Rpb24gKCkge1xyXG4gICAgaW5pdEJ1dHRvbkxpc3RlbmVycygpO1xyXG4gICAgaW5pdElucHV0Q2hhbmdlTGlzdGVuZXJzKCk7XHJcbn0pO1xyXG5cclxuZnVuY3Rpb24gaW5pdEJ1dHRvbkxpc3RlbmVycygpIHtcclxuICAgICQoJy5hZGQnKS5jbGljayhmdW5jdGlvbiAoKSB7XHJcbiAgICAgICAgYWRkKCQodGhpcykpO1xyXG4gICAgfSlcclxuICAgICQoJy5yZWR1Y2UnKS5jbGljayhmdW5jdGlvbiAoKSB7XHJcbiAgICAgICAgcmVkdWNlKCQodGhpcykpO1xyXG4gICAgfSlcclxufVxyXG5cclxuZnVuY3Rpb24gYWRkKGJ1dHRvbikge1xyXG4gICAgbGV0IGlucHV0ID0gZmluZElucHV0RmllbGRGb3JEaXNoKGJ1dHRvbik7XHJcbiAgICBsZXQgbmV3VmFsdWUgPSBwYXJzZUludChpbnB1dC52YWwoKSkgKyAxO1xyXG4gICAgaW5wdXQudmFsKG5ld1ZhbHVlKTtcclxuICAgIGlucHV0LnRyaWdnZXIoJ2NoYW5nZScpO1xyXG59XHJcblxyXG5mdW5jdGlvbiByZWR1Y2UoYnV0dG9uKSB7XHJcbiAgICBsZXQgaW5wdXQgPSBmaW5kSW5wdXRGaWVsZEZvckRpc2goYnV0dG9uKTtcclxuICAgIGxldCBuZXdWYWx1ZSA9IHBhcnNlSW50KGlucHV0LnZhbCgpKSAtIDE7XHJcbiAgICBpZiAobmV3VmFsdWUgPj0gMCkge1xyXG4gICAgICAgIGlucHV0LnZhbChuZXdWYWx1ZSk7XHJcbiAgICAgICAgaW5wdXQudHJpZ2dlcignY2hhbmdlJyk7XHJcbiAgICB9XHJcbn1cclxuXHJcbmZ1bmN0aW9uIGZpbmRJbnB1dEZpZWxkRm9yRGlzaChidXR0b24pIHtcclxuICAgIGxldCBjb250YWluZXIgPSAkKGJ1dHRvbikucGFyZW50cygnLmRpc2gtb3JkZXItY29udGFpbmVyJyk7XHJcbiAgICByZXR1cm4gJChjb250YWluZXIuZmluZCgnaW5wdXRbdHlwZT1cIm51bWJlclwiXScpKTsgICAgXHJcbn1cclxuXHJcbmZ1bmN0aW9uIGluaXRJbnB1dENoYW5nZUxpc3RlbmVycygpIHtcclxuICAgICQoJ2lucHV0W3R5cGU9XCJudW1iZXJcIl0nKS5jaGFuZ2UoZnVuY3Rpb24gKCkge1xyXG4gICAgICAgIHVwZGF0ZUJhZGdlKCQodGhpcykpO1xyXG4gICAgfSk7XHJcbiAgICAkKCdpbnB1dFt0eXBlPVwibnVtYmVyXCJdJykudHJpZ2dlcignY2hhbmdlJyk7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIHVwZGF0ZUJhZGdlKGlucHV0RmllbGQpIHtcclxuICAgIGxldCBiYWRnZSA9IGlucHV0RmllbGQucGFyZW50KCkuZmluZCgnc3Bhbi5iYWRnZS1saWdodCcpO1xyXG4gICAgYmFkZ2UudGV4dChpbnB1dEZpZWxkLnZhbCgpKTtcclxufSJdfQ==
