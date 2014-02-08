/*
Masked Input plugin for jQuery
Copyright (c) 2007-2013 Josh Bush (digitalbush.com)
Licensed under the MIT license (http://digitalbush.com/projects/masked-input-plugin/#license)
Version: 1.3.1
*/
(function ($) {
    function getPasteEvent() {
        var el = document.createElement('input'),
        name = 'onpaste';
        el.setAttribute(name, '');
        return (typeof el[name] === 'function') ? 'paste' : 'input';
    }

    var pasteEventName = getPasteEvent() + ".mask",
	ua = navigator.userAgent,
	iPhone = /iphone/i.test(ua),
	android = /android/i.test(ua),
	caretTimeoutId;

    $.mask = {
        //Predefined character definitions
        definitions: {
            //Obligatory
            '&': "[\\S]",
            'L': "[A-Za-z]",
            '0': "[0-9]",
            'A': "[0-9A-Za-z]",
            //Optional
            'C': ".",
            '?': "[A-Za-z\\s]",
            '9': "[0-9\\s]",
            '#': "[0-9\\+\\-\\s]",
            'a': "[0-9A-Za-z\\s]"
            //Special
            //'\': Following character will be displayed literally - Already implemented
            //'>': All characters to follow are converted to uppercase - Not implemented
            //'<': All characters to follow are converted to lowercase - Not implemented
            //'!': Mask is filled left to right - Not implemented
            //'""': Characters enclosed will be displayed literally - Not implemented
        },
        dataName: "rawMaskFn",
        placeholder: '_'
    };

    $.fn.extend({
        //Helper Function for Caret positioning
        caret: function (begin, end) {
            var range;

            if (this.length === 0 || this.is(":hidden")) {
                return;
            }

            if (typeof begin == 'number') {
                end = (typeof end === 'number') ? end : begin;
                return this.each(function () {
                    if (this.setSelectionRange) {
                        this.setSelectionRange(begin, end);
                    } else if (this.createTextRange) {
                        range = this.createTextRange();
                        range.collapse(true);
                        range.moveEnd('character', end);
                        range.moveStart('character', begin);
                        range.select();
                    }
                });
            } else {
                if (this[0].setSelectionRange) {
                    begin = this[0].selectionStart;
                    end = this[0].selectionEnd;
                } else if (document.selection && document.selection.createRange) {
                    range = document.selection.createRange();
                    begin = 0 - range.duplicate().moveStart('character', -100000);
                    end = begin + range.text.length;
                }
                return { begin: begin, end: end };
            }
        },
        unmask: function () {
            return this.trigger("unmask");
        },
        mask: function (mask, settings) {
            var input,
			defs,
			tests,
			partialPosition,
			firstNonMaskPos,
			len,
            setLiteralChar;

            if (!mask && this.length > 0) {
                input = $(this[0]);
                return input.data($.mask.dataName)();
            }
            settings = $.extend({
                placeholder: $.mask.placeholder, // Load default placeholder
                completed: null
            }, settings);

            defs = $.mask.definitions;
            tests = [];
            firstNonMaskPos = null;
            setLiteralChar = false;

            $.each(mask.split(""), function (i, c) {
                if (setLiteralChar) {
                    setLiteralChar = false;
                    tests.push(null);
                } else if (c == '\\') {
                    setLiteralChar = true;
                } else if (defs[c]) {
                    tests.push(new RegExp(defs[c]));
                    if (firstNonMaskPos === null) {
                        firstNonMaskPos = tests.length - 1;
                    }
                } else {
                    tests.push(null);
                }
            });

            partialPosition = len = tests.length;

            return this.trigger("unmask").each(function () {
                var input = $(this),
				focusText = input.val(),
				buffer = [];
                setLiteralChar = false;

                $.each(mask.split(""), function (i, c) {
                    if (setLiteralChar) {
                        setLiteralChar = false;
                        buffer.push(c);
                    } else if (c == '\\') {
                        setLiteralChar = true;
                    } else if (defs[c]) {
                        buffer.push(settings.placeholder);
                    } else {
                        buffer.push(c);
                    }
                });

                function seekNext(pos) {
                    while (++pos < len && !tests[pos]);
                    return pos;
                }

                function seekPrev(pos) {
                    while (--pos >= 0 && !tests[pos]);
                    return pos;
                }

                function shiftL(begin, end) {
                    var i,
					j;

                    if (begin < 0) {
                        return;
                    }

                    for (i = begin, j = seekNext(end); i < len; i++) {
                        if (tests[i]) {
                            if (j < len && tests[i].test(buffer[j])) {
                                buffer[i] = buffer[j];
                                buffer[j] = settings.placeholder;
                            } else {
                                break;
                            }

                            j = seekNext(j);
                        }
                    }
                    writeBuffer();
                    input.caret(Math.max(firstNonMaskPos, begin));
                }

                function shiftR(pos) {
                    var i,
					c,
					j,
					t;

                    for (i = pos, c = settings.placeholder; i < len; i++) {
                        if (tests[i]) {
                            j = seekNext(i);
                            t = buffer[i];
                            buffer[i] = c;
                            if (j < len && tests[j].test(t)) {
                                c = t;
                            } else {
                                break;
                            }
                        }
                    }
                }

                function keydownEvent(e) {
                    var k = e.which,
					pos,
					begin,
					end;

                    //backspace, delete, and escape get special treatment
                    if (k === 8 || k === 46 || (iPhone && k === 127)) {
                        pos = input.caret();
                        begin = pos.begin;
                        end = pos.end;

                        if (end - begin === 0) {
                            begin = k !== 46 ? seekPrev(begin) : (end = seekNext(begin - 1));
                            end = k === 46 ? seekNext(end) : end;
                        }
                        clearBuffer(begin, end);
                        shiftL(begin, end - 1);

                        e.preventDefault();
                    } else if (k == 27) {//escape
                        input.val(focusText);
                        input.caret(0, checkVal());
                        e.preventDefault();
                    }
                }

                function keypressEvent(e) {
                    var k = e.which,
					pos = input.caret(),
					p,
					c,
					next;

                    if (e.ctrlKey || e.altKey || e.metaKey || k < 32) {//Ignore
                        return;
                    } else if (k) {
                        if (pos.end - pos.begin !== 0) {
                            clearBuffer(pos.begin, pos.end);
                            shiftL(pos.begin, pos.end - 1);
                        }

                        p = seekNext(pos.begin - 1);
                        if (p < len) {
                            c = String.fromCharCode(k);
                            if (c == settings.placeholder) c = ' ';
                            if (tests[p].test(c)) {
                                shiftR(p);

                                buffer[p] = (c == ' ' ? settings.placeholder : c);
                                writeBuffer();
                                next = seekNext(p);

                                if (android) {
                                    setTimeout($.proxy($.fn.caret, input, next), 0);
                                } else {
                                    input.caret(next);
                                }

                                if (settings.completed && next >= len) {
                                    settings.completed.call(input);
                                }
                            }
                        }
                        e.preventDefault();
                    }
                }

                function clearBuffer(start, end) {
                    var i;
                    for (i = start; i < end && i < len; i++) {
                        if (tests[i]) {
                            buffer[i] = settings.placeholder;
                        }
                    }
                }

                function writeBuffer() { input.val(buffer.join('')); }

                function checkVal(allow) {
                    //try to place characters where they belong
                    var test = input.val(),
					lastMatch = -1,
					i,
					c,
                    empty = true;

                    for (i = 0, pos = 0; i < len; i++) {
                        if (tests[i]) {
                            buffer[i] = settings.placeholder;
                            while (pos++ < test.length) {
                                c = test.charAt(pos - 1);
                                if (c == settings.placeholder) c = ' ';
                                if (tests[i].test(c)) {
                                    if (c != ' ') {
                                        empty = false;
                                        buffer[i] = c;
                                    }
                                    lastMatch = i;
                                    break;
                                }
                            }
                            if (pos > test.length) {
                                break;
                            }
                        } else if (buffer[i] === test.charAt(pos) && i !== partialPosition) {
                            pos++;
                            lastMatch = i;
                        }
                    }
                    if (allow) {
                        writeBuffer();
                    } else if (lastMatch + 1 < partialPosition) {
                        if (!empty) {
                            for (i = lastMatch + 1; i < len; i++)
                                if (tests[i])
                                    if (tests[i].test(' ')) {
                                        buffer[i] = settings.placeholder;
                                    } else {
                                        empty = true;
                                        break;
                                    }
                        }
                        if (empty) {
                            input.val("");
                            clearBuffer(0, len);
                        }
                    } else {
                        writeBuffer();
                        input.val(empty ? '' : input.val().substring(0, lastMatch + 1));
                    }
                    return (partialPosition ? i : firstNonMaskPos);
                }

                function removePlaceholders() {
                    if (input.val() != "") {
                        for (i = 0; i < len; i++)
                            if (tests[i] && buffer[i] == settings.placeholder)
                                buffer[i] = ' ';
                        writeBuffer();
                        input.val(input.val().replace(/\s+$/, ""));
                    }
                }

                input.data($.mask.dataName, function () {
                    return $.map(buffer, function (c, i) {
                        return tests[i] && c != settings.placeholder ? c : null;
                    }).join('');
                });

                if (!input.attr("readonly"))
                    input
				.one("unmask", function () {
				    input
						.unbind(".mask")
						.removeData($.mask.dataName);
				})
				.bind("focus.mask", function () {
				    clearTimeout(caretTimeoutId);
				    var pos,
						moveCaret,
                        i;

				    focusText = input.val();
				    pos = checkVal();

				    for (i = 0; i < len; i++)
				        if (tests[i] && buffer[i] == ' ')
				            buffer[i] = settings.placeholder;

				    caretTimeoutId = setTimeout(function () {
				        writeBuffer();
				        if (pos == len) {
				            input.caret(0, pos);
				        } else {
				            input.caret(pos);
				        }
				    }, 10);
				})
				.bind("blur.mask", function () {
				    checkVal();
				    removePlaceholders();
				    if (input.val() != focusText)
				        input.change();
				})
				.bind("keydown.mask", keydownEvent)
				.bind("keypress.mask", keypressEvent)
				.bind(pasteEventName, function () {
				    setTimeout(function () {
				        var pos = checkVal(true);
				        input.caret(pos);
				        if (settings.completed && pos == input.val().length)
				            settings.completed.call(input);
				    }, 0);
				});
                checkVal(); //Perform initial check for existing values
                removePlaceholders();
            });
        }
    });


})(jQuery);