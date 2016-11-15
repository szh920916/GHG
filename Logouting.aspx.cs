using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Logouting : System.Web.UI.Page
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

        // 跳转设置信息
        string url = "Modules/Common/System/Messages.aspx"
            + "?MessageType=MessageOk"
            + "&Mtitle=安全退出"
            + "&Mbody=安全退出本次登录。"
            + "&MbuttonUrl=../../../Logout.aspx";
        Page.Response.Redirect(url);
    }
}
