using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //txtErrorMsg.Text = Application["error"].ToString();
        //lblStackInfo.Text = Application["errorStack"].ToString();

        Response.StatusCode = 404;
        SendError();
    }

    private void SendError()
    {
        //Utilities.GetConfiguration();
        //if (Utilities.IsSendBug == true)
        //{
        //    using (System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage())
        //    {
        //        // 接收人邮箱地址
        //        message.To.Add(new System.Net.Mail.MailAddress(Utilities.BugFeedbackMailBox));
        //        message.Body = this.GetBody();

        //        message.From = new System.Net.Mail.MailAddress(Utilities.ServiceMailBox, Utilities.ServiceMailBoxDisplayname);
        //        message.BodyEncoding = Encoding.GetEncoding("GB2312");
        //        message.Subject = "河南省工业企业能源利用信息管理及能耗诊断预警系统 BugFeedback";
        //        message.IsBodyHtml = true;
        //        System.Net.Mail.SmtpClient smtpclient = new System.Net.Mail.SmtpClient(Utilities.ServiceMailBoxSMTP, Utilities.ServiceMailBoxSMTPPort);
        //        smtpclient.Credentials = new System.Net.NetworkCredential(Utilities.ServiceMailBox, Utilities.ServiceMailBoxPassword);
        //        smtpclient.EnableSsl = false;
        //        smtpclient.Send(message);
        //    }
        //}
    }


    /// <summary>
    /// 获取邮件内容
    /// </summary>
    /// <returns>邮件主体内容</returns>
    private string GetBody()
    {
        StringBuilder htmlBody = new StringBuilder();
        htmlBody.Append("<body style=\"font-size:10pt\">");
        htmlBody.Append("<div style=\"font-size:10pt;font-weight:bold\">发生时间：" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "</div>");
        htmlBody.Append("<br>");

        htmlBody.Append("<div style=\"font-size:10pt;font-weight:bold\">" + Application["error"].ToString() + "</div>");
        htmlBody.Append("<br>");
        htmlBody.Append("<div style=\"font-size:10pt\">" + Application["errorStack"].ToString().Replace("\n", "<br>") + "</div>");
        htmlBody.Append("<br>");
        htmlBody.Append("<div style=\"font-size:10pt;font-weight:bold\">" + "环境信息" + "</div>");
        htmlBody.Append("<div style=\"font-size:10pt\">" + GetClientInfo().Replace("\n", "<br>") + "</div>");
        htmlBody.Append("<br>");
        htmlBody.Append("</body>");
        return htmlBody.ToString();
    }

    private string GetClientInfo()
    {
        StringBuilder clientInfo = new StringBuilder();

        //clientInfo.Append("客户端IP：" + Page.Request.UserHostAddress);
        //clientInfo.Append("\n");

        clientInfo.Append("客户端IP地址：" + GetIp());
        clientInfo.Append("\n");

        //clientInfo.Append("用户信息：" + Page.User.ToString());
        //clientInfo.Append("\n");
        
        clientInfo.Append("服务器电脑名称：" + Page.Server.MachineName);
        clientInfo.Append("\n");
        
        //clientInfo.Append("当前用户电脑名称：" + System.Net.Dns.GetHostName());
        //clientInfo.Append("\n");
   
        //clientInfo.Append("当前电脑名：" + System.Environment.MachineName);
        //clientInfo.Append("\n");
   
        //clientInfo.Append("当前电脑所属网域：" + System.Environment.UserDomainName);
        //clientInfo.Append("\n");
   
        //clientInfo.Append("当前电脑用户：" + System.Environment.UserName);
        //clientInfo.Append("\n");
  
   
        clientInfo.Append("浏览器类型：" + Request.Browser.Browser);
        clientInfo.Append("\n");
   
        clientInfo.Append("浏览器标识：" + Request.Browser.Id);
        clientInfo.Append("\n");
        
   
        clientInfo.Append("浏览器版本号：" + Request.Browser.Version);
        clientInfo.Append("\n");
   
        clientInfo.Append("浏览器是不是测试版本：" + Request.Browser.Beta);
        clientInfo.Append("\n");
   
        //clientInfo.Append("浏览器的分辨率(像素)：" + Request["width"].ToString() + "*" + Request["height"].ToString());//1280/1024);
        //clientInfo.Append("\n");
   
        clientInfo.Append("客户端的操作系统：" + Request.Browser.Platform);
        clientInfo.Append("\n");
   
        //clientInfo.Append("是不是win16系统：" + Request.Browser.Win16);
        //clientInfo.Append("\n");
   
        //clientInfo.Append("是不是win32系统：" + Request.Browser.Win32);
        //clientInfo.Append("\n");


        return  clientInfo.ToString();
    }

    //获取真实IP
    string GetIp()
    {
        //可以隔过代理IP获得真实IP
        string userIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        //没有代理服务器,如果有代理服务器获取的是代理服务器的IP
        if (userIP == null || userIP == "")
        {
            userIP = Request.ServerVariables["REMOTE_ADDR"];
        }
        return userIP;
    }
}
