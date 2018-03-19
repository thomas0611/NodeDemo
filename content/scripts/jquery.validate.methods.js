(function() {

    function stripHtml(value) {
        // remove html tags and space chars
        return value.replace(/<.[^<>]*?>/g, ' ').replace(/&nbsp;|&#160;/gi, ' ')
            // remove numbers and punctuation
            .replace(/[0-9.(),;:!?%#$'"_+=\/-]*/g, '');
    }
    jQuery.validator.addMethod("maxWords", function(value, element, params) {
        return this.optional(element) || stripHtml(value).match(/\b\w+\b/g).length < params;
    }, jQuery.validator.format("Please enter {0} words or less."));

    jQuery.validator.addMethod("minWords", function(value, element, params) {
        return this.optional(element) || stripHtml(value).match(/\b\w+\b/g).length >= params;
    }, jQuery.validator.format("Please enter at least {0} words."));

    jQuery.validator.addMethod("rangeWords", function(value, element, params) {
        return this.optional(element) || stripHtml(value).match(/\b\w+\b/g).length >= params[0] && value.match(/bw+b/g).length < params[1];
    }, jQuery.validator.format("Please enter between {0} and {1} words."));

})();

//验证电话号码
jQuery.validator.addMethod("checkTel", function(value, element) {
    //可以匹配座机号码，形式如0511-12345678-1234，其中区号可以3位或4位或没有，直拨号码可以7位或8位，分机号可以为0至4位    
    var tel = /^(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}(-\d{1,4})?$/;
    return this.optional(element) || (tel.test(value));
}, "请输入有效的电话");

jQuery.validator.addMethod("checkMobile", function(value, element) {

    var reg0 = /^13\d{5,9}$/;

    var reg1 = /^15\d{5,9}$/;

    var reg2 = /^189\d{4,8}$/;

    var reg3 = /^0\d{10,11}$/;

    var my = false;

    if (reg0.test(value)) my = true;

    if (reg1.test(value)) my = true;

    if (reg2.test(value)) my = true;

    if (reg3.test(value)) my = true;

    if (value != '') { if (!my) { return false; } };

    return true;

}, " 请输入有效的手机号码");

jQuery.validator.addMethod("letterswithbasicpunc", function(value, element) {
    return this.optional(element) || /^[a-z-.,()'\"\s]+$/i.test(value);
}, "Letters or punctuation only please");

jQuery.validator.addMethod("alphanumeric", function(value, element) {
    return this.optional(element) || /^\w+$/i.test(value);
}, "Letters, numbers, spaces or underscores only please");

jQuery.validator.addMethod("lettersonly", function(value, element) {
    return this.optional(element) || /^[a-z]+$/i.test(value);
}, "Letters only please");

jQuery.validator.addMethod("nowhitespace", function(value, element) {
    return this.optional(element) || /^\S+$/i.test(value);
}, "No white space please");

jQuery.validator.addMethod("ziprange", function(value, element) {
    return this.optional(element) || /^90[2-5]\d\{2}-\d{4}$/.test(value);
}, "Your ZIP-code must be in the range 902xx-xxxx to 905-xx-xxxx");

jQuery.validator.addMethod("integer", function(value, element) {
    return this.optional(element) || /^-?\d+$/.test(value);
}, "A positive or negative non-decimal number please");

// 正数验证
jQuery.validator.addMethod("positive", function(value, element) {
    if (value > 0) {
        return true;
    } else {
        return false;
    }
}, "非正数!");

// 正数保留2位小数
jQuery.validator.addMethod("positiveMoney", function(value, element) {
    var ma = /^\d+(\.\d{1,2})?$/;
    return this.optional(element) || (ma.test(value));
}, "最多保留2位小数");

// 正数验证非必填
jQuery.validator.addMethod("positiveNoRequired", function(value, element) {
    var ma = /^[+]?[\d]+(([\.]{1}[\d]+)|([\d]*))$/;
    return this.optional(element) || (ma.test(value));
}, "非正数!");

// 正整数验证
jQuery.validator.addMethod("positiveInteger", function(value, element) {
    var tel = /^[1-9]\d*$/;
    return this.optional(element) || (tel.test(value));
}, "非正整数!");

// 手机号码验证
jQuery.validator.addMethod("mobile", function(value, element) {
    var length = value.length;
    return this.optional(element) || (/^[1][0-9]{10}$/.test(value));
}, "手机号码格式错误,请重新输入!");

// 电话号码验证
jQuery.validator.addMethod("phone", function(value, element) {
    var phone = /((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/;
    return this.optional(element) || (phone.test(value));
}, "电话号码格式错误,请重新输入!");

//联系方式验证
jQuery.validator.addMethod("contactWay", function(value, element) {
    //var contactWay = /^(\d)+-?(\d)+$/;
    var regPhone = /^1[3-8]\d{9}$/;
    var regTel = /^((0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$/;
    return this.optional(element) || (regPhone.test(value) || regTel.test(value));
}, "联系方式格式错误,请重新输入!");

// 邮政编码验证
jQuery.validator.addMethod("zipCode", function(value, element) {
    var zip = /^[0-9]{6}$/;
    return this.optional(element) || (zip.test(value));
}, "邮政编码格式错误,请重新输入!");

// 若指定元素为不为空则此元素也为必填
jQuery.validator.addMethod("requiredTo", function(value, element, param) {
    var requiredTo = $(param).val();
    if (requiredTo != "") {
        return value != "";
    } else {
        return true;
    }
}, "此内容为必填项,请输入!");

// 指定元素与此元素必须填写其中一项
jQuery.validator.addMethod("requiredOne", function(value, element, param) {
    var requiredOne = $(param).val();
    if (requiredOne == "") {
        return value != "";
    } else {
        return true;
    }
}, $.validator.format("两项必须填写一项!"));

// 用户名字符串验证
jQuery.validator.addMethod("username", function(value, element) {
    return this.optional(element) || /^[\u0391-\uFFE5\w]+$/.test(value);
}, "只允许包含中文、英文、数字和下划线!");

// 字符串前缀验证
jQuery.validator.addMethod("prefix", function(value, element, param) {
    var prefix = new RegExp("^" + param);
    return this.optional(element) || (prefix.test(value));
}, $.validator.format("请输入以 {0} 开头的字符串!"));

// 验证值不允许与特定值等于
jQuery.validator.addMethod("notEqual", function(value, element, param) {
    return value != param;
}, $.validator.format("输入值不允许为{0}!"));

/**
 * Return true, if the value is a valid vehicle identification number (VIN).
 *
 * Works with all kind of text inputs.
 *
 * @example <input type="text" size="20" name="VehicleID" class="{required:true,vinUS:true}" />
 * @desc Declares a required input element whose value must be a valid vehicle identification number.
 *
 * @name jQuery.validator.methods.vinUS
 * @type Boolean
 * @cat Plugins/Validate/Methods
 */
jQuery.validator.addMethod(
    "vinUS",
    function(v) {
        if (v.length != 17)
            return false;
        var i, n, d, f, cd, cdv;
        var LL = ["A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];
        var VL = [1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 7, 9, 2, 3, 4, 5, 6, 7, 8, 9];
        var FL = [8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2];
        var rs = 0;
        for (i = 0; i < 17; i++) {
            f = FL[i];
            d = v.slice(i, i + 1);
            if (i == 8) {
                cdv = d;
            }
            if (!isNaN(d)) {
                d *= f;
            } else {
                for (n = 0; n < LL.length; n++) {
                    if (d.toUpperCase() === LL[n]) {
                        d = VL[n];
                        d *= f;
                        if (isNaN(cdv) && n == 8) {
                            cdv = LL[n];
                        }
                        break;
                    }
                }
            }
            rs += d;
        }
        cd = rs % 11;
        if (cd == 10) { cd = "X"; }
        if (cd == cdv) { return true; }
        return false;
    },
    "The specified vehicle identification number (VIN) is invalid."
);

/**
 * Return true, if the value is a valid date, also making this formal check dd/mm/yyyy.
 *
 * @example jQuery.validator.methods.date("01/01/1900")
 * @result true
 *
 * @example jQuery.validator.methods.date("01/13/1990")
 * @result false
 *
 * @example jQuery.validator.methods.date("01.01.1900")
 * @result false
 *
 * @example <input name="pippo" class="{dateITA:true}" />
 * @desc Declares an optional input element whose value must be a valid date.
 *
 * @name jQuery.validator.methods.dateITA
 * @type Boolean
 * @cat Plugins/Validate/Methods
 */
jQuery.validator.addMethod(
    "dateITA",
    function(value, element) {
        var check = false;
        var re = /^\d{1,2}\/\d{1,2}\/\d{4}$/;
        if (re.test(value)) {
            var adata = value.split('/');
            var gg = parseInt(adata[0], 10);
            var mm = parseInt(adata[1], 10);
            var aaaa = parseInt(adata[2], 10);
            var xdata = new Date(aaaa, mm - 1, gg);
            if ((xdata.getFullYear() == aaaa) && (xdata.getMonth() == mm - 1) && (xdata.getDate() == gg))
                check = true;
            else
                check = false;
        } else
            check = false;
        return this.optional(element) || check;
    },
    "Please enter a correct date"
);

jQuery.validator.addMethod("dateNL", function(value, element) {
    return this.optional(element) || /^\d\d?[\.\/-]\d\d?[\.\/-]\d\d\d?\d?$/.test(value);
}, "Vul hier een geldige datum in.");

jQuery.validator.addMethod("time", function(value, element) {
    return this.optional(element) || /^([01][0-9])|(2[0123]):([0-5])([0-9])$/.test(value);
}, "Please enter a valid time, between 00:00 and 23:59");

/**
 * matches US phone number format 
 * 
 * where the area code may not start with 1 and the prefix may not start with 1 
 * allows '-' or ' ' as a separator and allows parens around area code 
 * some people may want to put a '1' in front of their number 
 * 
 * 1(212)-999-2345
 * or
 * 212 999 2344
 * or
 * 212-999-0983
 * 
 * but not
 * 111-123-5434
 * and not
 * 212 123 4567
 */
jQuery.validator.addMethod("phoneUS", function(phone_number, element) {
    phone_number = phone_number.replace(/\s+/g, "");
    return this.optional(element) || phone_number.length > 9 &&
        phone_number.match(/^(1-?)?(\([2-9]\d{2}\)|[2-9]\d{2})-?[2-9]\d{2}-?\d{4}$/);
}, "Please specify a valid phone number");

jQuery.validator.addMethod('phoneUK', function(phone_number, element) {
    return this.optional(element) || phone_number.length > 9 &&
        phone_number.match(/^(\(?(0|\+44)[1-9]{1}\d{1,4}?\)?\s?\d{3,4}\s?\d{3,4})$/);
}, 'Please specify a valid phone number');

jQuery.validator.addMethod('mobileUK', function(phone_number, element) {
    return this.optional(element) || phone_number.length > 9 &&
        phone_number.match(/^((0|\+44)7(5|6|7|8|9){1}\d{2}\s?\d{6})$/);
}, 'Please specify a valid mobile number');

// TODO check if value starts with <, otherwise don't try stripping anything
jQuery.validator.addMethod("strippedminlength", function(value, element, param) {
    return jQuery(value).text().length >= param;
}, jQuery.validator.format("Please enter at least {0} characters"));

// same as email, but TLD is optional
jQuery.validator.addMethod("email2", function(value, element, param) {
    return this.optional(element) || /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)*(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i.test(value);
}, jQuery.validator.messages.email);

// same as url, but TLD is optional
jQuery.validator.addMethod("url2", function(value, element, param) {
    return this.optional(element) || /^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)*(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/i.test(value);
}, jQuery.validator.messages.url);

// NOTICE: Modified version of Castle.Components.Validator.CreditCardValidator
// Redistributed under the the Apache License 2.0 at http://www.apache.org/licenses/LICENSE-2.0
// Valid Types: mastercard, visa, amex, dinersclub, enroute, discover, jcb, unknown, all (overrides all other settings)
jQuery.validator.addMethod("creditcardtypes", function(value, element, param) {

    if (/[^0-9-]+/.test(value))
        return false;

    value = value.replace(/\D/g, "");

    var validTypes = 0x0000;

    if (param.mastercard)
        validTypes |= 0x0001;
    if (param.visa)
        validTypes |= 0x0002;
    if (param.amex)
        validTypes |= 0x0004;
    if (param.dinersclub)
        validTypes |= 0x0008;
    if (param.enroute)
        validTypes |= 0x0010;
    if (param.discover)
        validTypes |= 0x0020;
    if (param.jcb)
        validTypes |= 0x0040;
    if (param.unknown)
        validTypes |= 0x0080;
    if (param.all)
        validTypes = 0x0001 | 0x0002 | 0x0004 | 0x0008 | 0x0010 | 0x0020 | 0x0040 | 0x0080;

    if (validTypes & 0x0001 && /^(51|52|53|54|55)/.test(value)) { //mastercard
        return value.length == 16;
    }
    if (validTypes & 0x0002 && /^(4)/.test(value)) { //visa
        return value.length == 16;
    }
    if (validTypes & 0x0004 && /^(34|37)/.test(value)) { //amex
        return value.length == 15;
    }
    if (validTypes & 0x0008 && /^(300|301|302|303|304|305|36|38)/.test(value)) { //dinersclub
        return value.length == 14;
    }
    if (validTypes & 0x0010 && /^(2014|2149)/.test(value)) { //enroute
        return value.length == 15;
    }
    if (validTypes & 0x0020 && /^(6011)/.test(value)) { //discover
        return value.length == 16;
    }
    if (validTypes & 0x0040 && /^(3)/.test(value)) { //jcb
        return value.length == 16;
    }
    if (validTypes & 0x0040 && /^(2131|1800)/.test(value)) { //jcb
        return value.length == 15;
    }
    if (validTypes & 0x0080) { //unknown
        return true;
    }
    return false;
}, "Please enter a valid credit card number.");

// 身份证号码验证
jQuery.validator.addMethod("isIdCardNo", function(value, element) {
    return this.optional(element) || isIdCardNo(value);
}, "请正确输入您的身份证号码");

function isIdCardNo(num) {
    var factorArr = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1);
    var parityBit = new Array("1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2");
    var varArray = new Array();
    var intValue;
    var lngProduct = 0;
    var intCheckDigit;
    var intStrLen = num.length;
    var idNumber = num;
    // initialize
    if ((intStrLen != 15) && (intStrLen != 18)) {
        return false;
    }
    // check and set value
    for (i = 0; i < intStrLen; i++) {
        varArray[i] = idNumber.charAt(i);
        if ((varArray[i] < "0" || varArray[i] > "9") && (i != 17)) {
            return false;
        } else if (i < 17) {
            varArray[i] = varArray[i] * factorArr[i];
        }
    }
    if (intStrLen == 18) {
        //check date
        var date8 = idNumber.substring(6, 14);
        if (isDate8(date8) == false) {
            return false;
        }
    } else { //length is 15
        //check date
        var date6 = idNumber.substring(6, 12);
        if (isDate6(date6) == false) {
            return false;
        }
    }
    return true;
}

function isDate8(sDate) {
    if (!/^[0-9]{8}$/.test(sDate)) {
        return false;
    }
    var year, month, day;
    year = sDate.substring(0, 4);
    month = sDate.substring(4, 6);
    day = sDate.substring(6, 8);
    var iaMonthDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]
    if (year < 1700 || year > 2500) return false
    if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)) iaMonthDays[1] = 29;
    if (month < 1 || month > 12) return false
    if (day < 1 || day > iaMonthDays[month - 1]) return false
    return true
}

function isDate6(sDate) {
    if (!/^[0-9]{6}$/.test(sDate)) {
        return false;
    }
    var year, month, day;
    year = Number("19" + sDate.substring(0, 2));
    month = sDate.substring(2, 4);
    day = sDate.substring(4, 6);
    var iaMonthDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]
    if (year < 1700 || year > 2500) return false
    if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)) iaMonthDays[1] = 29;
    if (month < 1 || month > 12) return false
    if (day < 1 || day > iaMonthDays[month - 1]) return false
    return true
}

// 非中文字符验证
jQuery.validator.addMethod("nonChinese", function(value, element) {
    var zip = /^[^\u4e00-\u9fa5]{0,}$/;
    return this.optional(element) || (zip.test(value));
}, "非中文!");