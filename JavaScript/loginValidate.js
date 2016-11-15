/**
*
*用户登录验证
*
*/
function submitLogin() {
    if (!hitUserName() || !hitPassword()) {
        return false;
    }
    return true;
}

function hitUserName() {
    var usernameFoucs = document.getElementById("txtUserName");
    var username = usernameFoucs.value;
    document.getElementById('validateid').innerHTML = '';
    if (!username) {
        document.getElementById("loginTip").innerHTML = "用户名不能为空。";
        usernameFoucs.focus();
        return false;
    } 
    return true;
}

function hitPassword() {
    var passwordFoucs = document.getElementById("txtPassword");
    var password = passwordFoucs.value;
    var _pwdLength = new RegExp('^.{3,32}$');
    if (!password) {
        document.getElementById("loginTip").innerHTML = "密码不能为空。";
        passwordFoucs.focus();
        return false;
    }
    if (!_pwdLength.test(password)) {
        document.getElementById("loginTip").innerHTML = "密码长度为6-32位。";
        passwordFoucs.focus();
        return false;
    }
    return true;
}
