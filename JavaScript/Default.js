//----------------------
// 函数目录：
//----------------------
// pagePrint()屏幕打印
// openStdDlg(sPath, oArgs, iX, iY)弹出窗口打开方法
// OpenPrintWindows(aspxName,paramName,paramValue)弹出打印窗口
// EnterToTab()按下回车时转换为Tab键
// CheckSelected(paramI)是否有选中的复选框
// CheckAll(checkedControlID)全选复选框
// ButtonCheckAll(checkedControlID)按钮全选
// IsSelectdAll(checkedControlID)是否全部选中了
// IsSelectdColAll(checkedControlID, checkGroupName)是否全部选中了
// IsSelectdAnyOne()是否选中了任何一个
// CheckSelectAnyOne(paramConfirm)检查至少选择一条记录检查
// SelectOne(tempControl)选择单个CheckBox
// VerifyMailAddress(paramTargetString)验证输入数据的格式的合法性
// VerifyNumeric(paramTargetString)数字验证
// IsDate(paramTargetString)判断是否为日期
// checkPredetermineEditByCategory(paramID)检查输入的有效性
// IsNumeric()只能输入数字
// Cancel()取消(弹出窗口)
// ltrim(s)去左空格
// rtrim(s)去右空格
// trim(s)左右空格
// IsEmpty(_str)是否为空值
// IsMail(_str)是否有效的Email
// IsNumber(_str)是否有效的正数
// IsFloat(_str)是否有效的数字
// IsColor(color)是否有效的颜色值
// IsURL(url)是否有效的链接
// IsMobile(_str)是否有效的手机号码
// CheckDT(str)校验日期格式(2008-03-29) 
// CheckTime(str)校验时间格式(10:08:45)
// isdate(intYear,intMonth,intDay)检查年月日是否是合法日期(20080329)
// checkCardID(dcardid)检查身份证是否是正确格式
// clearNoNum(obj)检查输入的是否为数字
// 判断文本框内输入的是否是数字类型(可以是负数)
// checkPhone(obj)检查输入的是否为电话
// checkNum(obj)检查输入的是否为数字
// changeTwoDecimal(double)将浮点数四舍五入，取小数点后2位
// changeTwoDecimal_f(double)将浮点数四舍五入，取小数点后2位（强制保留2位小数）
//
//----------------------


