/**
* 用户验证
* 
* @author libinqi
* @version 1.0
* 
*/
jQuery(document).ready(function () {
    //    jQuery("#txtEmail").focus();
    //    jQuery("#txtUserName").val("");
    //    jQuery("#txtPwd").val("");
    //    jQuery("#txtPwd2").val("");
    //    jQuery("#txtCaptcha").val("");
    //    jQuery("#s1").attr("checked", false);
}
);
/*
*
*JavaScript验证(不便于维护,工作之余换成JQuery验证)
*
**/
function validate() {
    var _isEmail = new RegExp('^\\w+((-\\w+)|(\\.\\w+))*\\@[A-Za-z0-9]+((\\.|-)[A-Za-z0-9]+)*\\.[A-Za-z0-9]+$');
    var _pwdLength = new RegExp('^.{6,32}$');

    var regemail = document.getElementById("txtEmail");
    var password = document.getElementById("txtPwd");
    var password2 = document.getElementById("txtPwd2");
    var username = document.getElementById("txtUserName");
    var captcha = document.getElementById("txtCaptcha");
    var check = document.getElementById("s1");

    if (regemail.value.length == 0) {
        document.getElementById("regemailTip").innerHTML = "请输入电子邮箱地址";
        regemail.focus();
        return false;
    }
    else {
        document.getElementById("regemailTip").innerHTML = "";
    }

    if (!_isEmail.test(regemail.value)) {
        document.getElementById("regemailTip").innerHTML = "电子邮箱格式不正确";
        regemail.select();
        regemail.focus();
        return false;
    }
    else {
        document.getElementById("regemailTip").innerHTML = "";
    }

    if (username.value.length == 0) {
        document.getElementById("usernameTip").innerHTML = "请输入用户名";
        username.focus();
        return false;
    }
    else {
        document.getElementById("usernameTip").innerHTML = "";
    }

    if (password.value.length == 0) {
        document.getElementById("passwordTip").innerHTML = "请输入密码";
        password.focus();
        return false;
    }
    else {
        document.getElementById("passwordTip").innerHTML = "";
    }

    if (!_pwdLength.test(password.value)) {
        document.getElementById("passwordTip").innerHTML = "密码长度6-32位";
        password.focus();
        return false;
    }
    else {
        document.getElementById("passwordTip").innerHTML = "";
    }

    if (password2.value.length == 0) {
        document.getElementById("password2Tip").innerHTML = "请输入确认密码";
        password2.focus();
        return false;
    }
    else {
        document.getElementById("password2Tip").innerHTML = "";
    }

    if (password2.value != password.value) {
        document.getElementById("password2Tip").innerHTML = "确认密码输入不一致";
        password2.focus();
        password2.select();
        return false;
    }
    else {
        document.getElementById("password2Tip").innerHTML = "";
    }

    if (captcha.value.length == 0) {
        document.getElementById("captchaTip").innerHTML = "请输入验证码";
        captcha.focus();
        return false;
    }
    else {
        document.getElementById("captchaTip").innerHTML = "";
    }

    /*
    *验证码的有效验证
    */
    //            if (captcha.value.length != "条件") {
    //                document.getElementById("captchaTip").innerHTML = "验证码输入有误,请重新输入";
    //                captcha.focus();
    //                //重新生成验证码(JavaScript Code)
    //                return false;
    //            }

    if (!check.checked) {
        alert('温馨提示：请选择是否同意服务条款。');
        check.focus();
        return false;
    }

    return true;
}

function validate2() {
    var _isEmail = new RegExp('^\\w+((-\\w+)|(\\.\\w+))*\\@[A-Za-z0-9]+((\\.|-)[A-Za-z0-9]+)*\\.[A-Za-z0-9]+$');
    var regemail = document.getElementById("txtEmail");

    if (regemail.value.length == 0) {
        document.getElementById("emailTip").innerHTML = "请输入电子邮箱地址";
        regemail.focus();
        return false;
    }
    else {
        document.getElementById("emailTip").innerHTML = "";
    }

    if (!_isEmail.test(regemail.value)) {
        document.getElementById("emailTip").innerHTML = "电子邮箱格式不正确";
        regemail.focus();
        return false;
    }
    else {
        document.getElementById("emailTip").innerHTML = "";
    }
}

function emailBlur(email) {
    var _isEmail = new RegExp('^\\w+((-\\w+)|(\\.\\w+))*\\@[A-Za-z0-9]+((\\.|-)[A-Za-z0-9]+)*\\.[A-Za-z0-9]+$');
    if (email.value.length == 0 || _isEmail.test(email.value)) {
        document.getElementById("regemailTip").innerHTML = "";
    }
    else if (!_isEmail.test(email.value)) {
        document.getElementById("regemailTip").innerHTML = "电子邮箱格式不正确";
    }
}

function emailblur(email) {
    var _isEmail = new RegExp('^\\w+((-\\w+)|(\\.\\w+))*\\@[A-Za-z0-9]+((\\.|-)[A-Za-z0-9]+)*\\.[A-Za-z0-9]+$');
    if (email.value.length == 0 || _isEmail.test(email.value)) {
        document.getElementById("emailTip").innerHTML = "";
    }
    else if (!_isEmail.test(email.value)) {
        document.getElementById("emailTip").innerHTML = "电子邮箱格式不正确";
    }
}

function emailFocus() {
    document.getElementById("regemailTip").innerHTML = "";
}

function emailfocus() {
    document.getElementById("emailTip").innerHTML = "";
}

function usernameBlur() {
    document.getElementById("usernameTip").innerHTML = "";
}

function usernameFocus() {
    document.getElementById("usernameTip").innerHTML = "";
}
function realnameBlur() {
    document.getElementById("realnameTip").innerHTML = "";
}

function realnameFocus() {
    document.getElementById("realnameTip").innerHTML = "";
}

function pwdBlur(pwd) {
    var _pwdLength = new RegExp('^.{6,32}$');
    if (pwd.value.length == 0 || _pwdLength.test(pwd.value)) {
        document.getElementById("passwordTip").innerHTML = "";
    }
    else if (!_pwdLength.test(pwd.value)) {
        document.getElementById("passwordTip").innerHTML = "密码长度6-32位";
    }
}

function pwdFocus() {
    document.getElementById("passwordTip").innerHTML = "";
}

function pwd2Blur(pwd2) {
    var _pwdLength = new RegExp('^.{6,32}$');
    var pwd = document.getElementById("txtPwd");
    if (pwd2.value.length == 0) {
        document.getElementById("password2Tip").innerHTML = "";
    }
    else if (!_pwdLength.test(pwd2.value)) {
        document.getElementById("password2Tip").innerHTML = "密码长度6-32位";
    }
    else if (pwd2.value != pwd.value) {
        document.getElementById("password2Tip").innerHTML = "确认密码输入不一致";
    }
}

function pwd2Focus() {
    document.getElementById("password2Tip").innerHTML = "";
}

function captchaBlur() {
    var capt = document.getElementById("txtCaptcha");
    if (capt.value.length != 4 && capt.value.length != 0) {
        document.getElementById("captchaTip").innerHTML = "长度为4位";
    }
    else {
        document.getElementById("captchaTip").innerHTML = "";
    }
}

function captchaFocus() {
    document.getElementById("captchaTip").innerHTML = "";
}
