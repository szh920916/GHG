//数据是否发生修改
//为了支持对于提示保存，将状态判断改为判断没有修改
var pageNotChanged = true;
function _isInteger(str) {
    //alert(/^\d+$/.test(str));
    return /^\d+$/.test(str)
}
function _isDecimal(str) {
    if (/[^\d\.]/g.test(str)) {
        return false;
    }
    return true;
}
function isDecimal(str) {
    //alert(!/^\d+\.\d*$/.test(str));
    if (!/^d+.d*$/.test(str)) {
        return false;
    }
    return true;
}
function checkLength(obj, length) {
    var tempValue = obj.value;
    if (obj.value.length > length) {
        //输入长度不能大于length
        MsgTip(obj, "整数部分长度不能大于" + length + "位");
        obj.value = obj.value.substr(0, length);
        if (tempValue == obj.value) {
            obj.value = "";
        }
    }
}
function changeValue(obj) {
    SetNotChangeState(false);
    if (!_isDecimal(obj.value)) {
        //提示只能包含数字、小数点
        obj.value = obj.value.replace(/[^\d\.]/, "");
        MsgTip(obj, "只能包含数字、小数点");

        return false;
    }
}
function repeatStr(str, num) {
    for (var i = 1; i < num; i++)
        str += str;
    return str;
}
function checkDecimalInput(obj, length, prec, index, cate) {
    if (!prec) prec = 2;
    if (obj.value == "") return false;
    if (obj.value.indexOf(".") == -1) {
        if (_isInteger(obj.value)) {
            if (obj.value.length > (length - prec)) {
                //提示整数部分长度不能大于（length-prec）
                MsgTip(obj, "整数部分长度不能大于" + (length - prec) + "位");
                obj.value = "";
                return false;
            }
            else {
                obj.value += "." + repeatStr("0", prec);
            }
        }
    }
    else {
        if (obj.value.substr(0, obj.value.indexOf(".")).length > (length - prec)) {
            //提示整数部分长度不能大于（length-prec）
            MsgTip(obj, "整数部分长度不能大于" + length - prec + "位");
            obj.value = "";
            return false;
        }
        if (obj.value.substr(obj.value.indexOf(".") + 1).length < prec) {
            obj.value += repeatStr("0", prec - obj.value.substr(obj.value.indexOf(".") + 1).length);
        }
    }
    if (isDecimal(obj.value)) {
        //提示输入数据格式有误
        MsgTip(obj, "输入数据格式有误");
        obj.value = "";
        return false;
    }
    checkLength(obj, length + 1);
    if (obj.value.substr(obj.value.indexOf(".")).length > (prec + 1)) {
        //精度不能大于prec
        MsgTip(obj, "小数部分不能多于" + prec+"位");
        obj.value = obj.value.substr(0, obj.value.indexOf(".") + prec + 1);
    }
    //格式化数字的格式
    // Calculate(obj, index, cate);
    //formatDecimal(obj);

}
function MsgTip(obj, TipMsg) {
    var elem = $("#" + obj.id);
    var mTop = elem.offset().top;
    var mLeft = elem.offset().left;
    var addLeft = elem.width();
    var finalTop = mTop - 30;
    var finalLeft = mLeft + 20;
    $("#tips").remove();
    popDiv(finalTop, finalLeft, TipMsg);
}

//弹出窗口也放在这里面一起处理
//固定的信息框
function popDiv(tops, lefts, messages) {
    var str = "";
    str = "<div id='tips'><img id='tipsArrow' src='../../../../javascript/images/arrow.png' alt=''/><img id='close' src='../../../../javascript/images/close.jpg' alt='' onclick='closeUp()'/><img src='../../../../javascript/images/light.gif' alt='' id='light'/><p>" + messages + "</p></div>";
  
    $('body').append(str);

    $("#tips").css({ "top": tops + "px", "left": lefts + "px" });
}

function closeUp() {
    $("#tips").remove();
}




//专用于DC01表 工业增加值，当前其实有问题，不能处理例如 1-2  1-- -- 等情况
function changeValue2(obj) {
    SetNotChangeState(false);
    if (!_isDecimal2(obj.value)) {
        //提示只能包含数字、小数点
        obj.value = obj.value.replace(/[^\d\.]/, "");
        MsgTip(obj, "只能包含数字、小数点");

        return false;
    }
}


function _isDecimal2(str) {
    if (/[^-\d\.]/g.test(str)) {
        return false;
    }
    return true;
}


//退出时判断修改状态
function SetNotChangeState(state) {
    pageNotChanged = state;
}

//退出审核状态
function SetNotChangeStateByVerify(state) {
    if (state == true) {
        pageNotChanged = state;
    }
    //为了支持对于提示保存，仍然将状态进行返回
    return state;
}

function window.onbeforeunload() {
    if (pageNotChanged == false)
        window.event.returnValue = "发现数据没有保存，如果需要保存，请首先选择取消，然后点击保存按钮？";
}
//通过css样式名称清除带样式的所有数据
function ResetReportByCssName(cssName) {
    $(cssName).val("");
}