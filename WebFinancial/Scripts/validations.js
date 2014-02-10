Sys.Application.add_load(function () {
    //Activate ToolTip
    $("a[data-toggle='tooltip']").tooltip();

    $('.input-group.date').datepicker({
        autoclose: true,
        todayHighlight: true
    });

    //Close all modal windows
    $('.close-flyout').click(function () {
        $(this).parents('.overlay').hide();
    });
    //Disable cut-copy-paste functions
    $('input').bind("cut copy paste", function (e) {
        e.preventDefault();
    });
    //Configure help management
    $('.help-button').click(function () {
        $("#helpOverlay").show();
    });
    //Get culture configuration
    currencyDecimalDigits = $('#currencyDecimalDigits').val();
    currencyDecimalSeparator = $('#currencyDecimalSeparator').val();
    numberDecimalDigits = $('#numberDecimalDigits').val();
    numberDecimalSeparator = $('#numberDecimalSeparator').val();
    datepickerDateFormat = $('#datepickerDateFormat').val();
    datepickerLanguageName = $('#datepickerLanguageName').val();
    //Configure input validations
    $('.literal').validateLiteral();
    $('.alphabetic').validateAlphabetic(false);
    $('.alphanumeric').validateAlphanumeric(false);
    $('.integer').validateCurrency(true, '', 0, false);
    $('.unsigned-integer').validateCurrency(false, '', 0, false);
    $('.numeric').validateCurrency(true, numberDecimalSeparator, numberDecimalDigits, false);
    $('.unsigned-numeric').validateCurrency(false, numberDecimalSeparator, numberDecimalDigits, false);
    $('.currency').validateCurrency(true, currencyDecimalSeparator, currencyDecimalDigits, false);
    $('.unsigned-currency').validateCurrency(false, currencyDecimalSeparator, currencyDecimalDigits, false);
    $('.spaced-alphabetic').validateAlphabetic(true);
    $('.spaced-alphanumeric').validateAlphanumeric(true);
    $('.spaced-integer').validateCurrency(true, '', 0, true);
    $('.spaced-unsigned-integer').validateCurrency(false, '', 0, true);
    $('.spaced-numeric').validateCurrency(true, numberDecimalSeparator, numberDecimalDigits, true);
    $('.spaced-unsigned-numeric').validateCurrency(false, numberDecimalSeparator, numberDecimalDigits, true);
    $('.spaced-currency').validateCurrency(true, currencyDecimalSeparator, currencyDecimalDigits, true);
    $('.spaced-unsigned-currency').validateCurrency(false, currencyDecimalSeparator, currencyDecimalDigits, true);
    $('.datepicker').validateDate(datepickerDateFormat, datepickerLanguageName);
    $('.phone').validatePhone();
    $('.email').validateEmail();
    $('.regex').validateRegex();
    //Configure mask validations
    //NOTE: Mask to apply is searched in mask attribute
    $('.masked').each(function () {
        var mask = $(this).attr('mask');
        if (mask != null && mask.length > 0)
            $(this).mask(mask);
    });
    //Configure ToolTips
    $('[title]').bind('focus', function () {
        $(this).tooltip('show');
    });
    $('[title]').bind('blur', function () {
        $(this).tooltip('hide');
    });
    //Initialize vertical menues
    $('.vertical-menu').verticalMenuInit();
});

function trim(value) {
    return value.replace(/^\s+|\s+$/g, '');
}

function isControlKey(e) {
    //Control keys for FireFox
    if (e.which == 0) {
        return true;
    }
    //Key validations for Firefox or IE -- BackSPace(8), Return(13), Esc(27)
    if (e.which == e.keyCode && (e.keyCode == 8 || e.keyCode == 13 || e.keyCode == 27)) {
        return true;
    }
    //Everything else is rejected
    return false;
}

function isExpressionKey(e, reggex, allowSpacebar) {
    //IE: which and keyCode are equal - FireFox: keyCode is zero
    if (e.which == e.keyCode || e.keyCode == 0) {
        if (e.which == 32 && allowSpacebar) {
            return true;
        }
        return reggex.test(String.fromCharCode(e.which));
    }
    return false;
}

