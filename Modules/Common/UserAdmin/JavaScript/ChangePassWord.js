//
// 窗体加载时运行
//
function window.onload()
{
    document.onkeydown = EnterToTab;
    document.all["txtOldPassword"].focus();
}

//
// 验证两次输入的密码是否相同
//
function CheckInput(paramValue)
{
    var oldPassword = document.getElementById("txtOldPassword");
    var newPassword = document.getElementById("txtNewPassword");
    var confirmPassword = document.getElementById("txtConfirmPassword");
    if(!paramValue)
    {
        if(oldPassword.value.length == 0)
        {
            alert("提示信息：原始密码不能为空。");
            oldPassword.focus();
            return false;
        }
        if(newPassword.value.length == 0)
        {
            alert("提示信息：新密码不能为空。");
            newPassword.focus();
            return false;
        }
        if(confirmPassword.value.length == 0)
        {
            alert("提示信息：确认密码不能为空。");
            confirmPassword.focus();
            return false;
        }
    }
    if (newPassword.value != confirmPassword.value)
    {
        alert("提示信息：您输入的密码不匹配，请重新输入密码。");
        newPassword.focus();
        newPassword.value = "";
        confirmPassword.value = "";
        return false;
    }
    return true;
}