//
// 屏幕打印
//
function pagePrint() {
    window.open('/JavaScript/comPrint.htm', 'print', 'toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
    return false;
}

//
// 弹出窗口打开方法
//
function openStdDlg(sPath, oArgs, iX, iY) {
    return window.showModalDialog(sPath, oArgs, "dialogWidth:" + iX + "px;dialogHeight:" + iY + "px;help:0;status:0;scroll:0;center:1");
}

//
// 弹出打印窗口
//
function OpenPrintWindows(aspxName, paramName, paramValue) {
    var returnValue = window.showModalDialog(aspxName + "?" + paramName + "=" + paramValue, null, "dialogWidth:780px;dialogHeight:700px;help:0;status:0;scroll:1;center:1");
    return false;
}

//
// 按下回车时转换为Tab键
//
function EnterToTab() {
    if (event.keyCode == 13 && event.srcElement.type != 'button' && event.srcElement.type != 'submit' && event.srcElement.type != 'file' && event.srcElement.type != 'reset' && event.srcElement.type != 'textarea' && event.srcElement.type != '') {
        event.keyCode = 9
    }
}

//
// 选择用户（复数）
//
function SelectUsers() {
    var returnValue = openStdDlg("../../Common/User/SelectUsers.aspx", null, 650, 500);
    if (returnValue != null) {
        document.getElementById('txtUserIDs').value = returnValue.IDs;
        return true;
    }
    return false;
}

//
// 选择商品（复数）
//
function SelectGoods() {
    var returnValue = openStdDlg("../../Convenience/Goods/SelectGoods.aspx", null, 800, 500);
    if (returnValue != null) {
        document.getElementById('txtGoodsIDs').value = returnValue.IDs;
        return true;
    }
    return false;
}

//
// 是否有选中的复选框
//
function CheckSelected(form) {
    var objForm = document.forms[form];
    var objLen = objForm.length;
    var selected = false;
    for (var i = 0; i < objLen; i++) {
        if (objForm.elements[i].type == "checkbox") {
            if (objForm.elements[i].checked) {
                selected = true;
                break;
            }
        }
    }
    return selected;
}

function CheckItem(checkedControlID) {
    document.getElementById(checkedControlID).checked = IsSelectdAll("from1");
}

function CheckColItem(checkedControlID, checkGroupName) {
    document.getElementById(checkedControlID).checked = IsSelectdColAll(checkedControlID, checkGroupName);
}

//
// 全选复选框
//
function CheckAll(checkedControlID) {
    CheckColAll(checkedControlID, "chkSelected");
}

function CheckColAll(checkedControlID, checkGroupName) {
    // 在哪个form里的控件
    var targetForm = document.form1;
    var checkedControl = document.getElementById(checkedControlID);
    for (var i = 0; i < targetForm.length; i++) {
        var targetControl = targetForm.elements[i];
        if (targetControl.type == "checkbox") {
            var targetControlname = targetControl.name.substr((targetControl.name.length - checkGroupName.length), (targetControl.name.length - 1));
            // alert(targetControl.name + ' ----::--- ' + checkGroupName + ' ----::--- ' + targetControlname);
            if (targetControlname == checkGroupName) {
                // 不可以把当前控件的状态给改变了 
                if (targetControl.id != checkedControlID) {
                    targetControl.checked = checkedControl.checked;
                }
            }
        }
    }
}

//
// 按钮全选
//
function ButtonCheckAll(checkedControlID) {
    var controlCheck = document.getElementById(checkedControlID);
    controlCheck.checked = !controlCheck.checked;
    // 全选复选框
    CheckAll(checkedControlID);
    return false;
}

//
// 是否全部选中了
//
function IsSelectdAll(checkedControlID) {
    return IsSelectdColAll(checkedControlID, "chkSelected")
}

//
// 是否全部选中了
//
function IsSelectdColAll(checkedControlID, checkGroupName) {
    var returnValue = true;
    var controlCheck = document.getElementById(checkedControlID);
    var objForm = document.form1;
    var objLen = objForm.length;
    var i = 0;
    for (var iCount = 0; iCount < objLen; iCount++) {
        var objType = objForm.elements[iCount];
        if (objType.type == "checkbox" && objType.name.substr((objType.name.length - checkGroupName.length), (objType.name.length - 1)) == checkGroupName) {
            if (!objType.checked) {
                i += 1;
                break;
            }
        }
    }
    if (i > 0) {
        returnValue = false;
    }
    return returnValue;
}

//
// 是否选中了任何一个
//
function IsSelectdAnyOne() {
    var returnValue = 0;
    var objForm = document.form1;
    var objLen = objForm.length;
    var i = 0;
    for (var iCount = 0; iCount < objLen; iCount++) {
        var objType = objForm.elements[iCount];
        if (objType.type == "checkbox" && objType.name.substr((objType.name.length - 11), (objType.name.length - 1)) == "chkSelected") {
            if (objType.checked) {
                returnValue += 1;
                //break;
            }
        }
    }
    //if(i > 0)
    //{
    //    returnValue = i;
    //}
    return returnValue;
}

//
// 检查至少选择一条记录检查
//
function CheckSelectAnyOne(paramConfirm) {
    // 是否选中了任何一个
    if (IsSelectdAnyOne() <= 0) {
        alert("提示信息：请至少选择一项。");
        return false;
    }
    else {
        if (paramConfirm != null) {
            if (paramConfirm.length > 0) {
                return confirm(paramConfirm);
            }
        }
    }
    return true;
}

//
// 检查选择一条记录检查
//
function CheckSelectOne(paramConfirm) {
    // 是否选中了任何一个
    if (IsSelectdAnyOne() != 1) {
        alert("提示信息：请选择一项。");
        return false;
    }
    else {
        if (paramConfirm != null) {
            if (paramConfirm.length > 0) {
                return confirm(paramConfirm);
            }
        }
    }
    return true;
}

function InputCheck(strParam, paramStr) {
    return CheckSelectAnyOne(strParam, paramStr)
}

//
// 选择单个CheckBox
//
function SelectOne(tempControl) {
    // 将除头模板中的其它所有的CheckBox取反
    // alert(tempControl);
    var theBox = tempControl;
    xState = theBox.checked;
    elem = theBox.form.elements;
    for (i = 0; i < elem.length; i++) {
        if (elem[i].type == "checkbox" && elem[i].id != theBox.id) {
            elem[i].checked = false;
        }
    }
}

//
// 验证输入数据的格式的合法性
//
function VerifyMailAddress(targetString) {
    var email = paramTargetString;
    var pattern = /^([a-zA-Z0-9._-])+@([a-zA-Z0-9_-])+(\.[a-zA-Z0-9_-])+/;
    flag = pattern.test(email);
    if (flag) {
        return true;
    }
    else {
        return false;
    }
}

//
// 数字验证
//
function VerifyNumeric(paramTargetString) {
    var numeric = paramTargetString;
    var pattern = /^[+-]?[0-9.]*$/;
    flag = pattern.test(numeric);
    if (flag) {
        return true;
    }
    else {
        return false;
    }
}

//
// 判断是否为日期
//
function IsDate(paramTargetString) {
    return true;
}

//
// 检查输入的有效性
//
function checkPredetermineEditByCategory(paramID) {
    var objMoney = document.getElementById(paramID);
    // 若是空的,没有问题的
    if (objMoney.value == "") {
        return true;
    }
    if (objMoney.value >= -99999999.99 && objMoney.value < 99999999.99) {
        return true;
    }
    else {
        alert("提示信息：请输入 -99999999.99 至 99999999.99 之间的数字");
        objMoney.value = "";
        objMoney.focus();
        return false;
    }
}

//
// 只能输入数字
//
function IsNumeric() {
    if (event.keyCode < 45 || event.keyCode > 57) {
        event.keyCode = 0;
    }
}
//
// 只能输入数字和回车
//
function IsNumericOrEnter() {
    if ((event.keyCode < 45 || event.keyCode > 57) && event.keyCode != 13) {
        event.keyCode = 0;
    }
}
//
// 只能输入数字
//
function IsSignNumeric() {
    if (event.keyCode < 45 || (event.keyCode == 109 && event.keyCode > 57)) {
        event.keyCode = 0;
    }
}

//
// 取消(弹出窗口)
//
function Cancel() {
    window.returnValue = null;
    window.close();
}

//
//去左空格;
// 
function ltrim(s) {
    return s.replace(/^\s*/, "");
}

//
//去右空格; 
//
function rtrim(s) {
    return s.replace(/\s*$/, "");
}

//
//左右空格;
// 
function trim(s) {
    return rtrim(ltrim(s));
}

//
//是否为空值;
//返回值：1为是空值，0为不是空值
//
function IsEmpty(_str) {
    var tmp_str = trim(_str);
    return tmp_str.length == 0;
}

//
//是否有效的Email; 
//返回值：1为是有效，0为不是有效
//
function IsMail(_str) {
    var tmp_str = trim(_str);
    var pattern = /^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*$/;
    return pattern.test(tmp_str);
}

//
//是否有效的正数; 
//返回值：1为是有效，0为不是有效
//
function IsNumber(_str) {
    var tmp_str = trim(_str);
    var pattern = /^[0-9]/;
    return pattern.test(tmp_str);
}

//
//是否有效的数子; 
//返回值：1为是有效，0为不是有效
//
function isFloat(_str) {
    var tmp_str = trim(_str);
    var pattern = /^[0-9]+.?[0-9]*$/;
    return pattern.test(tmp_str);
}

//
//是否有效的颜色值; 
//返回值：1为是有效，0为不是有效
//
function IsColor(color) {
    var temp = color;
    if (temp == "") return true;
    if (temp.length != 7) return false;
    return (temp.search(/\#[a-fA-F0-9]{6}/) != -1);
}

//
//是否有效的链接; 
//返回值：1为是有效，0为不是有效
//
function IsURL(url) {
    var sTemp;
    var b = true;
    sTemp = url.substring(0, 7);
    sTemp = sTemp.toUpperCase();
    if ((sTemp != "HTTP://") || (url.length < 10)) {
        b = false;
    }
    return b;
}

//
//是否有效的手机号码; 
//返回值：1为是有效，0为不是有效
//
function IsMobile(_str) {
    var tmp_str = trim(_str);
    var pattern = /1\d{10}/;
    return pattern.test(tmp_str);
}

//
// 校验日期格式(2008-03-29)   
//  
function CheckDT(str) {
    var r = str.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
    if (r == null) {
        return false;
    }
    else {
        var d = new Date(r[1], r[3] - 1, r[4]);
        return (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4]);
    }
}

//
// 校验时间格式(10:08:45)
//     
function CheckTime(str) {
    var a = str.match(/^(\d{1,2})(:)?(\d{1,2})\2(\d{1,2})$/);
    if (a == null) {
        alert('时间格式不正确');
        return false;
    }
    if (a[1] > 24 || a[3] > 60 || a[4] > 60) {
        alert("无效时间");
        return false
    }
    return true;
}

//
//检查年月日是否是合法日期 (20080329)
//
function isdate(intYear, intMonth, intDay) {
    if (isNaN(intYear) || isNaN(intMonth) || isNaN(intDay))
        return false;
    if (intMonth > 12 || intMonth < 1)
        return false;
    if (intDay < 1 || intDay > 31)
        return false;
    if ((intMonth == 4 || intMonth == 6 || intMonth == 9 || intMonth == 11) && (intDay > 30))
        return false;
    if (intMonth == 2) {
        if (intDay > 29)
            return false;
        if ((((intYear % 100 == 0) && (intYear % 400 != 0)) || (intYear % 4 != 0)) && (intDay > 28))
            return false;
    }
    return true;
}

//
//检查身份证是否是正确格式
//
function checkCardID(dcardid) {
    var pattern;
    if (dcardid.length == 15) {
        pattern = /^\d{15}$/; //正则表达式,15位且全是数字
        if (pattern.exec(dcardid) == null) {
            alert("15位身份证号码必须为数字！")
            return false;
        }
        if (!isdate("19" + dcardid.substring(6, 8), dcardid.substring(8, 10), dcardid.substring(10, 12))) {
            alert("身份证号码中所含日期不正确")
            return false;
        }
    }
    else if (dcardid.length == 18) {
        pattern = /^\d{17}(\d|x|X)$/; //正则表达式,18位且前17位全是数字，最后一位只能数字,x,X
        if (pattern.exec(dcardid) == null) {
            alert("18位身份证号码必须为数字！")
            return false;
        }
        if (!isdate(dcardid.substring(6, 10), dcardid.substring(10, 12), dcardid.substring(12, 14))) {
            alert("身份证号码中所含日期不正确")
            return false;
        }
        var strJiaoYan = ["1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2"];
        var intQuan = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1];
        var intTemp = 0;
        for (i = 0; i < dcardid.length - 1; i++)
            intTemp += dcardid.substring(i, i + 1) * intQuan[i];
        intTemp %= 11;
        if (dcardid.substring(dcardid.length - 1, dcardid.length).toUpperCase() != strJiaoYan[intTemp]) {
            alert("身份证末位验证码失败！")
            return false;
        }
    }
    else {
        alert("身份证号长度必须为15或18！")
        return false;
    }
    return true;
}

//
//判断文本框内输入的是否是数字类型
//
function clearNoNum(obj) {
    //先把非数字的都替换掉，除了数字和.
    obj.value = obj.value.replace(/[^\d.]/g, "");
    //必须保证第一个为数字而不是.
    obj.value = obj.value.replace(/^\./g, "");
    //保证只有出现一个.而没有多个.
    obj.value = obj.value.replace(/\.{2,}/g, ".");
    //保证.只出现一次，而不能出现两次以上
    obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
}

//
// 判断文本框内输入的是否是数字类型(可以是负数)
//
function clearNoNumF(obj) {
    //先把非数字的都替换掉，除了数字和.
    obj.value = obj.value.replace(/[^\d\.\-]/g, "");
    //必须保证第一个为数字而不是.
    obj.value = obj.value.replace(/^\./g, "");
    //保证只有出现一个.而没有多个.
    obj.value = obj.value.replace(/\.{2,}/g, ".");
    obj.value = obj.value.replace(/\-{1}/g, "-");
    //保证.只出现一次，而不能出现两次以上
    obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
    obj.value = obj.value.replace("-", "$#$").replace(/\-/g, "").replace("$#$", "-");
}

//
//判断文本框内输入的是否是电话类型
//
function checkPhone(obj) {
    //先把非数字的都替换掉，除了数字
    obj.value = obj.value.replace(/[^\d-]/g, "");
}

//
//判断文本框内输入的是否是数字
//
function checkNum(obj) {
    //先把非数字的都替换掉，除了数字
    obj.value = obj.value.replace(/[^\d]/g, "");
}

//
//将浮点数四舍五入，取小数点后2位
//
function changeTwoDecimal(x) {
    var f_x = parseFloat(x);
    if (isNaN(f_x)) {
        alert('function:changeTwoDecimal->parameter error');
        return false;
    }
    var f_x = Math.round(x * 100) / 100;

    return f_x;
}


//
//将浮点数四舍五入，取小数点后2位（强制保留2位小数）
//
function changeTwoDecimal_f(x) {
    var f_x = parseFloat(x);
    if (isNaN(f_x)) {
        alert('function:changeTwoDecimal->parameter error');
        return false;
    }
    var f_x = Math.round(x * 100) / 100;
    var s_x = f_x.toString();
    var pos_decimal = s_x.indexOf('.');
    if (pos_decimal < 0) {
        pos_decimal = s_x.length;
        s_x += '.';
    }
    while (s_x.length <= pos_decimal + 2) {
        s_x += '0';
    }
    return s_x;
}
//
//Table的隐藏与显示
//
function displayTable() {
    var table = document.getElementById("table");
    var element = document.getElementById("img");
    if (element.alt == "隐藏") {
        element.alt = "显示";
        element.src = "../../../Themes/Default/Images/open.gif";
        table.style.display = "none";
    } else {
        element.alt = "隐藏";
        element.src = "../../../Themes/Default/Images/close.gif";
        table.style.display = "block";
    }
}