function validateKeyPress(e, reggex, allowSpacebar) {
    //All control keys are allowed
    if (isControlKey(e)) {
        return true;
    } else {
        return isExpressionKey(e, reggex, allowSpacebar);
    }
}

function parseNumeric(value, decimalSeparator) {
    var numericValue = undefined;
    if (value != undefined && value.length > 0) {
        if (decimalSeparator == undefined || decimalSeparator.length == 0) {
            numericValue = parseFloat(value);
        } else {
            //Before to convert, replaces custom decimal separator for user process decimal separator
            numericValue = parseFloat(value.replace(decimalSeparator[0], (1.1).toLocaleString().substring(1, 2)));
        }
    }
    return numericValue;
}

/**************************** INPUT VALIDATIONS ****************************/

$.fn.validateLiteral = function () {
    $(this).blur(function (e) {
        e.target.value = trim(e.target.value);
    });
}

$.fn.validateAlphabetic = function (allowSpacebar) {
    $(this).keypress(function (e) {
        var reggex = /[a-zA-ZñÑáéíóúÁÉÍÓÚäëïöüÄËÏÖÜàèìòùÀÈÌÒÙ]/;
        return validateKeyPress(e, reggex, allowSpacebar);
    });
    $(this).blur(function (e) {
        e.target.value = trim(e.target.value);
    });
}

$.fn.validateAlphanumeric = function (allowSpacebar) {
    $(this).keypress(function (e) {
        var reggex = /[0-9a-zA-ZñÑáéíóúÁÉÍÓÚäëïöüÄËÏÖÜàèìòùÀÈÌÒÙ]/;
        return validateKeyPress(e, reggex, allowSpacebar);
    });
    $(this).blur(function (e) {
        e.target.value = trim(e.target.value);
    });
}

$.fn.validateCurrencyValue = function (decimalSeparator) {
    var values = [];
    var valid = true;
    var min = parseNumeric($(this).attr('min'), decimalSeparator);
    var max = parseNumeric($(this).attr('max'), decimalSeparator);
    var num = 0;
    if ($(this).val() != undefined) {
        if (decimalSeparator == undefined || decimalSeparator.length == 0) {
            values = $(this).val().split(' ');
        } else {
            values = $(this).val().replace(decimalSeparator[0], '#').split(' ');
        }
    }
    if (values.length > 0) {
        $.each(values, function (key, value) {
            num = parseNumeric(value, '#');
            if (num != undefined) {
                if (isNaN(num)) {
                    valid = false;
                    return false; //means break;
                } else if (!isNaN(min) && num < min) {
                    valid = false;
                    return false; //means break
                } else if (!isNaN(max) && num > max) {
                    valid = false;
                    return false; //means break
                }
            }
        });
    }
    if (valid) {
        $(this).removeClass('invalid-field');
    } else {
        $(this).addClass('invalid-field');
    }
}

