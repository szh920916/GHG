using System;
using System.Text;
using System.Web;
using System.Web.UI;

/// <summary>
/// 提供向页面输出客户端代码实现特殊功能的方法
/// </summary>
public class ScriptUtil
{
    /// <summary>
    /// 弹出JavaScript小窗口
    /// </summary>
    /// <param name="message">窗口信息</param>
    public static void Alert(string message)
    {
        // message = StringUtil.DeleteUnVisibleChar(message);
        string js = @"<Script language='JavaScript'>
                    alert('" + message + "');</Script>";

        //2008年4月26日15:46:38 Modify by zxy
        //现在使用Page来注册脚本，如果使用 Response.Write来输出脚本，该脚本会出现在页面的顶部，破坏页面的布局。
        Page page = System.Web.HttpContext.Current.Handler as Page;
        if (page != null)
        {
            string key = "Alert" + Guid.NewGuid();
            if (!page.ClientScript.IsClientScriptBlockRegistered(key))
                page.ClientScript.RegisterClientScriptBlock(typeof(Page), key, js);
        }
        else
            HttpContext.Current.Response.Write(js);
    }
    /// <summary>
    /// 弹出提示框，用于UpdatePanel
    /// </summary>
    /// <param name="strmess"></param>
    public static void AlertMessage(string strmess)
    {
        Page page = HttpContext.Current.Handler as Page;
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append("<script>");
        strBuilder.AppendFormat("alert('{0}');", strmess);
        strBuilder.Append("</script>");
        // if (page != null)
        //    ScriptManager.RegisterClientScriptBlock(page, typeof(Page), "", strBuilder.ToString(), false);
    }

    /// <summary>
    /// 弹出一个消息随后关闭当前窗口
    /// </summary>
    /// <param name="message">窗口信息</param>
    public static void AlertAndCloseWindow(string message)
    {
        // message = StringUtil.DeleteUnVisibleChar(message);
        string js = @"<Script language='JavaScript'>
                    alert('" + message + "'); window.close(); </Script>";


        Page page = System.Web.HttpContext.Current.Handler as Page;
        if (page != null)
        {
            string key = "CloseWindow" + page.ClientID;
            if (!page.ClientScript.IsClientScriptBlockRegistered(key))
                page.ClientScript.RegisterClientScriptBlock(typeof(Page), key, js);
        }
        else
            HttpContext.Current.Response.Write(js);
    }

    /// <summary>
    /// 弹出JavaScript小窗口,并转到指定的页面
    /// </summary>
    /// <param name="message"></param>
    /// <param name="toURL"></param>
    public static void AlertAndRedirect(string message, string toURL)
    {
        string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
        HttpContext.Current.Response.Write(string.Format(js, message, toURL));
    }
}