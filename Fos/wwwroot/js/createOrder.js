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
        recalculateTotalItems();
    });
    $('input[type="number"]').trigger('change');
}

function updateBadge(inputField) {
    var badge = inputField.parent().find('span.badge-light');
    badge.text(inputField.val());
}

function recalculateTotalItems() {
    var items = 0;
    $('.dish-order-input').each(function () {
        return items += parseInt($(this).val());
    });
    $('.total-items').text(items);
    if (items > 0) {
        $('.submit-button').prop('disabled', false);
    } else {
        $('.submit-button').prop('disabled', true);
    }
}