$.fn.validateCurrency = function (signed, decimalSeparator, decimalDigits, allowSpacebar) {
    $(this).keypress(function (e) {
        var isDecimal = decimalDigits > 0 && decimalSeparator.length > 0
        var baseExpression = '0-9' + (!isDecimal ? '' : '\\' + decimalSeparator[0]);
        var signedReggex = new RegExp('[\\-' + baseExpression + ']');
        var unsignedReggex = new RegExp('[' + baseExpression + ']');
        var result = false;
        if (isControlKey(e)) {
            result = true;
        } else if (isExpressionKey(e, (signed ? signedReggex : unsignedReggex), allowSpacebar)) {
            var key = e.which;
            var value = e.target.value;
            var start = e.target.selectionStart;
            var end = e.target.selectionEnd;
            var previous = (start == 0) ? '' : value.substring(0, start);
            var next = (end == value.length) ? '' : value.substring(end);
            var index = 0;
            if ((index = previous.lastIndexOf(' ')) != -1)
                previous = previous.substring(index + 1);
            if ((index = next.indexOf(' ')) != -1)
                next = next.substring(0, index);
            if (isDecimal && String.fromCharCode(key) == decimalSeparator[0]) {
                result = (previous.indexOf(decimalSeparator[0]) == -1 && next.indexOf(decimalSeparator[0]) == -1 && next.indexOf('-') == -1 && next.length <= decimalDigits);
            } else if (String.fromCharCode(key) == '-') {
                result = (previous.length == 0 && next.indexOf('-') == -1);
            } else if (String.fromCharCode(key) == ' ') {
                result = (previous.length == 0 || previous.length > 0 && previous[previous.length - 1] != '-');
            } else {
                index = (!isDecimal ? -1 : previous.indexOf(decimalSeparator[0]));
                result = (next.indexOf('-') == -1 && (index == -1 || index != -1 && previous.length - index - 1 + next.length < decimalDigits))
            }
        }
        return result;
    });
    $(this).blur(function (e) {
        var value = e.target.value;
        var index = value.length - 1;
        var isDecimal = (decimalDigits > 0 && decimalSeparator.length > 0);
        while (index >= 0) {
            var char = value.substring(index, index + 1);
            var previous = (index == 0) ? '' : value.substring(0, index);
            var next = value.substring(index + 1)
            if (char == ' ' && (previous.length == 0 || previous[previous.length - 1] == ' ' || next.length == 0 || next[0] == ' '))
                value = previous + next;
            else if (char == '-' && (previous.length == 0 || previous[previous.length - 1] == ' ') && (next.length == 0 || next[0] == ' '))
                value = previous + next;
            else if (isDecimal && char == decimalSeparator[0]) {
                if ((next.length == 0 || next[0] == ' '))
                    value = previous + next;
                else if (previous.length == 0 || previous[previous.length - 1] == ' ' || previous[previous.length - 1] == '-')
                    value = previous + '0' + char + next;
            }
            index--;
        }
        e.target.value = trim(value);
    });
    $(this).validateCurrencyValue(decimalSeparator);
    $(this).bind('keyup change blur', function () {
        $(this).validateCurrencyValue(decimalSeparator);
    });
}

$.fn.validateDate = function (dateFormat, languageName) {
    //$(this).datepicker({ changeMonth: true, changeYear: true, minDate: new Date(1900, 1 - 1, 1), yearRange: "-100:+0", dateFormat: dateFormat });
    $(this).datepicker({
        language: languageName,
        format:dateFormat,
        autoclose: true,
        todayHighlight: true
    });
    //$(this).datepicker($.datepicker.regional[languageName]);
    $(this).prop('readOnly', true);
}

$.fn.validatePhoneValue = function () {
    var filter = /^(((\+|00)[1-9]{1,3}(\(\d{1,3}\)|\-?\d{1,3}\-?))|(\(\d{1,3}\)|\d{1,3}\-?))?\d{5,11}$/i;
    if ($(this).val() == '' || filter.test($(this).val())) {
        $(this).removeClass('invalid-field');
    } else {
        $(this).addClass('invalid-field');
    }
}

$.fn.validatePhone = function () {
    $(this).keypress(function (e) {
        var reggex = /[0-9\+\-\(\)]/;
        return validateKeyPress(e, reggex, false);
    });
    $(this).validatePhoneValue();
    $(this).bind('keyup change', function () {
        $(this).validatePhoneValue();
    });
}

$.fn.validateEmailValue = function () {
    var filter = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
    if ($(this).val() == '' || filter.test($(this).val())) {
        $(this).removeClass('invalid-field');
    } else {
        $(this).addClass('invalid-field');
    }
}

$.fn.validateEmail = function () {
    $(this).keypress(function (e) {
        var reggex = /[0-9a-zA-Z\_\-\.\@]/;
        return validateKeyPress(e, reggex, false);
    });
    $(this).validateEmailValue();
    $(this).bind('keyup change', function () {
        $(this).validateEmailValue();
    });
}

$.fn.validateRegexValue = function (regex) {
    var regexVal = $(this).attr('regex');
    if (regexVal != undefined && regexVal.length > 0) {
        if ($(this).val() == '' || (new RegExp(regexVal, 'i')).test($(this).val())) {
            $(this).removeClass('invalid-field');
        } else {
            $(this).addClass('invalid-field');
        }
    }
}

