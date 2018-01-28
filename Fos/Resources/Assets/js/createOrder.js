$(document).ready(function () {
    initButtonListeners();
    initInputChangeListeners();
});

function initButtonListeners() {
    $('.add').click(function () {
        add($(this));
    })
    $('.reduce').click(function () {
        reduce($(this));
    })
}

function add(button) {
    let input = findInputFieldForDish(button);
    let newValue = parseInt(input.val()) + 1;
    input.val(newValue);
    input.trigger('change');
}

function reduce(button) {
    let input = findInputFieldForDish(button);
    let newValue = parseInt(input.val()) - 1;
    if (newValue >= 0) {
        input.val(newValue);
        input.trigger('change');
    }
}

function findInputFieldForDish(button) {
    let container = $(button).parents('.dish-order-container');
    return $(container.find('input[type="number"]'));    
}

function initInputChangeListeners() {
    $('input[type="number"]').change(function () {
        updateBadge($(this));
    });
    $('input[type="number"]').trigger('change');
}

function updateBadge(inputField) {
    let badge = inputField.parent().find('span.badge-light');
    badge.text(inputField.val());
}