using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 清空cookie
        Utilities.RemoveUserCookie();
        // 清除Seesion对象
        Utilities.RemoveUserSession();
        // 清理 Session
        // Session.Abandon();
        Session.Clear();
        // 在此处放置用户代码以初始化页面
        FormsAuthentication.SignOut();
        // 重新定位到登录页面
        Response.Redirect("Login.aspx", true);
    }
}