$.fn.validateRegex = function () {
    $(this).validateRegexValue();
    $(this).bind('keyup change', function () {
        $(this).validateRegexValue();
    });
}

$.fn.validateEqualityValue = function () {
    var valueToCompare = '';
    var isValid = true;
    $(this).each(function () {
        var value = $(this).val();
        if (value != undefined && value != '') {
            if (valueToCompare == '') {
                valueToCompare = value;
            } else if (valueToCompare != value) {
                isValid = false;
            }
        }
    });
    if (isValid) {
        $(this).removeClass('invalid-equality');
    } else {
        $(this).addClass('invalid-equality');
    }
}

//Allows to validate that all members of invoker selector have same value
$.fn.validateEquality = function () {
    var selection = $(this);
    selection.validateEqualityValue();
    selection.bind('keyup change', function () {
        selection.validateEqualityValue();
    });
}

//invalid-custom: It can be only used by user for custom validations in a page.
//It must not be used for general propose validations. 
$.fn.validateCounters = function (counters) {
    if ($(this).hasClass('invalid-field') ||
        $(this).hasClass('invalid-equality') ||
        $(this).hasClass('invalid-custom')) {
        counters.invalidFields++;
    }
}

var validateHandler = [];
$.fn.addValidateHandler = function (main, options) {
    if ($.inArray($(this)[0], validateHandler) == -1) {
        $(this).bind('keyup change blur.mask', function () {
            $(main).validate(options);
        });
        validateHandler.push($(this)[0]);
    }
}

//[validationGroup]: Sets the validationGroup attribute value for validation
//[validateFields]: Enable/disable validation for fields values
//[actionButton]: Selector of the button(s) to activate/deactivate on validation
//[successMessageItem]: Selector of the element(s) to show on validation success
//[errorMessageItem]: Selector of the element(s) to show on validation error
$.fn.validate = function (options) {
    var defaults = { validationGroup: '', validateFields: true, actionButton: '', successMessageItem: '[controlID=masterValidationSuccessMessage]', errorMessageItem: '[controlID=masterValidationErrorMessage]' };
    var opts = $.extend(defaults, options);
    var counters = { missingFields: 0, invalidFields: 0 }
    var main = $(this);
    $(main).find('.required, input[type!="hidden"]').each(function () {
        var validationGroup = $(this).attr('validationGroup') == null ? '' : $(this).attr('validationGroup');
        if (validationGroup == opts.validationGroup) {
            if ($(this).hasClass('required')) {
                if ($(this).val() == null || trim($(this).val()) == '' || $(this).val() == $(this).attr('unselectedValue')) {
                    var parent = $(this).parent();
                    parent.addClass('has-error has-feedback');
                    parent.append('<span class="glyphicon glyphicon-remove form-control-feedback"></span>');

                    counters.missingFields++;
                } else {
                    var parent = $(this).parent();
                    parent.removeClass('has-error has-feedback');
                    parent.find('span').remove();
                    parent.addClass('has-success has-feedback');
                    parent.append('<span class="glyphicon glyphicon-ok form-control-feedback"></span>');
                }
            }
            $(this).validateCounters(counters);
            $(this).addValidateHandler(main, options);
        }
    });
    if (counters.missingFields == 0 && (counters.invalidFields == 0 || !opts.validateFields)) {
        if (opts.successMessageItem != '')
            $(opts.successMessageItem).show();
        if (opts.errorMessageItem != '')
            $(opts.errorMessageItem).hide();
        if (opts.actionButton != '') {
            $(opts.actionButton).attr("disabled", false);
            $(opts.actionButton).removeClass('disabled');
        }
    } else {
        if (opts.successMessageItem != '')
            $(opts.successMessageItem).hide();
        if (opts.errorMessageItem != '')
            $(opts.errorMessageItem).show();
        if (opts.actionButton != '') {
            $(opts.actionButton).attr("disabled", true);
            $(opts.actionButton).addClass('disabled');
        }
    }
}

/**************************** TOOLTIP MANAGEMENT ****************************/

//[toolTipText]: Sets the text to show
//[toolTipPosition]: Sets the position for the toolTip ballon <top|bottom|left|right>
$.fn.showToolTip = function () {
    var toolTipText = $(this).attr('toolTipText');
    var position = $(this).attr('toolTipPosition');
    $('table.toolTip').remove();
    if (toolTipText != undefined) {
        toolTipText = trim(toolTipText);
        if (toolTipText.length > 0) {
            if (position != 'top' && position != 'bottom' && position != 'left' && position != 'right') {
                position = 'right';
            }
            var toolTipObject = $('<div class="toolTip ' + position + '"><div class="pointer" /><div class="text">' + toolTipText + '</div></div>');
            $(toolTipObject).appendTo($(this).parent());
            $(toolTipObject).attr('z-order', $(this).attr('z-order'));
            var offset = $(this).offset();
            switch (position) {
                case 'top': $(toolTipObject).offset({ top: offset.top - $(toolTipObject).outerHeight() + 2, left: offset.left - ($(toolTipObject).outerWidth() - $(this).outerWidth()) / 2 });
                    break;
                case 'bottom': $(toolTipObject).offset({ top: offset.top + $(this).outerHeight() + 1, left: offset.left - ($(toolTipObject).outerWidth() - $(this).outerWidth()) / 2 });
                    break;
                case 'left': $(toolTipObject).offset({ top: offset.top - ($(toolTipObject).outerHeight() - $(this).outerHeight()) / 2, left: offset.left - $(toolTipObject).outerWidth() - 1 });
                    break;
                case 'right': $(toolTipObject).offset({ top: offset.top - ($(toolTipObject).outerHeight() - $(this).outerHeight()) / 2, left: offset.left + $(this).outerWidth() + 1 });
                    break;
            }
        }
    }
}

$.fn.hideToolTip = function () {
    $('div.toolTip').remove();
}

/**************************** VERTICAL MENU BEHAVIOR ****************************/

var menuItemHandler = [];
$.fn.addMenuItemHandler = function (menu) {
    if ($.inArray($(this)[0], menuItemHandler) == -1) {
        $(this).click(function () {
            var key = menu.find('input[type=hidden]')
            var ul = $(this).next('ul');
            if (ul != undefined && ul.length > 0) {
                if (ul.is(':visible')) {
                    ul.find('ul:visible').slideUp(100);
                    ul.slideUp(100);
                    key.val($(this).parents('ul:first').not(menu.find('ul:first')).prev('div').attr('key'));
                } else {
                    ul.slideDown(100);
                    ul.parents('ul:first').find('ul:visible').not(ul).slideUp(100);
                    key.val($(this).attr('key'));
                }
            }
        });
        menuItemHandler.push($(this)[0])
    }
}

$.fn.verticalMenuInit = function () {
    var menu = $(this);
    var val = menu.find('input[type=hidden]').val();
    menu.find('ul ul').hide();
    if (val != undefined && val.length > 0) {
        var div = menu.find('div[key="' + val + '"]');
        if (div != undefined && div.length > 0) {
            div.parents('ul').not(menu.parents('ul')).show();
            div.next('ul').show();
        }
    }
    menu.find('div.menu-header').each(function () {
        $(this).addMenuItemHandler(menu);
    });
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////

function setCookie(name, value) {
    var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

function getCookie(c_name) {
    var i, x, y, ARRcookies = document.cookie.split(";");
    for (i = 0; i < ARRcookies.length; i++) {
        x = ARRcookies[i].substr(0, ARRcookies[i].indexOf("="));
        y = ARRcookies[i].substr(ARRcookies[i].indexOf("=") + 1);
        x = x.replace(/^\s+|\s+$/g, "");
        if (x == c_name) {
            return unescape(y);
        }
    }
}

function MoveListItems(source, target) {
    $('#' + source + ' option:selected').appendTo('#' + target);
}

function GetCommaSeparatedValues(source, target) {
    $('#' + target).val($('#' + source).find('option').map(function () { return this.value; }).get().join(','));
};

function setCatalogItem(obj) {
    $('#' + $(obj).closest('.catalogSection').find('.hiddenCode').val()).val($(obj).attr('internalcode'));
    $('#' + $(obj).closest('.catalogSection').find('.hiddenDescription').val()).val($(obj).html());
    closeFlyout($(obj));
};
